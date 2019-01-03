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
    public partial class HR_Arena_Civil : Form
    {

        List<Object> elments_of_Universe = new List<Object>();
        List<string> skill = new List<string>();
        List<string> fuzzy_skill = new List<string>();
        List<skillneededcivil> priority = new List<skillneededcivil>();


        public int autocad = 0, word = 0, excel = 0, powerpoint = 0, boq = 0, realestate = 0, developer = 0, engineeringfirm = 0, multinationalcompany = 0, ngo = 0;

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
        int lengthmem1, experience;
        string department1;
        string experience1;
        int showrankuptocivil;


        public HR_Arena_Civil()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Upload_cv_civil cvupcivil = new Upload_cv_civil();
            cvupcivil.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HR_Login gotologin = new HR_Login();
            gotologin.Show();

        }

        //search jobs in search box
        private void search_job_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnection = "datasource=localhost;port=3306;username=root;password=root";

                textbox = this.textBox1.Text;
                string Query = "select id as 'Job ID',post as 'Post',salary as 'Salary',place as 'Place',qualification as 'Qualification',experience as 'Experience',software as 'Software',designtool as 'Design Tools',workingexp as 'Working Experience' from test.jobdetailscivil where id='" + this.textBox1.Text + "' ";
                MySqlConnection myConn = new MySqlConnection(myConnection);
                MySqlCommand myCommand = new MySqlCommand(Query, myConn);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = myCommand;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                dataGridView1.DataSource = dTable;
                department1 = dTable.Rows[0][4].ToString();
                experience1 = dTable.Rows[0][5].ToString();
                experience = Convert.ToInt32(experience1);



            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter Job ID");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "AutoCAD")
            {
                autocad = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneededcivil() { lanfrmcivil = "autocad", priorityvaluecivil = autocad });
                // MessageBox.Show("Saved");
            }
            if (comboBox2.Text == "Microsoft word")
            {
                word = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneededcivil() { lanfrmcivil = "word", priorityvaluecivil = word });
                // MessageBox.Show("Saved");
            }
            if (comboBox2.Text == "Excel")
            {
                excel = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneededcivil() { lanfrmcivil = "excel", priorityvaluecivil = excel });
                //MessageBox.Show("Saved");
            }
            if (comboBox2.Text == "Power Point")
            {
                powerpoint = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneededcivil() { lanfrmcivil = "powerpoint", priorityvaluecivil = powerpoint });
                //MessageBox.Show("Saved");
            }
            if (comboBox2.Text == "Prepare BOQ")
            {
                boq = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneededcivil() { lanfrmcivil = "boq", priorityvaluecivil = boq });
                // MessageBox.Show("Saved");
            }
            if (comboBox2.Text == "Real Estate")
            {
                realestate = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneededcivil() { lanfrmcivil = "realestate", priorityvaluecivil = realestate });
                //MessageBox.Show("Saved");
            }
            if (comboBox2.Text == "Consulting/Engineering Firms")
            {
                engineeringfirm = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneededcivil() { lanfrmcivil = "engineeringfirm", priorityvaluecivil = engineeringfirm });
                //MessageBox.Show("Saved");
            }
            if (comboBox2.Text == "Developer")
            {
                developer = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneededcivil() { lanfrmcivil = "developer", priorityvaluecivil = developer });
                // MessageBox.Show("Saved");
                // MessageBox.Show(developer.ToString());
            }
            if (comboBox2.Text == "Multinational Companies")
            {
                multinationalcompany = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneededcivil() { lanfrmcivil = "multinationalcompany", priorityvaluecivil = multinationalcompany });
                //MessageBox.Show("Saved");
            }
            if (comboBox2.Text == "NGO")
            {
                ngo = Convert.ToInt32(comboBox1.Text);
                priority.Add(new skillneededcivil() { lanfrmcivil = "ngo", priorityvaluecivil = ngo });
                //MessageBox.Show("Saved");
            }

        }

        private void scan_Click(object sender, EventArgs e)
        {

            if (comboBox3.Text == "Top 5")
            {
                showrankuptocivil = 5;
            }
            if (comboBox3.Text == "Top 10")
            {
                showrankuptocivil = 10;
            }
            if (comboBox3.Text == "Top 15")
            {
                showrankuptocivil = 15;
            }
            if (comboBox3.Text == "Top 20")
            {
                showrankuptocivil = 20;
            }
            if (comboBox3.Text == "Top 25")
            {
                showrankuptocivil = 25;
            }
            if (comboBox3.Text == "Top 30")
            {
                showrankuptocivil = 30;
            }


            //original data
            string myConnection0 = "datasource=localhost;port=3306;username=root;password=root";
            string Query0 = "select id as 'ID',autocad as 'AutoCAD',word as 'Word',excel as 'Excel', powerpoint as 'Powerpoint',realestate as 'Realestate',developer as'Developer',engineeringfirm as 'Engineering Firm',ngo as 'NGO',multinationalcompany as'Multinational Company',boq as 'BOQ' from test.skillcivil";
            MySqlConnection myConn0 = new MySqlConnection(myConnection0);
            MySqlCommand myCommand0 = new MySqlCommand(Query0, myConn0);
            MySqlDataAdapter MyAdapter0 = new MySqlDataAdapter();
            MyAdapter0.SelectCommand = myCommand0;
            DataTable dTable0 = new DataTable();
            MyAdapter0.Fill(dTable0);
            for (int ar = 0; ar < dTable0.Rows.Count; ar++)
            {
                for (int ac = 1; ac <= 10; ac++)
                {
                    string val = dTable0.Rows[ar][ac].ToString();
                    original[ar, ac - 1] = Convert.ToInt32(val);
                }
            }



            string myConnection = "datasource=localhost;port=3306;username=root;password=root";
            string Query = "select id as 'ID',autocad as 'AutoCAD',word as 'Word',excel as 'Excel', powerpoint as 'Powerpoint',realestate as 'Realestate',developer as'Developer',engineeringfirm as 'Engineering Firm',ngo as 'NGO',multinationalcompany as'Multinational Company',boq as 'BOQ' from test.skillcivil";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand = new MySqlCommand(Query, myConn);
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            MyAdapter.SelectCommand = myCommand;
            DataTable dTable = new DataTable();
            MyAdapter.Fill(dTable);
            for (int a = 0; a < dTable.Rows.Count; a++)
            {
                string ids = dTable.Rows[a][0].ToString();
                id[a] = Convert.ToInt32(ids);
            }



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




            skill.Add("autocad");
            skill.Add("word");
            skill.Add("excel");
            skill.Add("powerpoint");
            skill.Add("realestate");
            skill.Add("developer");
            skill.Add("engineeringfirm");
            skill.Add("ngo");
            skill.Add("multinationalcompany");
            skill.Add("boq");


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
                //MessageBox.Show("-----");//no core

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
                //MessageBox.Show(getcore.ToString());

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
                    if (colname == "autocad")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select autocad from test.skillcivil ";
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
                        fuzzy_skill.Add("autocad");
                    }
                    if (colname == "word")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select word from test.skillcivil ";
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
                        fuzzy_skill.Add("word");

                    }
                    if (colname == "excel")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select excel from test.skillcivil ";
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
                        fuzzy_skill.Add("excel");
                    }
                    if (colname == "powerpoint")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select powerpoint from test.skillcivil ";
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
                        fuzzy_skill.Add("powerpoint");
                    }
                    if (colname == "realestate")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select realestate from test.skillcivil ";
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
                        fuzzy_skill.Add("realestate");
                    }
                    if (colname == "developer")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select developer from test.skillcivil ";
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
                        fuzzy_skill.Add("developer");
                    }
                    if (colname == "engineeringfirm")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select engineeringfirm from test.skillcivil ";
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
                        fuzzy_skill.Add("engineeringfirm");
                    }
                    if (colname == "ngo")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select ngo from test.skillcivil ";
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
                        fuzzy_skill.Add("ngo");
                    }
                    if (colname == "multinationalcompany")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select multinationalcompany from test.skillcivil ";
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
                        fuzzy_skill.Add("multinationalcompany");
                    }
                    if (colname == "boq")
                    {
                        string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";
                        string Query1 = "select boq from test.skillcivil ";
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
                        fuzzy_skill.Add("boq");
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
                }//15 iteration end (FCM End)



                //ranking started

                priority.Sort();
                priority.Reverse();


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

            }




            string myConnection5 = "datasource=localhost;port=3306;username=root;password=root";
            string Query5 = "select id as 'ID',department as 'Department',experience as 'experience' from test.qualificationcivil";
            MySqlConnection myConn5 = new MySqlConnection(myConnection5);
            MySqlCommand myCommand5 = new MySqlCommand(Query5, myConn5);
            MySqlDataAdapter MyAdapter5 = new MySqlDataAdapter();
            MyAdapter5.SelectCommand = myCommand5;
            DataTable dTable50 = new DataTable();
            MyAdapter5.Fill(dTable50);
            for (int ar = 0; ar < dTable50.Rows.Count; ar++)
            {

                string val1 = dTable50.Rows[ar][1].ToString();
                string val2 = dTable50.Rows[ar][2].ToString();

                dep_exp[ar, 0] = Convert.ToInt32(val1);
                dep_exp[ar, 1] = Convert.ToInt32(val2);


            }


            foreach (skillneededcivil pk in priority)
            {
                if (pk.priorityvaluecivil > 0)
                {
                    int lan_indexorg = skill.IndexOf(pk.lanfrmcivil);
                    string str_fuzzy_skill = pk.lanfrmcivil;
                    int lan_index = fuzzy_skill.IndexOf(str_fuzzy_skill);

                    for (int lo = 0; lo < lengthmem1; lo++)
                    {

                        //if (original[lo, lan_indexorg] != 0 && dep_exp[lo,1]>=experience)
                        if (original[lo, lan_indexorg] != 0)
                        {
                            cv[lo] = cv[lo] + (support_val[lo, lan_index] * pk.priorityvaluecivil) + dep_exp[lo, 1];
                        }

                    }
                }


            }


            List<rankcivil> ranking = new List<rankcivil>();
            List<finalrankcivil> finalranking = new List<finalrankcivil>();

            for (int ind = 0; ind < darrlen; ind++)
            {
                if (cv[ind] > 0)
                {
                    ranking.Add(new rankcivil() { indexcivil1 = ind, totalpointcivil = cv[ind] });
                }
            }
            ranking.Sort();
            ranking.Reverse();


            foreach (rankcivil r in ranking)
            {

                finalranking.Add(new finalrankcivil() { indexcivil2 = id[r.indexcivil1], totalpointcivil1 = r.totalpointcivil });
            }



            //show rank
            List<temporarycivil1> tempary1 = new List<temporarycivil1>();
            foreach (rankcivil r in ranking)
            {
                tempary1.Add(new temporarycivil1() { indexcivil3 = id[r.indexcivil1], totalpointcivil2 = r.totalpointcivil });
            }


            int count1 = 0, count2 = 0, ind1 = 0;
            while (count1 != tempary1.Count)
            {
                tempary1.Sort();
                tempary1.Reverse();
                temporarycivil1 t = tempary1[0];
                double temp = t.totalpointcivil2;
                count1 = 0;
                foreach (temporarycivil1 tem in tempary1)
                {

                    if (tem.totalpointcivil2 == temp)
                    {
                        showrank[ind1, 0] = tem.indexcivil3;
                        showrank[ind1, 1] = count2 + 1;
                        tem.totalpointcivil2 = 0;
                        count1 = count1 + 1;
                        ind1 = ind1 + 1;

                    }
                    else if (tem.totalpointcivil2 == 0)
                    {
                        count1 = count1 + 1;
                    }

                }
                count2 = count2 + 1;
            }

            foreach (finalrankcivil tfr in finalranking)
            {
                if (tfr.totalpointcivil1 == 0)
                {
                    showrank[ind1, 0] = tfr.indexcivil2;
                    showrank[ind1, 1] = count2 + 1;
                    ind1 = ind1 + 1;
                }
            }




            int height = ind1;
            int width = 2;

            this.dataGridView2.ColumnCount = width + 2;
            dataGridView2.Columns[0].HeaderText = "Serial No.";
            dataGridView2.Columns[1].HeaderText = "CV ID";
            dataGridView2.Columns[2].HeaderText = "CV Rank";

            if (showrankuptocivil >= height)
            {
                showrankuptocivil = height;
            }


            //datagridview
            for (int r = 0; r < showrankuptocivil; r++)
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
                ; pdfname = "F://civil CV//" + pdfname;
                System.Diagnostics.Process.Start(pdfname);

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }




    public class skillneededcivil : IComparable<skillneededcivil>
    {

        public string lanfrmcivil { get; set; }

        public int priorityvaluecivil { get; set; }

        public int CompareTo(skillneededcivil other)
        {
            if (this.priorityvaluecivil > other.priorityvaluecivil)
                return 1;
            else if (this.priorityvaluecivil < other.priorityvaluecivil)
                return -1;
            else
                return 0;

        }
    }

    public class temporarycivil : IComparable<temporarycivil>
    {

        public int indexcivil { get; set; }

        public double memvaluecivil { get; set; }

        public int CompareTo(temporarycivil other)
        {
            if (this.memvaluecivil > other.memvaluecivil)
                return 1;
            else if (this.memvaluecivil < other.memvaluecivil)
                return -1;
            else
                return 0;

        }
    }

    public class temporarycivil1 : IComparable<temporarycivil1>
    {

        public int indexcivil3 { get; set; }

        public double totalpointcivil2 { get; set; }
        public int CompareTo(temporarycivil1 other)
        {
            if (this.totalpointcivil2 > other.totalpointcivil2)
                return 1;
            else if (this.totalpointcivil2 < other.totalpointcivil2)
                return -1;
            else
                return 0;

        }


    }
    public class rankcivil : IComparable<rankcivil>
    {

        public int indexcivil1 { get; set; }

        public double totalpointcivil { get; set; }

        public int CompareTo(rankcivil other)
        {
            if (this.totalpointcivil > other.totalpointcivil)
                return 1;
            else if (this.totalpointcivil < other.totalpointcivil)
                return -1;
            else
                return 0;

        }
    }


    public class finalrankcivil : IComparable<finalrankcivil>
    {

        public int indexcivil2 { get; set; }

        public double totalpointcivil1 { get; set; }

        public int CompareTo(finalrankcivil other)
        {
            if (this.totalpointcivil1 > other.totalpointcivil1)
                return 1;
            else if (this.totalpointcivil1 < other.totalpointcivil1)
                return -1;
            else
                return 0;

        }
    }







}
