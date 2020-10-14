﻿namespace Apprentice
{
    partial class UserRegistration
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.fromToLabel = new System.Windows.Forms.Label();
            this.endingEffectiveDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cancellButton = new System.Windows.Forms.Button();
            this.registrationButton = new System.Windows.Forms.Button();
            this.startEffectiveDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.effectiveDateLabel = new System.Windows.Forms.Label();
            this.passwordConfirmationTextBox = new System.Windows.Forms.TextBox();
            this.passwordConfirmationLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userIdTextBox = new System.Windows.Forms.TextBox();
            this.userIdLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.titleLabel.Location = new System.Drawing.Point(315, 59);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(186, 24);
            this.titleLabel.TabIndex = 73;
            this.titleLabel.Text = "新規ユーザー登録";
            // 
            // fromToLabel
            // 
            this.fromToLabel.AutoSize = true;
            this.fromToLabel.Location = new System.Drawing.Point(409, 295);
            this.fromToLabel.Name = "fromToLabel";
            this.fromToLabel.Size = new System.Drawing.Size(17, 12);
            this.fromToLabel.TabIndex = 72;
            this.fromToLabel.Text = "～";
            // 
            // endingEffectiveDateTimePicker
            // 
            this.endingEffectiveDateTimePicker.Location = new System.Drawing.Point(443, 292);
            this.endingEffectiveDateTimePicker.Name = "endingEffectiveDateTimePicker";
            this.endingEffectiveDateTimePicker.Size = new System.Drawing.Size(111, 19);
            this.endingEffectiveDateTimePicker.TabIndex = 71;
            this.endingEffectiveDateTimePicker.ValueChanged += new System.EventHandler(this.EndingEffectiveDateTimePickerValueChanged);
            // 
            // cancellButton
            // 
            this.cancellButton.Location = new System.Drawing.Point(443, 362);
            this.cancellButton.Name = "cancellButton";
            this.cancellButton.Size = new System.Drawing.Size(75, 23);
            this.cancellButton.TabIndex = 70;
            this.cancellButton.Text = "キャンセル";
            this.cancellButton.UseVisualStyleBackColor = true;
            this.cancellButton.Click += new System.EventHandler(this.CancellButtonClick);
            // 
            // registrationButton
            // 
            this.registrationButton.Location = new System.Drawing.Point(317, 362);
            this.registrationButton.Name = "registrationButton";
            this.registrationButton.Size = new System.Drawing.Size(75, 23);
            this.registrationButton.TabIndex = 69;
            this.registrationButton.Text = "登録";
            this.registrationButton.UseVisualStyleBackColor = true;
            this.registrationButton.Click += new System.EventHandler(this.RegistrationButtonClick);
            // 
            // startEffectiveDateTimePicker
            // 
            this.startEffectiveDateTimePicker.Location = new System.Drawing.Point(281, 292);
            this.startEffectiveDateTimePicker.Name = "startEffectiveDateTimePicker";
            this.startEffectiveDateTimePicker.Size = new System.Drawing.Size(111, 19);
            this.startEffectiveDateTimePicker.TabIndex = 68;
            this.startEffectiveDateTimePicker.ValueChanged += new System.EventHandler(this.StartEffectiveDateTimePickerValueChanged);
            // 
            // effectiveDateLabel
            // 
            this.effectiveDateLabel.AutoSize = true;
            this.effectiveDateLabel.Location = new System.Drawing.Point(222, 295);
            this.effectiveDateLabel.Name = "effectiveDateLabel";
            this.effectiveDateLabel.Size = new System.Drawing.Size(53, 12);
            this.effectiveDateLabel.TabIndex = 67;
            this.effectiveDateLabel.Text = "有効期限";
            // 
            // passwordConfirmationTextBox
            // 
            this.passwordConfirmationTextBox.Location = new System.Drawing.Point(281, 247);
            this.passwordConfirmationTextBox.Name = "passwordConfirmationTextBox";
            this.passwordConfirmationTextBox.Size = new System.Drawing.Size(273, 19);
            this.passwordConfirmationTextBox.TabIndex = 66;
            this.passwordConfirmationTextBox.UseSystemPasswordChar = true;
            // 
            // passwordConfirmationLabel
            // 
            this.passwordConfirmationLabel.AutoSize = true;
            this.passwordConfirmationLabel.Location = new System.Drawing.Point(191, 250);
            this.passwordConfirmationLabel.Name = "passwordConfirmationLabel";
            this.passwordConfirmationLabel.Size = new System.Drawing.Size(84, 12);
            this.passwordConfirmationLabel.TabIndex = 65;
            this.passwordConfirmationLabel.Text = "パスワード(確認)";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(281, 202);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(273, 19);
            this.passwordTextBox.TabIndex = 64;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(223, 205);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(52, 12);
            this.passwordLabel.TabIndex = 63;
            this.passwordLabel.Text = "パスワード";
            // 
            // userIdTextBox
            // 
            this.userIdTextBox.Location = new System.Drawing.Point(281, 157);
            this.userIdTextBox.Name = "userIdTextBox";
            this.userIdTextBox.Size = new System.Drawing.Size(273, 19);
            this.userIdTextBox.TabIndex = 62;
            // 
            // userIdLabel
            // 
            this.userIdLabel.AutoSize = true;
            this.userIdLabel.Location = new System.Drawing.Point(219, 160);
            this.userIdLabel.Name = "userIdLabel";
            this.userIdLabel.Size = new System.Drawing.Size(56, 12);
            this.userIdLabel.TabIndex = 61;
            this.userIdLabel.Text = "ユーザーID";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(281, 112);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(273, 19);
            this.userNameTextBox.TabIndex = 60;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(218, 115);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(57, 12);
            this.userNameLabel.TabIndex = 59;
            this.userNameLabel.Text = "ユーザー名";
            // 
            // UserRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.fromToLabel);
            this.Controls.Add(this.endingEffectiveDateTimePicker);
            this.Controls.Add(this.cancellButton);
            this.Controls.Add(this.registrationButton);
            this.Controls.Add(this.startEffectiveDateTimePicker);
            this.Controls.Add(this.effectiveDateLabel);
            this.Controls.Add(this.passwordConfirmationTextBox);
            this.Controls.Add(this.passwordConfirmationLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userIdTextBox);
            this.Controls.Add(this.userIdLabel);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.userNameLabel);
            this.Name = "UserRegistration";
            this.Text = "UserRegistration";
            this.Load += new System.EventHandler(this.UserRegistrationLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label fromToLabel;
        private System.Windows.Forms.DateTimePicker endingEffectiveDateTimePicker;
        private System.Windows.Forms.Button cancellButton;
        private System.Windows.Forms.Button registrationButton;
        private System.Windows.Forms.DateTimePicker startEffectiveDateTimePicker;
        private System.Windows.Forms.Label effectiveDateLabel;
        private System.Windows.Forms.TextBox passwordConfirmationTextBox;
        private System.Windows.Forms.Label passwordConfirmationLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox userIdTextBox;
        private System.Windows.Forms.Label userIdLabel;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label userNameLabel;
    }
}