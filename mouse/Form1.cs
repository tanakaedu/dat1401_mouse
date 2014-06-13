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


        private static Random rand = new Random();
        int iVelX = rand.Next(100);
        int iVelY = rand.Next(100);
        int iVelX2 = rand.Next(100);
        int iVelY2 = rand.Next(100);

    
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

                int vx = iVelX + 50;
                int vy = iVelY + 50;

                int vx2 = iVelX2 + 80;
                int vy2 = iVelY2 + 80;


                label3.Left = label3.Left + vx;
                label3.Top = label3.Top + vy;
                label2.Left = label2.Left + vx2;
                label2.Top = label2.Top + vy2;
                //ラベルの反射:ラベル1
                if ((label3.Left < 0) || (label3.Left + label3.Width > ClientSize.Width))
                {
                    label3.Left -= vx;
                    iVelX = -vx;
                }

                if ((label3.Top < 0) || (label3.Top + label3.Height > ClientSize.Height))
                {
                    label3.Top -= vy;
                    iVelY = -vy;
                }

                if ((label3.Left < cpos.X) && (label3.Left + label3.Width > cpos.X) && (label3.Top < cpos.Y) && (label3.Top + label3.Height > cpos.Y))
                {

                    iVelX = 0;
                    iVelY = 0;

                //ラベルの反射：ラベル2
                }
                if ((label2.Left < 0) || (label2.Left + label2.Width > ClientSize.Width))
                {
                    label2.Left -= vx2;
                    iVelX2 = -vx2;
                }

                if ((label2.Top < 0) || (label2.Top + label2.Height > ClientSize.Height))
                {
                    label2.Top -= vy2;
                    iVelY2 = -vy2;
                }

                if ((label2.Left < cpos.X) && (label2.Left + label2.Width > cpos.X) && (label2.Top < cpos.Y) && (label2.Top + label2.Height > cpos.Y))
                {

                    iVelX2 = 0;
                    iVelY2 = 0;

                }

                //反射試し
                if ((label2.Left == label3.Left + label3.Width) || (label2.Left + label2.Width == label3.Left))
                {
                    /*label3.Left -= vx;
                    iValX = (-vx);
                    label2.Left -= vx2;
                    iValX = (-vx2);*/
                }
                /*if ((label2.Top < label3.Top + label3.Height) || (label3.Top > label2.Top + label2.Height))
                {
                    label3.Top -= vy;
                    iValY = -vy;
                    label2.Top -= vy2;
                    iValY = -vy2;
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
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            iVelX = 0;
            iVelY = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            iVelX2 = 10;
            iVelY2 = 10;
        }


    }
}
