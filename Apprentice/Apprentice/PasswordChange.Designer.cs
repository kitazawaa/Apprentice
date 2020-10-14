namespace Apprentice
{
    partial class PasswordChange
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
            this.label6 = new System.Windows.Forms.Label();
            this.endingEffectiveDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startEffectiveDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.effectiveDateLabel = new System.Windows.Forms.Label();
            this.currentPasswordLabel = new System.Windows.Forms.Label();
            this.currentPasswordTextBox = new System.Windows.Forms.TextBox();
            this.goBackButton = new System.Windows.Forms.Button();
            this.registrationButton = new System.Windows.Forms.Button();
            this.newPasswordConfirmationTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordConfirmationLabel = new System.Windows.Forms.Label();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.userIdLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(389, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 88;
            this.label6.Text = "～";
            // 
            // endingEffectiveDateTimePicker
            // 
            this.endingEffectiveDateTimePicker.Location = new System.Drawing.Point(423, 305);
            this.endingEffectiveDateTimePicker.Name = "endingEffectiveDateTimePicker";
            this.endingEffectiveDateTimePicker.Size = new System.Drawing.Size(111, 19);
            this.endingEffectiveDateTimePicker.TabIndex = 87;
            this.endingEffectiveDateTimePicker.Value = new System.DateTime(2020, 10, 9, 15, 40, 11, 0);
            this.endingEffectiveDateTimePicker.ValueChanged += new System.EventHandler(this.EndingEffectiveDateTimePickerValueChanged);
            // 
            // startEffectiveDateTimePicker
            // 
            this.startEffectiveDateTimePicker.Location = new System.Drawing.Point(256, 305);
            this.startEffectiveDateTimePicker.Name = "startEffectiveDateTimePicker";
            this.startEffectiveDateTimePicker.Size = new System.Drawing.Size(111, 19);
            this.startEffectiveDateTimePicker.TabIndex = 86;
            this.startEffectiveDateTimePicker.ValueChanged += new System.EventHandler(this.StartEffectiveDateTimePickerValueChanged);
            // 
            // effectiveDateLabel
            // 
            this.effectiveDateLabel.AutoSize = true;
            this.effectiveDateLabel.Location = new System.Drawing.Point(199, 308);
            this.effectiveDateLabel.Name = "effectiveDateLabel";
            this.effectiveDateLabel.Size = new System.Drawing.Size(53, 12);
            this.effectiveDateLabel.TabIndex = 85;
            this.effectiveDateLabel.Text = "有効期限";
            // 
            // currentPasswordLabel
            // 
            this.currentPasswordLabel.AutoSize = true;
            this.currentPasswordLabel.Location = new System.Drawing.Point(166, 167);
            this.currentPasswordLabel.Name = "currentPasswordLabel";
            this.currentPasswordLabel.Size = new System.Drawing.Size(86, 12);
            this.currentPasswordLabel.TabIndex = 84;
            this.currentPasswordLabel.Text = "現在のパスワード";
            // 
            // currentPasswordTextBox
            // 
            this.currentPasswordTextBox.Location = new System.Drawing.Point(256, 164);
            this.currentPasswordTextBox.Name = "currentPasswordTextBox";
            this.currentPasswordTextBox.Size = new System.Drawing.Size(298, 19);
            this.currentPasswordTextBox.TabIndex = 83;
            // 
            // goBackButton
            // 
            this.goBackButton.Location = new System.Drawing.Point(422, 370);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(75, 23);
            this.goBackButton.TabIndex = 82;
            this.goBackButton.Text = "戻る";
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Click += new System.EventHandler(this.GoBackButtonClick);
            // 
            // registrationButton
            // 
            this.registrationButton.Location = new System.Drawing.Point(292, 370);
            this.registrationButton.Name = "registrationButton";
            this.registrationButton.Size = new System.Drawing.Size(75, 23);
            this.registrationButton.TabIndex = 81;
            this.registrationButton.Text = "登録";
            this.registrationButton.UseVisualStyleBackColor = true;
            this.registrationButton.Click += new System.EventHandler(this.RegistrationButtonClick);
            // 
            // newPasswordConfirmationTextBox
            // 
            this.newPasswordConfirmationTextBox.Location = new System.Drawing.Point(256, 258);
            this.newPasswordConfirmationTextBox.Name = "newPasswordConfirmationTextBox";
            this.newPasswordConfirmationTextBox.Size = new System.Drawing.Size(298, 19);
            this.newPasswordConfirmationTextBox.TabIndex = 80;
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Location = new System.Drawing.Point(256, 211);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.Size = new System.Drawing.Size(298, 19);
            this.newPasswordTextBox.TabIndex = 79;
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.Location = new System.Drawing.Point(256, 117);
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.Size = new System.Drawing.Size(298, 19);
            this.userIdTextBox.TabIndex = 78;
            // 
            // newPasswordConfirmationLabel
            // 
            this.newPasswordConfirmationLabel.AutoSize = true;
            this.newPasswordConfirmationLabel.Location = new System.Drawing.Point(137, 261);
            this.newPasswordConfirmationLabel.Name = "newPasswordConfirmationLabel";
            this.newPasswordConfirmationLabel.Size = new System.Drawing.Size(115, 12);
            this.newPasswordConfirmationLabel.TabIndex = 77;
            this.newPasswordConfirmationLabel.Text = "新しいパスワード(確認)";
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Location = new System.Drawing.Point(169, 214);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(83, 12);
            this.newPasswordLabel.TabIndex = 76;
            this.newPasswordLabel.Text = "新しいパスワード";
            // 
            // userIdLabel
            // 
            this.userIdLabel.AutoSize = true;
            this.userIdLabel.Location = new System.Drawing.Point(196, 120);
            this.userIdLabel.Name = "userIdLabel";
            this.userIdLabel.Size = new System.Drawing.Size(56, 12);
            this.userIdLabel.TabIndex = 75;
            this.userIdLabel.Text = "ユーザーID";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.titleLabel.Location = new System.Drawing.Point(327, 53);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(151, 24);
            this.titleLabel.TabIndex = 74;
            this.titleLabel.Text = "パスワード変更";
            // 
            // PasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.endingEffectiveDateTimePicker);
            this.Controls.Add(this.startEffectiveDateTimePicker);
            this.Controls.Add(this.effectiveDateLabel);
            this.Controls.Add(this.currentPasswordLabel);
            this.Controls.Add(this.currentPasswordTextBox);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.registrationButton);
            this.Controls.Add(this.newPasswordConfirmationTextBox);
            this.Controls.Add(this.newPasswordTextBox);
            this.Controls.Add(this.userIdTextBox);
            this.Controls.Add(this.newPasswordConfirmationLabel);
            this.Controls.Add(this.newPasswordLabel);
            this.Controls.Add(this.userIdLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "PasswordChange";
            this.Text = "PasswordChange";
            this.Load += new System.EventHandler(this.PasswordChangeLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker endingEffectiveDateTimePicker;
        private System.Windows.Forms.DateTimePicker startEffectiveDateTimePicker;
        private System.Windows.Forms.Label effectiveDateLabel;
        private System.Windows.Forms.Label currentPasswordLabel;
        private System.Windows.Forms.TextBox currentPasswordTextBox;
        private System.Windows.Forms.Button goBackButton;
        private System.Windows.Forms.Button registrationButton;
        private System.Windows.Forms.TextBox newPasswordConfirmationTextBox;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.Label newPasswordConfirmationLabel;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.Label userIdLabel;
        private System.Windows.Forms.Label titleLabel;
    }
}