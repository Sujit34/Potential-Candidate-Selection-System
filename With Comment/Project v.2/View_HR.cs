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
    public partial class View_HR : Form
    {
        public View_HR()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_arenacs admin_arena = new Admin_arenacs();
            admin_arena.Show();
        }

        //show data in gridview
        private void Show_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";
                //Display query  
                //string Query = "select * from test.hrinfo;";
                           
                string Query = "select hr_id as 'HR ID',name as 'Name',company_name as 'Company Name',contact_no as 'Contact No.',email as 'Email' from test.hrinfo order by hr_id";
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

        //update data

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                string myConnection = "datasource=localhost;port=3306;username=root;password=root";
                
                string Query = "update test.hrinfo set name='" + this.textBox2.Text + "',company_name='" + this.textBox5.Text + "',contact_no='" + this.textBox6.Text + "',email='" + this.textBox7.Text + "' where hr_id='" + this.textBox1.Text + "';";
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

            refresh();


            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();


        }

        private void View_HR_Load(object sender, EventArgs e)
        {

        }

        //fetch data in textbox clicking in datagridview cells
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
                textBox5.Text = row.Cells[2].Value.ToString();
                textBox6.Text = row.Cells[3].Value.ToString();
                textBox7.Text = row.Cells[4].Value.ToString();
                
                

            }
        }


        public void refresh()
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";
                //Display query  
                //string Query = "select * from test.hrinfo;";

                string Query = "select hr_id as 'HR ID',name as 'Name',company_name as 'Company Name',contact_no as 'Contact No.',email as 'Email' from test.hrinfo order by hr_id";
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


        // delete data
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";
                string Query = "delete from test.hrinfo where hr_id='" + this.textBox1.Text + "';";
                //string Query = "select hr_id as 'HR ID',name as 'Name',company_name as 'Company Name',contact_no as 'Contact No.',email as 'Email' from test.hrinfo order by hr_id";
                MySqlConnection myConn= new MySqlConnection(myConnection);
                MySqlCommand myCommand = new MySqlCommand(Query,myConn);
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
            refresh();

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}
