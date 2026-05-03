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
    public partial class frmUser : Form
    {
        MyDatabase db = new MyDatabase();
        public frmUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {

                string sql = "INSERT INTO tbl_registration (firstname, middlename, lastname, email, address, birthdate, username, password) " +
                             "VALUES (@fn, @mn, @ln, @em, @addr, @bd, @un, @pw)";


                string fullBirthdate = cbYear.Text + "-" + GetMonthNumber(cbMonth.Text) + "-" + cbDay.Text;

                MySqlParameter[] parameters = {
            new MySqlParameter("@fn",   tbFirstName.Text),
            new MySqlParameter("@mn",   tbMiddleName.Text),
            new MySqlParameter("@ln",   tbLastName.Text),
            new MySqlParameter("@em",   tbEmail.Text),
            new MySqlParameter("@addr", tbAddress.Text),
            new MySqlParameter("@bd",   fullBirthdate), 
            new MySqlParameter("@un",   tbUsernameReg.Text),
            new MySqlParameter("@pw",   tbPasswordReg.Text)
        };

                if (db.ExecuteNonQuery(sql, parameters))
                {
                    MessageBox.Show("Registration Successful!");
                    LoadUserData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private string GetMonthNumber(string monthName)
        {
            switch (monthName)
            {
                case "January": return "01";
                case "February": return "02";
                case "March": return "03";
                case "April": return "04";
                case "May": return "05";
                case "June": return "06";
                case "July": return "07";
                case "August": return "08";
                case "September": return "09";
                case "October": return "10";
                case "November": return "11";
                case "December": return "12";
                default: return "01";
            }
        }


        private void ClearFields()
        {
            tbUsernameReg.Clear();
            tbPasswordReg.Clear();
            cbMonth.SelectedIndex = -1;
            cbDay.SelectedIndex = -1;
            cbYear.SelectedIndex = -1;
        }
        public void LoadUserData()
        {
            try
            {

                string sql = "SELECT regID, firstname, middlename, lastname, email, address, birthdate, username FROM tbl_registration";

                DataTable dt = db.ExecuteReturnQuery(sql, null);
                dgvUser.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            MyDatabase db = new MyDatabase();


            string[] months = { "January", "February", "March", "April", "May", "June",
                        "July", "August", "September", "October", "November", "December" };
            cbMonth.Items.AddRange(months);

            for (int i = 1; i <= 31; i++)
            {
                cbDay.Items.Add(i.ToString());
            }


            for (int i = 2026; i >= 1950; i--)
            {
                cbYear.Items.Add(i.ToString());
            }
        }
    }
}

