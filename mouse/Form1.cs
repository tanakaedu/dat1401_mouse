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
        Label[] chrs = new Label[100];
        int[] iVX = new int[100];
        int[] iVY = new int[100];
        
        int iVelX = rand.Next(10);
        int iVelY = rand.Next(10);

        private static Random rand = new Random();

        //コンストラスタ
        //Form1クラスが生成されるときに実行
        //特別な関数
        public Form1()
        {
            InitializeComponent();
            
            //ラベルの生成
            for (int i = 0; i < 100; i++)
            {
                chrs[i] = new Label();
                chrs[i].AutoSize = true; //ミソ
                chrs[i].Text = "(▼皿▼ノノ)";
                chrs[i].Left = rand.Next(ClientSize.Width);
                chrs[i].Top = rand.Next(ClientSize.Height);
                Controls.Add(chrs[i]);//フォームに追加

                iVX[i] = rand.Next(100);
                iVY[i] = rand.Next(100);
            }
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
            
            catch (Exception )
            {

            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int型の配列変数3つを定義
            int[] iar = new int[3];
            //[]の中に租添え字をいれることで
            //別の場所にアクセスできる
            iar[0] = 0;
            iar[1] = 1;
            iar[2] = 2;
            MessageBox.Show(iar[0].ToString());
            MessageBox.Show(iar[1].ToString());
            MessageBox.Show(iar[2].ToString());
            int i = 0;
            MessageBox.Show(iar[i].ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < 10; i++)
            {
                if (i < 3)
                {
                    continue;
                }
                if (i >= 6)
                {
                    break;
                }
                MessageBox.Show(i.ToString());
                MessageBox.Show("iは" + i);
            }
        }

    }
}
