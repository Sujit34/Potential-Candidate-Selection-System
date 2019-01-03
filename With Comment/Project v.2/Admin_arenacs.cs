using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_v._2
{
    public partial class Admin_arenacs : Form
    {
        public Admin_arenacs()
        {
            InitializeComponent();
        }

        //Admin Requirement
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Requirement add = new Add_Requirement();
            add.Show();
        }

        //Logout
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Login ad_login = new Admin_Login();
            ad_login.Show();
        }

       /* private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Upload_CV upcv = new Upload_CV();
            upcv.Show();

        }*/

        /*private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HR_Detail hrdetail = new HR_Detail();
            hrdetail.Show();
        }*/

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_HR hrdetail = new View_HR();
            hrdetail.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            view_job jobdetail = new view_job();
            jobdetail.Show();
        }
    }
}
