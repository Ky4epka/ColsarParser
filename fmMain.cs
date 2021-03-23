using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using System.Reflection;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using System.Threading;
using NLog;
using System.Runtime.InteropServices;


namespace ColsarParser
{
    public partial class fmMain : Form
    {
        public static string SettingsFile { get => ProgramSettings.ExecutePath(ProgramSettings.SETTINGS_FILE); }

        protected ProgramSettings hSettings = new ProgramSettings();

        protected Size hMainPanelSize = new Size();
        protected Size hSettingsPanelSize = new Size();
        protected bool hSettingsPanelVisible = false;

        protected HtmlParser hParser = new HtmlParser();
        protected bool hInitialVisibleFlag = true;
        protected bool hVisibleFlag = true;

        protected CancellationTokenSource hTokenSource = null;
        protected CancellationToken hToken = default;
        protected Task hMonitorTask = null;

        protected CancellationTokenSource hRunCheckerTokenSource = null;
        protected CancellationToken hRunCheckerToken = default;
        protected Task hRunCheckerMonitorTask = null;

        public ProgramSettings Settings { get => hSettings; }


        public static Logger Logger
        {
            get
            {
                if (iLogger == null)
                {
                    iLogger = LogManager.GetCurrentClassLogger();
                }

                return iLogger;
            }
        }

        public const int rbLoggerMaxLineSize = 1024;
        public const int rbLoggerMaxLines = 2048;

        protected static Logger iLogger = null;
        protected static RichTextBox rbLogger = null;
        //protected static StringBuilder rbLoggerData = new StringBuilder(rbLoggerMinSize, rbLoggerMaxSize);
        protected static string [] rbLoggerLoop = new string[rbLoggerMaxLines];
        protected static int rbLoggerNextLine = 0;
        protected static bool rbLoggerInLoop = false;
        protected static StringBuilder rbLoggerBuffer = new StringBuilder(rbLoggerMaxLineSize, rbLoggerMaxLineSize * rbLoggerMaxLines);


        [DllImport("kernel32.dll")]
        public static extern uint GetLastError();


        public static void LogToUI(string message, LogLevel level=default)
        {
            if (rbLogger == null) return;

            rbLoggerLoop[rbLoggerNextLine++] = message;

            if (!rbLoggerInLoop)
            {
                rbLoggerBuffer.Clear();

                for (int i=0; i<rbLoggerNextLine; i++)
                {
                    rbLoggerBuffer.AppendLine(rbLoggerLoop[i]);
                }

                rbLogger.Text = rbLoggerBuffer.ToString();
            }
            else
            {
                rbLoggerBuffer.Clear();

                for (int i = rbLoggerNextLine; i < rbLoggerMaxLines; i++)
                {
                    rbLoggerBuffer.AppendLine(rbLoggerLoop[i]);
                }

                for (int i = 0; i < rbLoggerNextLine; i++)
                {
                    rbLoggerBuffer.AppendLine(rbLoggerLoop[i]);
                }

                rbLogger.Text = rbLoggerBuffer.ToString();
            }

            if (rbLoggerNextLine + 1 >= rbLoggerMaxLines)
            {
                rbLoggerInLoop = true;
                rbLoggerNextLine = 0;
            }
        }

        public static string LogFormatter(string message, LogLevel level)
        {
            return String.Format("[{0} {1}] {2}", new object[3] { DateTime.Now.ToString("yy-MM-dd HH.mm.ss.fff"), level.ToString(), message });
        }

