using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_EDP
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string[,] users = {
                {"admin", "1234", "Admin"},
                {"john", "1111", "John"},
            };

            if (tbUsername.Text == "")
            {
                MessageBox.Show("Enter username");
                return;
            }

            if (tbPassword.Text == "")
            {
                MessageBox.Show("Enter password");
                return;
            }

            for (int i = 0; i < users.GetLength(0); i++)
            {
                if (tbUsername.Text == users[i, 0] &&
                    tbPassword.Text == users[i, 1])
                {
                    MessageBox.Show("Welcome " + users[i, 2]);

                    Form2 home = new Form2();
                    home.userName = users[i, 2];

                    this.Hide();
                    home.Show();
                    break;
                }
                else
                {
                    MessageBox.Show("Invalid Username/Password");           
                }
            }
        }
    }
}
