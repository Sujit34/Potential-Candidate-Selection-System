using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace Project_v._2
{
    public partial class HR_Login : Form
    {
        public HR_Login()
        {
            InitializeComponent();
        }

        private void admin_loginbutton_Click(object sender, EventArgs e)
        {
            if (hr_id.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hr_id.Focus();
                return;
            }
            if (pass_word.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pass_word.Focus();
                return;
            }

            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";

                MySqlConnection MyConn = new MySqlConnection(myConnection);
                string Query = "select username,password from test.hrinfo where username = ?username and password = ?pass";
                MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                MyConn.Open();
                cmd.CommandText = Query;
                string username = hr_id.Text;
                string pass = pass_word.Text;
                cmd.Parameters.AddWithValue("?username", username);
                cmd.Parameters.AddWithValue("?pass", pass);

                MySqlDataReader MyReader;
                MyReader = cmd.ExecuteReader();
                if (MyReader.Read() == true)
                {
                    this.Hide();
                    Choose_Field_HR cHRarena = new Choose_Field_HR();
                    cHRarena.Show();

                }

                else
                {
                    MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    
                    hr_id.Clear();
                    pass_word.Clear();
                    hr_id.Focus();

                }
                MyConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            /*this.Hide();
            Choose_Field_HR cHRarena = new Choose_Field_HR();
            cHRarena.Show();*/

        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.Show();
        }

        private void sign_Click(object sender, EventArgs e)
        {

            this.Hide();
            HR_Detail hrdetail = new HR_Detail();
            hrdetail.Show();

        }
    }
}
