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
    public partial class view_job : Form
    {
        public view_job()
        {
            InitializeComponent();
        }


        // show data through gridview
        private void show_job_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";
                //Display query  
                //string Query = "select * from test.hrinfo;";

                string Query = "select job_id as 'Job ID',post as 'Post',salary as 'Salary',place as 'Place',qualification as 'Qualification',experience as 'Experience',language as 'Language',framework as 'Framework' from test.jobdetails order by job_id";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand myCommand = new MySqlCommand(Query, myConn);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = myCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                // MyConn2.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //select by clicking cell
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cel = null;
            foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
            {
                cel = selectedCell;
                break;

            }
            if (cel != null) //find out row
            {

                DataGridViewRow row = cel.OwningRow;

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox7.Text = row.Cells[6].Value.ToString();
                textBox8.Text = row.Cells[7].Value.ToString();



            }
        }

        //update data
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string myConnection = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "update test.jobdetails set job_id='" + this.textBox1.Text + "',post='" + this.textBox2.Text + "',salary='" + this.textBox3.Text + "',place='" + this.textBox4.Text + "',qualification='" + this.textBox5.Text + "',experience='" + this.textBox6.Text + "',language='" + this.textBox7.Text + "',framework='" + this.textBox8.Text + "' where job_id='" + this.textBox1.Text + "';";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand myCommand = new MySqlCommand(Query, myConn);
                MySqlDataReader MyReader2;
                myConn.Open();
                MyReader2 = myCommand.ExecuteReader();
                MessageBox.Show("Data Updated");
                while (MyReader2.Read())
                {
                }
                myConn.Close();//Connection closed here  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            refresh2();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }


        //refresh data
        public void refresh2()
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";
                //Display query  
                //string Query = "select * from test.hrinfo;";

                string Query = "select job_id as 'Job ID',post as 'Post',salary as 'Salary',place as 'Place',qualification as 'Qualification',experience as 'Experience',language as 'Language',framework as 'Framework' from test.jobdetails order by job_id";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand myCommand = new MySqlCommand(Query, myConn);
                //  MyConn2.Open();  
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = myCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                // MyConn2.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_arenacs admin_arena = new Admin_arenacs();
            admin_arena.Show();
        }


        //delete data
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";
                string Query = "delete from test.jobdetails where job_id='" + this.textBox1.Text + "';";
                //string Query = "select hr_id as 'HR ID',name as 'Name',company_name as 'Company Name',contact_no as 'Contact No.',email as 'Email' from test.hrinfo order by hr_id";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand myCommand = new MySqlCommand(Query, myConn);
                MySqlDataReader MyReader2;
                myConn.Open();
                MyReader2 = myCommand.ExecuteReader();
                MessageBox.Show("Data Deleted");
                while (MyReader2.Read())
                {
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            refresh2();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();


        }





    }
}
