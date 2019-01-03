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
    public partial class Choose_Field_Admin : Form
    {
        public Choose_Field_Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_arenacs adminarena = new Admin_arenacs();
            adminarena.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_arena_civil adminarenacivil = new Admin_arena_civil();
            adminarenacivil.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_arena_ee adminarenaee = new Admin_arena_ee();
            adminarenaee.Show();
        }
    }
}
