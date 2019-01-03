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
    public partial class Choose_Field_HR : Form
    {
        public Choose_Field_HR()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HR_Arena HRarena = new HR_Arena();
            HRarena.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            HR_Arena_Civil civilHRarena = new HR_Arena_Civil();
            civilHRarena.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            HR_Arena_ee eeHRarena = new HR_Arena_ee();
            eeHRarena.Show();
        }
    }
}
