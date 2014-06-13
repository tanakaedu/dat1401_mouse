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
                int vx = iVelX;
                int vy = iVelY;

                // ラベルの座標に加算
                label2.Left = label2.Left + vx;
                label2.Top = label2.Top + vy;
                if ((label2.Left < 0) || (label2.Left + label2.Width > ClientSize.Width))
                {
                    label2.Left -= vx;
                    iVelX = -vx;
                }
                if ((label2.Top < 0) || (label2.Top + label2.Height > ClientSize.Height))
                {
                    label2.Top -= vy;
                    iVelY = -vy;
                }
                if ((label2.Left < cpos.X) && (label2.Left + label2.Width > cpos.X)&&(label2.Top < cpos.Y) && (label2.Top + label2.Height > cpos.Y))
                {
                    iVelX = 0;
                    iVelY = 0;
                    label2.Text = "j(´-｀)しﾀｶｼ";
                }
               
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
            iVelX = 10;
            iVelY = 10;
            label2.Text = "j(´-｀)しﾂｶﾚﾀﾜ";
        }
    }
}