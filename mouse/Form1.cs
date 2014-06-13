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
        int iVelX = rand.Next(-10, 11);
        int iVelY = rand.Next(-10, 11);
        private static Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
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
                if ((label2.Top < 0) || (label2.Top + label2.Height > ClientSize.Height))
                {
                    // 上下反転させる
                    label2.Top -= vy;
                    iVelY = -vy;
                }

                // ラベルに当たり判定をつける
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
                       iVelX = 0;
                       iVelY = 0;
                   }
                

            }
            catch (Exception ee)
            {
            }



        }
    }
}
