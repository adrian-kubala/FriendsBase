using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FriendsBase
{
    public partial class MainForm : Form
    {
        private SqlExecutor executor = new SqlExecutor();


        public MainForm()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            friendsGridView.DataSource = executor.Select(Properties.Resources.selectFriends);
        }

        private void friendsGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            executor.id = Convert.ToInt32(friendsGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            nameTextBox.Text = friendsGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            lastNameTextBox.Text = friendsGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
