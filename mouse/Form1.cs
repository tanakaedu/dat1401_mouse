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
        }
    }
}
