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
using MySql.Data.MySqlClient;

namespace Login_EDP
{
    public partial class frmLogin : Form
    {
        MyDatabase db = new MyDatabase();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (tbUsername.Text == "Admin" && tbPassword.Text == "1234")
            {
                MessageBox.Show("Login Success! Welcome Admin.");


                Form2 dashboard = new Form2();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.");
            }
        }



        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (db.TestConnection())
            {
                MessageBox.Show("Database Connected Successfully!");
            }
            else
            {
                MessageBox.Show("Failed to connect to Database. Check XAMPP.");

            }
        }
    }
}
