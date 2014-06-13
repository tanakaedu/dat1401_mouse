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
        Label[] chrs = new Label[10];
        int[] iVX = new int[10];
        int[] iVY = new int[10];


        int iVelX = rand.Next(100);
        int iVelY = rand.Next(100);
        private static Random rand = new Random();



        //コンストラクタ
        //Form1クラスが生成される時に実行する
        //特別な関数
        public Form1()
        {
            InitializeComponent();

            //ラベルの生成
            for (int i = 0; i < 10; i++)
            {
                chrs[i] = new Label();
                chrs[i].AutoSize = true; //ミソ
                chrs[i].Text = "＼(｀・ω・´)ゝ∠(｀・ω・´)／";
                chrs[i].Left = rand.Next(ClientSize.Width);
                chrs[i].Top = rand.Next(ClientSize.Height);
                Controls.Add(chrs[i]); //フォームの追加

                iVX[i] = rand.Next(100);
                iVY[i] = rand.Next(100);
            }
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

                int vx = iVelX ;
                int vy = iVelY ;
                label3.Left = label3.Left + vx;
                label3.Top = label3.Top + vy;

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
                }

                


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
            iVelX = 50;
            iVelY = 50;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //int型の配列変数3つ定義
            int[] iar = new int [3];
            //[]の中に添え字を入れることで、
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

        private void button4_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < 10; i++)
            {
                if (i < 3)
                {
                    continue;
                }
                MessageBox.Show(i.ToString());
                if (i >= 6)
                {
                    break;
                }
            }
            MessageBox.Show("iは" + i);
        }


    }
}
