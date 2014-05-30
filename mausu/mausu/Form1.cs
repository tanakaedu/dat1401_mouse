using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mausu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point cpos;

            cpos = this.PointToClient (MousePosition);

            Text = "" + cpos.X + "," + cpos.Y;
            label1.Left=cpos.X;
            label1.Top=cpos.Y;
        }

        private void label1_Click(object sender, EventArgs e)
        {   

        }
    }
}
