using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mouse
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
                // 2次元クラスPoint型の変数cposを宣言
                Point cpos;

                // cposに、マウスのフォーム座標を取り出す
                cpos = this.PointToClient(MousePosition);

                // ラベル(フォーム)にマウス座標を表示
                Text = "" + cpos.X + "," + cpos.Y;

                // マウス座標にラベルをくっつけてみよう
                label1.Left = cpos.X;
                label1.Top = cpos.Y;
                int vx = int.Parse(textBox1.Text);
                int vy = int.Parse(textBox2.Text);

                label2.Left = label2.Left + vx;
                label2.Top = label2.Top + vy;

                if ((label2.Left < 0) || (label2.Right > ClientSize.Width))
                {
                    label2.Left -= vx;
                    textBox1.Text = (-vx).ToString();
                }
                if ((label2.Top < 0) || (label2.Bottom > ClientSize.Height))
                {
                    label2.Top -= vy;
                    textBox2.Text = (-vx).ToString();
                }
                if ((label2.Left >= cpos.X) && (label1.Right + cpos.X > ClientSize.Width))
                {
                    label2.Left = label1;
                }
                if ((label2.Top >= cpos.Y) && (label1.Bottom + cpos.Y > ClientSize.Height))
                {
                    label2.Top = label1;
                }
                /*if (label1.Right > ClientSize.Width)
                {
                    textBox1.Text = "-10";
                    textBox2.Text = "1";
                }*/
                /*if (label1.Bottom >ClientSize.Height)
                {
                    textBox1.Text = "1";
                    textBox2.Text = "-10";
                }*/
            }
            catch (Exception ee)
            {
   
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = "-10";
            label2.Text = "0";
        }
    }
}
