using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ramon5_30
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //2次元クラスPoint型の変数cposを
            Point cpos;

            cpos = this.PointToClient(MousePosition);


            Text = "" + cpos.X + "," + cpos.Y;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Point bottone;


            bottone = this.PointToClient(MousePosition);


            Text = "" + bottone.X + "," + bottone.Y;
        }
    }
}
