using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace mouse
{
    public partial class Form1 : Form
    {
        // 状態遷移関連
        // 無効シーン
        const int SC_NONE = -1;
        // 起動
        const int SC_BOOT = 0;
        // タイトルシーン
        const int SC_TITLE = 1;
        // ゲームシーン
        const int SC_GAME = 2;
        // ゲームオーバー
        const int SC_GAMEOVER = 3;

        // 現在のシーン
        int iNowScene = SC_NONE;
        // 次のシーン
        int iNextScene = SC_BOOT;


        const int TEKI_MAX = 20;
        const int TEKI_VEL_MAX = 400;   // 敵の最高速度(秒速)

        int chrnum;
        int time;

        long lastTime;

        Label[] chrs = new Label[TEKI_MAX];
        int[] iVX = new int[TEKI_MAX];
        int[] iVY = new int[TEKI_MAX];

        int iVelX = rand.Next(-20, 21);
        int iVelY = rand.Next(-20, 21);

        private static Random rand = new Random();
        private static Stopwatch stwatch = new Stopwatch();

        // コンストラクタ
        // Form1クラスが生成される時に実行する
        // 特別な関数
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        void init()
        {
            // シーンの切り替えがあるか
            if (iNextScene == SC_NONE)
            {
                return;
            }

            // シーンの切り替え
            iNowScene = iNextScene;
            iNextScene = SC_NONE;

            // 初期化処理
            switch (iNowScene)
            {
                case SC_BOOT:
                    initBoot();
                    break;
            }
        }

        void initBoot()
        {
            iNextScene = SC_TITLE;
            chrnum = TEKI_MAX;
            time = 0;
            stwatch.Start();    // ストップウォッチを動かす

            // ラベルの生成
            for (int i = 0; i < TEKI_MAX; i++)
            {
                chrs[i] = new Label();
                chrs[i].AutoSize = true; // ミソ
                chrs[i].Text = "（▼皿▼)";
                chrs[i].Left = rand.Next(ClientSize.Width);
                chrs[i].Top = rand.Next(ClientSize.Height);
                chrs[i].Font = new Font("HGS創英角ﾎﾟｯﾌﾟ体", 24);
                chrs[i].ForeColor = Color.FromArgb(255, 0, 0);
                Controls.Add(chrs[i]); // フォームに追加

                iVX[i] = rand.Next(-TEKI_VEL_MAX, TEKI_VEL_MAX + 1);
                iVY[i] = rand.Next(-TEKI_VEL_MAX, TEKI_VEL_MAX + 1);
            }
        }

        // 2次元クラスPoint型の変数cposを宣言
        Point cpos;

        /// <summary>
        /// 入力の確定
        /// </summary>
        void input()
        {
            // cposに、マウスのフォーム座標を取り出す
            cpos = this.PointToClient(MousePosition);

            // ラベル(フォーム)にマウス座標を表示
            Text = "" + cpos.X + "," + cpos.Y;

            // クリックの更新
            isClicked = isClick;
            isClick = false;
        }

        bool isClicked = false; // input()でisClickをコピーする
        bool isClick = false;   // クリックされた瞬間にtrueにする
        /// <summary>
        /// 更新処理
        /// </summary>
        void update()
        {
            switch (iNowScene)
            {
                case SC_TITLE:
                    if (isClicked) iNextScene = SC_GAME;
                    break;
                case SC_GAME:
                    updateGame();
                    break;
                case SC_GAMEOVER:
                    break;
            }
        }

        long deltaTime = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 経過時間を算出
            deltaTime = stwatch.ElapsedMilliseconds - lastTime;
            lastTime = stwatch.ElapsedMilliseconds;
            //label3.Text += ":" + deltaTime;

            // 初期化
            init();

            // 入力
            input();

            // 更新
            update();
        }

        /// <summary>
        /// ゲームの更新処理
        /// </summary>
        void updateGame()
        {
            time+=(int)deltaTime;
            label3.Text = "Time:" + time + ":" + stwatch.ElapsedMilliseconds;

            // マウス座標にラベルをくっつけてみよう。
            label1.Left = cpos.X;
            label1.Top = cpos.Y;

            // ラベルを動かす
            for (int i = 0; i < TEKI_MAX; i++)
            {
                // キャラクタが有効か
                if (chrs[i].Visible == false)
                {
                    continue;
                }

                // ラベルの移動
                chrs[i].Left += iVX[i] * (int)deltaTime / 1000;
                chrs[i].Top += iVY[i] * (int)deltaTime / 1000;

                // ラベルの跳ね返り
                // 跳ね返り
                if ((chrs[i].Left < 0)
                    || ((chrs[i].Left + chrs[i].Width) > ClientSize.Width))
                {
                    chrs[i].Left -= iVX[i] * (int)deltaTime / 1000;
                    iVX[i] = -iVX[i];
                }
                if ((chrs[i].Top < 0)
                    || ((chrs[i].Top + chrs[i].Height) > ClientSize.Height))
                {
                    chrs[i].Top -= iVY[i] * (int)deltaTime / 1000;
                    iVY[i] = -iVY[i];
                }

                // マウスとの当たり判定
                if ((cpos.X >= chrs[i].Left)
                                && (cpos.X < chrs[i].Left + chrs[i].Width)
                                && (cpos.Y >= chrs[i].Top)
                                && (cpos.Y < chrs[i].Top + chrs[i].Height))
                {
                    // 消す
                    chrs[i].Visible = false;  // 消える
                    chrnum--;
                    if (chrnum == 0)
                    {
                        MessageBox.Show("clear");
                    }
                    // 止める:速度が0になればよい
                    //iVX = 0;
                    //iVY = 0;
                }
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
            int i = 0;
            for (i = 0; i < TEKI_MAX; i++)
            {
                if (i < 3)
                {
                    continue;
                }
                if (i >= 6)
                {
                    break;
                }
                MessageBox.Show(i.ToString());
            }
            MessageBox.Show("iは" + i);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            isClick = true;
        }
    }
}
