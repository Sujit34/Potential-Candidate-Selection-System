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
    public partial class Upload_cv_eee : Form
    {
        public Upload_cv_eee()
        {
            InitializeComponent();
        }

        int cad, substation, lift, generator, installation, raspberry, ardunio, pic, op, garment, factory, office,exp,dept;

        float cgpa;

        private void refresh_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection = "datasource=localhost;port=3306;username=root;password=root";
                string Query = "delete from test.skillee ;";
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
                string Query3 = "delete from test.qualificationee ;";
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


        //upload CV info
        private void upload_Click(object sender, EventArgs e)
        {
            string path = @"F:\eee CV\";

            // rename pdf (kono pdf name age theke digit thakte parbe na such as 1,2,3,....)

             /* int count = 1;
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
                        cad = 1;
                    }
                    else
                    {

                        cad = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bMicrosoft Office\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bMs Office\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bWord\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bword\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bExcel\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bPower Point\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bPower point\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bpower point\\b", RegexOptions.IgnoreCase))
                    {

                        office = 2;
                    }
                    else
                    {

                        office = 0;
                    }                   
                  

                    if (Regex.IsMatch(strText, "\\bFactory\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bPlant\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bFacility Management\\b", RegexOptions.IgnoreCase))
                    {

                        factory = 1;
                    }
                    else
                    {

                        factory = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bGarments\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bGarment\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\btextiles\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\btextile\\b", RegexOptions.IgnoreCase))
                    {

                        garment = 1;
                    }
                    else
                    {

                        garment = 0;
                    }

                    if (Regex.IsMatch(strText, "\\boperation and maintenance\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bOperation and Maintenance\\b", RegexOptions.IgnoreCase) )     // \\b...\\b boundary delimiter
                    {

                        op = 1;
                    }
                    else
                    {

                        op = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bPIC\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bPIC Mirocontroller\\b", RegexOptions.IgnoreCase))
                    {

                        pic = 1;
                    }
                    else
                    {

                        pic = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bArduino\\b", RegexOptions.IgnoreCase) )     // \\b...\\b boundary delimiter
                    {

                        ardunio= 1;
                    }
                    else
                    {
                        ardunio = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bRaspberry Pi\\b", RegexOptions.IgnoreCase)) 
                    {

                        raspberry = 1;
                    }
                    else
                    {
                        raspberry = 0;
                    }

                    if (Regex.IsMatch(strText, "\\binstallation\\b", RegexOptions.IgnoreCase))
                    {

                        installation = 1;
                    }
                    else
                    {
                        installation = 0;
                    }
                    if (Regex.IsMatch(strText, "\\bgenerator\\b", RegexOptions.IgnoreCase))
                    {

                        generator = 1;
                    }
                    else
                    {
                        generator = 0;
                    }
                    if (Regex.IsMatch(strText, "\\blift\\b", RegexOptions.IgnoreCase))
                    {

                        lift = 1;
                    }
                    else
                    {
                        lift = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bsubstation\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bSub station\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bSub-station\\b", RegexOptions.IgnoreCase))
                    {

                        substation = 1;
                    }
                    else
                    {
                        substation = 0;
                    }



                    if (Regex.IsMatch(strText, "\\bElectrical\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\belectrical\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
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


                    string Query = "insert into test.skillee(id,autocad,office,picmicrocontroller,arduino,raspberrypi,factory,garments,operationandmaintenance,installation,generator,lift,substation) values(?id,?autocad,?office,?picmicrocontroller,?arduino,?raspberrypi,?factory,?garments,?operationandmaintenance,?installation,?generator,?lift,?substation);";

                    MySqlConnection MyConn = new MySqlConnection(myConnection);


                    MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                    MyConn.Open();

                    cmd.Parameters.AddWithValue("?id", id);
                    cmd.Parameters.AddWithValue("?autocad", cad);
                    cmd.Parameters.AddWithValue("?office", office);
                    cmd.Parameters.AddWithValue("?picmicrocontroller", pic);
                    cmd.Parameters.AddWithValue("?arduino", ardunio);
                    cmd.Parameters.AddWithValue("?raspberrypi", raspberry);
                    cmd.Parameters.AddWithValue("?factory", factory);
                    cmd.Parameters.AddWithValue("?garments", garment);
                    cmd.Parameters.AddWithValue("?operationandmaintenance", op);
                    cmd.Parameters.AddWithValue("?installation", installation);
                    cmd.Parameters.AddWithValue("?generator", generator);
                    cmd.Parameters.AddWithValue("?lift", lift);
                    cmd.Parameters.AddWithValue("?substation", substation);



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

                    string Query1 = "insert into test.qualificationee(id,department,experience,cgpa) values(?id,?department,?experience,?cgpa);";

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HR_Arena_ee hree = new HR_Arena_ee();
            hree.Show();

        }
    }
}
