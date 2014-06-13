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

        int iValX = 10;
        int iValY = 10;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //2次元クラスPoint型の変数cposを宣言
            Point cpos;
            // cposに、マウスのフォーム座標を取り出す
            cpos = this.PointToClient(MousePosition);

            // フォームにマウス座標を表示
            Text = "" + cpos.X + "," + cpos.Y;
            label1.Left = cpos.X;
            label1.Top = cpos.Y;

            //ラベル2の移動
            try
            {
                int vx = int.Parse(textBox1.Text);
                int vy = int.Parse(textBox2.Text);

                // ラベルの座標に加算
                label2.Left = label2.Left + vx;
                label2.Top = label2.Top + vy;
                if ((label2.Left < 0) || (label2.Left + label2.Width > ClientSize.Width))
                {
                    label2.Left -= vx;
                    textBox1.Text = (-vx).ToString();
                }
                if ((label2.Top < 0) || (label2.Top + label2.Height > ClientSize.Height))
                {
                    label2.Top -= vy;
                    textBox2.Text = (-vy).ToString();
                }
                if ((label2.Left < cpos.X) && (label2.Left + label2.Width > cpos.X)&&(label2.Top < cpos.Y) && (label2.Top + label2.Height > cpos.Y))
                {
                    //a+=5;
                    textBox1.Text = "0";//a.ToString();
                    textBox2.Text = "0";//a.ToString();
                    label2.Text = "j(´-｀)しﾀｶｼ";
                }
                /*if (a > 1000)
                {
                    a = 0;
                }
               if ((label2.Left<label3.Left)&&(label2.Left +label2.Width > label3.Left+label3.Width)&&(label2.Top<label3.Top)&&(label2.Top+label2.Height >label3.Top+label3.Height))
                {
                    textBox1.Text = (-vx).ToString();
                    textBox2.Text = (-vy).ToString();
                }*/               
            }
            catch (Exception ee)
            {
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text ="50";
            textBox2.Text ="50";
            label2.Text = "j(´-｀)しﾂｶﾚﾀﾜ";
            a = 0;
        }
    }
}
