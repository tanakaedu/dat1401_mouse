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
        const int TEKI_MAX = 50;

        int chrnum;
        int time;

        Label[] chrs = new Label[TEKI_MAX];
        int[] iVX = new int[TEKI_MAX];
        int[] iVY = new int[TEKI_MAX];

        
        int iVelX = rand.Next(-15,15);
        int iVelY = rand.Next(-15,15);
        private static Random rand = new Random();

        //コンストラクタ
        //Form1クラスが生成される時に実行する
        //特別な関数
        public Form1()
        {
            chrnum = TEKI_MAX;
            time = 0;

            InitializeComponent();
            
            //ラベルの生成
            for (int i = 0; i < TEKI_MAX; i++)
            {
                chrs[i] = new Label();
                chrs[i].AutoSize = true; //ミソ
                chrs[i].Text = "j(´-｀)し";
                chrs[i].Left = rand.Next(ClientSize.Width);
                chrs[i].Top = rand.Next(ClientSize.Height);
                chrs[i].Font = new Font("ＭＳ 明朝",12);
                chrs[i].ForeColor = Color.FromArgb(255, 0, 0);
                Controls.Add(chrs[i]); //フォームに追加

                iVX[i] = rand.Next(-100,99);
                iVY[i] = rand.Next(-100,99);
            }
        }

        private void timer1_Tick  (object sender, EventArgs e)
        {
            if(chrnum > 0)
            {
                time++;
                label5.Text = "Time:" + time;
            }
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
                if((label2.Left < cpos.X) && (label2.Left + label2.Width > cpos.X) && (label2.Top < cpos.Y) && (label2.Top + label2.Height > cpos.Y))
                {
                    iVelX = rand.Next(-20,20);
                    iVelY = rand.Next(-20,0);
                }

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
                    if ((chrs[i].Left<0)||(chrs[i].Left+chrs[i].Width>ClientSize.Width))
                    {
                        chrs[i].Left -= iVX[i];
                        iVX[i] = -iVX[i];
                    }
                    if ((chrs[i].Top < 0) || (chrs[i].Top + chrs[i].Height > ClientSize.Height))
                    {
                        chrs[i].Left -= iVY[i];
                        iVY[i] = -iVY[i];
                    }
                    //マウスとの当たり判定
                    if ((chrs[i].Left < cpos.X) && (chrs[i].Left + chrs[i].Width > cpos.X) && (chrs[i].Top < cpos.Y) && (chrs[i].Top + chrs[i].Height > cpos.Y))
                    {
                        //iVX[i] = 0;//rand.Next(-99, 100);
                        //iVY[i] = 0;//rand.Next(-99, 100);
                        chrs[i].Visible = false;
                        chrnum--;
                        label4.Text = chrnum.ToString();
                        if (chrnum == 0)
                        {
                            label3.Visible = true;
                        }
                    }
                    

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
            iVelX = rand.Next(15);
            iVelY = rand.Next(15);
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}