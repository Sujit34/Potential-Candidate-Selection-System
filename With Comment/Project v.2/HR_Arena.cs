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

    public partial class HR_Arena : Form
    {
        List<Object> elments_of_Universe = new List<Object>();
        List<string> skill = new List<string>();
        List<string> fuzzy_skill = new List<string>();
        List<skillneeded> priority = new List<skillneeded>();

        public int java = 0, c = 0, cplus = 0, csharp = 0, html = 0, php = 0, css = 0, javascript = 0, laravel = 0, aspdotnet = 0, dotnet = 0;
        public string language;
        public string framework;
        public int a;
        public int sum;
        public string getreduct;
        public string getreduct1;
        public string getcore;
        public string getindispensible;
        public string getdispensible;
        public int length;
        public int fcmcolumncount = 0, fcmrowcount = 0;
        public double rcc1;//random cluster center1
        public double rcc2;//random cluster center2
        public double rcc3;//random cluster center3
        public double m;//
        public string requirelanguage;
        public string requireframework;
        double[] cv = new double[500];
        int[] id = new int[500];
        int[,] showrank = new int[500, 2];
        int[,] dep_exp = new int[500, 2];
        double[,] support_val = new double[500, 15];
        public int darrlen;
        public string textbox;
        int[,] original = new int[500, 15];
        int lengthmem1,experience,department;
        string department1;
        string experience1;
        int showrankupto;

        public HR_Arena()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HR_Login HRlogout = new HR_Login();
            HRlogout.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Upload_CV upcv = new Upload_CV();
            upcv.Show();





        }





        private void search_job_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";

                textbox = this.textBox1.Text;
                string Query = "select job_id as 'Job ID',post as 'Post',salary as 'Salary',place as 'Place',qualification as 'Qualification',experience as 'Experience',language as 'Language',framework as 'Framework' from test.jobdetails where job_id='" + this.textBox1.Text + "' ";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand myCommand = new MySqlCommand(Query, myConn);
                //For offline connection we weill use  MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = myCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.     
                requirelanguage = dTable.Rows[0][6].ToString();
                requireframework = dTable.Rows[0][7].ToString();
                department1 = dTable.Rows[0][4].ToString();
                experience1 = dTable.Rows[0][5].ToString();
               // MessageBox.Show(department1);
                //MessageBox.Show(experience1);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter Job ID");
            }
        }

        //select priority
        private void button4_Click(object sender, EventArgs e)
        {

            if (comboBox2.Text == "C")
            {
                c = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneeded() { lanfrm = "c", priorityvalue = c });
            }
            if (comboBox2.Text == "C++")
            {
                cplus = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneeded() { lanfrm = "cplus", priorityvalue = cplus });

            }
            if (comboBox2.Text == "C#")
            {
                csharp = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneeded() { lanfrm = "csharp", priorityvalue = csharp });
            }
            if (comboBox2.Text == "JAVA")
            {
                java = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneeded() { lanfrm = "java", priorityvalue = java });
            }
            if (comboBox2.Text == "PHP")
            {
                php = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneeded() { lanfrm = "php", priorityvalue = php });
            }
            if (comboBox2.Text == "HTML")
            {
                html = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneeded() { lanfrm = "html", priorityvalue = html });
            }
            if (comboBox2.Text == "CSS")
            {
                css = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneeded() { lanfrm = "css", priorityvalue = css });
            }
            if (comboBox2.Text == "JAVASCRIPT")
            {
                javascript = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneeded() { lanfrm = "javascript", priorityvalue = javascript });
            }
            if (comboBox2.Text == "LARAVEL")
            {
                laravel = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneeded() { lanfrm = "laravel", priorityvalue = laravel });
            }
            if (comboBox2.Text == "ASP.NET")
            {
                aspdotnet = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneeded() { lanfrm = "aspdotnet", priorityvalue = aspdotnet });
            }
            if (comboBox2.Text == ".NET")
            {
                dotnet = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneeded() { lanfrm = "dotent", priorityvalue = dotnet });
            }
        }



        //datagrid clicking( not necessary for this form)
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

                //department1=row.Cells[4].Value.ToString();
                /*if(department1=="BSC in CSE")
                {
                    department = 1;
                }
                else
                {
                    department=0;
                }*/


              /*  experience1 = row.Cells[5].Value.ToString();
                if (experience1 == "Fresher" || experience1 == "fresher")
                {
                    experience = 0;
                }
                else
                {
                    experience = Convert.ToInt32(row.Cells[5].Value.ToString());
                }*/
               

            }
        }

        private void scan_Click(object sender, EventArgs e)
        {

            if (comboBox3.Text == "Top 5")
            {
                showrankupto = 5;
            }
            if (comboBox3.Text == "Top 10")
            {
                showrankupto = 10;
            }
            if (comboBox3.Text == "Top 15")
            {
                showrankupto = 15;
            }
            if (comboBox3.Text == "Top 20")
            {
                showrankupto = 20;
            }
            if (comboBox3.Text == "Top 25")
            {
                showrankupto = 25;
            }
            if (comboBox3.Text == "Top 30")
            {
                showrankupto = 30;
            }




            //original data
            string myConnection0 = "datasource=localhost;port=3306;username=root;password=root";
            string Query0 = "select id as 'ID',c as 'C',cplus as 'Cplus',csharp as 'CSharp', php as 'PHP',java as 'Java',html as'Html',css as 'Css',javascript as 'Javascript',laravel as'Laravel',aspdotnet as'AspdotNet',dotnet as 'Dotnet' from test.skill";
            MySqlConnection myConn0 = new MySqlConnection(myConnection0);
            MySqlCommand myCommand0 = new MySqlCommand(Query0, myConn0);
            //For offline connection we weill use  MySqlDataAdapter class.  
            MySqlDataAdapter MyAdapter0 = new MySqlDataAdapter();
            MyAdapter0.SelectCommand = myCommand0;
            DataTable dTable0 = new DataTable();
            /* dTable.Columns.Add("decission", typeof(System.Int32));*/
            MyAdapter0.Fill(dTable0);
            for (int ar = 0; ar < dTable0.Rows.Count; ar++)
            {
                for (int ac = 1; ac <= 11; ac++)
                {
                    string val = dTable0.Rows[ar][ac].ToString();
                    original[ar, ac - 1] = Convert.ToInt32(val);

                }


            }





            string myConnection = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "select id as 'ID',c as 'C',cplus as 'Cplus',csharp as 'CSharp', php as 'PHP',java as 'Java',html as'Html',css as 'Css',javascript as 'Javascript',laravel as'Laravel',aspdotnet as'AspdotNet',dotnet as 'Dotnet' from test.skill";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(Query, myConn);
            //For offline connection we weill use  MySqlDataAdapter class.  
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = myCommand;
            DataTable dTable = new DataTable();
            /* dTable.Columns.Add("decission", typeof(System.Int32));*/
            MyAdapter.Fill(dTable);
            for (int a = 0; a < dTable.Rows.Count; a++)
            {
                string ids = dTable.Rows[a][0].ToString();
                id[a] = Convert.ToInt32(ids);
            }


            //decission attribute
            /* for (int i = 0; i < dTable.Rows.Count; i++)
             {

               /*  sum = 0;
                 if (int.Parse(dTable.Rows[i][2].ToString()) == 1)
                 {
                     sum = sum + c;
                 }
                 if (int.Parse(dTable.Rows[i][3].ToString()) == 1)
                 {
                     sum = sum + cplus;
                 }
                 if (int.Parse(dTable.Rows[i][4].ToString()) == 1)
                 {
                     sum = sum + csharp;
                 }
                 if (int.Parse(dTable.Rows[i][5].ToString()) == 1)
                 {
                     sum = sum + php;
                 }
                 if (int.Parse(dTable.Rows[i][6].ToString()) == 1)
                 {
                     sum = sum + java;
                 }
                 if (int.Parse(dTable.Rows[i][7].ToString()) == 1)
                 {
                     sum = sum + html;
                 }
                 if (int.Parse(dTable.Rows[i][8].ToString()) == 1)
                 {
                     sum = sum + css;
                 }
                 if (int.Parse(dTable.Rows[i][9].ToString()) == 1)
                 {
                     sum = sum + javascript;
                 }
                 if (int.Parse(dTable.Rows[i][10].ToString()) == 1)
                 {
                     sum = sum + laravel;
                 }
                 if (int.Parse(dTable.Rows[i][11].ToString()) == 1)
                 {
                     sum = sum + aspdotnet;
                 }
                 if (int.Parse(dTable.Rows[i][12].ToString()) == 1)
                 {
                     sum = sum + dotnet;
                 }
                // MessageBox.Show(sum.ToString());
                 //dTable.Rows[i][0] = sum;
             }*/

            //MyAdapter.Fill(dTable);
            //dataGridView2.DataSource = dTable; 

            //datatable to array convert
            int rowcount = dTable.Rows.Count;
            int columncount = dTable.Columns.Count;

            object[,] arr = new object[rowcount, columncount];

            for (int i = 0; i < rowcount; i++)
            {
                for (int j = 1; j < columncount; j++)
                {
                    arr[i, j] = dTable.Rows[i][j];
                }
            }





            skill.Add("c");
            skill.Add("cplus");
            skill.Add("csharp");
            skill.Add("php");
            skill.Add("java");
            skill.Add("html");
            skill.Add("css");
            skill.Add("javascript");
            skill.Add("laravel");
            skill.Add("aspdotnet");
            skill.Add("dotnet");

            //insert into list
            int index = 0;
            for (int i = 0; i < rowcount; i++)
            {
                List<Attribute> attr_values = new List<Attribute>();

                for (int j = 1; j < columncount; j++)
                {
                    Attribute x = new Attribute(skill[j - 1], arr[i, j]);
                    attr_values.Add(x);
                }
                index++;
                Object xx = new Object(index, attr_values);
                elments_of_Universe.Add(xx);
            }





            //dispensable print
            RoughSet RouObj = new RoughSet(elments_of_Universe);
            List<object> Dispen = RouObj.Dispensable();
            if (Dispen.Count == 0)
            {
                //MessageBox.Show("-----");//no dispensable
            }


            else
            {
                for (int i = 0; i < Dispen.Count; i++)
                {
                    if (i == Dispen.Count - 1)
                        getdispensible += Dispen[i].ToString();//dispensable(last er ta coma cara)
                    else
                        getdispensible += Dispen[i].ToString() + ",";//dispensable(first er gula coma soho)

                }
                //MessageBox.Show(getdispensible.ToString());
            }




            //indispensable & core

            List<object> Indispen = RouObj.Indispensable();
            if (Indispen.Count == 0)
            {
                //  MessageBox.Show("-----");// no indespensable
                // MessageBox.Show("-----");//no core

            }
            else
            {
                for (int i = 0; i < Indispen.Count; i++)
                {
                    if (i == Indispen.Count - 1)
                    {

                        getindispensible += Indispen[i].ToString();// indespensable(last er ta coma cara)
                        getcore += Indispen[i].ToString();//core(last er ta coma cara)

                    }
                    else
                    {

                        getindispensible += Indispen[i].ToString() + ",";// indespensable(first er gula coma soho)
                        getcore += Indispen[i].ToString() + ",";//core(first er gula coma soho)


                    }
                }
                //  MessageBox.Show(getindispensible.ToString());
               // MessageBox.Show(getcore.ToString());

            }


            //reduct print

            List<object> Reducts = RouObj.Reducts();
            if (Reducts.Count == 0)
            {
                //MessageBox.Show("-----");//no reduct
            }



            else
            {
                for (int i = 0; i < Reducts.Count; i++)
                {
                    if (i == Reducts.Count - 1)
                    {
                        getreduct += Reducts[i].ToString();//reduct (coma cara)
                        getreduct1 += Reducts[i].ToString();//reduct (coma cara)
                    }
                    else
                    {
                        getreduct += Reducts[i].ToString() + ";";//reduct (coma soho)
                        getreduct1 += Reducts[i].ToString() + ";    ";//reduct (coma cara)
                    }


                }
                // MessageBox.Show(getreduct1.ToString());
            }









            // FCM apply for each table


            length = getreduct.Length;
            //MessageBox.Show(length.ToString());


            for (int i = 0; i < length; i++)
            {
                if (getreduct[i] == ',')
                {
                    fcmcolumncount++;
                }
                if (getreduct[i] == ';')
                {
                    fcmrowcount++;
                    fcmcolumncount = 0;
                }
            }
            // MessageBox.Show(fcmcolumncount.ToString());
            //  MessageBox.Show(fcmrowcount.ToString());


            int p, q = 0;

            char[] str = new char[50];
            for (int ifcm = 0; ifcm < fcmrowcount; ifcm++)
            {


                List<string> fcmcolumn = new List<string>();

                // Array.Clear(str, null, str.Length);

                for (int j = 0; j < fcmcolumncount; j++)
                {
                    for (int lo = 0; lo < 50; lo++)
                    {
                        str[lo] = '\0';
                    }//making array empty

                    p = 0;
                    while (getreduct[q] != ',')
                    {

                        str[p++] = getreduct[q];
                        q++;
                    }
                    q++;
                    str[p++] = '\0';
                    string s = new string(str);
                    s = s.Trim('\0');
                    fcmcolumn.Add(s);
                    //MessageBox.Show(s);
                }
                q++;

                object[,] array = new object[rowcount, columncount];
                int col = 0;
                foreach (string st in fcmcolumn)
                {

                    //MessageBox.Show(st.ToString());
                    string colname = st.ToString();
                    if (colname == "c")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select c from test.skill ";
                        MySqlConnection myConn1 = new MySqlConnection(myConnection1);
                        MySqlCommand myCommand1 = new MySqlCommand(Query1, myConn1);
                        MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                        MyAdapter.SelectCommand = myCommand1;
                        DataTable dTable1 = new DataTable();
                        MyAdapter.Fill(dTable1);
                        int crowcount = dTable1.Rows.Count;
                        for (int i = 0; i < crowcount; i++)
                        {
                            array[i, col] = dTable1.Rows[i][0];
                        }
                        col++;
                        fuzzy_skill.Add("c");
                    }
                    if (colname == "cplus")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select cplus from test.skill ";
                        MySqlConnection myConn1 = new MySqlConnection(myConnection1);
                        MySqlCommand myCommand1 = new MySqlCommand(Query1, myConn1);
                        MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                        MyAdapter.SelectCommand = myCommand1;
                        DataTable dTable2 = new DataTable();
                        MyAdapter.Fill(dTable2);
                        int crowcount = dTable2.Rows.Count;
                        for (int i = 0; i < crowcount; i++)
                        {
                            array[i, col] = dTable2.Rows[i][0];
                        }
                        col++;
                        fuzzy_skill.Add("cplus");

                    }
                    if (colname == "csharp")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select csharp from test.skill ";
                        MySqlConnection myConn1 = new MySqlConnection(myConnection1);
                        MySqlCommand myCommand1 = new MySqlCommand(Query1, myConn1);
                        MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                        MyAdapter.SelectCommand = myCommand1;
                        DataTable dTable3 = new DataTable();
                        MyAdapter.Fill(dTable3);
                        int crowcount = dTable3.Rows.Count;
                        for (int i = 0; i < crowcount; i++)
                        {
                            array[i, col] = dTable3.Rows[i][0];
                        }
                        col++;
                        fuzzy_skill.Add("csharp");
                    }
                    if (colname == "php")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select php from test.skill ";
                        MySqlConnection myConn1 = new MySqlConnection(myConnection1);
                        MySqlCommand myCommand1 = new MySqlCommand(Query1, myConn1);
                        MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                        MyAdapter.SelectCommand = myCommand1;
                        DataTable dTable4 = new DataTable();
                        MyAdapter.Fill(dTable4);
                        int crowcount = dTable4.Rows.Count;
                        for (int i = 0; i < crowcount; i++)
                        {
                            array[i, col] = dTable4.Rows[i][0];
                        }
                        col++;
                        fuzzy_skill.Add("php");
                    }
                    if (colname == "java")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select java from test.skill ";
                        MySqlConnection myConn1 = new MySqlConnection(myConnection1);
                        MySqlCommand myCommand1 = new MySqlCommand(Query1, myConn1);
                        MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                        MyAdapter.SelectCommand = myCommand1;
                        DataTable dTable5 = new DataTable();
                        MyAdapter.Fill(dTable5);
                        int crowcount = dTable5.Rows.Count;
                        for (int i = 0; i < crowcount; i++)
                        {
                            array[i, col] = dTable5.Rows[i][0];
                        }
                        col++;
                        fuzzy_skill.Add("java");
                    }
                    if (colname == "html")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select html from test.skill ";
                        MySqlConnection myConn1 = new MySqlConnection(myConnection1);
                        MySqlCommand myCommand1 = new MySqlCommand(Query1, myConn1);
                        MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                        MyAdapter.SelectCommand = myCommand1;
                        DataTable dTable6 = new DataTable();
                        MyAdapter.Fill(dTable6);
                        int crowcount = dTable6.Rows.Count;
                        for (int i = 0; i < crowcount; i++)
                        {
                            array[i, col] = dTable6.Rows[i][0];
                        }
                        col++;
                        fuzzy_skill.Add("html");
                    }
                    if (colname == "css")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select css from test.skill ";
                        MySqlConnection myConn1 = new MySqlConnection(myConnection1);
                        MySqlCommand myCommand1 = new MySqlCommand(Query1, myConn1);
                        MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                        MyAdapter.SelectCommand = myCommand1;
                        DataTable dTable7 = new DataTable();
                        MyAdapter.Fill(dTable7);
                        int crowcount = dTable7.Rows.Count;
                        for (int i = 0; i < crowcount; i++)
                        {
                            array[i, col] = dTable7.Rows[i][0];
                        }
                        col++;
                        fuzzy_skill.Add("css");
                    }
                    if (colname == "javascript")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select javascript from test.skill ";
                        MySqlConnection myConn1 = new MySqlConnection(myConnection1);
                        MySqlCommand myCommand1 = new MySqlCommand(Query1, myConn1);
                        MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                        MyAdapter.SelectCommand = myCommand1;
                        DataTable dTable8 = new DataTable();
                        MyAdapter.Fill(dTable8);
                        int crowcount = dTable8.Rows.Count;
                        for (int i = 0; i < crowcount; i++)
                        {
                            array[i, col] = dTable8.Rows[i][0];
                        }
                        col++;
                        fuzzy_skill.Add("javascript");
                    }
                    if (colname == "laravel")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select laravel from test.skill ";
                        MySqlConnection myConn1 = new MySqlConnection(myConnection1);
                        MySqlCommand myCommand1 = new MySqlCommand(Query1, myConn1);
                        MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                        MyAdapter.SelectCommand = myCommand1;
                        DataTable dTable9 = new DataTable();
                        MyAdapter.Fill(dTable9);
                        int crowcount = dTable9.Rows.Count;
                        for (int i = 0; i < crowcount; i++)
                        {
                            array[i, col] = dTable9.Rows[i][0];
                        }
                        col++;
                        fuzzy_skill.Add("laravel");
                    }
                    if (colname == "aspdotnet")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select aspdotnet from test.skill ";
                        MySqlConnection myConn1 = new MySqlConnection(myConnection1);
                        MySqlCommand myCommand1 = new MySqlCommand(Query1, myConn1);
                        MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                        MyAdapter.SelectCommand = myCommand1;
                        DataTable dTable10 = new DataTable();
                        MyAdapter.Fill(dTable10);
                        int crowcount = dTable10.Rows.Count;
                        for (int i = 0; i < crowcount; i++)
                        {
                            array[i, col] = dTable10.Rows[i][0];
                        }
                        col++;
                        fuzzy_skill.Add("aspdotnet");
                    }
                    if (colname == "dotnet")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select dotnet from test.skill ";
                        MySqlConnection myConn1 = new MySqlConnection(myConnection1);
                        MySqlCommand myCommand1 = new MySqlCommand(Query1, myConn1);
                        MySqlDataAdapter MyAdapter1 = new MySqlDataAdapter();
                        MyAdapter.SelectCommand = myCommand1;
                        DataTable dTable11 = new DataTable();
                        MyAdapter.Fill(dTable11);
                        int crowcount = dTable11.Rows.Count;
                        for (int i = 0; i < crowcount; i++)
                        {
                            array[i, col] = dTable11.Rows[i][0];
                        }
                        col++;
                        fuzzy_skill.Add("dotnet");
                    }



                }



                object[,] arraycopy = new object[rowcount, fcmcolumncount];

                for (int cpi = 0; cpi < rowcount; cpi++)
                {
                    for (int cpj = 0; cpj < col; cpj++)
                    {
                        arraycopy[cpi, cpj] = array[cpi, cpj];

                    }
                }


                int[,] iarray = new int[arraycopy.GetLength(0), arraycopy.GetLength(1)];
                Array.Copy(arraycopy, iarray, arraycopy.Length);//convert from object to integer

                double[,] darray = new double[iarray.GetLength(0), iarray.GetLength(1)];
                Array.Copy(iarray, darray, iarray.Length);//convert from integer to float

                // MessageBox.Show(darray[2, 2].ToString());


                rcc1 = 0.5; rcc2 = 0.6; rcc3 = .4;
                m = 1.5;//fuzzyfication parameter[1,N]




                double[,] cl1array = new double[darray.GetLength(0), darray.GetLength(1)];//cluster1 array
                double[,] cl2array = new double[darray.GetLength(0), darray.GetLength(1)];//cluster2 array
                double[,] cl3array = new double[darray.GetLength(0), darray.GetLength(1)];//cluster2 array


                //cluster1 , cluster2 & cluster3 er distance finding
                for (int cli = 0; cli < darray.GetLength(0); cli++)
                {
                    for (int clj = 0; clj < darray.GetLength(1); clj++)
                    {
                        if (darray[cli, clj] != 0)
                        {
                            cl1array[cli, clj] = Math.Sqrt((darray[cli, clj] - rcc1) * (darray[cli, clj] - rcc1));//cluster1
                            cl2array[cli, clj] = Math.Sqrt((darray[cli, clj] - rcc2) * (darray[cli, clj] - rcc2));//cluster2
                            cl3array[cli, clj] = Math.Sqrt((darray[cli, clj] - rcc3) * (darray[cli, clj] - rcc3));//cluster3

                        }
                    }
                }


                double[,] mem1array = new double[darray.GetLength(0), darray.GetLength(1)];//membership value array for cluster1
                double[,] mem2array = new double[darray.GetLength(0), darray.GetLength(1)];//membership value array for cluster2
                double[,] mem3array = new double[darray.GetLength(0), darray.GetLength(1)];//membership value array for cluster3
                

                //Membership value finding
                for (int iteration = 0; iteration < 15; iteration++)// 500 iteration for U(k+1)-U(k)= very less
                {
                    for (int cli = 0; cli < darray.GetLength(0); cli++)
                    {
                        for (int clj = 0; clj < darray.GetLength(1); clj++)
                        {
                            if (darray[cli, clj] != 0)
                            {
                                mem1array[cli, clj] = cl1array[cli, clj] / (cl1array[cli, clj] + cl2array[cli, clj] + cl3array[cli, clj]);
                                mem2array[cli, clj] = cl2array[cli, clj] / (cl1array[cli, clj] + cl2array[cli, clj] + cl3array[cli, clj]);
                                mem3array[cli, clj] = cl3array[cli, clj] / (cl1array[cli, clj] + cl2array[cli, clj] + cl3array[cli, clj]);
                            }
                            else
                            {
                                mem1array[cli, clj] = 0;
                                mem2array[cli, clj] = 0;
                                mem3array[cli, clj] = 0;
                            }
                        }
                    }

                    darrlen = darray.GetLength(0);
                    //centriod update
                    double uadd1 = 0, uadd2 = 0, uadd3 = 0;//upper value
                    double ladd1 = 0, ladd2 = 0, ladd3 = 0;//lower value
                    for (int cli = 0; cli < darray.GetLength(0); cli++)
                    {
                        for (int clj = 0; clj < darray.GetLength(1); clj++)
                        {
                            if (darray[cli, clj] != 0)
                            {
                                uadd1 = uadd1 + mem1array[cli, clj] * darray[cli, clj];
                                uadd2 = uadd2 + mem2array[cli, clj] * darray[cli, clj];
                                uadd3 = uadd3 + mem3array[cli, clj] * darray[cli, clj];
                                ladd1 = ladd1 + mem1array[cli, clj];
                                ladd2 = ladd2 + mem2array[cli, clj];
                                ladd3 = ladd3 + mem3array[cli, clj];
                            }
                        }
                    }

                    rcc1 = uadd1 / ladd1;
                    rcc2 = uadd2 / ladd2;
                    rcc3 = uadd3 / ladd3;

                    //again same calclation
                    for (int cli = 0; cli < darray.GetLength(0); cli++)
                    {
                        for (int clj = 0; clj < darray.GetLength(1); clj++)
                        {
                            if (darray[cli, clj] != 0)
                            {
                                cl1array[cli, clj] = Math.Sqrt((darray[cli, clj] - rcc1) * (darray[cli, clj] - rcc1));//cluster1
                                cl2array[cli, clj] = Math.Sqrt((darray[cli, clj] - rcc2) * (darray[cli, clj] - rcc2));//cluster2
                                cl3array[cli, clj] = Math.Sqrt((darray[cli, clj] - rcc3) * (darray[cli, clj] - rcc3));//cluster3

                            }

                        }
                    }
                }//500 iteration end (FCM End)



                //ranking started

                priority.Sort();
                priority.Reverse();

                /*  foreach (skillneeded sk in priority)
                   {

                       List<temporary> tempary = new List<temporary>();
                    
                       for (int tempj = 1; tempj <= 3; tempj++)
                       {
                           for (int tempi = 0; tempi < mem1array.GetLength(0); tempi++)
                           {
                            
                               tempary.Add(new temporary() { index = tempi, memvalue = mem1array[tempi,skill.IndexOf(sk.lanfrm)]});

                           }
                               if (tempj == 1)
                               {
                                 int count=0 ;
                                 while(count!=tempary.Count)
                                 {
                                       tempary.Sort();
                                       tempary.Reverse();
                                       temporary t = tempary[0]; 
                                       double temp = t.memvalue;
                                       count = 0;
                                       foreach (temporary tem in tempary)
                                       {

                                           if (tem.memvalue == temp)
                                           {
                                               cv[tem.index] = cv[tem.index] + (sk.priorityvalue + temp);                                           
                                               tem.memvalue = 0;
                                               count=count+1;

                                           }
                                           else if(tem.memvalue==0)
                                           {
                                               count = count+1;
                                           }

                                       }                        
                                  }
                               }
                               tempary.Clear();


                           for (int tempi = 0; tempi < mem2array.GetLength(0); tempi++)
                           {
                               tempary.Add(new temporary() { index = tempi, memvalue = mem2array[tempi,skill.IndexOf(sk.lanfrm)]});

                           }

                           if (tempj == 2)
                           {
                                 int count=0 ;
                                 while(count!=tempary.Count)
                                 {
                                       tempary.Sort();
                                       tempary.Reverse();
                                       temporary t = tempary[0]; 
                                       double temp = t.memvalue;
                                       count = 0;
                                       foreach (temporary tem in tempary)
                                       {

                                           if (tem.memvalue == temp)
                                           {
                                               cv[tem.index] = cv[tem.index] + (sk.priorityvalue + temp);                                            
                                               tem.memvalue = 0;
                                               count=count+1;

                                           }
                                           else if(tem.memvalue==0)
                                           {
                                               count = count+1;
                                           }

                                       }                        
                                  }

                           }


                           tempary.Clear();
                           for (int tempi = 0; tempi < mem3array.GetLength(0); tempi++)
                           {
                               tempary.Add(new temporary() { index = tempi, memvalue = mem3array[tempi, skill.IndexOf(sk.lanfrm)] });

                           }

                           if (tempj == 3)
                           {
                               int count = 0;
                               while (count != tempary.Count)
                               {
                                   tempary.Sort();
                                   tempary.Reverse();
                                   temporary t = tempary[0];
                                   double temp = t.memvalue;
                                   count = 0;
                                   foreach (temporary tem in tempary)
                                   {

                                       if (tem.memvalue == temp)
                                       {
                                           cv[tem.index] = cv[tem.index] + (sk.priorityvalue + temp);                                      
                                           tem.memvalue = 0;
                                           count = count + 1;

                                       }
                                       else if (tem.memvalue == 0)
                                       {
                                           count = count + 1;
                                       }

                                   }
                               }
                                
                           }



                       }

                   }               
                               
            */

                double a, b, c;



                for (int tempi = 0; tempi < mem1array.GetLength(0); tempi++)
                {
                    for (int tempj = 0; tempj < mem1array.GetLength(1); tempj++)
                    {
                        a = Convert.ToDouble(mem1array[tempi, tempj]);
                        b = Convert.ToDouble(mem2array[tempi, tempj]);
                        c = Convert.ToDouble(mem3array[tempi, tempj]);
                        if (a >= b && a >= c)
                        {
                            support_val[tempi, tempj] = a;
                        }
                        if (b >= a && b >= c)
                        {
                            support_val[tempi, tempj] = b;

                        }
                        if (c >= a && c >= b)
                        {
                            support_val[tempi, tempj] = c;

                        }
                    }

                }


                lengthmem1 = mem1array.GetLength(0);



                string myConnection5 = "datasource=localhost;port=3306;username=root;password=root";
                string Query5 = "select id as 'ID',degree as 'degree',experience as 'experience' from test.qualifications";
                MySqlConnection myConn5 = new MySqlConnection(myConnection5);
                MySqlCommand myCommand5 = new MySqlCommand(Query5, myConn5);
                MySqlDataAdapter MyAdapter5 = new MySqlDataAdapter();
                MyAdapter5.SelectCommand = myCommand5;
                DataTable dTable50 = new DataTable();
                /* dTable.Columns.Add("decission", typeof(System.Int32));*/
                MyAdapter5.Fill(dTable50);
                for (int ar = 0; ar < dTable50.Rows.Count; ar++)
                {

                    string val1 = dTable50.Rows[ar][1].ToString();
                    string val2 = dTable50.Rows[ar][2].ToString();

                    dep_exp[ar, 0] = Convert.ToInt32(val1);
                    dep_exp[ar, 1] = Convert.ToInt32(val2);


                }



                if (department1 == "BSC in CSE")
                {
                    foreach (skillneeded pk in priority)
                    {
                        if (pk.priorityvalue > 0)
                        {
                            int lan_indexorg = skill.IndexOf(pk.lanfrm);
                            string str_fuzzy_skill = pk.lanfrm;
                            int lan_index = fuzzy_skill.IndexOf(str_fuzzy_skill);

                            for (int lo = 0; lo < lengthmem1; lo++)
                            {

                                if (original[lo, lan_indexorg] != 0 && dep_exp[lo, 0] == 1)
                                //if (dep_exp[lo, 0] == 1)
                                {
                                    cv[lo] = cv[lo] + (support_val[lo, lan_index] * pk.priorityvalue) ;
                                }

                            }
                        }


                    }

                }
                else
                {
                    foreach (skillneeded pk in priority)
                    {
                        if (pk.priorityvalue > 0)
                        {
                            int lan_indexorg = skill.IndexOf(pk.lanfrm);
                            string str_fuzzy_skill = pk.lanfrm;
                            int lan_index = fuzzy_skill.IndexOf(str_fuzzy_skill);

                            for (int lo = 0; lo < lengthmem1; lo++)
                            {

                                if (original[lo, lan_indexorg] != 0)
                                {
                                    cv[lo] = cv[lo] + (support_val[lo, lan_index] * pk.priorityvalue) ;
                                }

                            }
                        }


                    }
                }







            } //each table calculate end   



            






           
            
                

            List<rank> ranking = new List<rank>();
            List<finalrank> finalranking = new List<finalrank>();

            for (int ind = 0; ind < darrlen; ind++)
            {
                if (cv[ind] > 0)
                {
                    ranking.Add(new rank() { index1 = ind, totalpoint = cv[ind] });
                }
            }
            ranking.Sort();
            ranking.Reverse();


            foreach (rank r in ranking)
            {
                //finalrank[fr++]=id[r.index1];           
                finalranking.Add(new finalrank() { index2 = id[r.index1], totalpoint1 = r.totalpoint });
            }



            //show rank
            List<temporary1> tempary1 = new List<temporary1>();
            foreach (rank r in ranking)
            {
                tempary1.Add(new temporary1() { index3 = id[r.index1], totalpoint2 = r.totalpoint });
            }


            int count1 = 0, count2 = 0, ind1 = 0;
            while (count1 != tempary1.Count)
            {
                tempary1.Sort();
                tempary1.Reverse();
                temporary1 t = tempary1[0];
                double temp = t.totalpoint2;
                count1 = 0;
                foreach (temporary1 tem in tempary1)
                {

                    if (tem.totalpoint2 == temp)
                    {
                        showrank[ind1, 0] = tem.index3;
                        showrank[ind1, 1] = count2 + 1;
                        tem.totalpoint2 = 0;
                        count1 = count1 + 1;
                        ind1 = ind1 + 1;

                    }
                    else if (tem.totalpoint2 == 0)
                    {
                        count1 = count1 + 1;
                    }

                }
                count2 = count2 + 1;
            }

            foreach (finalrank tfr in finalranking)
            {
                if (tfr.totalpoint1 == 0)
                {
                    showrank[ind1, 0] = tfr.index2;
                    showrank[ind1, 1] = count2 + 1;
                    ind1 = ind1 + 1;
                }
            }




            int height = ind1;
            int width = 2;

            //MessageBox.Show(height.ToString());
            this.dataGridView2.ColumnCount = width + 2;
            dataGridView2.Columns[0].HeaderText = "Serial No.";
            dataGridView2.Columns[1].HeaderText = "CV ID";
            dataGridView2.Columns[2].HeaderText = "CV Rank";

            //MessageBox.Show(height.ToString());
            if (showrankupto >= height)
            {
                showrankupto = height;
            }


            //datagridview
            //for (int r = 0; r < height; r++)
            for (int r = 0; r < showrankupto; r++) //show rank top5,10,15,20
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView2);

                row.Cells[0].Value = r;

                for (int c = 0; c < width; c++)
                {
                    row.Cells[c + 1].Value = showrank[r, c];
                }
                row.Cells[3].Value = "Click for open CV";
                this.dataGridView2.Rows.Add(row);
            }






        }

        private void HR_Arena_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewCell cel = null;
            foreach (DataGridViewCell selectedCell in dataGridView2.SelectedCells)
            {
                cel = selectedCell;
                break;

            }
            if (cel != null) //find out row
            {

                DataGridViewRow row = cel.OwningRow;

                string pdfname = row.Cells[1].Value.ToString();
                pdfname = pdfname + ".pdf";
                ; pdfname = "F://class CV//" + pdfname;
                System.Diagnostics.Process.Start(pdfname);

            }

        }
    }


    public class skillneeded : IComparable<skillneeded>
    {

        public string lanfrm { get; set; }

        public int priorityvalue { get; set; }

        public int CompareTo(skillneeded other)
        {
            if (this.priorityvalue > other.priorityvalue)
                return 1;
            else if (this.priorityvalue < other.priorityvalue)
                return -1;
            else
                return 0;

        }
    }

    public class temporary : IComparable<temporary>
    {

        public int index { get; set; }

        public double memvalue { get; set; }

        public int CompareTo(temporary other)
        {
            if (this.memvalue > other.memvalue)
                return 1;
            else if (this.memvalue < other.memvalue)
                return -1;
            else
                return 0;

        }
    }

    public class temporary1 : IComparable<temporary1>
    {

        public int index3 { get; set; }

        public double totalpoint2 { get; set; }
        public int CompareTo(temporary1 other)
        {
            if (this.totalpoint2 > other.totalpoint2)
                return 1;
            else if (this.totalpoint2 < other.totalpoint2)
                return -1;
            else
                return 0;

        }


    }
    public class rank : IComparable<rank>
    {

        public int index1 { get; set; }

        public double totalpoint { get; set; }

        public int CompareTo(rank other)
        {
            if (this.totalpoint > other.totalpoint)
                return 1;
            else if (this.totalpoint < other.totalpoint)
                return -1;
            else
                return 0;

        }
    }


    public class finalrank : IComparable<finalrank>
    {

        public int index2 { get; set; }

        public double totalpoint1 { get; set; }

        public int CompareTo(finalrank other)
        {
            if (this.totalpoint1 > other.totalpoint1)
                return 1;
            else if (this.totalpoint1 < other.totalpoint1)
                return -1;
            else
                return 0;

        }
    }



}
