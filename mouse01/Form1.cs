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
        const int TEKI_MAX = 10;
        int time;
        int a;

        Label[] chrs = new Label[TEKI_MAX];
        int[] iVX = new int [TEKI_MAX];
        int[] iVY = new int[TEKI_MAX];

        int iVelX = rand.Next(-60,80);
        int iVelY = rand.Next(-60,80);
        private static Random rand = new Random();

        //コンストラクタ
        //Form1クラスが生成される時に実行する
        //特別な関数
        public Form1()
        {
            time = 100;
            a = 0;
            InitializeComponent();

            //ラベル生成
            for (int i = 0; i < TEKI_MAX; i++)
            {
                chrs[i] = new Label();
                chrs[i].AutoSize = true;//ミソ
                chrs[i].Text = "うらあああああああ";
                chrs[i].Left = rand.Next(ClientSize.Width);
                chrs[i].Font = new Font("HGS創英角ﾎﾟｯﾌﾟ体", 16);
                chrs[i].ForeColor = Color.FromArgb(0, 150, 190);
                chrs[i].Top = rand.Next(ClientSize.Height);
                Controls.Add(chrs[i]);//フォーム追加

                iVX[i] = rand.Next(-20, 21);
                iVY[i] = rand.Next(-20, 21);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((a != TEKI_MAX) && (time > 0))
            {
                time--;
                label4.Text = "Time:" + time;
            }
            if (time == 0)
            {
                label3.Text = "GameOver";
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

                //　左にオーバーした時
                //　「あるいは」
                // 　右にオーバーした時
                if ((label2.Left <= 0) || (label2.Right >= ClientSize.Width))
                {
                    //　左右反転させる
                    label2.Left -= vx;
                    iVelX = -vy;
                }
                //上下反転
                if ((label2.Top <= 0) || (label2.Bottom >= ClientSize.Height))
                {
                    label2.Top -= vy;
                    iVelY = -vy;
                }

                //ラベルを動かす
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
                    if ((chrs[i].Left <= 0) || (chrs[i].Right >= ClientSize.Width))
                    {
                        chrs[i].Left -= iVX[i];
                        iVX[i] = -iVX[i];
                    }
                    if ((chrs[i].Top <= 0) || (chrs[i].Bottom >= ClientSize.Height))
                    {
                        chrs[i].Top -= iVY[i];
                        iVY[i] = -iVY[i];
                    }

                    //マウスとの当たり判定
                    if ((chrs[i].Top <= cpos.Y) && (chrs[i].Top + chrs[i].Height >= cpos.Y))
                    {
                        if ((chrs[i].Left <= cpos.X) && (chrs[i].Left + chrs[i].Width >= cpos.X))
                        {
                            iVX[i] = 0;
                            iVY[i] = 0;
                            chrs[i].Visible = false;
                            a = a + 1;
                            if (a == TEKI_MAX)
                            {
                                label3.Text = "クリア";
                            }

                            /*無理やり止める
                            iVX[i] = iVX[i] - iVX[i];
                            iVY[i] = iVY[i] - iVY[i];*/

                        }
                    }


                    //ぶつかったら止まる:速度が０になればよい
                    if ((label2.Top <= cpos.Y) && (label2.Top + label2.Height >= cpos.Y))
                    {
                        if ((label2.Left <= cpos.X) && (label2.Left + label2.Width >= cpos.X))
                        {
                            iVelX = 0;
                            iVelY = 0;
                            label1.Text = "つっかまえた！！";

                            //chrs[i].Visible = false;

                            //マウスカーソルと重なったら
                            //タイマー停止　or 表情変更

                            // cpos.X : マウスX座標
                            // cpos.Y : マウスのY座標
                            // if((条件１) && (条件２) && (条件３) && (条件４))
                            //→条件１～４まで全部成立した時のif文
                            // label2とcposの関係を確認する
                            //条件1:cpos.Xは、label2.Left以上
                            //条件2:cpos.Xは、label2.Left+label2.Width未満
                            //条件3:cpos.Yは、label2.Top以上
                            //条件4:cpos.Yは、label2.Top+label2.Height未満
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
            /*//int型の配列変数３つを定義
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
            MessageBox.Show(iar[i].ToString());*/
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
        }
    }
}
