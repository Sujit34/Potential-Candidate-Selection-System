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
    public partial class HR_Detail : Form
    {
        public HR_Detail()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HR_Login Hr_login = new HR_Login();
            Hr_login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                string myConnection = "datasource=localhost;port=3306;username=root;password=root";


                string Query = "insert into test.hrinfo(hr_id,name,username,password,company_name,contact_no,email) values(?id,?name,?username,?password,?company,?contact,?email);";



                MySqlConnection MyConn = new MySqlConnection(myConnection);

                MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                MyConn.Open();

                int id = Convert.ToInt32(textBox1.Text);
                string name = textBox2.Text;
                string username = textBox5.Text;
                string password = textBox7.Text;
                string company_name = textBox6.Text;
                string contact_no=textBox3.Text;
                string email = textBox4.Text;


                cmd.Parameters.AddWithValue("?id", id);
                cmd.Parameters.AddWithValue("?name", name);
                cmd.Parameters.AddWithValue("?username", username);
                cmd.Parameters.AddWithValue("?password", password);
                cmd.Parameters.AddWithValue("?company", company_name);
                cmd.Parameters.AddWithValue("?contact", contact_no);
                cmd.Parameters.AddWithValue("?email", email);



                cmd.ExecuteNonQuery();
                MessageBox.Show("Info. Saved");
                MyConn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
