﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mausu
{
    public partial class Form1 : Form
    {
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
            //ラベル(フォーム)にマウス座標を表示
            Text = "" + cpos.X + "," + cpos.Y;
            label1.Top = cpos.Y;
            label1.Left = cpos.X;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
