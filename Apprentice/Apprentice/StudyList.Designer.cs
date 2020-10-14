namespace Apprentice
{
    partial class StudyList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.updateIntervalNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.logoutButton = new System.Windows.Forms.Button();
            this.holdButton = new System.Windows.Forms.Button();
            this.userInfoChangeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.userRegistrationLinkLabel = new System.Windows.Forms.LinkLabel();
            this.searchStudyStatusComboBox = new System.Windows.Forms.ComboBox();
            this.StudyStatusLabel = new System.Windows.Forms.Label();
            this.SecLabel = new System.Windows.Forms.Label();
            this.AutoUpdateIntervalLabel = new System.Windows.Forms.Label();
            this.studyDetailsButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.invalidRadioButton = new System.Windows.Forms.RadioButton();
            this.validRadioButton = new System.Windows.Forms.RadioButton();
            this.searchPatientIdTextBox = new System.Windows.Forms.TextBox();
            this.PatientIdLabel = new System.Windows.Forms.Label();
            this.fromToLabel = new System.Windows.Forms.Label();
            this.searchToStudyDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.searchFromStudyDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StudyDateLabel = new System.Windows.Forms.Label();
            this.studyListDataGridView = new System.Windows.Forms.DataGridView();
            this.orderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studyStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduledOnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientIdscheduledOnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientKanjiNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientKanaNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studyTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shotItemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studyviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studydata_dbDataSet = new Apprentice.Studydata_dbDataSet();
            this.AutoUpadateGroupBox = new System.Windows.Forms.GroupBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.study_viewTableAdapter = new Apprentice.Studydata_dbDataSetTableAdapters.Study_viewTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studyListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studyviewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studydata_dbDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // updateIntervalNumericUpDown
            // 
            this.updateIntervalNumericUpDown.Location = new System.Drawing.Point(601, 55);
            this.updateIntervalNumericUpDown.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.updateIntervalNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updateIntervalNumericUpDown.Name = "updateIntervalNumericUpDown";
            this.updateIntervalNumericUpDown.Size = new System.Drawing.Size(49, 19);
            this.updateIntervalNumericUpDown.TabIndex = 71;
            this.updateIntervalNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updateIntervalNumericUpDown.ValueChanged += new System.EventHandler(this.UpdateIntervalNumericUpDownValueChanged);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(737, 420);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(82, 32);
            this.logoutButton.TabIndex = 70;
            this.logoutButton.Text = "ログアウト";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.LogoutButtonClick);
            // 
            // holdButton
            // 
            this.holdButton.Location = new System.Drawing.Point(379, 58);
            this.holdButton.Name = "holdButton";
            this.holdButton.Size = new System.Drawing.Size(82, 32);
            this.holdButton.TabIndex = 69;
            this.holdButton.Text = "保留";
            this.holdButton.UseVisualStyleBackColor = true;
            this.holdButton.Click += new System.EventHandler(this.HoldButtonClick);
            // 
            // userInfoChangeLinkLabel
            // 
            this.userInfoChangeLinkLabel.AutoSize = true;
            this.userInfoChangeLinkLabel.Location = new System.Drawing.Point(726, 100);
            this.userInfoChangeLinkLabel.Name = "userInfoChangeLinkLabel";
            this.userInfoChangeLinkLabel.Size = new System.Drawing.Size(93, 12);
            this.userInfoChangeLinkLabel.TabIndex = 68;
            this.userInfoChangeLinkLabel.TabStop = true;
            this.userInfoChangeLinkLabel.Text = "ユーザー情報変更";
            this.userInfoChangeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UserInfoChangeLinkLabelLinkClicked);
            // 
            // userRegistrationLinkLabel
            // 
            this.userRegistrationLinkLabel.AutoSize = true;
            this.userRegistrationLinkLabel.Location = new System.Drawing.Point(726, 81);
            this.userRegistrationLinkLabel.Name = "userRegistrationLinkLabel";
            this.userRegistrationLinkLabel.Size = new System.Drawing.Size(93, 12);
            this.userRegistrationLinkLabel.TabIndex = 67;
            this.userRegistrationLinkLabel.TabStop = true;
            this.userRegistrationLinkLabel.Text = "新規ユーザー登録";
            this.userRegistrationLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UserRegistrationLinkLabelLinkClicked);
            // 
            // searchStudyStatusComboBox
            // 
            this.searchStudyStatusComboBox.FormattingEnabled = true;
            this.searchStudyStatusComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.searchStudyStatusComboBox.Items.AddRange(new object[] {
            "",
            "予約済",
            "受付済",
            "撮影済"});
            this.searchStudyStatusComboBox.Location = new System.Drawing.Point(63, 84);
            this.searchStudyStatusComboBox.Name = "searchStudyStatusComboBox";
            this.searchStudyStatusComboBox.Size = new System.Drawing.Size(115, 20);
            this.searchStudyStatusComboBox.TabIndex = 66;
            // 
            // StudyStatusLabel
            // 
            this.StudyStatusLabel.AutoSize = true;
            this.StudyStatusLabel.Location = new System.Drawing.Point(4, 88);
            this.StudyStatusLabel.Name = "StudyStatusLabel";
            this.StudyStatusLabel.Size = new System.Drawing.Size(53, 12);
            this.StudyStatusLabel.TabIndex = 64;
            this.StudyStatusLabel.Text = "検査状況";
            // 
            // SecLabel
            // 
            this.SecLabel.AutoSize = true;
            this.SecLabel.Location = new System.Drawing.Point(656, 58);
            this.SecLabel.Name = "SecLabel";
            this.SecLabel.Size = new System.Drawing.Size(17, 12);
            this.SecLabel.TabIndex = 63;
            this.SecLabel.Text = "秒";
            // 
            // AutoUpdateIntervalLabel
            // 
            this.AutoUpdateIntervalLabel.AutoSize = true;
            this.AutoUpdateIntervalLabel.Location = new System.Drawing.Point(599, 37);
            this.AutoUpdateIntervalLabel.Name = "AutoUpdateIntervalLabel";
            this.AutoUpdateIntervalLabel.Size = new System.Drawing.Size(77, 12);
            this.AutoUpdateIntervalLabel.TabIndex = 62;
            this.AutoUpdateIntervalLabel.Text = "自動更新間隔";
            // 
            // studyDetailsButton
            // 
            this.studyDetailsButton.Location = new System.Drawing.Point(379, 19);
            this.studyDetailsButton.Name = "studyDetailsButton";
            this.studyDetailsButton.Size = new System.Drawing.Size(82, 32);
            this.studyDetailsButton.TabIndex = 61;
            this.studyDetailsButton.Text = "検査詳細";
            this.studyDetailsButton.UseVisualStyleBackColor = true;
            this.studyDetailsButton.Click += new System.EventHandler(this.StudyDetailsButtonClick);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(699, 15);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(120, 48);
            this.updateButton.TabIndex = 60;
            this.updateButton.Text = "更新";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.UpdateButtonClick);
            // 
            // invalidRadioButton
            // 
            this.invalidRadioButton.AutoSize = true;
            this.invalidRadioButton.Checked = true;
            this.invalidRadioButton.Location = new System.Drawing.Point(521, 65);
            this.invalidRadioButton.Name = "invalidRadioButton";
            this.invalidRadioButton.Size = new System.Drawing.Size(47, 16);
            this.invalidRadioButton.TabIndex = 59;
            this.invalidRadioButton.TabStop = true;
            this.invalidRadioButton.Text = "無効";
            this.invalidRadioButton.UseVisualStyleBackColor = true;
            this.invalidRadioButton.CheckedChanged += new System.EventHandler(this.InvalidRadioButtonCheckedChanged);
            // 
            // validRadioButton
            // 
            this.validRadioButton.AutoSize = true;
            this.validRadioButton.Location = new System.Drawing.Point(521, 44);
            this.validRadioButton.Name = "validRadioButton";
            this.validRadioButton.Size = new System.Drawing.Size(47, 16);
            this.validRadioButton.TabIndex = 58;
            this.validRadioButton.Text = "有効";
            this.validRadioButton.UseVisualStyleBackColor = true;
            this.validRadioButton.CheckedChanged += new System.EventHandler(this.ValidRadioButtonCheckedChanged);
            // 
            // searchPatientIdTextBox
            // 
            this.searchPatientIdTextBox.Location = new System.Drawing.Point(63, 55);
            this.searchPatientIdTextBox.Name = "searchPatientIdTextBox";
            this.searchPatientIdTextBox.Size = new System.Drawing.Size(115, 19);
            this.searchPatientIdTextBox.TabIndex = 57;
            // 
            // PatientIdLabel
            // 
            this.PatientIdLabel.AutoSize = true;
            this.PatientIdLabel.Location = new System.Drawing.Point(17, 58);
            this.PatientIdLabel.Name = "PatientIdLabel";
            this.PatientIdLabel.Size = new System.Drawing.Size(40, 12);
            this.PatientIdLabel.TabIndex = 56;
            this.PatientIdLabel.Text = "患者ID";
            // 
            // fromToLabel
            // 
            this.fromToLabel.AutoSize = true;
            this.fromToLabel.Location = new System.Drawing.Point(184, 29);
            this.fromToLabel.Name = "fromToLabel";
            this.fromToLabel.Size = new System.Drawing.Size(17, 12);
            this.fromToLabel.TabIndex = 55;
            this.fromToLabel.Text = "～";
            // 
            // searchToStudyDateTimePicker
            // 
            this.searchToStudyDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.searchToStudyDateTimePicker.Location = new System.Drawing.Point(207, 26);
            this.searchToStudyDateTimePicker.Name = "searchToStudyDateTimePicker";
            this.searchToStudyDateTimePicker.ShowCheckBox = true;
            this.searchToStudyDateTimePicker.Size = new System.Drawing.Size(115, 19);
            this.searchToStudyDateTimePicker.TabIndex = 54;
            this.searchToStudyDateTimePicker.ValueChanged += new System.EventHandler(this.SearchToStudyDateDateTimePickerValueChanged);
            // 
            // searchFromStudyDateTimePicker
            // 
            this.searchFromStudyDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.searchFromStudyDateTimePicker.Location = new System.Drawing.Point(63, 26);
            this.searchFromStudyDateTimePicker.Name = "searchFromStudyDateTimePicker";
            this.searchFromStudyDateTimePicker.ShowCheckBox = true;
            this.searchFromStudyDateTimePicker.Size = new System.Drawing.Size(115, 19);
            this.searchFromStudyDateTimePicker.TabIndex = 53;
            this.searchFromStudyDateTimePicker.ValueChanged += new System.EventHandler(this.SearchFromStudyDateDateTimePickerValueChanged);
            // 
            // StudyDateLabel
            // 
            this.StudyDateLabel.AutoSize = true;
            this.StudyDateLabel.Location = new System.Drawing.Point(16, 29);
            this.StudyDateLabel.Name = "StudyDateLabel";
            this.StudyDateLabel.Size = new System.Drawing.Size(41, 12);
            this.StudyDateLabel.TabIndex = 52;
            this.StudyDateLabel.Text = "検査日";
            // 
            // studyListDataGridView
            // 
            this.studyListDataGridView.AutoGenerateColumns = false;
            this.studyListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studyListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNumberDataGridViewTextBoxColumn,
            this.studyStatusDataGridViewTextBoxColumn,
            this.scheduledOnDataGridViewTextBoxColumn,
            this.patientIdscheduledOnDataGridViewTextBoxColumn,
            this.patientKanjiNameDataGridViewTextBoxColumn,
            this.patientKanaNameDataGridViewTextBoxColumn,
            this.studyTypeNameDataGridViewTextBoxColumn,
            this.shotItemNameDataGridViewTextBoxColumn});
            this.studyListDataGridView.DataSource = this.studyviewBindingSource;
            this.studyListDataGridView.Location = new System.Drawing.Point(6, 119);
            this.studyListDataGridView.MultiSelect = false;
            this.studyListDataGridView.Name = "studyListDataGridView";
            this.studyListDataGridView.RowHeadersVisible = false;
            this.studyListDataGridView.RowTemplate.Height = 21;
            this.studyListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.studyListDataGridView.Size = new System.Drawing.Size(803, 290);
            this.studyListDataGridView.TabIndex = 51;
            // 
            // orderNumberDataGridViewTextBoxColumn
            // 
            this.orderNumberDataGridViewTextBoxColumn.DataPropertyName = "OrderNumber";
            this.orderNumberDataGridViewTextBoxColumn.HeaderText = "オーダ番号";
            this.orderNumberDataGridViewTextBoxColumn.Name = "orderNumberDataGridViewTextBoxColumn";
            // 
            // studyStatusDataGridViewTextBoxColumn
            // 
            this.studyStatusDataGridViewTextBoxColumn.DataPropertyName = "StudyStatus";
            this.studyStatusDataGridViewTextBoxColumn.HeaderText = "検査状況";
            this.studyStatusDataGridViewTextBoxColumn.Name = "studyStatusDataGridViewTextBoxColumn";
            // 
            // scheduledOnDataGridViewTextBoxColumn
            // 
            this.scheduledOnDataGridViewTextBoxColumn.DataPropertyName = "ScheduledOn";
            this.scheduledOnDataGridViewTextBoxColumn.HeaderText = "検査日";
            this.scheduledOnDataGridViewTextBoxColumn.Name = "scheduledOnDataGridViewTextBoxColumn";
            // 
            // patientIdscheduledOnDataGridViewTextBoxColumn
            // 
            this.patientIdscheduledOnDataGridViewTextBoxColumn.DataPropertyName = "PatientId";
            this.patientIdscheduledOnDataGridViewTextBoxColumn.HeaderText = "患者ID";
            this.patientIdscheduledOnDataGridViewTextBoxColumn.Name = "patientIdscheduledOnDataGridViewTextBoxColumn";
            // 
            // patientKanjiNameDataGridViewTextBoxColumn
            // 
            this.patientKanjiNameDataGridViewTextBoxColumn.DataPropertyName = "PatientKanjiName";
            this.patientKanjiNameDataGridViewTextBoxColumn.HeaderText = "氏名";
            this.patientKanjiNameDataGridViewTextBoxColumn.Name = "patientKanjiNameDataGridViewTextBoxColumn";
            // 
            // patientKanaNameDataGridViewTextBoxColumn
            // 
            this.patientKanaNameDataGridViewTextBoxColumn.DataPropertyName = "PatientKanaName";
            this.patientKanaNameDataGridViewTextBoxColumn.HeaderText = "シメイ";
            this.patientKanaNameDataGridViewTextBoxColumn.Name = "patientKanaNameDataGridViewTextBoxColumn";
            // 
            // studyTypeNameDataGridViewTextBoxColumn
            // 
            this.studyTypeNameDataGridViewTextBoxColumn.DataPropertyName = "StudyTypeName";
            this.studyTypeNameDataGridViewTextBoxColumn.HeaderText = "検査種";
            this.studyTypeNameDataGridViewTextBoxColumn.Name = "studyTypeNameDataGridViewTextBoxColumn";
            // 
            // shotItemNameDataGridViewTextBoxColumn
            // 
            this.shotItemNameDataGridViewTextBoxColumn.DataPropertyName = "ShotItemName";
            this.shotItemNameDataGridViewTextBoxColumn.HeaderText = "撮影項目";
            this.shotItemNameDataGridViewTextBoxColumn.Name = "shotItemNameDataGridViewTextBoxColumn";
            // 
            // studyviewBindingSource
            // 
            this.studyviewBindingSource.DataMember = "Study_view";
            this.studyviewBindingSource.DataSource = this.studydata_dbDataSet;
            // 
            // studydata_dbDataSet
            // 
            this.studydata_dbDataSet.DataSetName = "Studydata_dbDataSet";
            this.studydata_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // AutoUpadateGroupBox
            // 
            this.AutoUpadateGroupBox.Location = new System.Drawing.Point(510, 22);
            this.AutoUpadateGroupBox.Name = "AutoUpadateGroupBox";
            this.AutoUpadateGroupBox.Size = new System.Drawing.Size(69, 68);
            this.AutoUpadateGroupBox.TabIndex = 65;
            this.AutoUpadateGroupBox.TabStop = false;
            this.AutoUpadateGroupBox.Text = "自動更新";
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.UpdateTimerTick);
            // 
            // study_viewTableAdapter
            // 
            this.study_viewTableAdapter.ClearBeforeFill = true;
            // 
            // StudyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 472);
            this.Controls.Add(this.updateIntervalNumericUpDown);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.holdButton);
            this.Controls.Add(this.userInfoChangeLinkLabel);
            this.Controls.Add(this.userRegistrationLinkLabel);
            this.Controls.Add(this.searchStudyStatusComboBox);
            this.Controls.Add(this.StudyStatusLabel);
            this.Controls.Add(this.SecLabel);
            this.Controls.Add(this.AutoUpdateIntervalLabel);
            this.Controls.Add(this.studyDetailsButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.invalidRadioButton);
            this.Controls.Add(this.validRadioButton);
            this.Controls.Add(this.searchPatientIdTextBox);
            this.Controls.Add(this.PatientIdLabel);
            this.Controls.Add(this.fromToLabel);
            this.Controls.Add(this.searchToStudyDateTimePicker);
            this.Controls.Add(this.searchFromStudyDateTimePicker);
            this.Controls.Add(this.StudyDateLabel);
            this.Controls.Add(this.studyListDataGridView);
            this.Controls.Add(this.AutoUpadateGroupBox);
            this.Name = "StudyList";
            this.Text = "StudyList";
            this.Load += new System.EventHandler(this.StudyListLoad);
            ((System.ComponentModel.ISupportInitialize)(this.updateIntervalNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studyListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studyviewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studydata_dbDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown updateIntervalNumericUpDown;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button holdButton;
        private System.Windows.Forms.LinkLabel userInfoChangeLinkLabel;
        private System.Windows.Forms.LinkLabel userRegistrationLinkLabel;
        private System.Windows.Forms.ComboBox searchStudyStatusComboBox;
        private System.Windows.Forms.Label StudyStatusLabel;
        private System.Windows.Forms.Label SecLabel;
        private System.Windows.Forms.Label AutoUpdateIntervalLabel;
        private System.Windows.Forms.Button studyDetailsButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.RadioButton invalidRadioButton;
        private System.Windows.Forms.RadioButton validRadioButton;
        private System.Windows.Forms.TextBox searchPatientIdTextBox;
        private System.Windows.Forms.Label PatientIdLabel;
        private System.Windows.Forms.Label fromToLabel;
        private System.Windows.Forms.DateTimePicker searchToStudyDateTimePicker;
        private System.Windows.Forms.DateTimePicker searchFromStudyDateTimePicker;
        private System.Windows.Forms.Label StudyDateLabel;
        private System.Windows.Forms.DataGridView studyListDataGridView;
        private System.Windows.Forms.GroupBox AutoUpadateGroupBox;
        private System.Windows.Forms.Timer updateTimer;
        private Studydata_dbDataSet studydata_dbDataSet;
        private System.Windows.Forms.BindingSource studyviewBindingSource;
        private Studydata_dbDataSetTableAdapters.Study_viewTableAdapter study_viewTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studyStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduledOnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientIdscheduledOnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientKanjiNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientKanaNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studyTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shotItemNameDataGridViewTextBoxColumn;
    }
}