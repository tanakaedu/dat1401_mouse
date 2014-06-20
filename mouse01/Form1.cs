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
        const int TEKI_MAX = 2;

        int time;
        int aaa;

        Label[] chrs = new Label[TEKI_MAX];
        int[] iVX = new int[TEKI_MAX];
        int[] iVY = new int[TEKI_MAX];
        
        

        int iVelX = rand.Next(10);
        int iVelY = rand.Next(10);
        private static Random rand = new Random();

        public Form1()
        {
            //コンストラクタ
            //form1クラスが生成されるときに実行する
            //特別な関数
            InitializeComponent();
            time = 0;
            aaa = TEKI_MAX;
            label4.Text = aaa.ToString();



            //ラベルの生成
            for (int i = 0; i < TEKI_MAX; i++)
            {
                chrs[i] = new Label();
                chrs[i].AutoSize = true; //ミソ
                chrs[i].Text = "ひぃ～～";
                chrs[i].Left = rand.Next(ClientSize.Width);
                chrs[i] .Top = rand.Next(ClientSize.Height);
                Controls.Add(chrs[i]);//フォームに追加
                chrs[i].Font = new Font("HGP創英角ﾎﾟｯﾌﾟ体", 45);
                chrs[i].ForeColor = Color.FromArgb(64,126,0);

                iVX[i] = rand.Next( 5,6);
                iVY[i] = rand.Next( 5,6);

            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (aaa>0)
            {
            time++;
            label5.Text = "Time:" + time;
            }

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
                if ((label2.Left < 0) || (label2.Left + label2.Width > ClientSize.Width))
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


                    label2.Text = "つかまった～";
                }
            }
            //シビアに止まる
            /*if ((label1.Left == label2.Left)||(label1.Top==label2.Top)) 
            {
                textBox1.Text = "0";
                textBox2.Text = "0";
            }*/

            //量産ラベルを動かす
            for (int i = 0; i < TEKI_MAX; i++)
            {
                if (chrs[i].Visible == false)
                {
                    continue;
                }
                //ラベルの移動
                chrs[i].Left += iVX[i];
                chrs[i].Top += iVY[i];
                //ラベルの跳ね返り
                chrs[i].Left = chrs[i].Left ;
                chrs[i].Top = chrs[i].Top ;
                if ((chrs[i].Left < 0) || (chrs[i].Left + chrs[i].Width > ClientSize.Width))
                {
                    //左右反転させる
                    chrs[i].Left -= iVX[i];
                    iVX[i] = -iVX[i];
                }

                if ((chrs[i].Top < 0) || (chrs[i].Bottom > ClientSize.Height))
                {
                    //上下反転させる
                    chrs[i].Top -= iVY[i];
                    iVY[i] = -iVY[i];
                }
                //マウスとの当たり判定
                if ((chrs[i].Left <= cpos.X) && (chrs[i].Left + chrs[i].Width >= cpos.X))
                {
                    if ((chrs[i].Top <= cpos.Y) && (chrs[i].Top + chrs[i].Height >= cpos.Y))
                    {
                        iVX[i] = 0; 
                        iVY[i] = 0;
                        aaa--;
                        label4.Text = aaa.ToString();
                        

                        chrs[i].Visible = false;
                        
                    }
                }
                /*if (iVX[i] == 0)
                {
                    aaa = aaa - 1;
                    label4.Text = aaa.ToString();
                }*/
                if (aaa == 0)
                {
                     label3.Text = "クリア!!";
                }
            }

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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
