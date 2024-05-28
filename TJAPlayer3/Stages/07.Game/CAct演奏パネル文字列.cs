using FDK;
using System;
using System.Diagnostics;
using System.Drawing;
using Point = System.Drawing.Point;
using RectangleF = System.Drawing.Rectangle;

namespace TJAPlayer3
{
    internal class CAct演奏パネル文字列 : CActivity
    {

        // コンストラクタ

        public CAct演奏パネル文字列()
        {

            ST文字位置[] st文字位置Array = new ST文字位置[10];

            ST文字位置 st文字位置 = new ST文字位置();
            st文字位置.ch = '0';
            st文字位置.pt = new Point(0, 0);
            st文字位置Array[0] = st文字位置;
            ST文字位置 st文字位置2 = new ST文字位置();
            st文字位置2.ch = '1';
            st文字位置2.pt = new Point(33, 0);
            st文字位置Array[1] = st文字位置2;
            ST文字位置 st文字位置3 = new ST文字位置();
            st文字位置3.ch = '2';
            st文字位置3.pt = new Point(66, 0);
            st文字位置Array[2] = st文字位置3;
            ST文字位置 st文字位置4 = new ST文字位置();
            st文字位置4.ch = '3';
            st文字位置4.pt = new Point(99, 0);
            st文字位置Array[3] = st文字位置4;
            ST文字位置 st文字位置5 = new ST文字位置();
            st文字位置5.ch = '4';
            st文字位置5.pt = new Point(132, 0);
            st文字位置Array[4] = st文字位置5;
            ST文字位置 st文字位置6 = new ST文字位置();
            st文字位置6.ch = '5';
            st文字位置6.pt = new Point(165, 0);
            st文字位置Array[5] = st文字位置6;
            ST文字位置 st文字位置7 = new ST文字位置();
            st文字位置7.ch = '6';
            st文字位置7.pt = new Point(198, 0);
            st文字位置Array[6] = st文字位置7;
            ST文字位置 st文字位置8 = new ST文字位置();
            st文字位置8.ch = '7';
            st文字位置8.pt = new Point(231, 0);
            st文字位置Array[7] = st文字位置8;
            ST文字位置 st文字位置9 = new ST文字位置();
            st文字位置9.ch = '8';
            st文字位置9.pt = new Point(264, 0);
            st文字位置Array[8] = st文字位置9;
            ST文字位置 st文字位置10 = new ST文字位置();
            st文字位置10.ch = '9';
            st文字位置10.pt = new Point(297, 0);
            st文字位置Array[9] = st文字位置10;

            for (int i = 0; i < 10; i++)
            {
                stSongNumberIngame[i].ch = i.ToString().ToCharArray()[0];
                stSongNumberIngame[i].pt = new Point(27 * i, 0);
            }

            base.b活性化してない = true;
            this.Start();
        }


        // メソッド

