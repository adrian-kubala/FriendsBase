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

            friendsGridView.DataSource = executor.Select(Properties.Resources.selectFriends);
        }
    }
}
