
namespace ColsarParser
{
    partial class fmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.pMain = new System.Windows.Forms.Panel();
            this.btStateToggle = new System.Windows.Forms.Button();
            this.btCheckButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btCheckAuth = new System.Windows.Forms.Button();
            this.tbSenderPasswordVal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSenderLoginVal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSMTPUseSSLVal = new System.Windows.Forms.CheckBox();
            this.tbSMPTServerPortVal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSMTPServerVal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbMessageBodyVal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbMessageSubjectVal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pSettings = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btDiscardSettings = new System.Windows.Forms.Button();
            this.btApplySettings = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbAutorun = new System.Windows.Forms.CheckBox();
            this.tbUrlCheckVal = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbCheckIntervalMinVal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNotifyValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbToListEditField = new System.Windows.Forms.TextBox();
            this.pToListControls = new System.Windows.Forms.Panel();
            this.btToListRemove = new System.Windows.Forms.Button();
            this.btToListChange = new System.Windows.Forms.Button();
            this.btToListAdd = new System.Windows.Forms.Button();
            this.lboxToList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSettingsPanelWidth = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbMainPanelWidth = new System.Windows.Forms.Label();
            this.lbSettingsPanelHeight = new System.Windows.Forms.Label();
            this.lbMainPanelHeight = new System.Windows.Forms.Label();
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.показатьОкноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btSettingsToggle = new System.Windows.Forms.Button();
            this.cbStableManager = new System.Windows.Forms.CheckBox();
            this.cbRunIfError = new System.Windows.Forms.CheckBox();
            this.rtLog = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pSettings.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pToListControls.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.Controls.Add(this.rtLog);
            this.pMain.Controls.Add(this.label13);
            this.pMain.Controls.Add(this.cbRunIfError);
            this.pMain.Controls.Add(this.btStateToggle);
            this.pMain.Controls.Add(this.btCheckButton);
            this.pMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Padding = new System.Windows.Forms.Padding(5);
            this.pMain.Size = new System.Drawing.Size(215, 690);
            this.pMain.TabIndex = 4;
            // 
            // btStateToggle
            // 
            this.btStateToggle.Dock = System.Windows.Forms.DockStyle.Top;
            this.btStateToggle.Location = new System.Drawing.Point(5, 28);
            this.btStateToggle.Name = "btStateToggle";
            this.btStateToggle.Size = new System.Drawing.Size(205, 23);
            this.btStateToggle.TabIndex = 9;
            this.btStateToggle.Text = "Запустить автопроверку";
            this.btStateToggle.UseVisualStyleBackColor = true;
            this.btStateToggle.Click += new System.EventHandler(this.btStateToggle_Click);
            // 
            // btCheckButton
            // 
            this.btCheckButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.btCheckButton.Location = new System.Drawing.Point(5, 5);
            this.btCheckButton.Name = "btCheckButton";
            this.btCheckButton.Size = new System.Drawing.Size(205, 23);
            this.btCheckButton.TabIndex = 4;
            this.btCheckButton.Text = "Проверить";
            this.btCheckButton.UseVisualStyleBackColor = true;
            this.btCheckButton.Click += new System.EventHandler(this.btCheckButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btCheckAuth);
            this.panel2.Controls.Add(this.tbSenderPasswordVal);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbSenderLoginVal);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbSMTPUseSSLVal);
            this.panel2.Controls.Add(this.tbSMPTServerPortVal);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.tbSMTPServerVal);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel2.Size = new System.Drawing.Size(245, 205);
            this.panel2.TabIndex = 25;
            // 
            // btCheckAuth
            // 
            this.btCheckAuth.Dock = System.Windows.Forms.DockStyle.Top;
            this.btCheckAuth.Location = new System.Drawing.Point(0, 179);
            this.btCheckAuth.Name = "btCheckAuth";
            this.btCheckAuth.Size = new System.Drawing.Size(245, 23);
            this.btCheckAuth.TabIndex = 39;
            this.btCheckAuth.Text = "Проверить соединение";
            this.btCheckAuth.UseVisualStyleBackColor = true;
            this.btCheckAuth.Click += new System.EventHandler(this.btCheckAuth_Click);
            // 
            // tbSenderPasswordVal
            // 
            this.tbSenderPasswordVal.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSenderPasswordVal.Location = new System.Drawing.Point(0, 159);
            this.tbSenderPasswordVal.Name = "tbSenderPasswordVal";
            this.tbSenderPasswordVal.Size = new System.Drawing.Size(245, 20);
            this.tbSenderPasswordVal.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 141);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(104, 18);
            this.label2.TabIndex = 38;
            this.label2.Text = "Пароль исх. почты:";
            // 
            // tbSenderLoginVal
            // 
            this.tbSenderLoginVal.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSenderLoginVal.Location = new System.Drawing.Point(0, 121);
            this.tbSenderLoginVal.Name = "tbSenderLoginVal";
            this.tbSenderLoginVal.Size = new System.Drawing.Size(245, 20);
            this.tbSenderLoginVal.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 103);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(177, 18);
            this.label1.TabIndex = 36;
            this.label1.Text = "Логин исх. почты (Яндекс, Майл):";
            // 
            // cbSMTPUseSSLVal
            // 
            this.cbSMTPUseSSLVal.AutoSize = true;
            this.cbSMTPUseSSLVal.Checked = true;
            this.cbSMTPUseSSLVal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSMTPUseSSLVal.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbSMTPUseSSLVal.Location = new System.Drawing.Point(0, 81);
            this.cbSMTPUseSSLVal.Name = "cbSMTPUseSSLVal";
            this.cbSMTPUseSSLVal.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.cbSMTPUseSSLVal.Size = new System.Drawing.Size(245, 22);
            this.cbSMTPUseSSLVal.TabIndex = 34;
            this.cbSMTPUseSSLVal.Text = "Использовать SSL:";
            this.cbSMTPUseSSLVal.UseVisualStyleBackColor = true;
            // 
            // tbSMPTServerPortVal
            // 
            this.tbSMPTServerPortVal.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSMPTServerPortVal.Location = new System.Drawing.Point(0, 61);
            this.tbSMPTServerPortVal.Name = "tbSMPTServerPortVal";
            this.tbSMPTServerPortVal.Size = new System.Drawing.Size(245, 20);
            this.tbSMPTServerPortVal.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 43);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label7.Size = new System.Drawing.Size(113, 18);
            this.label7.TabIndex = 33;
            this.label7.Text = "Порт SMTP-сервера:";
            // 
            // tbSMTPServerVal
            // 
            this.tbSMTPServerVal.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSMTPServerVal.Location = new System.Drawing.Point(0, 23);
            this.tbSMTPServerVal.Name = "tbSMTPServerVal";
            this.tbSMTPServerVal.Size = new System.Drawing.Size(245, 20);
            this.tbSMTPServerVal.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 5);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label6.Size = new System.Drawing.Size(79, 18);
            this.label6.TabIndex = 31;
            this.label6.Text = "SMTP-сервер:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbMessageBodyVal);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.tbMessageSubjectVal);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(5, 210);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel3.Size = new System.Drawing.Size(245, 128);
            this.panel3.TabIndex = 26;
            // 
            // tbMessageBodyVal
            // 
            this.tbMessageBodyVal.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbMessageBodyVal.Location = new System.Drawing.Point(0, 61);
            this.tbMessageBodyVal.Multiline = true;
            this.tbMessageBodyVal.Name = "tbMessageBodyVal";
            this.tbMessageBodyVal.Size = new System.Drawing.Size(245, 65);
            this.tbMessageBodyVal.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 43);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label9.Size = new System.Drawing.Size(116, 18);
            this.label9.TabIndex = 28;
            this.label9.Text = "Содержимое письма:";
            // 
            // tbMessageSubjectVal
            // 
            this.tbMessageSubjectVal.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbMessageSubjectVal.Location = new System.Drawing.Point(0, 23);
            this.tbMessageSubjectVal.Name = "tbMessageSubjectVal";
            this.tbMessageSubjectVal.Size = new System.Drawing.Size(245, 20);
            this.tbMessageSubjectVal.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 5);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label8.Size = new System.Drawing.Size(78, 18);
            this.label8.TabIndex = 26;
            this.label8.Text = "Тема письма:";
            // 
            // pSettings
            // 
            this.pSettings.Controls.Add(this.panel5);
            this.pSettings.Controls.Add(this.panel4);
            this.pSettings.Controls.Add(this.panel1);
            this.pSettings.Controls.Add(this.label3);
            this.pSettings.Controls.Add(this.panel3);
            this.pSettings.Controls.Add(this.panel2);
            this.pSettings.Dock = System.Windows.Forms.DockStyle.Left;
            this.pSettings.Location = new System.Drawing.Point(215, 0);
            this.pSettings.Name = "pSettings";
            this.pSettings.Padding = new System.Windows.Forms.Padding(5);
            this.pSettings.Size = new System.Drawing.Size(255, 690);
            this.pSettings.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btDiscardSettings);
            this.panel5.Controls.Add(this.btApplySettings);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(5, 657);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel5.Size = new System.Drawing.Size(245, 30);
            this.panel5.TabIndex = 30;
            // 
            // btDiscardSettings
            // 
            this.btDiscardSettings.Location = new System.Drawing.Point(165, 3);
            this.btDiscardSettings.Name = "btDiscardSettings";
            this.btDiscardSettings.Size = new System.Drawing.Size(75, 23);
            this.btDiscardSettings.TabIndex = 1;
            this.btDiscardSettings.Text = "Отмена";
            this.btDiscardSettings.UseVisualStyleBackColor = true;
            this.btDiscardSettings.Click += new System.EventHandler(this.btDiscardSettings_Click);
            // 
            // btApplySettings
            // 
            this.btApplySettings.Location = new System.Drawing.Point(4, 3);
            this.btApplySettings.Name = "btApplySettings";
            this.btApplySettings.Size = new System.Drawing.Size(75, 23);
            this.btApplySettings.TabIndex = 0;
            this.btApplySettings.Text = "Применить";
            this.btApplySettings.UseVisualStyleBackColor = true;
            this.btApplySettings.Click += new System.EventHandler(this.btApplySettings_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbStableManager);
            this.panel4.Controls.Add(this.cbAutorun);
            this.panel4.Controls.Add(this.tbUrlCheckVal);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.tbCheckIntervalMinVal);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.tbNotifyValue);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(5, 488);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel4.Size = new System.Drawing.Size(245, 169);
            this.panel4.TabIndex = 29;
            // 
            // cbAutorun
            // 
            this.cbAutorun.AutoSize = true;
            this.cbAutorun.Checked = true;
            this.cbAutorun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutorun.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbAutorun.Location = new System.Drawing.Point(0, 119);
            this.cbAutorun.Name = "cbAutorun";
            this.cbAutorun.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.cbAutorun.Size = new System.Drawing.Size(245, 22);
            this.cbAutorun.TabIndex = 35;
            this.cbAutorun.Text = "Автозагрузка с Windows";
            this.cbAutorun.UseVisualStyleBackColor = true;
            // 
            // tbUrlCheckVal
            // 
            this.tbUrlCheckVal.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbUrlCheckVal.Location = new System.Drawing.Point(0, 99);
            this.tbUrlCheckVal.Name = "tbUrlCheckVal";
            this.tbUrlCheckVal.Size = new System.Drawing.Size(245, 20);
            this.tbUrlCheckVal.TabIndex = 29;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Location = new System.Drawing.Point(0, 81);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label12.Size = new System.Drawing.Size(164, 18);
            this.label12.TabIndex = 30;
            this.label12.Text = "Ссылка на страницу проверки:";
            // 
            // tbCheckIntervalMinVal
            // 
            this.tbCheckIntervalMinVal.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbCheckIntervalMinVal.Location = new System.Drawing.Point(0, 61);
            this.tbCheckIntervalMinVal.Name = "tbCheckIntervalMinVal";
            this.tbCheckIntervalMinVal.Size = new System.Drawing.Size(245, 20);
            this.tbCheckIntervalMinVal.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 43);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label5.Size = new System.Drawing.Size(139, 18);
            this.label5.TabIndex = 28;
            this.label5.Text = "Интервал проверки (мин):";
            // 
            // tbNotifyValue
            // 
            this.tbNotifyValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbNotifyValue.Location = new System.Drawing.Point(0, 23);
            this.tbNotifyValue.Name = "tbNotifyValue";
            this.tbNotifyValue.Size = new System.Drawing.Size(245, 20);
            this.tbNotifyValue.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 5);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(191, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Уведомить, если закрепов меньше:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbToListEditField);
            this.panel1.Controls.Add(this.pToListControls);
            this.panel1.Controls.Add(this.lboxToList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 356);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(245, 132);
            this.panel1.TabIndex = 28;
            // 
            // tbToListEditField
            // 
            this.tbToListEditField.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbToListEditField.Location = new System.Drawing.Point(0, 74);
            this.tbToListEditField.Name = "tbToListEditField";
            this.tbToListEditField.Size = new System.Drawing.Size(245, 20);
            this.tbToListEditField.TabIndex = 1;
            // 
            // pToListControls
            // 
            this.pToListControls.Controls.Add(this.btToListRemove);
            this.pToListControls.Controls.Add(this.btToListChange);
            this.pToListControls.Controls.Add(this.btToListAdd);
            this.pToListControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pToListControls.Location = new System.Drawing.Point(0, 74);
            this.pToListControls.Name = "pToListControls";
            this.pToListControls.Size = new System.Drawing.Size(245, 58);
            this.pToListControls.TabIndex = 1;
            // 
            // btToListRemove
            // 
            this.btToListRemove.Location = new System.Drawing.Point(165, 26);
            this.btToListRemove.Name = "btToListRemove";
            this.btToListRemove.Size = new System.Drawing.Size(75, 23);
            this.btToListRemove.TabIndex = 2;
            this.btToListRemove.Text = "Удалить";
            this.btToListRemove.UseVisualStyleBackColor = true;
            this.btToListRemove.Click += new System.EventHandler(this.btToListRemove_Click);
            // 
            // btToListChange
            // 
            this.btToListChange.Location = new System.Drawing.Point(84, 26);
            this.btToListChange.Name = "btToListChange";
            this.btToListChange.Size = new System.Drawing.Size(75, 23);
            this.btToListChange.TabIndex = 1;
            this.btToListChange.Text = "Изменить";
            this.btToListChange.UseVisualStyleBackColor = true;
            this.btToListChange.Click += new System.EventHandler(this.btToListChange_Click);
            // 
            // btToListAdd
            // 
            this.btToListAdd.Location = new System.Drawing.Point(3, 26);
            this.btToListAdd.Name = "btToListAdd";
            this.btToListAdd.Size = new System.Drawing.Size(75, 23);
            this.btToListAdd.TabIndex = 0;
            this.btToListAdd.Text = "Добавить";
            this.btToListAdd.UseVisualStyleBackColor = true;
            this.btToListAdd.Click += new System.EventHandler(this.btToListAdd_Click);
            // 
            // lboxToList
            // 
            this.lboxToList.Cursor = System.Windows.Forms.Cursors.Default;
            this.lboxToList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lboxToList.ForeColor = System.Drawing.Color.Black;
            this.lboxToList.FormattingEnabled = true;
            this.lboxToList.HorizontalScrollbar = true;
            this.lboxToList.Location = new System.Drawing.Point(0, 5);
            this.lboxToList.Name = "lboxToList";
            this.lboxToList.Size = new System.Drawing.Size(245, 69);
            this.lboxToList.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(5, 338);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 27;
            this.label3.Text = "Получатели:";
            // 
            // lbSettingsPanelWidth
            // 
            this.lbSettingsPanelWidth.AutoSize = true;
            this.lbSettingsPanelWidth.Location = new System.Drawing.Point(526, 25);
            this.lbSettingsPanelWidth.Name = "lbSettingsPanelWidth";
            this.lbSettingsPanelWidth.Size = new System.Drawing.Size(25, 13);
            this.lbSettingsPanelWidth.TabIndex = 14;
            this.lbSettingsPanelWidth.Text = "260";
            this.lbSettingsPanelWidth.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(516, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Размеры панели настроек";
            this.label10.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(516, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Размеры главной панели";
            this.label11.Visible = false;
            // 
            // lbMainPanelWidth
            // 
            this.lbMainPanelWidth.AutoSize = true;
            this.lbMainPanelWidth.Location = new System.Drawing.Point(526, 89);
            this.lbMainPanelWidth.Name = "lbMainPanelWidth";
            this.lbMainPanelWidth.Size = new System.Drawing.Size(25, 13);
            this.lbMainPanelWidth.TabIndex = 17;
            this.lbMainPanelWidth.Text = "270";
            this.lbMainPanelWidth.Visible = false;
            // 
            // lbSettingsPanelHeight
            // 
            this.lbSettingsPanelHeight.AutoSize = true;
            this.lbSettingsPanelHeight.Location = new System.Drawing.Point(582, 25);
            this.lbSettingsPanelHeight.Name = "lbSettingsPanelHeight";
            this.lbSettingsPanelHeight.Size = new System.Drawing.Size(25, 13);
            this.lbSettingsPanelHeight.TabIndex = 13;
            this.lbSettingsPanelHeight.Text = "730";
            this.lbSettingsPanelHeight.Visible = false;
            // 
            // lbMainPanelHeight
            // 
            this.lbMainPanelHeight.AutoSize = true;
            this.lbMainPanelHeight.Location = new System.Drawing.Point(582, 89);
            this.lbMainPanelHeight.Name = "lbMainPanelHeight";
            this.lbMainPanelHeight.Size = new System.Drawing.Size(25, 13);
            this.lbMainPanelHeight.TabIndex = 16;
            this.lbMainPanelHeight.Text = "425";
            this.lbMainPanelHeight.Visible = false;
            // 
            // niTray
            // 
            this.niTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.niTray.BalloonTipText = "ColsarParser";
            this.niTray.BalloonTipTitle = "ColsarParser";
            this.niTray.ContextMenuStrip = this.contextMenuStrip1;
            this.niTray.Icon = ((System.Drawing.Icon)(resources.GetObject("niTray.Icon")));
            this.niTray.Text = "ColsarParser";
            this.niTray.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатьОкноToolStripMenuItem,
            this.toolStripMenuItem2,
            this.выходToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 70);
            // 
            // показатьОкноToolStripMenuItem
            // 
            this.показатьОкноToolStripMenuItem.Name = "показатьОкноToolStripMenuItem";
            this.показатьОкноToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.показатьОкноToolStripMenuItem.Text = "Показать окно";
            this.показатьОкноToolStripMenuItem.Click += new System.EventHandler(this.показатьОкноToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem2.Text = "-----";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // btSettingsToggle
            // 
            this.btSettingsToggle.Dock = System.Windows.Forms.DockStyle.Left;
            this.btSettingsToggle.Image = ((System.Drawing.Image)(resources.GetObject("btSettingsToggle.Image")));
            this.btSettingsToggle.Location = new System.Drawing.Point(470, 0);
            this.btSettingsToggle.Name = "btSettingsToggle";
            this.btSettingsToggle.Size = new System.Drawing.Size(40, 690);
            this.btSettingsToggle.TabIndex = 12;
            this.btSettingsToggle.UseVisualStyleBackColor = true;
            this.btSettingsToggle.Click += new System.EventHandler(this.btSettingsToggle_Click);
            // 
            // cbStableManager
            // 
            this.cbStableManager.AutoSize = true;
            this.cbStableManager.Checked = true;
            this.cbStableManager.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStableManager.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbStableManager.Location = new System.Drawing.Point(0, 141);
            this.cbStableManager.Name = "cbStableManager";
            this.cbStableManager.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.cbStableManager.Size = new System.Drawing.Size(245, 22);
            this.cbStableManager.TabIndex = 36;
            this.cbStableManager.Text = "Установить менеджер безотказности";
            this.cbStableManager.UseVisualStyleBackColor = true;
            // 
            // cbRunIfError
            // 
            this.cbRunIfError.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbRunIfError.Location = new System.Drawing.Point(5, 51);
            this.cbRunIfError.Name = "cbRunIfError";
            this.cbRunIfError.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.cbRunIfError.Size = new System.Drawing.Size(205, 40);
            this.cbRunIfError.TabIndex = 36;
            this.cbRunIfError.Text = "Принудительно запускать при ошибке";
            this.cbRunIfError.UseVisualStyleBackColor = true;
            this.cbRunIfError.CheckedChanged += new System.EventHandler(this.cbRunIfError_CheckedChanged);
            // 
            // rtLog
            // 
            this.rtLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtLog.Location = new System.Drawing.Point(5, 109);
            this.rtLog.Name = "rtLog";
            this.rtLog.Size = new System.Drawing.Size(205, 267);
            this.rtLog.TabIndex = 38;
            this.rtLog.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Location = new System.Drawing.Point(5, 91);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label13.Size = new System.Drawing.Size(26, 18);
            this.label13.TabIndex = 37;
            this.label13.Text = "Лог";
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 690);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbMainPanelWidth);
            this.Controls.Add(this.lbMainPanelHeight);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbSettingsPanelWidth);
            this.Controls.Add(this.lbSettingsPanelHeight);
            this.Controls.Add(this.btSettingsToggle);
            this.Controls.Add(this.pSettings);
            this.Controls.Add(this.pMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "fmMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ColsarParser!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmMain_FormClosed);
            this.pMain.ResumeLayout(false);
            this.pMain.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pSettings.ResumeLayout(false);
            this.pSettings.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pToListControls.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Button btCheckButton;
        private System.Windows.Forms.Button btStateToggle;
        private System.Windows.Forms.Button btSettingsToggle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbSenderPasswordVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSenderLoginVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbSMTPUseSSLVal;
        private System.Windows.Forms.TextBox tbSMPTServerPortVal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSMTPServerVal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbMessageBodyVal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbMessageSubjectVal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pSettings;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbCheckIntervalMinVal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNotifyValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbToListEditField;
        private System.Windows.Forms.Panel pToListControls;
        private System.Windows.Forms.Button btToListRemove;
        private System.Windows.Forms.Button btToListChange;
        private System.Windows.Forms.Button btToListAdd;
        private System.Windows.Forms.ListBox lboxToList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btDiscardSettings;
        private System.Windows.Forms.Button btApplySettings;
        private System.Windows.Forms.Label lbSettingsPanelWidth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbMainPanelWidth;
        private System.Windows.Forms.Label lbSettingsPanelHeight;
        private System.Windows.Forms.Label lbMainPanelHeight;
        private System.Windows.Forms.Button btCheckAuth;
        private System.Windows.Forms.TextBox tbUrlCheckVal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbAutorun;
        private System.Windows.Forms.NotifyIcon niTray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem показатьОкноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbStableManager;
        private System.Windows.Forms.RichTextBox rtLog;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cbRunIfError;
    }
}

