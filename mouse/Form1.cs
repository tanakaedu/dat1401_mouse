﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 2次元クラスPoint型の変数cposを宣言
            Point cpos;

            // cposに、マウスのフォーム座標を取り出す
            cpos = this.PointToClient(MousePosition);

            // ラベル(フォーム)にマウス座標を表示
            Text = "" + cpos.X + "," + cpos.Y;

            // マウス座標にラベルをくっつけてみよう。
            label1.Left = cpos.X;
            label1.Top = cpos.Y;


            // ラベル2の移動
            int vx = int.Parse(textBox1.Text);
            int vy = int.Parse(textBox2.Text);
            label2.Left += vx;
            label2.Top += vy;

            // 跳ね返り
            if ((label2.Left < 0) || ((label2.Left + label2.Width) > ClientSize.Width))
            {
                label2.Left -= vx;
                textBox1.Text = (-vx).ToString();
            }
            if ((label2.Top < 0) || ((label2.Top + label2.Height) > ClientSize.Height))
            {
                label2.Top -= vy;
                textBox2.Text = (-vy).ToString();
            }
            

            // マウスカーソルと重なったら
            // タイマー停止 or 表情変更
            
            // cpos.x：マウスのX座標
            // cpos.y：マウスのY座標
            // if ((条件1) && (条件2) && (条件3) && (条件4))
            // →条件１～４まで全部成立した時のif文
            // label2とcposの関係を確認する
            // 条件1：cpos.xは、label2.Left以上
            // 条件2：cpos.xは、label2.Left+label2.Width未満
            // 条件3：cpos.yは、label2.Top以上
            // 条件4：cpos.yは、label2.Top+label2.Height未満
            if (    ()
                &&  ()
                &&  ()
                &&  ())
            {
            }

        }
    }
}
