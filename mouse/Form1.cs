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
        //int a = 0;
        int ivalX = 10;
        int iValY = 10;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //2次元クラスPoint型の変数cposを宣言
            Point cpos;

            //cposに、マウスのフォーム座標を取り出す
            cpos = this.PointToClient(MousePosition);

            //フォームにマウス座標を表示
            Text = "" + cpos.X + "," + cpos.Y;

            label1.Left = cpos.X;
            label1.Top = cpos.Y;

            //ラベル2の移動
            try
            {

                int vx = int.Parse(textBox1.Text);
                int vy = int.Parse(textBox2.Text);

                int vx2 = int.Parse(textBox3.Text);
                int vy2 = int.Parse(textBox4.Text);


                label3.Left = label3.Left + vx;
                label3.Top = label3.Top + vy;
                label2.Left = label2.Left + vx2;
                label2.Top = label2.Top + vy2;
                //ラベルの反射:ラベル1
                if ((label3.Left < 0) || (label3.Left + label3.Width > ClientSize.Width))
                {
                    label3.Left -= vx;
                    textBox1.Text = (-vx).ToString();
                }

                if ((label3.Top < 0) || (label3.Top + label3.Height > ClientSize.Height))
                {
                    label3.Top -= vy;
                    textBox2.Text = (-vy).ToString();
                }

                if ((label3.Left < cpos.X) && (label3.Left + label3.Width > cpos.X) && (label3.Top < cpos.Y) && (label3.Top + label3.Height > cpos.Y))
                {
                   /* a += 10;
                    textBox1.Text = a.ToString();
                    textBox2.Text = a.ToString();
                    */
                    textBox1.Text = "0";
                    textBox2.Text = "0";

                //ラベルの反射：ラベル2
                }
                if ((label2.Left < 0) || (label2.Left + label2.Width > ClientSize.Width))
                {
                    label2.Left -= vx2;
                    textBox3.Text = (-vx2).ToString();
                }

                if ((label2.Top < 0) || (label2.Top + label2.Height > ClientSize.Height))
                {
                    label2.Top -= vy2;
                    textBox4.Text = (-vy2).ToString();
                }

                if ((label2.Left < cpos.X) && (label2.Left + label2.Width > cpos.X) && (label2.Top < cpos.Y) && (label2.Top + label2.Height > cpos.Y))
                {
                    /* a += 10;
                    textBox1.Text = a.ToString();
                    textBox2.Text = a.ToString();
                    */
                    textBox3.Text = "0";
                    textBox4.Text = "0";

                }

                //反射試し
                if ((label2.Left == label3.Left + label3.Width) || (label2.Left + label2.Width == label3.Left))
                {
                    label3.Left -= vx;
                    textBox1.Text = (-vx).ToString();
                    label2.Left -= vx2;
                    textBox3.Text = (-vx2).ToString();
                }
                /*if ((label2.Top < label3.Top + label3.Height) || (label3.Top > label2.Top + label2.Height))
                {
                    label3.Top -= vy;
                    textBox2.Text = (-vy).ToString();
                    label2.Top -= vy2;
                    textBox4.Text = (-vy2).ToString();
                }*/
            }

            catch (Exception ee)
            {
            }
        }
            


        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            a = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "0";
            textBox4.Text = "0";
            a = 0;
        }


    }
}
