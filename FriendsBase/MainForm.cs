using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text != "" && lastNameTextBox.Text != "")
            {
                executor.InsertFriend(nameTextBox.Text, lastNameTextBox.Text);

                MessageBox.Show("Wprowadzanie powiodło się.");
                RefreshData();
            }
            else
            {
                MessageBox.Show("Proszę wprowadzić wszystkie dane!");
            }
        }

        private void ClearData()
        {
            nameTextBox.Text = "";
            lastNameTextBox.Text = "";
            executor.id = 0;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (TextBoxesAreNotEmpty())
            {
                executor.UpdateFriend(nameTextBox.Text, lastNameTextBox.Text);

                MessageBox.Show("Aktualizacja wpisu powiodła się.");
                RefreshData();
            }
            else
            {
                MessageBox.Show("Proszę wybrać rekord w celu jego aktualizacji");
            }
        }

        private void RefreshData()
        {
            DisplayData();
            ClearData();
        }

        private bool TextBoxesAreNotEmpty()
        {
            return nameTextBox.Text != "" && lastNameTextBox.Text != "";
        }
    }
}