        /// <summary>
        /// 右上の曲名、曲数表示の更新を行います。
        /// </summary>
        /// <param name="songName">曲名</param>
        /// <param name="genreName">ジャンル名</param>
        /// <param name="stageText">曲数</param>
        public void SetPanelString(string songName, string genreName, string stageText = null)
        {
            if (base.b活性化してる)
            {
                TJAPlayer3.tテクスチャの解放(ref this.txPanel);
                if ((songName != null) && (songName.Length > 0))
                {
                    try
                    {
                        using (var bmpSongTitle = pfMusicName.DrawPrivateFont(songName, TJAPlayer3.Skin.Game_MusicName_ForeColor, TJAPlayer3.Skin.Game_MusicName_BackColor))
                        {
                            this.txMusicName = TJAPlayer3.tテクスチャの生成(bmpSongTitle, false);
                        }
                        if (txMusicName != null)
                        {
                            this.txMusicName.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref txMusicName);
                            this.txMusicName.vc拡大縮小倍率.Y = TJAPlayer3.GetSongNameXScaling(ref txMusicName);
                        }

                        Bitmap bmpDiff;
                        string strDiff = "";
                        if (TJAPlayer3.Skin.eDiffDispMode == E難易度表示タイプ.n曲目に表示)
                        {
                            switch (TJAPlayer3.stage選曲.n確定された曲の難易度[0])
                            {
                                case 0:
                                    strDiff = "かんたん ";
                                    break;
                                case 1:
                                    strDiff = "ふつう ";
                                    break;
                                case 2:
                                    strDiff = "むずかしい ";
                                    break;
                                case 3:
                                    strDiff = "おに ";
                                    break;
                                case 4:
                                    strDiff = "えでぃと ";
                                    break;
                                default:
                                    strDiff = "おに ";
                                    break;
                            }
                            bmpDiff = pfMusicName.DrawPrivateFont(strDiff + stageText, TJAPlayer3.Skin.Game_StageText_ForeColor, TJAPlayer3.Skin.Game_StageText_BackColor);
                        }
                        else
                        {
                            bmpDiff = pfMusicName.DrawPrivateFont(stageText, TJAPlayer3.Skin.Game_StageText_ForeColor, TJAPlayer3.Skin.Game_StageText_BackColor);
                        }

                        using (bmpDiff)
                        {
                            txStage = TJAPlayer3.Tx.TxCGen("Songs");
                            txStageNumber = TJAPlayer3.Tx.Song_Number_Ingame;
                        }
                    }
                    catch (CTextureCreateFailedException e)
                    {
                        Trace.TraceError(e.ToString());
                        Trace.TraceError("パネル文字列テクスチャの生成に失敗しました。");
                        this.txPanel = null;
                    }
                }
                if (!string.IsNullOrEmpty(genreName))
                {
                    if (genreName.Equals("ポップス") || genreName.Equals("J-POP"))
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Pops");
                    }
                    else if (genreName.Equals("アニメ"))
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Anime");
                    }
                    else if (genreName.Equals("ゲームミュージック") || genreName.Equals("ゲーム"))
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Game");
                    }
                    else if (genreName.Equals("ナムコオリジナル") || genreName.Equals("ナムコ") || genreName.Equals("ナムオリ"))
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Namco");
                    }
                    else if (genreName.Equals("クラシック"))
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Classic");
                    }
                    else if (genreName.Equals("バラエティ"))
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Variety");
                    }
                    else if (genreName.Equals("キッズ") || genreName.Equals("どうよう"))
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Child");
                    }
                    else if (genreName.Equals("ボーカロイド") || genreName.Equals("Vocaloid") || genreName.Equals("ボカロ"))
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Vocaloid");
                    }
                    else
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Other");
                    }
                }

                this.ct進行用 = new CCounter(0, 2000, 2, TJAPlayer3.Timer);
                this.Start();
            }
        }

        public void Stop()
        {
            this.bMute = true;
        }
        public void Start()
        {
            this.bMute = false;
        }

        // CActivity 実装

        public override void On活性化()
        {
            if (!string.IsNullOrEmpty(TJAPlayer3.ConfigIni.FontName))
            {
                this.pfMusicName = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), TJAPlayer3.Skin.Game_MusicName_FontSize - 1);
            }

            this.txPanel = null;
            this.ct進行用 = new CCounter();
            this.Start();
            base.On活性化();
        }
        public override void On非活性化()
        {
            this.ct進行用 = null;
            base.On非活性化();
        }
        public override void OnManagedリソースの作成()
        {
            if (!base.b活性化してない)
            {
                base.OnManagedリソースの作成();
            }
        }
        public override void OnManagedリソースの解放()
        {
            if (!base.b活性化してない)
            {
                TJAPlayer3.t安全にDisposeする(ref txPanel);
                TJAPlayer3.t安全にDisposeする(ref txMusicName);
                TJAPlayer3.t安全にDisposeする(ref txGENRE);
                TJAPlayer3.t安全にDisposeする(ref txStage);
                TJAPlayer3.t安全にDisposeする(ref txStageNumber);
                TJAPlayer3.t安全にDisposeする(ref txPanel);
                TJAPlayer3.t安全にDisposeする(ref pfMusicName);
                base.OnManagedリソースの解放();
            }
        }
        public override int On進行描画()
        {
            throw new InvalidOperationException("t進行描画(x,y)のほうを使用してください。");

        }
        public int t進行描画(int x, int y)
        {
            if (TJAPlayer3.stage演奏ドラム画面.actDan.IsAnimating) return 0;
            if (!base.b活性化してない && !bMute)
            {
                ct進行用.t進行Loop();
                txGENRE?.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Genre_X, TJAPlayer3.Skin.Game_Genre_Y);
                txStage?.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Genre_X, TJAPlayer3.Skin.Game_Genre_Y);
                tSongNumberDrawIngame(1091, 70, TJAPlayer3.stage選曲.NowSong.ToString());
                tSongNumberDrawIngame(1190, 70, TJAPlayer3.stage選曲.MaxSong.ToString());

                #region[ 透明度制御 ]
                if (txStage != null && txStageNumber != null)
                {
                    if (ct進行用.n現在の値 < 745)
                    {
                        txStage.Opacity = 0;
                        txStageNumber.Opacity = 0;
                    }
                    else if (ct進行用.n現在の値 >= 745 && ct進行用.n現在の値 < 1000)
                    {
                        txStage.Opacity = (ct進行用.n現在の値 - 745);
                        txStageNumber.Opacity = (ct進行用.n現在の値 - 745);
                    }
                    else if (ct進行用.n現在の値 >= 1000 && ct進行用.n現在の値 <= 1745)
                    {
                        txStage.Opacity = 255;
                        txStageNumber.Opacity = 255;
                    }
                    else if (ct進行用.n現在の値 >= 1745)
                    {
                        txStage.Opacity = 255 - (ct進行用.n現在の値 - 1745);
                        txStageNumber.Opacity = 255 - (ct進行用.n現在の値 - 1745);
                    }
                }

                #endregion

                if (txMusicName != null)
                {
                    if (b初めての進行描画)
                    {
                        b初めての進行描画 = false;
                    }

                    if (txMusicName.szテクスチャサイズ.Width >= 225)
                        txMusicName.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_MusicName_X - (this.txMusicName.szテクスチャサイズ.Width * txMusicName.vc拡大縮小倍率.X), TJAPlayer3.Skin.Game_MusicName_Y + 2);
                    else
                        txMusicName.t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_MusicName_X - 108, TJAPlayer3.Skin.Game_MusicName_Y + 40);
                }
            }
            return 0;
        }


        // その他

        #region [ private ]
        //-----------------
        private CCounter ct進行用;
        private CTexture txPanel;
        private bool bMute;
        private CTexture txMusicName;
        private CTexture txStage;
        private CTexture txStageNumber;
        private CTexture txGENRE;
        private CPrivateFastFont pfMusicName;
        private readonly STNumberIngame[] stSongNumberIngame = new STNumberIngame[10];
        private struct ST文字位置
        {
            public char ch;
            public Point pt;
        }
        public struct STNumberIngame
        {
            public char ch;
            public Point pt;
        }
        public void tSongNumberDrawIngame(int x, int y, string str)
        {
            for (int j = 0; j < str.Length; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (str[j] == stSongNumberIngame[i].ch)
                    {
                        TJAPlayer3.Tx.Song_Number_Ingame?.t2D描画(TJAPlayer3.app.Device, x - (str.Length * 27 + 27 * str.Length - str.Length * 27) / 2 + 27 / 2, (float)y, new RectangleF(stSongNumberIngame[i].pt.X, stSongNumberIngame[i].pt.Y, 27, 29));
                        x += str.Length >= 2 ? 16 : 27;
                    }
                }
                TJAPlayer3.Tx.Song_Number_Ingame.vc拡大縮小倍率.X = 0.70f;
                TJAPlayer3.Tx.Song_Number_Ingame.vc拡大縮小倍率.Y = 0.70f;
            }
        }
        //-----------------
        #endregion
    }
}

