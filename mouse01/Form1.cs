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
        Label[] chrs = new Label[100];
        int[] iVX = new int[100];
        int[] iVY = new int[100];

        int iVelX = rand.Next(10,30);
        int iVelY = rand.Next(10,30);
        private static Random rand = new Random();

        public Form1()
        {
            //コンストラクタ
            //form1クラスが生成されるときに実行する
            //特別な関数
            InitializeComponent();



            //ラベルの生成
            for (int i = 0; i < 30; i++)
            {
                chrs[i] = new Label();
                chrs[i].AutoSize = true; //ミソ ;
                chrs[i].Text = "*****";
                chrs[i].Left = rand.Next(ClientSize.Width);
                chrs[i] .Top = rand.Next(ClientSize.Height);
                Controls.Add(chrs[i]);//フォームに追加

                iVX[i] = rand.Next(10, 20);
                iVY[i] = rand.Next(10, 20);

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

            try
            {
                //textBoxからintの変数の値を取得
                int vx = iVelX;
                int vy = iVelY;
                //ラベルの座標に加算
                label2.Left = label2.Left + vx;
                label2.Top = label2.Top + vy;
                if ((label2.Left < 0) || (label2.Left + label1.Width > ClientSize.Width))
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

        private void button1_Click(object sender, EventArgs e)
        {
            //int型の配列変数3つを定義
            int[] iar = new int[3];
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

        private void button2_Click(object sender, EventArgs e)
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
