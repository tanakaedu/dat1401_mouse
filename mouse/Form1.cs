using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mouse
{
    public partial class Form1 : Form
    {
        const int Enemy_Max = 10;

        int enemynum;
        int time;

        Label[] chrs = new Label[Enemy_Max];
        int[] iVX = new int[Enemy_Max];
        int[] iVY = new int[Enemy_Max];

        int iVelX = rand.Next(-15,16);
        int iVelY = rand.Next(-15,16);

        private static Random rand = new Random();

        // コンストラクタ
        // Form1クラスが生成されるときに実行する
        // 特別な関数
        public Form1()
        {
            int i;

            enemynum = Enemy_Max;
            time = 0;

            InitializeComponent();

            // ラベルの生成
            for (i = 0; i < Enemy_Max; i++)
            {
                chrs[i] = new Label();
                chrs[i].AutoSize = true; // ミソ
                chrs[i].Text = "（*^_^*）";
                chrs[i].Left = rand.Next(ClientSize.Width);
                chrs[i].Top = rand.Next(ClientSize.Height);
                // chrs[i].Font = new Font("フォント名", サイズ); // フォントの変更
                // chrs[i].ForeColor = Color.FromArgb(R, G, B); //フォントカラー
                Controls.Add(chrs[i]); // フォームに追加

                iVX[i] = rand.Next(-20, 21);
                iVY[i] = rand.Next(-20, 21);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (enemynum > 0)
                {
                    time++;
                    label3.Text = "Time:" + time;
                }

                // textBoxからintの変数に値を取得
                int vx = iVelX;
                int vy = iVelY;

                // 2次元クラスPoint型の変数cposを宣言
                Point cpos;

                // cposに、マウスのフォーム座標を取り出す
                cpos = this.PointToClient(MousePosition);

                // ラベル(フォーム)にマウス座標を表示
                Text = "" + cpos.X + "," + cpos.Y;

                // マウス座標にラベルをくっつけてみよう
                label1.Left = cpos.X;
                label1.Top = cpos.Y;

                // ラベル2の移動
                label2.Left = label2.Left + vx;
                label2.Top = label2.Top + vy;

                // ラベルが左右オーバーした時
                if ((label2.Left < 0) || (label2.Left + label2.Width > ClientSize.Width))
                {
                    // 左右反転させる
                    label2.Left -= vx;
                    iVelX = -vx;
                }
                // ラベルが上下オーバーした時
                if ((label2.Top < 0) || (label2.Top + label2.Height> ClientSize.Height))
                {
                    // 上下反転させる
                    label2.Top -= vy;
                    iVelY = -vy;
                }

                /*// ラベルに当たり判定をつける
                if ((label2.Left < cpos.X) && (label2.Left + label2.Width > cpos.X))
                {
                    iVelX = 0;
                    iVelY = 0;
                }
                if ((label2.Top < cpos.Y) && (label2.Top + label2.Height > cpos.Y))
                {
                    iVelX = 0;
                    iVelY = 0;
                }
                */
                // マウスカーソルと重なったら
                // タイマー停止 or 表情変更
                
                // cpos.X：マウスのX座標
                // cpos.Y：マウスのY座標
                // if ((条件1) && (条件2) && (条件3) && (条件4))
                // →条件1～4まで全部成立した時のif文
                // label2とcposの関係を確認する
                // 条件1：cpos.Xは、label2.Left以上
                // 条件2：cpos.Xは、label2.Left + label2.Width未満
                // 条件3：cpos.Yは、label2.Top以上
                // 条件4：cpos.Yは、label2.Top + label2.Height未満
                if (    (cpos.X >= label2.Left)
                     && (cpos.X < label2.Left + label2.Width)
                     && (cpos.Y >= label2.Top)
                     && (cpos.Y < label2.Top + label2.Height))
                   {
                        // 止める:速度が0になればよい
                       label2.Visible = false;
                   }
                   
                   // ラベルを動かす
                for (int i = 0; i < Enemy_Max; i++)
                {
                    // キャラクタが有効か
                    if (chrs[i].Visible == false)
                    {
                        continue;
                    }

                    // ラベルの移動
                    chrs[i].Left += iVX[i];
                    chrs[i].Top += iVY[i];

                    // ラベルの跳ね返り
                    if ((chrs[i].Left < 0) || (chrs[i].Left + chrs[i].Width > ClientSize.Width))
                    {
                        // 左右反転させる
                        chrs[i].Left -= vx;
                        iVX[i] = -vx;
                    }
                    // ラベルが上下オーバーした時
                    if ((chrs[i].Top < 0) || (chrs[i].Top+ chrs[i].Height > ClientSize.Height))
                    {
                        // 上下反転させる
                        chrs[i].Top -= vy;
                        iVY[i] = -vy;
                    }

                    // マウスとの当たり判定
                    if ((cpos.X >= chrs[i].Left)
                     && (cpos.X < chrs[i].Left + chrs[i].Width)
                     && (cpos.Y >= chrs[i].Top)
                     && (cpos.Y < chrs[i].Top + chrs[i].Height))
                    {
                        // 消す
                        chrs[i].Visible = false;
                        enemynum--;
                    }
                    if (enemynum == 0)
                    {
                        MessageBox.Show("Clear");
                    }
                }
            }
            catch (Exception ee)
            {
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            // int型の配列変数3つを定義
            int[] iar = new int[3];
            // []の中に添え字を入れることで、
            // 別の場所にアクセスできる
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
