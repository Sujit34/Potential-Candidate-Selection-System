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
    public partial class Admin_arena_ee : Form
    {
        public Admin_arena_ee()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Login adlog = new Admin_Login();
            adlog.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Requirement_ee addrequirementee = new Add_Requirement_ee();
            addrequirementee.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_HR hrdetail = new View_HR();
            hrdetail.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            view_job_ee viewjobee = new view_job_ee();
            viewjobee.Show();
        }
    }
}