        public static void Log(string message, LogLevel level)
        {
            try
            {
                string fmessage = LogFormatter(message, level);
                Logger.Log(level, fmessage);
                LogToUI(fmessage, level);
            }
            catch (Exception e)
            {
                message += e.Message;
            }
            
            try
            {
                File.AppendAllText(ProgramSettings.ExecutePath("log.log"), message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void Log(Exception e)
        {
            Log(LogFormatter(e.Message, LogLevel.Error), LogLevel.Error);
        }

        public void SetShowMainWindow(bool show)
        {
            ShowInTaskbar = show;
            Visible = show;

            if (show) WindowState = FormWindowState.Normal;
        }

        public bool CheckMailboxAuth(string server, int port, bool use_ssl, string login, string password, ref string error)
        {
            error = "";

            try
            {
                using (SmtpClient smtp_client = new SmtpClient())
                {
                    smtp_client.Connect(server, port, use_ssl);
                    smtp_client.Authenticate(login, password);
                    smtp_client.Disconnect(true);
                }
            }
            catch (Exception Exc)
            {
                error = Exc.Message;
                return false;
            } 

            return true;
        }

        public void CheckSiteUrl()
        {
            Log("Проверка страницы.", LogLevel.Info);
            string res = hParser.DlHtmlString(Settings.UrlCheck);
            Regex reg = new Regex(ProgramSettings.FIND_TEMPLATE, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection mcol = reg.Matches(res);
            Log("Количество совпадений: " + mcol.Count, LogLevel.Info);

            if (mcol.Count < Settings.NotifyValue)
            {
                Log("Совпадений меньше заданных, отправка уведомлений.", LogLevel.Info);
                using (SmtpClient smtp_client = new SmtpClient())
                {
                    Log("Подключение к серверу почты.", LogLevel.Info);
                    smtp_client.Connect(Settings.SMTPServer, Settings.SMTPServerPort, Settings.SMTPUseSSL);
                    Log("Авторизация на сервере.", LogLevel.Info);
                    smtp_client.Authenticate(Settings.SenderLogin, Settings.SenderPassword);
                    MimeMessage message = new MimeMessage();
                    BodyBuilder body = new BodyBuilder();
                    body.TextBody = Settings.MessageBody;
                    message.From.Add(new MailboxAddress(Settings.SenderLogin, Settings.SenderLogin));

                    foreach (string toemail in Settings.ToList)
                    {
                        message.To.Add(new MailboxAddress("", toemail));
                    }

                    message.Subject = Settings.MessageSubject;
                    message.Body = body.ToMessageBody();
                    Log("Отправка сообщения.", LogLevel.Info);
                    smtp_client.Send(message);
                    Log("Отключение от сервера", LogLevel.Info);
                    smtp_client.Disconnect(true);
                }
            }
        }



        public void button1click(object sender, EventArgs e)
        {
            string res = hParser.DlHtmlString("https://sarov.info/forum/viewforum.php?f=142");
            Regex reg = new Regex(ProgramSettings.FIND_TEMPLATE, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            MatchCollection mcol = reg.Matches(res);

            if (mcol.Count < 10)
            {
                try
                {
                    using (SmtpClient smtp_client = new SmtpClient())
                    {
                        smtp_client.Connect("smtp.yandex.ru", 465, true);
                        smtp_client.Authenticate("cs.trueman@yandex.ru", "07089372221Ky4ePoK");
                        MimeMessage message = new MimeMessage();
                        BodyBuilder body = new BodyBuilder();
                        body.TextBody = "Количество совпадений меньше 10ти";
                        message.From.Add(new MailboxAddress("cs.trueman@yandex.ru", "cs.trueman@yandex.ru"));
                        message.To.Add(new MailboxAddress("", "cs.trueman@yandex.ru"));
                        message.Subject = "Уведомление на кол-сар";
                        message.Body = body.ToMessageBody();

                        smtp_client.Send(
                            message);
                        smtp_client.Disconnect(true);
                    }
                }
                catch (Exception Exc)
                {
                    Log(Exc);
                }
            }
        }

        public void LoadConfig()
        {
            XmlSerializer ser = new XmlSerializer(typeof(ProgramSettings));

            if (File.Exists(SettingsFile))
            {
                try
                {
                    try
                    {
                        using (StreamReader fs = new StreamReader(SettingsFile, false))
                        {
                            ProgramSettings set = ser.Deserialize(fs) as ProgramSettings;
                            Settings.Assign(set);
                        }
                    }
                    catch (Exception e)
                    {
                        Log("Файл настроек программы поврежден. Проведите настройку заного.", LogLevel.Error);
                        File.Delete(SettingsFile);
                    }

                    UI_UpdateSettings();
                    UI_MainUpdate();
                }
                catch (Exception e)
                {
                    Log(e);
                }
            }
        }

        public void SaveConfig()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProgramSettings));

            try
            {
                using (StreamWriter fs = new StreamWriter(SettingsFile, false))
                {
                    UI_ApplySettings();
                    serializer.Serialize(fs, Settings);
                }
            }
            catch (Exception e)
            {
                Log(e);
            }
        }

        public void UI_UpdateSettings()
        {
            tbSMTPServerVal.Text = Settings.SMTPServer;
            tbSMPTServerPortVal.Text = Settings.SMTPServerPort.ToString();
            cbSMTPUseSSLVal.Checked = Settings.SMTPUseSSL;
            tbSenderLoginVal.Text = Settings.SenderLogin;
            tbSenderPasswordVal.Text = Settings.SenderPassword;
            tbMessageSubjectVal.Text = Settings.MessageSubject;
            tbMessageBodyVal.Text = Settings.MessageBody;
            lboxToList.Items.Clear();
            lboxToList.Items.AddRange(Settings.ToList);
            tbToListEditField.Text = "";
            tbNotifyValue.Text = Settings.NotifyValue.ToString();
            tbCheckIntervalMinVal.Text = Settings.CheckInterval.ToString();
            tbUrlCheckVal.Text = Settings.UrlCheck;
            cbAutorun.Checked = Settings.Autorun;
            cbStableManager.Checked = Settings.StableManager;
        }

        public void UI_ApplySettings()
        {
            Settings.SMTPServer = tbSMTPServerVal.Text;
            try
            {
                Settings.SMTPServerPort = int.Parse(tbSMPTServerPortVal.Text);
            }
            catch (Exception e)
            {
                Log(e);
            }
            Settings.SMTPUseSSL = cbSMTPUseSSLVal.Checked;
            Settings.SenderLogin = tbSenderLoginVal.Text;
            Settings.SenderPassword = tbSenderPasswordVal.Text;
            Settings.MessageSubject = tbMessageSubjectVal.Text;
            Settings.MessageBody = tbMessageBodyVal.Text;

            if (lboxToList.Items.Count > 0)
            {
                string []items = new string[lboxToList.Items.Count];
                lboxToList.Items.CopyTo(items, 0);
                Settings.ToList = items;
            }
            else
            {
                lboxToList.Items.Clear();
            }

            try {
                Settings.NotifyValue = int.Parse(tbNotifyValue.Text);
            }
            catch (Exception e)
            {
                Log(e);
            }
            try
            { 
                Settings.CheckInterval = float.Parse(tbCheckIntervalMinVal.Text);
            }
            catch (Exception e)
            {
                Log(e);
            }

            Settings.UrlCheck = tbUrlCheckVal.Text;
            Settings.Autorun = cbAutorun.Checked;
            Settings.StableManager = cbStableManager.Checked;

            Settings.SetupAutorun(Settings.Autorun);
            Settings.SetupLifeCheckerTask(Settings.StableManager);
        }

        public void UI_MainUpdate()
        {
            btStateToggle.Text = (Settings.SiteMonitoring) ? "Остановить автопроверку" : "Запустить автопроверку";
            cbRunIfError.Checked = Settings.AutocheckRunTrying;
        }

        public void SetSettingsPanelVisible(bool value)
        {
            hSettingsPanelVisible = value;
            pSettings.Visible = value;
            int w = hMainPanelSize.Width;
            int h = hMainPanelSize.Height;

            if (value)
            {
                w += hSettingsPanelSize.Width;
                h = hSettingsPanelSize.Height;
            }

            this.Width = w;
            this.Height = h;
        }


        public async Task MonitorCycle(CancellationToken token)
        {
            Log("Monitoring a '" + Settings.UrlCheck + "' start", LogLevel.Info);

            try
            {
                token.ThrowIfCancellationRequested();

                Log("Проверка покдлючения к почте.", LogLevel.Info);
                string error = "";

                if (CheckMailboxAuth(Settings.SMTPServer, Settings.SMTPServerPort, Settings.SMTPUseSSL, Settings.SenderLogin, Settings.SenderPassword, ref error))
                {
                    Log("Подключение прошло успешно.", LogLevel.Info);
                }
                else
                {
                    throw new Exception("Ошибка подключения: " + error);
                }                

                Log("Проверка доступности страницы сайта.", LogLevel.Info);
                hParser.DlHtmlString(Settings.UrlCheck);
                Log("Страница доступна.", LogLevel.Info);

                while (true)
                {
                    try
                    {
                        int interval = (int)(Settings.CheckInterval * 60 * 1000);

                        if (interval <= 1000) interval = 1000;

                        await Task.Delay(interval);
                        CheckSiteUrl();
                    }
                    catch (Exception e)
                    {
                        Log(e);
                    }
                    finally
                    {
                        if (token.IsCancellationRequested) token.ThrowIfCancellationRequested();
                    }
                }
            }
            catch (Exception e)
            {
                Log(e);
            }
            finally
            {
                Log("Мониторинг завершен.", LogLevel.Info);
                SetMonitorStatus(false);
            }
        }

        public async Task MonitorLifeChecker(CancellationToken token)
        {
            try
            {
                token.ThrowIfCancellationRequested();

                while (true)
                {
                    try
                    {
                        await Task.Delay(1000);
                        if (!GetMonitorStatus()) SetMonitorStatus(true);
                        await Task.Delay(59000);
                    }
                    catch (Exception e)
                    {
                        Log(e);
                    }
                }
            }
            catch (Exception e)
            {
                Log(e);
            }
            finally
            {
                SetMonitorLifeChecker(false);
            }
        }


        public void SetMonitorLifeChecker(bool status)
        {
            Settings.AutocheckRunTrying = status;

            if (hRunCheckerMonitorTask != null)
            {
                hRunCheckerTokenSource.Cancel(true);
                hRunCheckerMonitorTask = null;
            }

            if (status)
            {
                hRunCheckerTokenSource = new CancellationTokenSource();
                hRunCheckerToken = hRunCheckerTokenSource.Token;
                hRunCheckerMonitorTask = MonitorLifeChecker(hRunCheckerToken);
            }

            UI_MainUpdate();
        }

        public bool GetMonitorLifeChecker()
        {
            return Settings.AutocheckRunTrying;
        }

        public void SetMonitorStatus(bool status)
        {
            Settings.SiteMonitoring = status;

            if (hMonitorTask != null)
            {
                hTokenSource.Cancel(true);
                hMonitorTask = null;
            }

            if (status)
            {
                hTokenSource = new CancellationTokenSource();
                hToken = hTokenSource.Token;
                hMonitorTask = MonitorCycle(hToken);
            }

            UI_MainUpdate();
        }

        public bool GetMonitorStatus()
        {
            return Settings.SiteMonitoring;
        }

        public void fmMainVisibleChanged(object sender, EventArgs e)
        {
            if (hInitialVisibleFlag)
            {
                hInitialVisibleFlag = false;

                System.Windows.Forms.Timer w = new System.Windows.Forms.Timer();
                w.Interval = 100;
                w.Enabled = true;
                w.Tick += (object tsender, EventArgs te) => { SetShowMainWindow(hVisibleFlag); w.Stop();  w.Dispose(); };
            }
        }

        public void fmMainMinimumSizeChanged(object sender, EventArgs e)
        {
            //SetShowMainWindow(false);
        }

        public fmMain(string []args)
        {
            try
            {
                InitializeComponent();
                Text = ProgramSettings.MAIN_FORM_CAPTION;
                rbLogger = rtLog;
                hMainPanelSize = new Size(int.Parse(lbMainPanelWidth.Text), int.Parse(lbMainPanelHeight.Text));
                hSettingsPanelSize = new Size(int.Parse(lbSettingsPanelWidth.Text), int.Parse(lbSettingsPanelHeight.Text));
                SetSettingsPanelVisible(false);
                VisibleChanged += fmMainVisibleChanged;
                MinimumSizeChanged += fmMainMinimumSizeChanged;
                FormClosing += (object sender, FormClosingEventArgs e) => { if (e.CloseReason == CloseReason.UserClosing) { e.Cancel = true; Hide(); } };
                
                if (!ProgramSettings.RegisterMonitorMessage())
                {
                    Log("Unable to register a message '" + ProgramSettings.WM_MONITOR_STATUS_STR + "' for a error code: " + GetLastError(), LogLevel.Error);
                }

                uint msg = ProgramSettings.WM_MONITOR_STATUS;
                LoadConfig();
                bool monitor_status = Settings.SiteMonitoring;

                if (args.Length > 0)
                {
                    foreach (string arg in args)
                    {
                        string larg = arg.ToLower();

                        if (larg.Equals(ProgramSettings.PARAMSTR_SILENT_KEY) ||
                            larg.Equals(ProgramSettings.PARAMSTR_SILENT_KEY_ALT))
                        {
                            hVisibleFlag = false;
                        }

                        if (larg.Equals(ProgramSettings.PARAMSTR_MONITOR_KEY) ||
                            larg.Equals(ProgramSettings.PARAMSTR_MONITOR_KEY_ALT))
                        {
                            monitor_status = true;
                        }
                    }
                }

                SetMonitorStatus(monitor_status);
            }
            catch (Exception e)
            {
                Log(e);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lboxToList.SelectedIndex;

            if ((index >= 0) && (index < lboxToList.Items.Count))
                tbToListEditField.Text = lboxToList.Items[index].ToString();
        }

        private void btSettingsToggle_Click(object sender, EventArgs e)
        {
            SetSettingsPanelVisible(!hSettingsPanelVisible);
        }

        private void btApplySettings_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }

        private void btDiscardSettings_Click(object sender, EventArgs e)
        {
            UI_UpdateSettings();
        }

        private void btToListAdd_Click(object sender, EventArgs e)
        {
            string text = tbToListEditField.Text.Trim();

            if (text.Length > 0)
            {
                tbToListEditField.Text = "";
                lboxToList.Items.Add(text);
            }
        }

        private void btToListChange_Click(object sender, EventArgs e)
        {
            int sel_index = lboxToList.SelectedIndex;

            if ((sel_index >= 0) && (sel_index < lboxToList.Items.Count))
            {
                string text = tbToListEditField.Text.Trim();

                if (text.Length > 0)
                {
                    lboxToList.Items[sel_index] = text;
                    tbToListEditField.Text = "";
                }
            }
        }

        private void btToListRemove_Click(object sender, EventArgs e)
        {
            int sel_index = lboxToList.SelectedIndex;

            if ((sel_index >= 0) && (sel_index < lboxToList.Items.Count))
            {
                lboxToList.Items.RemoveAt(sel_index);
            }
        }

        private void btCheckAuth_Click(object sender, EventArgs e)
        {
            string error = "";
            if (CheckMailboxAuth(tbSMTPServerVal.Text, 
                                  int.Parse(tbSMPTServerPortVal.Text),
                                  cbSMTPUseSSLVal.Checked,
                                  tbSenderLoginVal.Text,
                                  tbSenderPasswordVal.Text,
                                  ref error))
            {
                MessageBox.Show("Подключение прошло успешно.");
            }
            else
            {
                MessageBox.Show("Не удалось подключиться к почтовому серверу: " + error, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btStateToggle_Click(object sender, EventArgs e)
        {
            SetMonitorStatus(!GetMonitorStatus());
            SaveConfig();
        }

        private void показатьОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetShowMainWindow(true);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(new CancelEventArgs(true));
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if ((ProgramSettings.WM_MONITOR_STATUS != 0) && (m.Msg == ProgramSettings.WM_MONITOR_STATUS))
            {
                try
                {
                    SetMonitorStatus(true);
                }
                catch (Exception e)
                {
                    Log(e);
                }
            }
        }

        private void fmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            niTray.Visible = false;
        }

        private void btCheckButton_Click(object sender, EventArgs e)
        {
            try
            {

                CheckSiteUrl();
            }
            catch (Exception Exc)
            {
                Log(Exc);
            }
        }

        private void cbRunIfError_CheckedChanged(object sender, EventArgs e)
        {
            SetMonitorLifeChecker(cbRunIfError.Checked);
            SaveConfig();
        }
    }
}
