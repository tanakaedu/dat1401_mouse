using System;
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
           try
           {
            //2次元クラスPoint型の変数cposを宣言
            Point cpos;
            //cposに、マウスのフォーム座標を取り出す
            cpos = this.PointToClient(MousePosition);
            //ラベル(フォーム)にマウス座標を表示
            Text = "" + cpos.X + "," + cpos.Y;
            label1.Top = cpos.Y;
            label1.Left = cpos.X;

            int vx = int.Parse(textBox1.Text);
            int vy = int.Parse(textBox2.Text);

            // textBoxからintの変数に値を取得
            label2.Left = label2.Left + vx;
            label2.Top = label2.Top + vy;

            if ((label2.Left < 0) || (label2.Left + label2.Width > ClientSize.Width))
            {
                label2.Top -= vx;
                textBox1.Text = (-vx).ToString();
            }
            if ((label2.Top < 0) || (label2.Top + label2.Height > ClientSize.Height))
            {
                label2.Top -= vy;
                textBox2.Text = (-vy).ToString();
            }

            if ((label2.Left < cpos.X) && (label2.Left + label2.Width > cpos.X) && (label2.Top < cpos.Y) && (label2.Top + label2.Height > cpos.Y))
            {
                textBox1.Text = "0";
                textBox2.Text = "0";
                label2.Text = "ΣｱﾎﾞｰﾝЗ";
                label1.Text = "ﾋﾃﾞﾌﾞｯ!!";
            }
         
            }
            catch (Exception ee)
            {
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "10";
            textBox2.Text = "0";
            label2.Text = "[C4]";
            label1.Text = "(∵)";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "50";
            textBox2.Text = "10";
            label2.Text = "[C4]";
            label1.Text = "(∵)";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "67";
            textBox2.Text = "-10";
            label2.Text = "[C4]";
            label1.Text = "(∵)";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "100";
            textBox2.Text = "-60";
            label2.Text = "[C4]";
            label1.Text = "(∵)";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "214";
            textBox2.Text = "-58";
            label2.Text = "[C4]";
            label1.Text = "(∵)";
        }
    }
}
