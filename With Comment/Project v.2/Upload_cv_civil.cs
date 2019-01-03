using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

using System.Text.RegularExpressions;

using MySql.Data.MySqlClient;



namespace Project_v._2
{
    public partial class Upload_cv_civil : Form
    {
        public Upload_cv_civil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HR_Arena_Civil hrarenacivil = new HR_Arena_Civil();
            hrarenacivil.Show();

        }

        int cad,word,excel,powerpoint,realestate,developer,firm,ngo,multinationalcompany, dept, exp,boq;

        float cgpa;

        private void upload_Click(object sender, EventArgs e)
        {

            string path = @"F:\civil CV\";
           
                // rename pdf (kono pdf name age theke digit thakte parbe na such as 1,2,3,....)
                
             /*   int count = 1;
                foreach (string file in Directory.EnumerateFiles(path, "*.pdf"))
                {
                    string destinationFilename = Convert.ToString(count);
                    string getFileName1 = file.Substring(file.LastIndexOf("\\"));
                    string sourceFilename = Regex.Replace(getFileName1, @"\\", "");

                    sourceFilename = path + sourceFilename;
                    destinationFilename = path + destinationFilename + ".pdf";
                    //MessageBox.Show(sourceFilename);
                    //MessageBox.Show(destinationFilename);
                    if (File.Exists(destinationFilename))
                    {
                        File.Delete(destinationFilename);
                    }
                    File.Move(sourceFilename, destinationFilename);
                    count++;

                }*/
            
            
            
            
            //string path = @"F:\civil CV\";
            foreach (string file in Directory.EnumerateFiles(path, "*.pdf"))
            {
                string getFileName = file.Substring(file.LastIndexOf("\\"));
                string getFileWithoutExtras = Regex.Replace(getFileName, @"\\", "");
                string getFileWihtoutExtension = Regex.Replace(getFileWithoutExtras, @".pdf", "");
                int id = Convert.ToInt32(getFileWihtoutExtension);

                String strText = string.Empty;
                try
                {

                    PdfReader reader = new PdfReader(file);
                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                        String s = PdfTextExtractor.GetTextFromPage(reader, page, its);
                        s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                        strText = strText + s;

                    }


                    strText = Regex.Replace(strText, @"[^A-Za-z0-9#:+.@ ]+", "  ");

                    strText = Regex.Replace(strText, @"[0-9]+\.[0-9]+\.[0-9]+", "  ");


                    if (Regex.IsMatch(strText, "\\bAutoCAD\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bCAD\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bComputer Aided Design\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {
                        cad= 1;
                    }
                    else
                    {

                        cad = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bWord\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bword\\b", RegexOptions.IgnoreCase))     
                    {

                        word = 2;
                    }
                    else
                    {

                        word = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bExcel\\b", RegexOptions.IgnoreCase) )     
                    {

                        excel = 2;
                    }
                    else
                    {
                        excel = 0;
                    }
                    if (Regex.IsMatch(strText, "\\bPower Point\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bPower point\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bpower point\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        powerpoint = 2;
                    }
                    else
                    {

                        powerpoint = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bReal Estate\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bReal estate\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\breal estate\\b", RegexOptions.IgnoreCase))    
                    {

                        realestate = 1;
                    }
                    else
                    {

                        realestate = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bDeveloper\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bdeveloper\\b", RegexOptions.IgnoreCase) )     
                    {

                        developer = 1;
                    }
                    else
                    {

                        developer = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bEngineering Firms\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bengineering firm\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bEngineering firm\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bConsulting firms\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bconsulting firm\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bConsulting Firm\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        firm = 1;
                    }
                    else
                    {

                        firm = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bNGO\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bNgo\\b", RegexOptions.IgnoreCase))  
                    {

                        ngo = 1;
                    }
                    else
                    {

                        ngo = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bMultinational Companies\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bMultinational company\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bmultinational company\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        multinationalcompany = 1;
                    }
                    else
                    {
                        multinationalcompany = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bBOQ\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bBoq\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bBill of quantity\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        boq = 1;
                    }
                    else
                    {
                        boq = 0;
                    }
                    
                    


                    if (Regex.IsMatch(strText, "\\bCivil\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bcivil\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        dept = 1;

                    }
                    else
                    {

                        dept = 0;
                    }

                   
                    exp = 0;
                    for (int x = 0; x < strText.Length; x++)
                    {
                        if ((strText[x] == 'E' || strText[x] == 'e') && strText[x + 1] == 'x' && strText[x + 2] == 'p' && strText[x + 3] == 'e' && strText[x + 4] == 'r' && strText[x + 5] == 'i' && strText[x + 6] == 'e' && strText[x + 7] == 'n' && strText[x + 8] == 'c' && strText[x + 9] == 'e' && strText[x + 10] == ':')
                        { 
                            for (int y = x + 10; y < x + 10 + 4; y++)
                            {
                                if (strText[y] == '0' || strText[y] == '1' || strText[y] == '2' || strText[y] == '3' || strText[y] == '4' || strText[y] == '5' || strText[y] == '6' || strText[y] == '7' || strText[y] == '8')
                                {
                                    exp = (int)Char.GetNumericValue(strText[y]);
                                    break;
                                }
                                exp = 0;

                            }
                            break;
                        }

                    }



                    string InputString = strText;

                    var r = new Regex(@"[2-3]\.[0-9]+");
                    var mc = r.Matches(InputString);
                    var matches = new Match[mc.Count];
                    mc.CopyTo(matches, 0);

                    var myFloats = new float[matches.Length];
                    var ndx = 0;
                    foreach (Match m in matches)
                    {
                        myFloats[ndx] = float.Parse(m.Value);
                        ndx++;
                    }


                    float f = myFloats[0];
                    cgpa = f;

                    reader.Close();


                     
                    string myConnection = "datasource=localhost;port=3306;username=root;password=root";

                                          
                    string Query = "insert into test.skillcivil(id,autocad,word,excel,powerpoint,realestate,developer,engineeringfirm,ngo,multinationalcompany,boq) values(?id,?autocad,?word,?excel,?powerpoint,?realestate,?developer,?engineeringfirm,?ngo,?multinationalcompany,?boq);";
                    
                    MySqlConnection MyConn = new MySqlConnection(myConnection);

                     
                    MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                    MyConn.Open();

                    cmd.Parameters.AddWithValue("?id", id);
                    cmd.Parameters.AddWithValue("?autocad", cad);
                    cmd.Parameters.AddWithValue("?word", word);
                    cmd.Parameters.AddWithValue("?excel", excel);
                    cmd.Parameters.AddWithValue("?powerpoint", powerpoint);
                    cmd.Parameters.AddWithValue("?realestate", realestate);
                    cmd.Parameters.AddWithValue("?developer", developer);
                    cmd.Parameters.AddWithValue("?engineeringfirm", firm);
                    cmd.Parameters.AddWithValue("?ngo", ngo);
                    cmd.Parameters.AddWithValue("?multinationalcompany", multinationalcompany);
                    cmd.Parameters.AddWithValue("?boq", boq);
                    


                    cmd.ExecuteNonQuery();
                    MyConn.Close();





                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(id.ToString());
                }

                try
                {
                    string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";

                    string Query1 = "insert into test.qualificationcivil(id,department,experience,cgpa) values(?id,?department,?experience,?cgpa);";

                    MySqlConnection MyConn1 = new MySqlConnection(myConnection1);

                    MySqlCommand cmd1 = new MySqlCommand(Query1, MyConn1);
                    MyConn1.Open();


                    cmd1.Parameters.AddWithValue("?id", id);
                    cmd1.Parameters.AddWithValue("?department", dept);
                    cmd1.Parameters.AddWithValue("?experience", exp);
                    cmd1.Parameters.AddWithValue("?cgpa", cgpa);

                    cmd1.ExecuteNonQuery();
                    MyConn1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }



            }

            MessageBox.Show("All info Saved");
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection = "datasource=localhost;port=3306;username=root;password=root";
                string Query = "delete from test.skillcivil ;";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                //MessageBox.Show("Data Deleted");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();


                string MyConnection3 = "datasource=localhost;port=3306;username=root;password=root";
                string Query3 = "delete from test.qualificationcivil ;";
                MySqlConnection MyConn3 = new MySqlConnection(MyConnection3);
                MySqlCommand MyCommand3 = new MySqlCommand(Query3, MyConn3);
                MySqlDataReader MyReader3;
                MyConn3.Open();
                MyReader3 = MyCommand3.ExecuteReader();
                MessageBox.Show("Data Deleted");
                while (MyReader3.Read())
                {
                }
                MyConn3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
