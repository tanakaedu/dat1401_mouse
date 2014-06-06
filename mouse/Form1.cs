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

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        //---------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            //2次元クラスPoint型の変数cposを宣言
            Point cpos;

            //cposにマウスのフォーム座標を取り出す
            cpos = this.PointToClient(MousePosition);

            //フォームにマウス座標を表示
            Text= "" + cpos.X + "." + cpos.Y;

            //マウス座標にラベルをくっつける。
            label1.Left = cpos.X;
            label1.Top = cpos.Y;


            //--------------------ラベル２移動-----------------------
            //ラベル2の移動
            int vx = int.Parse(textBox1.Text);
            int vy = int.Parse(textBox2.Text);

            //ラベルの座標に加算
            label2.Left = label2.Left + vx;
            label2.Top = label2.Top + vy;

            if ((label2.Left < 0) || (label2.Left + label2.Width > ClientSize.Width))
            {
                //左右反転
                label2.Left -= vx;
                textBox1.Text = (-vx).ToString();
            }
            else
            if ((label2.Top < 0) || (label2.Top + label2.Height > ClientSize.Height))
            {
                //上下反転
                label2.Top -= vy;
                textBox2.Text = (-vy).ToString();
            }

            //--------ラベル1と2

        
   
        

