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
    public partial class Add_Requirement : Form
    {
        public Add_Requirement()
        {
            InitializeComponent();
        }

        //go admin arena using previous button
        private void previous_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_arenacs admin_arena = new Admin_arenacs();
            admin_arena.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {


                string myConnection = "datasource=localhost;port=3306;username=root;password=root";


                string Query = "insert into test.jobdetails(job_id,post,salary,place,qualification,experience,language,framework) values(?id,?post,?salary,?place,?qualification,?experience,?language,?framework);";



                MySqlConnection MyConn = new MySqlConnection(myConnection);

                MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                MyConn.Open();

                int id=Convert.ToInt32(textBox1.Text);
                string  post=textBox2.Text;
                string salary=textBox3.Text;
                string place = textBox4.Text;
                string qualification=textBox5.Text;
                string experience=textBox6.Text;
                string language=textBox7.Text;
                string framework=textBox8.Text;



                cmd.Parameters.AddWithValue("?id", id);
                cmd.Parameters.AddWithValue("?post", post);
                cmd.Parameters.AddWithValue("?salary", salary);
                cmd.Parameters.AddWithValue("?place", place);
                cmd.Parameters.AddWithValue("?qualification", qualification);
                cmd.Parameters.AddWithValue("?experience", experience);
                cmd.Parameters.AddWithValue("?language", language);
                cmd.Parameters.AddWithValue("?framework", framework);


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
