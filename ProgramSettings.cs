using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Windows;
using Microsoft.Win32;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace ColsarParser
{
    [Serializable]
    public class ProgramSettings
    {
        public const string PARSER_EXECUTABLE_FILE = "ColsarParser.exe";
        public const string LIFECHECKER_EXECUTABLE_FILE = "ColsarParserLifeChecker.exe";

        public const string LIFECHECKER_TASK_NAME = @"ColsarLifeChecker";
        public const int LIFECHECKER_PROCESS_NOT_ASK_TIMEOUT = 30000;

        public const string SETTINGS_FILE = "settings.xml";
        public const string MAIN_FORM_CAPTION = "ColsarParser";

        public static RegistryKey REG_ROOT = Registry.CurrentUser;
        public const string REG_AUTORUN_PATH = "HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Run";
        public const string REG_AUTORUN_KEY_NAME = "ColsarParser";

        public const string PARAMSTR_SILENT_KEY = "/silent";
        public const string PARAMSTR_SILENT_KEY_ALT = "-silent";

        public const string PARAMSTR_MONITOR_KEY = "/monitor";
        public const string PARAMSTR_MONITOR_KEY_ALT = "-monitor";

        public const string WM_MONITOR_STATUS_STR = "WM_MONITOR_STATUS";
        public static uint WM_MONITOR_STATUS = 0x0;

        public const string FIND_TEMPLATE = "class.*?=.*?\".*?row.*?bg.*?sticky\"";

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern uint RegisterWindowMessage(string lpProcName);

        [XmlElement]
        public string SMTPServer { get; set; }
        [XmlElement]
        public int SMTPServerPort { get; set; }
        [XmlElement]
        public bool SMTPUseSSL { get; set; }
        [XmlElement]
        public string SenderLogin { get; set; }
        [XmlElement]
        public string SenderPassword { get; set; }
        [XmlElement]
        public string MessageSubject { get; set; }
        [XmlElement]
        public string MessageBody { get; set; }
        [XmlArray("ToList")]
        [XmlArrayItem("ToEmail")]
        public string[] ToList { get; set; }
        [XmlElement]
        public int NotifyValue { get; set; }
        [XmlElement]
        public float CheckInterval { get; set; }
        [XmlElement]
        public string UrlCheck { get; set; }
        [XmlElement]
        public bool Autorun { get; set; }

        [XmlElement]
        public bool SiteMonitoring { get; set; }

        [XmlElement]
        public bool StableManager { get; set; }

        [XmlElement]
        public bool AutocheckRunTrying { get; set; }


        public void Assign(ProgramSettings source)
        {
            SMTPServer = source.SMTPServer;
            SMTPServerPort = source.SMTPServerPort;
            SMTPUseSSL = source.SMTPUseSSL;
            SenderLogin = source.SenderLogin;
            SenderPassword = source.SenderPassword;
            MessageSubject = source.MessageSubject;
            MessageBody = source.MessageBody;
            ToList = source.ToList;
            NotifyValue = source.NotifyValue;
            CheckInterval = source.CheckInterval;
            UrlCheck = source.UrlCheck;
            SiteMonitoring = source.SiteMonitoring;
            StableManager = source.StableManager;
            AutocheckRunTrying = source.AutocheckRunTrying;
        }

        public void SetupAutorun(bool value)
        {
            if (value)
            {
                Registry.SetValue(REG_AUTORUN_PATH, REG_AUTORUN_KEY_NAME, "\"" + Process.GetCurrentProcess().MainModule.FileName + "\" " + PARAMSTR_SILENT_KEY);
            }
            else
            {
                Registry.SetValue(REG_AUTORUN_PATH, REG_AUTORUN_KEY_NAME, "");
            }
        }

        public void SetupLifeCheckerTask(bool value)
        {

            try
            {
                using (Microsoft.Win32.TaskScheduler.TaskService ts = new Microsoft.Win32.TaskScheduler.TaskService())
                {
                    if (value && (!ts.RootFolder.Tasks.Exists(ProgramSettings.LIFECHECKER_TASK_NAME)))
                    {
                        Microsoft.Win32.TaskScheduler.TaskDefinition td = ts.NewTask();
                        td.RegistrationInfo.Description = "ColsarParser life checker task";
                        td.RegistrationInfo.Author = "Ky4ePoK";
                        td.Principal.LogonType = Microsoft.Win32.TaskScheduler.TaskLogonType.InteractiveToken;
                        td.Principal.RunLevel = Microsoft.Win32.TaskScheduler.TaskRunLevel.LUA;
                        td.Actions.Add(ProgramSettings.ExecutePath(ProgramSettings.LIFECHECKER_EXECUTABLE_FILE));
                        td.Principal.UserId = Environment.UserDomainName+"\\"+Environment.UserName;

                        Microsoft.Win32.TaskScheduler.DailyTrigger dt = new Microsoft.Win32.TaskScheduler.DailyTrigger(1);
                        dt.Repetition = new Microsoft.Win32.TaskScheduler.RepetitionPattern(new TimeSpan(1, 0, 0), new TimeSpan(1, 0, 0, 0));
                        dt.Enabled = true;

                        td.Triggers.Add(dt);
                        ts.RootFolder.RegisterTaskDefinition(ProgramSettings.LIFECHECKER_TASK_NAME, td);
                    }
                    else if (!ts.RootFolder.Tasks.Exists(ProgramSettings.LIFECHECKER_TASK_NAME))
                    {
                        ts.RootFolder.DeleteTask(ProgramSettings.LIFECHECKER_TASK_NAME, false);
                    }
                }
            }
            catch (Exception e)
            {
                fmMain.Log("Ошибка обработки задачи безотказности, убедитесь, что для настройки задачи программа запущена от имени администратора:" + e.Message, NLog.LogLevel.Error);
            }
        }

        public static string ExecutePath(string rightPart)
        {
            return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + "\\" + rightPart;
        }

        public static bool RegisterMonitorMessage()
        {
            WM_MONITOR_STATUS = RegisterWindowMessage(ProgramSettings.WM_MONITOR_STATUS_STR);
            return WM_MONITOR_STATUS != 0;
        }
    }
}
