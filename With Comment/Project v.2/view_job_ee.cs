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
    public partial class view_job_ee : Form
    {
        public view_job_ee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_arena_ee adarenaee = new Admin_arena_ee();
            adarenaee.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        // show data
        private void show_job_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "select id as 'Job ID',post as 'Post',salary as 'Salary',place as 'Place',qualification as 'Qualification',experience as 'Experience',software as 'Software',embeddedsystem as 'Embedded_system',workingexp as 'Working Experience',basicknowledge as 'Basic_Knowledge' from test.jobdetailsee order by id";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand myCommand = new MySqlCommand(Query, myConn);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = myCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //update data
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string myConnection = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "update test.jobdetailsee set id='" + this.textBox1.Text + "',post='" + this.textBox2.Text + "',salary='" + this.textBox3.Text + "',place='" + this.textBox4.Text + "',qualification='" + this.textBox5.Text + "',experience='" + this.textBox6.Text + "',software='" + this.textBox7.Text + "',embeddedsystem='" + this.textBox8.Text + "',workingexp='" + this.textBox9.Text + "',basicknowledge='" + this.textBox10.Text + "' where id='" + this.textBox1.Text + "';";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand myCommand = new MySqlCommand(Query, myConn);
                MySqlDataReader MyReader2;
                myConn.Open();
                MyReader2 = myCommand.ExecuteReader();
                MessageBox.Show("Data Updated");
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
            textBox9.Clear();
            textBox10.Clear();
        }

        //delete data
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";
                string Query = "delete from test.jobdetailscivil where id='" + this.textBox1.Text + "';";
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
            textBox9.Clear();
            textBox10.Clear();
        }


        //refresh data
        public void refresh2()
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";

                string Query = "select id as 'Job ID',post as 'Post',salary as 'Salary',place as 'Place',qualification as 'Qualification',experience as 'Experience',software as 'Software',embeddedsystem as 'Embedded_system',workingexp as 'Working Experience',basicknowledge as 'Basic_Knowledge' from test.jobdetailsee order by id";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand myCommand = new MySqlCommand(Query, myConn);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = myCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;

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
                textBox9.Text = row.Cells[8].Value.ToString();
                textBox10.Text = row.Cells[9].Value.ToString();



            }
        }




    }
}
