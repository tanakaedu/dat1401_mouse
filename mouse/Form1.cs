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
        int iVelX = 10;
        int iVelY = 10;

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
                int vx = iVelX;
                int vy = iVelY;

                label2.Left +=  vx;
                label2.Top +=   vy;

                //反射
                if ((label2.Left < 0) || (label2.Left+label2.Width >  ClientSize.Width))
                {
                   //左右反転
                    label2.Left -= vx;
                    iVelX = -vx;
                }
                if ((label2.Top < 0) || (label2.Top + label2.Height >  ClientSize.Height))
                {
                    //上下反転
                    label2.Top -= vy;
                    iVelY = -vy;
                }

                //cpos.x:マウスのX座標
                //cpos.y:マウスのY座標
                //if((条件１）＆＆（条件２）＆＆（条件３）＆＆（じょうけん４）
                //→条件1から４まで全部成立したときのif文
                //条件1cpos.xは.label2.left以上
                //条件２cpos.xは.label2.left+label2.Wideth未満
                //条件３cpos.ｙは.label2.Top以上
                //条件４cpos.ｙは.label2.Top+label2.Height未満
                if(     ( cpos.X >= label2.Left ) 
                    && (cpos.X < label2.Left+label2.Width)
                    && (cpos.Y >= label2.Top  ) 
                    && (cpos.Y < label2.Top+label2.Height))
                {
                    iVelX = 0;
                    iVelY = 0;
                }

            }
            /*
             
             if (label1.Right > ClientSize.Width)
            {
                textBox1.Text = "-10";
                textBox2.Text = "1";
            }
            if (label1.Bottom >ClientSize.Height)
            {
                textBox1.Text = "1";
                textBox2.Text = "-10";
            }*/
            
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
