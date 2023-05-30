using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using SharpDX;
using FDK;

using Rectangle = System.Drawing.Rectangle;
using Point = System.Drawing.Point;

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
            st小文字位置 = st文字位置Array;

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
                    else if (genreName.Equals("ナムコオリジナル") || genreName.Equals("ナムコ"))
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
                    else if (genreName.Equals("バラエティ"))
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Variety");
                    }
                    else if (genreName.Equals("ボーカロイド") || genreName.Equals("Vocaloid") || genreName.Equals("ボカロ"))
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Vocaloid");
                    }
                    else
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Other");
                        /*
                        using (var bmpDummy = new Bitmap(1, 1))
                        {
                            this.txGENRE = TJAPlayer3.tテクスチャの生成(bmpDummy, true);
                        }
                        */
                    }
                }

                this.ct進行用 = new CCounter(0, 2000, 2, TJAPlayer3.Timer);
                this.Start();
            }
        }

        public void t歌詞テクスチャを生成する(Bitmap bmplyric)
        {
            TJAPlayer3.t安全にDisposeする(ref this.tx歌詞テクスチャ);
            this.tx歌詞テクスチャ = TJAPlayer3.tテクスチャの生成(bmplyric);
        }
        public void t歌詞テクスチャを削除する()
        {
            TJAPlayer3.tテクスチャの解放(ref this.tx歌詞テクスチャ);
        }
        /// <summary>
        /// レイヤー管理のため、On進行描画から分離。
        /// </summary>
        public void t歌詞テクスチャを描画する()
        {
            if (this.tx歌詞テクスチャ != null)
            {
                if (TJAPlayer3.Skin.Game_Lyric_ReferencePoint == CSkin.ReferencePoint.Left)
                {
                    this.tx歌詞テクスチャ.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Lyric_X, TJAPlayer3.Skin.Game_Lyric_Y);
                }
                else if (TJAPlayer3.Skin.Game_Lyric_ReferencePoint == CSkin.ReferencePoint.Right)
                {
                    this.tx歌詞テクスチャ.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Lyric_X - this.tx歌詞テクスチャ.szテクスチャサイズ.Width, TJAPlayer3.Skin.Game_Lyric_Y);
                }
                else
                {
                    this.tx歌詞テクスチャ.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Lyric_X - (this.tx歌詞テクスチャ.szテクスチャサイズ.Width / 2), TJAPlayer3.Skin.Game_Lyric_Y);
                }
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
                this.pfMusicName = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), TJAPlayer3.Skin.Game_MusicName_FontSize);
                //this.pf縦書きテスト = new CPrivateFastFont( new FontFamily( CDTXMania.ConfigIni.strPrivateFontで使うフォント名 ), 22 );
            }

            this.txPanel = null;
            this.ct進行用 = new CCounter();
            this.Start();
            //this.bFirst = true;
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
                TJAPlayer3.t安全にDisposeする(ref txPanel);
                TJAPlayer3.t安全にDisposeする(ref tx歌詞テクスチャ);
                TJAPlayer3.t安全にDisposeする(ref pfMusicName);
                TJAPlayer3.t安全にDisposeする(ref pf歌詞フォント);
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

                #region[ 透明度制御 ]

                if (ct進行用.n現在の値 < 745)
                {
                    if (txStage != null)
                        txStage.Opacity = 0;
                }
                else if (ct進行用.n現在の値 >= 745 && ct進行用.n現在の値 < 1000)
                {
                    if (txStage != null)
                        txStage.Opacity = (ct進行用.n現在の値 - 745);
                }
                else if (ct進行用.n現在の値 >= 1000 && ct進行用.n現在の値 <= 1745)
                {
                    if (txStage != null)
                        txStage.Opacity = 255;
                }
                else if (ct進行用.n現在の値 >= 1745)
                {
                    if (txStage != null)
                        txStage.Opacity = 255 - (ct進行用.n現在の値 - 1745);
                }
                #endregion

                //int NS = 1;
                //int MS = 3;

                //t小文字表示(200, 10, string.Format("{0,9}", NS.ToString()));
                //t小文字表示(200, 20, string.Format("{0,9}", MS.ToString()));

                if (txMusicName != null)
                {
                    if (b初めての進行描画)
                    {
                        b初めての進行描画 = false;
                    }

                    if (txMusicName.szテクスチャサイズ.Width >= 225)
                        txMusicName.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_MusicName_X - (this.txMusicName.szテクスチャサイズ.Width * txMusicName.vc拡大縮小倍率.X), TJAPlayer3.Skin.Game_MusicName_Y);
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
        private CTexture txGENRE;
        private CTexture tx歌詞テクスチャ;
        private CPrivateFastFont pfMusicName;
        private CPrivateFastFont pf歌詞フォント;
        //private readonly CStage選曲 CS選曲;
        public int MaxSong = 3;
        public int NowSong = 1;

        private struct ST文字位置
        {
            public char ch;
            public Point pt;
        }
        private readonly ST文字位置[] st小文字位置;

        private void t小文字表示(int x, int y, string str)
        {
            foreach (char ch in str)
            {
                for (int i = 0; i < this.st小文字位置.Length; i++)
                {
                    if (ch == ' ')
                    {
                        break;
                    }

                    if (this.st小文字位置[i].ch == ch)
                    {
                        Rectangle rectangle = new Rectangle(st小文字位置[i].pt.X, this.st小文字位置[i].pt.Y, 33, 35);
                        //TJAPlayer3.Tx.SongSelect_ScoreNumber.vc拡大縮小倍率.X = 0.995f;
                        //TJAPlayer3.Tx.SongSelect_ScoreNumber.vc拡大縮小倍率.Y = 0.995f;
                        TJAPlayer3.Tx.NowStages?.t2D描画(TJAPlayer3.app.Device, x, y, rectangle);
                        break;
                    }
                }
                x += 14;
                //22
            }
        }

        //-----------------
        #endregion
    }
}

