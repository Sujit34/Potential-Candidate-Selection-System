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
    public partial class Sign_Up : Form
    {
        public Sign_Up()
        {
            InitializeComponent();
        }

        private void previous_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Login admin = new Admin_Login();
            admin.Show();
        }

        private void submit_Click(object sender, EventArgs e)
        {


            try
            {


                string myConnection = "datasource=localhost;port=3306;username=root;password=root";

                                     
                string Query = "insert into test.admininfo(admin_id,name,username,password,email) values(?id,?name,?username,?password,?email);";



                MySqlConnection MyConn = new MySqlConnection(myConnection);
 
                MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                MyConn.Open();

                int id = Convert.ToInt32(Employee_id.Text);
                string name = sign_name.Text;
                string username = User.Text;
                string password = pass_word.Text;
                string email=Emailid.Text;


                cmd.Parameters.AddWithValue("?id", id);
                cmd.Parameters.AddWithValue("?name", name);
                cmd.Parameters.AddWithValue("?username", username);
                cmd.Parameters.AddWithValue("?password", password);
                cmd.Parameters.AddWithValue("?email", email);
                


                cmd.ExecuteNonQuery();
                MessageBox.Show("Info. Saved");
                MyConn.Close(); 

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
