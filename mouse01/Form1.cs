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

                if ((label2.Top <= 0) || (label2.Bottom >= ClientSize.Height))
                {
                    label2.Top -= vy;
                    iVelY = -vy;
                }
            }
            catch (Exception ee)
            {
            }
                //ぶつかったら止まる:速度が０になればよい
                if ((label2.Top <= cpos.Y) && (label2.Top+label2.Height >= cpos.Y))
                {
                    if ((label2.Left <= cpos.X) && (label2.Left + label2.Width >= cpos.X))
                    {
                        iVelX = 0;
                        iVelY = 0;
                        label3.Text = "クリア！！";
                        label1.Text = "つっかまえた！！";

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
       
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
