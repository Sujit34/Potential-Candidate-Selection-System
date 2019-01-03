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
    public partial class Upload_CV : Form
    {
        public Upload_CV()
        {
            InitializeComponent();
        }


        int c, cplus, csharp, java, php, html, css, javascript,laravel,aspdotnet,dotnet,dept,exp,pos;

        float cgpa;

        private void upload_Click(object sender, EventArgs e)
        {


            string path = @"F:\class CV\";

              /* int count = 1;
               foreach (string file in Directory.EnumerateFiles(path, "*.pdf"))
                {
                    string destinationFilename = Convert.ToString(count);
                    string getFileName1 = file.Substring(file.LastIndexOf("\\"));
                    string sourceFilename = Regex.Replace(getFileName1, @"\\", "");

                    sourceFilename = path + sourceFilename;
                    destinationFilename = path + destinationFilename + ".pdf";
                   // MessageBox.Show(sourceFilename);
                   // MessageBox.Show(destinationFilename);
                    if (File.Exists(destinationFilename))
                    {
                        File.Delete(destinationFilename);
                    }
                    File.Move(sourceFilename, destinationFilename);
                    count++;

                }*/





            //string path = @"F:\class CV\";
            foreach (string file in Directory.EnumerateFiles(path, "*.pdf"))
            {
                string getFileName = file.Substring(file.LastIndexOf("\\"));
                string getFileWithoutExtras = Regex.Replace(getFileName, @"\\", "");
                string getFileWihtoutExtension = Regex.Replace(getFileWithoutExtras, @".pdf", "");
                int id = Convert.ToInt32(getFileWihtoutExtension);

               /* MessageBox.Show(getFileName);
                MessageBox.Show(getFileWithoutExtras);
                MessageBox.Show(getFileWihtoutExtension);*/

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
                    

                    strText = Regex.Replace(strText, @"[^A-Za-z0-9#+.@ ]+", "  ");

                    strText = Regex.Replace(strText, @"[0-9]+\.[0-9]+\.[0-9]+", "  ");
                    //MessageBox.Show(strText.ToString());
                    strText = Regex.Replace(strText, @"[#]+", "Sharp");                                  
                    if (Regex.IsMatch(strText, "\\bPHP\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bPhp\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bphp\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {
                        php = 1;
                    }
                    else
                    {

                        php = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bC+\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bc+\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        cplus = 1;
                    }
                    else
                    {

                        cplus = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bCSharp\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bCSHARP\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        csharp = 1;
                    }
                    else
                    {
                        csharp = 0;
                    }
                    if (Regex.IsMatch(strText, "\\bJavascript\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bJAVASCRIPT\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        javascript = 1;
                    }
                    else
                    {

                        javascript = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bC\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bc\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        c = 1;
                    }
                    else
                    {

                        c = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bHTML\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bHtml\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bHTML5\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bhtml\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        html = 1;
                    }
                    else
                    {

                        html = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bCSS\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bCSS3\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bCss\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bcss\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        css = 1;
                    }
                    else
                    {

                        css = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bJava\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bJAVA\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        java = 1;
                    }
                    else
                    {

                        java = 0;
                    }

                    if (Regex.IsMatch(strText, "\\bLaravel\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bLARAVEL\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        laravel = 2;
                    }
                    else
                    {
                        laravel = 0;
                    }
                    if (Regex.IsMatch(strText, "\\bAsp.Net\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bASP.NET\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        aspdotnet = 2;
                    }
                    else
                    {
                        aspdotnet = 0;
                    }
                    if (Regex.IsMatch(strText, "\\bsql\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\b.Sql\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\b.SQL\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\b.MySql\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\b.MYSQL\\b", RegexOptions.IgnoreCase) | Regex.IsMatch(strText, "\\b.mysql\\b", RegexOptions.IgnoreCase) | Regex.IsMatch(strText, "\\b.MySQL\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
                    {

                        dotnet = 2;
                    }
                    else
                    {
                        dotnet = 0;
                    }


                    if (Regex.IsMatch(strText, "\\bCSE\\b", RegexOptions.IgnoreCase) || Regex.IsMatch(strText, "\\bComputer Science\\b", RegexOptions.IgnoreCase))     // \\b...\\b boundary delimiter
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
                        if ((strText[x] == 'E'||strText[x]=='e') && strText[x+1] == 'x' && strText[x+2] == 'p' && strText[x+3] == 'e' && strText[x+4] == 'r' && strText[x+5] == 'i' && strText[x+6] == 'e' && strText[x+7] == 'n' && strText[x+8] == 'c' && strText[x+9] == 'e')

                        {
                            for (int y = x + 9; y < x + 9 + 4; y++)
                            {
                                if(strText[y]=='0'||strText[y]=='1'||strText[y]=='2'||strText[y]=='3'||strText[y]=='4'||strText[y]=='5'||strText[y]=='6'||strText[y]=='7'||strText[y]=='8')
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

                    var r = new Regex(@"[2-4]\.[0-9]+");
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


                    //This is my connection string i have assigned the database file address path  
                    string myConnection = "datasource=localhost;port=3306;username=root;password=root";

                    //This is my insert query in which i am taking input from the user through windows forms                      
                    string Query = "insert into test.skill(id,c,cplus,csharp,php,java,html,css,javascript,laravel,aspdotnet,dotnet) values(?id,?c,?cplus,?csharp,?php,?java,?html,?css,?javascript,?laravel,?aspdotnet,?dotnet);";



                    //This is  MySqlConnection here i have created the object and pass my connection string.  
                    MySqlConnection MyConn = new MySqlConnection(myConnection);

                    //This is command class which will handle the query and connection object.  
                    MySqlCommand cmd = new MySqlCommand(Query, MyConn);
                    MyConn.Open();

                    cmd.Parameters.AddWithValue("?id", id);
                    cmd.Parameters.AddWithValue("?c", c);
                    cmd.Parameters.AddWithValue("?cplus", cplus);
                    cmd.Parameters.AddWithValue("?csharp", csharp);
                    cmd.Parameters.AddWithValue("?php", php);
                    cmd.Parameters.AddWithValue("?java", java);
                    cmd.Parameters.AddWithValue("?html", html);
                    cmd.Parameters.AddWithValue("?css", css);
                    cmd.Parameters.AddWithValue("?javascript", javascript);
                    cmd.Parameters.AddWithValue("?laravel", laravel);
                    cmd.Parameters.AddWithValue("?aspdotnet", aspdotnet);
                    cmd.Parameters.AddWithValue("?dotnet", dotnet);


                    cmd.ExecuteNonQuery();
                    // MessageBox.Show("Info. Saved");
                    MyConn.Close();


                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Already Saved");
                    MessageBox.Show(id.ToString());
                }

                string myConnection1 = "datasource=localhost;port=3306;username=root;password=root";

                string Query1 = "insert into test.qualifications(id,degree,experience,cgpa) values(?id,?degree,?experience,?cgpa);";

                MySqlConnection MyConn1 = new MySqlConnection(myConnection1);

                MySqlCommand cmd1 = new MySqlCommand(Query1, MyConn1);
                MyConn1.Open();


                cmd1.Parameters.AddWithValue("?id", id);
                cmd1.Parameters.AddWithValue("?degree", dept);
                cmd1.Parameters.AddWithValue("?experience", exp);
                cmd1.Parameters.AddWithValue("?cgpa", cgpa);

                cmd1.ExecuteNonQuery();
                MyConn1.Close(); 
               
                

            }

            MessageBox.Show("All info Saved");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HR_Arena hr_arena = new HR_Arena();
            hr_arena.Show();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection = "datasource=localhost;port=3306;username=root;password=root";
                string Query = "delete from test.skill ;";
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
                string Query3 = "delete from test.qualifications ;";
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
    }
}
