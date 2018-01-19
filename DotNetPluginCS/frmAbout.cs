using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace xHotSpots
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Process.Start(label2.Text);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Process.Start(label6.Text);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Process.Start(label7.Text);
        }
    }
}
