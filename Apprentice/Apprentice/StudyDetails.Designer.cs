namespace Apprentice
{
    partial class StudyDetails
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
            this.patientGenderComboBox = new System.Windows.Forms.ComboBox();
            this.patientBirthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.goBackLinkLabel = new System.Windows.Forms.LinkLabel();
            this.shotItemTextBox = new System.Windows.Forms.TextBox();
            this.shotItemLabel = new System.Windows.Forms.Label();
            this.commentTextBox = new System.Windows.Forms.TextBox();
            this.changeIntoPerformedButton = new System.Windows.Forms.Button();
            this.undoStudyStatusButton = new System.Windows.Forms.Button();
            this.changeIntoAcceptedButton = new System.Windows.Forms.Button();
            this.studyStatusTextBox = new System.Windows.Forms.TextBox();
            this.studuStatusLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.studyTypeNameTextBox = new System.Windows.Forms.TextBox();
            this.patientKanaNameTextBox = new System.Windows.Forms.TextBox();
            this.patientKanjiNameTextBox = new System.Windows.Forms.TextBox();
            this.patientIdTextBox = new System.Windows.Forms.TextBox();
            this.studiedAtTextBox = new System.Windows.Forms.TextBox();
            this.scheduledOnTextBox = new System.Windows.Forms.TextBox();
            this.orderNumberTextBox = new System.Windows.Forms.TextBox();
            this.commentLabel = new System.Windows.Forms.Label();
            this.studyTypeNameLabel = new System.Windows.Forms.Label();
            this.patientGenderLabel = new System.Windows.Forms.Label();
            this.patientBirthDateLabel = new System.Windows.Forms.Label();
            this.patientKanaNameLabel = new System.Windows.Forms.Label();
            this.patientKanjiNameLabel = new System.Windows.Forms.Label();
            this.patientIdLabel = new System.Windows.Forms.Label();
            this.studiedAtLabel = new System.Windows.Forms.Label();
            this.scheduledOnLabel = new System.Windows.Forms.Label();
            this.orderNumberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // patientGenderComboBox
            // 
            this.patientGenderComboBox.FormattingEnabled = true;
            this.patientGenderComboBox.Items.AddRange(new object[] {
            "F",
            "M",
            "O"});
            this.patientGenderComboBox.Location = new System.Drawing.Point(90, 348);
            this.patientGenderComboBox.Name = "patientGenderComboBox";
            this.patientGenderComboBox.Size = new System.Drawing.Size(56, 20);
            this.patientGenderComboBox.TabIndex = 107;
            // 
            // patientBirthDateTimePicker
            // 
            this.patientBirthDateTimePicker.Location = new System.Drawing.Point(90, 313);
            this.patientBirthDateTimePicker.Name = "patientBirthDateTimePicker";
            this.patientBirthDateTimePicker.Size = new System.Drawing.Size(200, 19);
            this.patientBirthDateTimePicker.TabIndex = 106;
            // 
            // goBackLinkLabel
            // 
            this.goBackLinkLabel.AutoSize = true;
            this.goBackLinkLabel.Location = new System.Drawing.Point(746, 428);
            this.goBackLinkLabel.Name = "goBackLinkLabel";
            this.goBackLinkLabel.Size = new System.Drawing.Size(26, 12);
            this.goBackLinkLabel.TabIndex = 105;
            this.goBackLinkLabel.TabStop = true;
            this.goBackLinkLabel.Text = "戻る";
            this.goBackLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GoBackLinkLabelLinkClicked);
            // 
            // shotItemTextBox
            // 
            this.shotItemTextBox.Location = new System.Drawing.Point(90, 421);
            this.shotItemTextBox.Name = "shotItemTextBox";
            this.shotItemTextBox.ReadOnly = true;
            this.shotItemTextBox.Size = new System.Drawing.Size(199, 19);
            this.shotItemTextBox.TabIndex = 104;
            this.shotItemTextBox.Text = "胸部正面";
            // 
            // shotItemLabel
            // 
            this.shotItemLabel.AutoSize = true;
            this.shotItemLabel.Location = new System.Drawing.Point(30, 424);
            this.shotItemLabel.Name = "shotItemLabel";
            this.shotItemLabel.Size = new System.Drawing.Size(53, 12);
            this.shotItemLabel.TabIndex = 103;
            this.shotItemLabel.Text = "撮影項目";
            // 
            // commentTextBox
            // 
            this.commentTextBox.Location = new System.Drawing.Point(357, 76);
            this.commentTextBox.Multiline = true;
            this.commentTextBox.Name = "commentTextBox";
            this.commentTextBox.Size = new System.Drawing.Size(428, 270);
            this.commentTextBox.TabIndex = 102;
            // 
            // changeIntoPerformedButton
            // 
            this.changeIntoPerformedButton.Location = new System.Drawing.Point(496, 372);
            this.changeIntoPerformedButton.Name = "changeIntoPerformedButton";
            this.changeIntoPerformedButton.Size = new System.Drawing.Size(88, 45);
            this.changeIntoPerformedButton.TabIndex = 101;
            this.changeIntoPerformedButton.Text = "撮影済へ変更";
            this.changeIntoPerformedButton.UseVisualStyleBackColor = true;
            this.changeIntoPerformedButton.Click += new System.EventHandler(this.ChangeIntoPerformedButtonClick);
            // 
            // undoStudyStatusButton
            // 
            this.undoStudyStatusButton.Location = new System.Drawing.Point(611, 372);
            this.undoStudyStatusButton.Name = "undoStudyStatusButton";
            this.undoStudyStatusButton.Size = new System.Drawing.Size(88, 45);
            this.undoStudyStatusButton.TabIndex = 100;
            this.undoStudyStatusButton.Text = "検査状況を\r\n一つ前に戻す";
            this.undoStudyStatusButton.UseVisualStyleBackColor = true;
            this.undoStudyStatusButton.Click += new System.EventHandler(this.UndoStudyStatusButtonClick);
            // 
            // changeIntoAcceptedButton
            // 
            this.changeIntoAcceptedButton.Location = new System.Drawing.Point(383, 372);
            this.changeIntoAcceptedButton.Name = "changeIntoAcceptedButton";
            this.changeIntoAcceptedButton.Size = new System.Drawing.Size(88, 45);
            this.changeIntoAcceptedButton.TabIndex = 99;
            this.changeIntoAcceptedButton.Text = "受付済へ変更";
            this.changeIntoAcceptedButton.UseVisualStyleBackColor = true;
            this.changeIntoAcceptedButton.Click += new System.EventHandler(this.ChangeIntoAcceptedButtonClick);
            // 
            // studyStatusTextBox
            // 
            this.studyStatusTextBox.Location = new System.Drawing.Point(90, 97);
            this.studyStatusTextBox.Name = "studyStatusTextBox";
            this.studyStatusTextBox.ReadOnly = true;
            this.studyStatusTextBox.Size = new System.Drawing.Size(79, 19);
            this.studyStatusTextBox.TabIndex = 98;
            this.studyStatusTextBox.Text = "受付済";
            // 
            // studuStatusLabel
            // 
            this.studuStatusLabel.AutoSize = true;
            this.studuStatusLabel.Location = new System.Drawing.Point(30, 100);
            this.studuStatusLabel.Name = "studuStatusLabel";
            this.studuStatusLabel.Size = new System.Drawing.Size(53, 12);
            this.studuStatusLabel.TabIndex = 97;
            this.studuStatusLabel.Text = "検査状況";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(676, 10);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(109, 46);
            this.saveButton.TabIndex = 96;
            this.saveButton.Text = "更新";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // studyTypeNameTextBox
            // 
            this.studyTypeNameTextBox.Location = new System.Drawing.Point(90, 385);
            this.studyTypeNameTextBox.Name = "studyTypeNameTextBox";
            this.studyTypeNameTextBox.ReadOnly = true;
            this.studyTypeNameTextBox.Size = new System.Drawing.Size(199, 19);
            this.studyTypeNameTextBox.TabIndex = 95;
            this.studyTypeNameTextBox.Text = "CT";
            // 
            // patientKanaNameTextBox
            // 
            this.patientKanaNameTextBox.Location = new System.Drawing.Point(90, 277);
            this.patientKanaNameTextBox.Name = "patientKanaNameTextBox";
            this.patientKanaNameTextBox.Size = new System.Drawing.Size(199, 19);
            this.patientKanaNameTextBox.TabIndex = 94;
            this.patientKanaNameTextBox.Text = "タナカ　イチロウ";
            // 
            // patientKanjiNameTextBox
            // 
            this.patientKanjiNameTextBox.Location = new System.Drawing.Point(90, 241);
            this.patientKanjiNameTextBox.Name = "patientKanjiNameTextBox";
            this.patientKanjiNameTextBox.Size = new System.Drawing.Size(199, 19);
            this.patientKanjiNameTextBox.TabIndex = 93;
            this.patientKanjiNameTextBox.Text = "田中　一郎";
            // 
            // patientIdTextBox
            // 
            this.patientIdTextBox.Location = new System.Drawing.Point(90, 205);
            this.patientIdTextBox.Name = "patientIdTextBox";
            this.patientIdTextBox.ReadOnly = true;
            this.patientIdTextBox.Size = new System.Drawing.Size(199, 19);
            this.patientIdTextBox.TabIndex = 92;
            this.patientIdTextBox.Text = "1111111111";
            // 
            // studiedAtTextBox
            // 
            this.studiedAtTextBox.Location = new System.Drawing.Point(90, 169);
            this.studiedAtTextBox.Name = "studiedAtTextBox";
            this.studiedAtTextBox.ReadOnly = true;
            this.studiedAtTextBox.Size = new System.Drawing.Size(119, 19);
            this.studiedAtTextBox.TabIndex = 91;
            this.studiedAtTextBox.Text = "2020年  6月22日";
            // 
            // scheduledOnTextBox
            // 
            this.scheduledOnTextBox.Location = new System.Drawing.Point(90, 133);
            this.scheduledOnTextBox.Name = "scheduledOnTextBox";
            this.scheduledOnTextBox.ReadOnly = true;
            this.scheduledOnTextBox.Size = new System.Drawing.Size(119, 19);
            this.scheduledOnTextBox.TabIndex = 90;
            this.scheduledOnTextBox.Text = "2020年  6月22日";
            // 
            // orderNumberTextBox
            // 
            this.orderNumberTextBox.Location = new System.Drawing.Point(90, 61);
            this.orderNumberTextBox.Name = "orderNumberTextBox";
            this.orderNumberTextBox.ReadOnly = true;
            this.orderNumberTextBox.Size = new System.Drawing.Size(199, 19);
            this.orderNumberTextBox.TabIndex = 89;
            this.orderNumberTextBox.Text = "12345678";
            // 
            // commentLabel
            // 
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(355, 61);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(62, 12);
            this.commentLabel.TabIndex = 88;
            this.commentLabel.Text = "撮影コメント";
            // 
            // studyTypeNameLabel
            // 
            this.studyTypeNameLabel.AutoSize = true;
            this.studyTypeNameLabel.Location = new System.Drawing.Point(42, 388);
            this.studyTypeNameLabel.Name = "studyTypeNameLabel";
            this.studyTypeNameLabel.Size = new System.Drawing.Size(41, 12);
            this.studyTypeNameLabel.TabIndex = 87;
            this.studyTypeNameLabel.Text = "検査種";
            // 
            // patientGenderLabel
            // 
            this.patientGenderLabel.AutoSize = true;
            this.patientGenderLabel.Location = new System.Drawing.Point(54, 352);
            this.patientGenderLabel.Name = "patientGenderLabel";
            this.patientGenderLabel.Size = new System.Drawing.Size(29, 12);
            this.patientGenderLabel.TabIndex = 86;
            this.patientGenderLabel.Text = "性別";
            // 
            // patientBirthDateLabel
            // 
            this.patientBirthDateLabel.AutoSize = true;
            this.patientBirthDateLabel.Location = new System.Drawing.Point(30, 316);
            this.patientBirthDateLabel.Name = "patientBirthDateLabel";
            this.patientBirthDateLabel.Size = new System.Drawing.Size(53, 12);
            this.patientBirthDateLabel.TabIndex = 85;
            this.patientBirthDateLabel.Text = "生年月日";
            // 
            // patientKanaNameLabel
            // 
            this.patientKanaNameLabel.AutoSize = true;
            this.patientKanaNameLabel.Location = new System.Drawing.Point(51, 280);
            this.patientKanaNameLabel.Name = "patientKanaNameLabel";
            this.patientKanaNameLabel.Size = new System.Drawing.Size(32, 12);
            this.patientKanaNameLabel.TabIndex = 84;
            this.patientKanaNameLabel.Text = "シメイ";
            // 
            // patientKanjiNameLabel
            // 
            this.patientKanjiNameLabel.AutoSize = true;
            this.patientKanjiNameLabel.Location = new System.Drawing.Point(54, 244);
            this.patientKanjiNameLabel.Name = "patientKanjiNameLabel";
            this.patientKanjiNameLabel.Size = new System.Drawing.Size(29, 12);
            this.patientKanjiNameLabel.TabIndex = 83;
            this.patientKanjiNameLabel.Text = "氏名";
            // 
            // patientIdLabel
            // 
            this.patientIdLabel.AutoSize = true;
            this.patientIdLabel.Location = new System.Drawing.Point(43, 208);
            this.patientIdLabel.Name = "patientIdLabel";
            this.patientIdLabel.Size = new System.Drawing.Size(40, 12);
            this.patientIdLabel.TabIndex = 82;
            this.patientIdLabel.Text = "患者ID";
            // 
            // studiedAtLabel
            // 
            this.studiedAtLabel.AutoSize = true;
            this.studiedAtLabel.Location = new System.Drawing.Point(42, 172);
            this.studiedAtLabel.Name = "studiedAtLabel";
            this.studiedAtLabel.Size = new System.Drawing.Size(41, 12);
            this.studiedAtLabel.TabIndex = 81;
            this.studiedAtLabel.Text = "検査日";
            // 
            // scheduledOnLabel
            // 
            this.scheduledOnLabel.AutoSize = true;
            this.scheduledOnLabel.Location = new System.Drawing.Point(42, 136);
            this.scheduledOnLabel.Name = "scheduledOnLabel";
            this.scheduledOnLabel.Size = new System.Drawing.Size(41, 12);
            this.scheduledOnLabel.TabIndex = 80;
            this.scheduledOnLabel.Text = "予約日";
            // 
            // orderNumberLabel
            // 
            this.orderNumberLabel.AutoSize = true;
            this.orderNumberLabel.Location = new System.Drawing.Point(16, 64);
            this.orderNumberLabel.Name = "orderNumberLabel";
            this.orderNumberLabel.Size = new System.Drawing.Size(67, 12);
            this.orderNumberLabel.TabIndex = 79;
            this.orderNumberLabel.Text = "オーダー番号";
            // 
            // StudyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.patientGenderComboBox);
            this.Controls.Add(this.patientBirthDateTimePicker);
            this.Controls.Add(this.goBackLinkLabel);
            this.Controls.Add(this.shotItemTextBox);
            this.Controls.Add(this.shotItemLabel);
            this.Controls.Add(this.commentTextBox);
            this.Controls.Add(this.changeIntoPerformedButton);
            this.Controls.Add(this.undoStudyStatusButton);
            this.Controls.Add(this.changeIntoAcceptedButton);
            this.Controls.Add(this.studyStatusTextBox);
            this.Controls.Add(this.studuStatusLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.studyTypeNameTextBox);
            this.Controls.Add(this.patientKanaNameTextBox);
            this.Controls.Add(this.patientKanjiNameTextBox);
            this.Controls.Add(this.patientIdTextBox);
            this.Controls.Add(this.studiedAtTextBox);
            this.Controls.Add(this.scheduledOnTextBox);
            this.Controls.Add(this.orderNumberTextBox);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.studyTypeNameLabel);
            this.Controls.Add(this.patientGenderLabel);
            this.Controls.Add(this.patientBirthDateLabel);
            this.Controls.Add(this.patientKanaNameLabel);
            this.Controls.Add(this.patientKanjiNameLabel);
            this.Controls.Add(this.patientIdLabel);
            this.Controls.Add(this.studiedAtLabel);
            this.Controls.Add(this.scheduledOnLabel);
            this.Controls.Add(this.orderNumberLabel);
            this.Name = "StudyDetails";
            this.Text = "StudyDetails";
            this.Load += new System.EventHandler(this.StudyDetailsLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox patientGenderComboBox;
        private System.Windows.Forms.DateTimePicker patientBirthDateTimePicker;
        private System.Windows.Forms.LinkLabel goBackLinkLabel;
        private System.Windows.Forms.TextBox shotItemTextBox;
        private System.Windows.Forms.Label shotItemLabel;
        private System.Windows.Forms.TextBox commentTextBox;
        private System.Windows.Forms.Button changeIntoPerformedButton;
        private System.Windows.Forms.Button undoStudyStatusButton;
        private System.Windows.Forms.Button changeIntoAcceptedButton;
        private System.Windows.Forms.TextBox studyStatusTextBox;
        private System.Windows.Forms.Label studuStatusLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox studyTypeNameTextBox;
        private System.Windows.Forms.TextBox patientKanaNameTextBox;
        private System.Windows.Forms.TextBox patientKanjiNameTextBox;
        private System.Windows.Forms.TextBox patientIdTextBox;
        private System.Windows.Forms.TextBox studiedAtTextBox;
        private System.Windows.Forms.TextBox scheduledOnTextBox;
        private System.Windows.Forms.TextBox orderNumberTextBox;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.Label studyTypeNameLabel;
        private System.Windows.Forms.Label patientGenderLabel;
        private System.Windows.Forms.Label patientBirthDateLabel;
        private System.Windows.Forms.Label patientKanaNameLabel;
        private System.Windows.Forms.Label patientKanjiNameLabel;
        private System.Windows.Forms.Label patientIdLabel;
        private System.Windows.Forms.Label studiedAtLabel;
        private System.Windows.Forms.Label scheduledOnLabel;
        private System.Windows.Forms.Label orderNumberLabel;
    }
}