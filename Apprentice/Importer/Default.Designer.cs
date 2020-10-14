namespace Importer
{
    partial class Default
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusLabel = new System.Windows.Forms.Label();
            this.monitoredFolderTextBox = new System.Windows.Forms.TextBox();
            this.monitoredFolderLabel = new System.Windows.Forms.Label();
            this.importTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.statusLabel.Location = new System.Drawing.Point(259, 251);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(271, 24);
            this.statusLabel.TabIndex = 29;
            this.statusLabel.Text = "ファイルを取り込んでいます...";
            // 
            // monitoredFolderTextBox
            // 
            this.monitoredFolderTextBox.Location = new System.Drawing.Point(240, 191);
            this.monitoredFolderTextBox.Name = "monitoredFolderTextBox";
            this.monitoredFolderTextBox.ReadOnly = true;
            this.monitoredFolderTextBox.Size = new System.Drawing.Size(322, 19);
            this.monitoredFolderTextBox.TabIndex = 27;
            this.monitoredFolderTextBox.Text = "C:\\Program\\PG\\Monitored folder";
            // 
            // monitoredFolderLabel
            // 
            this.monitoredFolderLabel.AutoSize = true;
            this.monitoredFolderLabel.Location = new System.Drawing.Point(238, 176);
            this.monitoredFolderLabel.Name = "monitoredFolderLabel";
            this.monitoredFolderLabel.Size = new System.Drawing.Size(88, 12);
            this.monitoredFolderLabel.TabIndex = 28;
            this.monitoredFolderLabel.Text = "監視対象フォルダ";
            // 
            // importTimer
            // 
            this.importTimer.Tick += new System.EventHandler(this.ImportTimerTick);
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.monitoredFolderTextBox);
            this.Controls.Add(this.monitoredFolderLabel);
            this.Name = "Default";
            this.Text = "Default";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Default_FormClosing);
            this.Load += new System.EventHandler(this.DefaultLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox monitoredFolderTextBox;
        private System.Windows.Forms.Label monitoredFolderLabel;
        private System.Windows.Forms.Timer importTimer;
    }
}

