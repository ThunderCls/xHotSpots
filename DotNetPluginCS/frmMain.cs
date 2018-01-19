using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetPlugin
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            cmbCompiler.SelectedIndex = 0;
        }

        private void btnLocateHS_Click(object sender, EventArgs e)
        {
            int result = HotSpot.LocateHotSpot((HotSpot.COMPILER_TYPE)cmbCompiler.SelectedIndex, this);
            tFound.Text = result.ToString();
            if (result > 0)
                MessageBox.Show("HotSpots are successfully located, watch the breakpoints widget to manage them", "Success!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("HotSpots couldn't be located, be sure that you've selected the correct compiler for the debugged application", "Not Found!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }  
    }
}
