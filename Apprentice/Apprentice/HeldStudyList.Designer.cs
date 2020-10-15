namespace Apprentice
{
    partial class HeldStudyList
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
            this.studyviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.study_dbDataSet = new Apprentice.Study_dbDataSet();
            this.titleLabel = new System.Windows.Forms.Label();
            this.study_viewTableAdapter = new Apprentice.Study_dbDataSetTableAdapters.Study_viewTableAdapter();
            this.goBackLinkLabel = new System.Windows.Forms.LinkLabel();
            this.heldStudyListDataGridView = new System.Windows.Forms.DataGridView();
            this.transferIntoStudyList = new System.Windows.Forms.Button();
            this.orderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studyStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scheduledOnDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientKanjiNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientKanaNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studyTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shotItemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.studyviewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.study_dbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heldStudyListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // studyviewBindingSource
            // 
            this.studyviewBindingSource.DataMember = "Study_view";
            this.studyviewBindingSource.DataSource = this.study_dbDataSet;
            // 
            // study_dbDataSet
            // 
            this.study_dbDataSet.DataSetName = "Study_dbDataSet";
            this.study_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.titleLabel.Location = new System.Drawing.Point(347, 31);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(187, 29);
            this.titleLabel.TabIndex = 53;
            this.titleLabel.Text = "保留検査一覧";
            // 
            // study_viewTableAdapter
            // 
            this.study_viewTableAdapter.ClearBeforeFill = true;
            // 
            // goBackLinkLabel
            // 
            this.goBackLinkLabel.AutoSize = true;
            this.goBackLinkLabel.Location = new System.Drawing.Point(802, 429);
            this.goBackLinkLabel.Name = "goBackLinkLabel";
            this.goBackLinkLabel.Size = new System.Drawing.Size(26, 12);
            this.goBackLinkLabel.TabIndex = 106;
            this.goBackLinkLabel.TabStop = true;
            this.goBackLinkLabel.Text = "戻る";
            this.goBackLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GoBackLinkLabel_LinkClicked);
            // 
            // heldStudyListDataGridView
            // 
            this.heldStudyListDataGridView.AutoGenerateColumns = false;
            this.heldStudyListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.heldStudyListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNumberDataGridViewTextBoxColumn,
            this.studyStatusDataGridViewTextBoxColumn,
            this.scheduledOnDataGridViewTextBoxColumn,
            this.patientIdDataGridViewTextBoxColumn,
            this.patientKanjiNameDataGridViewTextBoxColumn,
            this.patientKanaNameDataGridViewTextBoxColumn,
            this.studyTypeNameDataGridViewTextBoxColumn,
            this.shotItemNameDataGridViewTextBoxColumn});
            this.heldStudyListDataGridView.DataSource = this.studyviewBindingSource;
            this.heldStudyListDataGridView.Location = new System.Drawing.Point(25, 94);
            this.heldStudyListDataGridView.MultiSelect = false;
            this.heldStudyListDataGridView.Name = "heldStudyListDataGridView";
            this.heldStudyListDataGridView.RowHeadersVisible = false;
            this.heldStudyListDataGridView.RowTemplate.Height = 21;
            this.heldStudyListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.heldStudyListDataGridView.Size = new System.Drawing.Size(803, 321);
            this.heldStudyListDataGridView.TabIndex = 52;
            // 
            // transferIntoStudyList
            // 
            this.transferIntoStudyList.Location = new System.Drawing.Point(704, 41);
            this.transferIntoStudyList.Name = "transferIntoStudyList";
            this.transferIntoStudyList.Size = new System.Drawing.Size(113, 23);
            this.transferIntoStudyList.TabIndex = 107;
            this.transferIntoStudyList.Text = "検査一覧へ戻す";
            this.transferIntoStudyList.UseVisualStyleBackColor = true;
            this.transferIntoStudyList.Click += new System.EventHandler(this.TransferIntoStudyList_Click);
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
            this.scheduledOnDataGridViewTextBoxColumn.HeaderText = "予約日";
            this.scheduledOnDataGridViewTextBoxColumn.Name = "scheduledOnDataGridViewTextBoxColumn";
            // 
            // patientIdDataGridViewTextBoxColumn
            // 
            this.patientIdDataGridViewTextBoxColumn.DataPropertyName = "PatientId";
            this.patientIdDataGridViewTextBoxColumn.HeaderText = "患者ID";
            this.patientIdDataGridViewTextBoxColumn.Name = "patientIdDataGridViewTextBoxColumn";
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
            // HeldStudyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 450);
            this.Controls.Add(this.transferIntoStudyList);
            this.Controls.Add(this.goBackLinkLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.heldStudyListDataGridView);
            this.Name = "HeldStudyList";
            this.Text = "HoldStudy";
            this.Load += new System.EventHandler(this.HeldStudyList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studyviewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.study_dbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heldStudyListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label titleLabel;
        private Study_dbDataSet study_dbDataSet;
        private System.Windows.Forms.BindingSource studyviewBindingSource;
        private Study_dbDataSetTableAdapters.Study_viewTableAdapter study_viewTableAdapter;
        private System.Windows.Forms.LinkLabel goBackLinkLabel;
        private System.Windows.Forms.DataGridView heldStudyListDataGridView;
        private System.Windows.Forms.Button transferIntoStudyList;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studyStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scheduledOnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientKanjiNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientKanaNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn studyTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shotItemNameDataGridViewTextBoxColumn;
    }
}