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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //home btton
        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 home = new Form1();
            home.Show();
        }

        //login button
        private void Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Login adminlogin = new Admin_Login();
            adminlogin.Show();
        }

        private void Admin_Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Login adminlogin = new Admin_Login();
            adminlogin.Show();
        }

        private void HR_Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            HR_Login HRlogin = new HR_Login();
            HRlogin.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Login adminlogin = new Admin_Login();
            adminlogin.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HR_Login HRlogin = new HR_Login();
            HRlogin.Show();
        }
    }
}
