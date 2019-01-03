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
    public partial class Admin_Login : Form
    {
        public Admin_Login()
        {
            InitializeComponent();
        }

        //go home using home button
        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.Show();
        }

        // sign up using sign up button
        private void signup_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sign_Up sign = new Sign_Up();
            sign.Show();
        }

        //login using loging button
        private void admin_loginbutton_Click(object sender, EventArgs e)
        {
            if (adminid.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please Enter User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                adminid.Focus();
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
                string Query = "select username,password from test.admininfo where username = ?username and password = ?pass";
                MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                MyConn.Open();       
                cmd.CommandText =Query;
                string username = adminid.Text;
                string pass = pass_word.Text;
                cmd.Parameters.AddWithValue("?username", username);
                cmd.Parameters.AddWithValue("?pass", pass);

                MySqlDataReader MyReader;                
                MyReader = cmd.ExecuteReader();
                if (MyReader.Read() == true)
                {
                    this.Hide();
                    Choose_Field_Admin choosearena = new Choose_Field_Admin();
                    choosearena.Show();
                }

                else
                {
                    MessageBox.Show("Login is Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    adminid.Clear();
                    pass_word.Clear();
                    adminid.Focus();

                }
                MyConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


           /* this.Hide();
            Choose_Field_Admin choosearena = new Choose_Field_Admin();
            choosearena.Show();*/
        }
    }
}
