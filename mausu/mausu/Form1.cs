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
            try
            {
                int vx = int.Parse(textBox1.Text);
                int vy = int.Parse(textBox2.Text);
                label2.Left = label2.Left + vx;
                label2.Top = label2.Top + vy;
                
                
                if (label2.Left < 0)
                {
                    textBox1.Text = "15";
                }
                if (label2.Top < 0)
                {
                    textBox2.Text = "15";
                }
                if (label2.Left + label2.Width > ClientSize.Width)
                {
                    label2.Left -= vx;
                    textBox1.Text = (-vx).ToString();
                }
                if (label2.Top + label2.Height > ClientSize.Height)
                {
                    label2.Top -= vy;
                    textBox2.Text = (-vy).ToString();
                }
                
                Point cpos;

                cpos = this.PointToClient(MousePosition);

                Text = "" + cpos.X + "," + cpos.Y;
                label1.Left = cpos.X;
                label1.Top = cpos.Y;
            }

            catch (Exception ee)
            { 
            }
           }

        private void label1_Click(object sender, EventArgs e)
        {   

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
