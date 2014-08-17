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

            label1.Left = cpos.X;
            label1.Top = cpos.Y;

            int vx = int.Parse(textBox1.Text);

            int vy = int.Parse(textBox2.Text);

            label2.Left = label2.Left + vx;
            label2.Top = label2.Top + vy;

            if ((label2.Left <= 0) || (label2.Left + label2.Width > ClientSize.Width))
            {
                label2.Left -= vx;
                textBox1.Text = (-vx).ToString();

            }


            if ((label2.Top <= 0) || (label2.Top + label2.Width > ClientSize.Width))
            {
                label2.Top -= vx;
                textBox1.Text = (-vx).ToString();

            }
            




            /*
            if ((label2.Left < cpos.X) && (label2.Left + label2.Width > cpos.X))
            {

                textBox1.Text = "0";
                textBox2.Text = "0";
             }
            if (label2.Top > cpos.Y && (label2.Top+label2.Height > cpos.Y))
            {
                textBox1.Text = "0";
                textBox2.Text = "0";
             }
             * */

        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {
        }


            


    }
}
