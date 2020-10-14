using ClassLibrary;
using DatabaseManager;
using log4net;
using System;
using System.Windows.Forms;

namespace Apprentice
{
    public partial class HeldStudyList : Form
    {
        ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public HeldStudyList()
        {
            InitializeComponent();
        }

        private void HeldStudyList_Load(object sender, EventArgs e)
        {
            DisplayHeldStudylist();
        }

        private void DisplayHeldStudylist()
        {
            studyviewBindingSource.DataSource = DbManager.DisplayHeldStudyList();
        }

        private void TransferIntoStudyList_Click(object sender, EventArgs e)
        {
            if (heldStudyListDataGridView.SelectedRows.Count != 0)
            {
                WorkItem item = heldStudyListDataGridView.CurrentRow.DataBoundItem as WorkItem;
                DbManager.TransferIntoStudyList(item.OrderNumber);

                logger.Info("オーダー番号 " + item.OrderNumber + "の検査をワークリストに戻しました。");

                DisplayHeldStudylist();
            }
        }

        private void GoBackLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
