using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mouse01
{
    public partial class Form1 : Form
    {
        int iVelX = rand.Next(10,30);
        int iVelY = rand.Next(10,30);
        private static Random rand = new Random();

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

            try
            {
                //textBoxからintの変数の値を取得
                int vx = iVelX;
                int vy = iVelY;
                //ラベルの座標に加算
                label2.Left = label2.Left + vx;
                label2.Top = label2.Top + vy;
                if ((label2.Left <= 0) || (label2.Left + label1.Width >= ClientSize.Width))
                {
                    //左右反転させる
                    label2.Left -= vx;
                    iVelX = -vx;
                }

                if ((label2.Top < 0) || (label2.Bottom > ClientSize.Height))
                {
                    //上下反転させる
                    label2.Top -= vy;
                    iVelY = -vy;
                }
            }
            catch (Exception ee)
            {

            }//終わり
            
            //条件1:cpos.Xは、label2.leftより大きい
            //条件2:cpos.Xは、label2.left+label2.width未満
            //条件3:cpos.Yは、label2.topより大きい
            //条件4:cpos.Yは、label2.top+label2.height未満
            if ((label2.Left <= cpos.X) && (label2.Left + label2.Width >= cpos.X))
            {
                if((label2.Top <= cpos.Y) && (label2.Top + label2.Height >= cpos.Y))
                {
                    iVelX = 0;
                    iVelY = 0;

                    label3.Text = "クリア！！";
                    label2.Text = "つかまった～";
                }
            }
            //シビアに止まる
            /*if ((label1.Left == label2.Left)||(label1.Top==label2.Top)) 
            {
                textBox1.Text = "0";
                textBox2.Text = "0";
            }*/
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
