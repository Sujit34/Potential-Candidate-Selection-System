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
    public partial class Admin_arena_civil : Form
    {
        public Admin_arena_civil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Requirement_civil addreqcivil = new Add_Requirement_civil();
            addreqcivil.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Login adminlogin = new Admin_Login();
            adminlogin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            view_job_civil viewjobcivil = new view_job_civil();
            viewjobcivil.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            view_HR_Civil viewhrcivil = new view_HR_Civil();
            viewhrcivil.Show();
        }
    }
}
