﻿using FDK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Point = SharpDX.Point;
using Rectangle = System.Drawing.Rectangle;
using RectangleF = System.Drawing.RectangleF;

namespace TJAPlayer3
{
    internal class CStage選曲 : CStage
    {
        // プロパティ
        public int nスクロールバー相対y座標
        {
            get
            {
                if (act曲リスト != null)
                {
                    return act曲リスト.nスクロールバー相対y座標;
                }
                else
                {
                    return 0;
                }
            }
        }
        public bool bIsEnumeratingSongs
        {
            get
            {
                return act曲リスト.bIsEnumeratingSongs;
            }
            set
            {
                act曲リスト.bIsEnumeratingSongs = value;
            }
        }
        public bool bスクロール中
        {
            get
            {
                return act曲リスト.bスクロール中;
            }
        }
        public int[] n確定された曲の難易度 = new int[2];

        public string str確定された曲のジャンル
        {
            get;
            set;
        }
        public Cスコア r確定されたスコア
        {
            get;
            set;
        }
        public C曲リストノード r確定された曲
        {
            get;
            set;
        }
        public int n現在選択中の曲の難易度
        {
            get
            {
                return act曲リスト.n現在選択中の曲の現在の難易度レベル;
            }
        }
        public Cスコア r現在選択中のスコア
        {
            get
            {
                return act曲リスト.r現在選択中のスコア;
            }
        }
        public C曲リストノード r現在選択中の曲
        {
            get
            {
                return act曲リスト.r現在選択中の曲;
            }
        }

        // コンストラクタ
        public CStage選曲()
        {
            eステージID = Eステージ.選曲;
            eフェーズID = Eフェーズ.共通_通常状態;
            b活性化してない = true;
            //list子Activities.Add(actオプションパネル = new CActオプションパネル());
            list子Activities.Add(actFIFO = new CActFIFOBlack());
            list子Activities.Add(actFIfrom結果画面 = new CActFIFOBlack());
            list子Activities.Add(actFOtoNowLoading = new CActFIFOStart());
            list子Activities.Add(act曲リスト = new CActSelect曲リスト());
            list子Activities.Add(actステータスパネル = new CActSelectステータスパネル());
            //list子Activities.Add(actPreimageパネル = new CActSelectPreimageパネル());
            list子Activities.Add(actPresound = new CActSelectPresound());
            list子Activities.Add(actArtistComment = new CActSelectArtistComment());
            list子Activities.Add(actInformation = new CActSelectInformation());
            list子Activities.Add(actSortSongs = new CActSortSongs());
            list子Activities.Add(actShowCurrentPosition = new CActSelectShowCurrentPosition());
            list子Activities.Add(actQuickConfig = new CActSelectQuickConfig());
            list子Activities.Add(act演奏履歴パネル = new CActSelect演奏履歴パネル());
            list子Activities.Add(act難易度選択画面 = new CActSelect難易度選択画面());
            list子Activities.Add(actPlayOption = new CActPlayOption());
            list子Activities.Add(PuchiChara = new PuchiChara());

            for (int i = 0; i < 10; i++)
            {
                stTimer[i].ch = i.ToString().ToCharArray()[0];
                stTimer[i].pt = new Point(46 * i, 0);
            }

            for (int i = 0; i < 10; i++)
            {
                stSongNumber[i].ch = i.ToString().ToCharArray()[0];
                stSongNumber[i].pt = new Point(27 * i, 0);
            }

            for (int i = 0; i < 10; i++)
            {
                stBoardNumber[i].ch = i.ToString().ToCharArray()[0];
                stBoardNumber[i].pt = new Point(15 * i, 0);
            }

            CommandHistory = new CCommandHistory();        // #24063 2011.1.16 yyagi
        }


        // メソッド

        public void t選択曲変更通知()
        {
            //this.actPreimageパネル.t選択曲が変更された();
            actPresound.t選択曲が変更された();
            actステータスパネル.t選択曲が変更された();
            actArtistComment.t選択曲が変更された();
            act演奏履歴パネル.t選択曲が変更された();

            #region [ プラグインにも通知する（BOX, RANDOM, BACK なら通知しない）]
            //---------------------
            if (TJAPlayer3.app != null)
            {
                var c曲リストノード = TJAPlayer3.stage選曲.r現在選択中の曲;
                var cスコア = TJAPlayer3.stage選曲.r現在選択中のスコア;

                if (c曲リストノード != null && cスコア != null && c曲リストノード.eノード種別 == C曲リストノード.Eノード種別.SCORE)
                {
                    string str選択曲ファイル名 = cスコア.ファイル情報.ファイルの絶対パス;
                    int n曲番号inブロック = TJAPlayer3.stage選曲.act曲リスト.n現在のアンカ難易度レベルに最も近い難易度レベルを返す(c曲リストノード);

                    foreach (TJAPlayer3.STPlugin stPlugin in TJAPlayer3.app.listプラグイン)
                    {
                        Directory.SetCurrentDirectory(stPlugin.strプラグインフォルダ);
                        stPlugin.plugin.On選択曲変更(str選択曲ファイル名, n曲番号inブロック);
                        Directory.SetCurrentDirectory(TJAPlayer3.strEXEのあるフォルダ);
                    }
                }
            }
            //---------------------
            #endregion
        }

        // CStage 実装

        /// <summary>
        /// 曲リストをリセットする
        /// </summary>
        /// <param name="cs"></param>
        public void Refresh(CSongs管理 cs, bool bRemakeSongTitleBar)
        {
            act曲リスト.Refresh(cs, bRemakeSongTitleBar);
        }

        public override void On活性化()
        {
            Trace.TraceInformation("選曲ステージを活性化します。");
            Trace.Indent();
            try
            {
                n確定された曲の難易度 = new int[2];
                eフェードアウト完了時の戻り値 = E戻り値.継続;
                bBGM再生済み = false;
                ftフォント = new Font("MS UI Gothic", 26f, GraphicsUnit.Pixel);
                for (int i = 0; i < 2; i++)
                    ctキー反復用[i] = new CCounter(0, 0, 0, TJAPlayer3.Timer);

                ctDonchan_Normal = new CCounter(0, TJAPlayer3.Tx.SongSelect_Donchan_Normal.Length - 1, 1000 / 60, TJAPlayer3.Timer);
                ctDonchan_Select = new CCounter();
                ctDonchan_Jump[0] = new CCounter();
                ctDonchan_Jump[1] = new CCounter();

                ctPuchiCounter = new CCounter(0, TJAPlayer3.Skin.Game_PuchiChara[2] - 1, 1000, TJAPlayer3.Timer);
                ctPuchiSineCounter = new CCounter(0, 360, 3, TJAPlayer3.Timer);

                ctBackgroundFade = new CCounter();
                ctCreditAnime = new CCounter(0, 4500, 1, TJAPlayer3.Timer);
                ctTimer = new CCounter(0, 100, 1000, TJAPlayer3.Timer);

                ctBackgroundFade.n現在の値 = 600;

                TJAPlayer3.Tx.PuchiChara[0].vc拡大縮小倍率.X = 0.75f;
                TJAPlayer3.Tx.PuchiChara[0].vc拡大縮小倍率.Y = 0.75f;

                if (TJAPlayer3.ConfigIni.bBGM音を発声する && !TJAPlayer3.Skin.bgm選曲画面.b再生中 && !TJAPlayer3.Skin.bgm選曲画面イン.b再生中)
                    TJAPlayer3.Skin.bgm選曲画面イン.t再生する();

                for (int i = 0; i < 3; i++)
                    r[i] = new Random();

                //this.act難易度選択画面.bIsDifficltSelect = true;
                base.On活性化();

                actステータスパネル.t選択曲が変更された();	// 最大ランクを更新
                // Discord Presenceの更新
                Discord.UpdatePresence("", Properties.Discord.Stage_SongSelect, TJAPlayer3.StartupTime);

                if (r現在選択中の曲 != null)
                    NowGenre = r現在選択中の曲.strジャンル;
            }
            finally
            {
                TJAPlayer3.ConfigIni.eScrollMode = EScrollMode.Normal;
                TJAPlayer3.ConfigIni.bスクロールモードを上書き = false;
                Trace.TraceInformation("選曲ステージの活性化を完了しました。");
                Trace.Unindent();
            }
            if (!string.IsNullOrEmpty(TJAPlayer3.ConfigIni.FontName))
            {
                pfScore = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 20);
            }
            else
                pfScore = new CPrivateFastFont(new FontFamily("MS UI Gothic"), 20);


        }
        public override void On非活性化()
        {
            Trace.TraceInformation("選曲ステージを非活性化します。");
            Trace.Indent();
            try
            {
                if (ftフォント != null)
                {
                    ftフォント.Dispose();
                    ftフォント = null;
                }
                for (int i = 0; i < 2; i++)
                {
                    ctキー反復用[i] = null;
                }
                ctDonchan_Normal = null;
                ctDonchan_Select = null;
                ctDonchan_Jump[0] = null;
                ctDonchan_Jump[1] = null;
                ctPuchiCounter = null;
                ctPuchiSineCounter = null;
                ctBackgroundFade = null;
                ctCreditAnime = null;
                ctTimer = null;
                base.On非活性化();
            }
            finally
            {
                Trace.TraceInformation("選曲ステージの非活性化を完了しました。");
                Trace.Unindent();
            }
        }
        public override void OnManagedリソースの作成()
        {
            if (!b活性化してない)
            {
                ct背景スクロール用タイマー = new CCounter(0, TJAPlayer3.Tx.SongSelect_Background.szテクスチャサイズ.Width, 18, TJAPlayer3.Timer);
                base.OnManagedリソースの作成();
            }
        }
        public override void OnManagedリソースの解放()
        {
            if (!b活性化してない)
            {
                TJAPlayer3.t安全にDisposeする(ref pfScore);
                base.OnManagedリソースの解放();
            }
        }
        public override int On進行描画()
        {
            if (!b活性化してない)
            {
                ct背景スクロール用タイマー.t進行Loop();

                #region [ 初めての進行描画 ]
                //---------------------
                if (b初めての進行描画)
                {
                    ct登場時アニメ用共通 = new CCounter(0, 100, 3, TJAPlayer3.Timer);
                    if (TJAPlayer3.r直前のステージ == TJAPlayer3.stage結果)
                    {
                        actFIfrom結果画面.tフェードイン開始();
                        eフェーズID = Eフェーズ.選曲_結果画面からのフェードイン;
                    }
                    else
                    {
                        actFIFO.tフェードイン開始();
                        eフェーズID = Eフェーズ.共通_フェードイン;
                    }
                    t選択曲変更通知();
                    b初めての進行描画 = false;
                }
                //---------------------
                #endregion

                ctTimer.t進行();

                #region [ タイマー音声 ]
                int NowTime = 100 - ctTimer.n現在の値;

                if (NowTime == 30 && TJAPlayer3.Skin.sound30sec.b読み込み成功 && !TJAPlayer3.Skin.sound30sec.b再生中)
                    TJAPlayer3.Skin.sound30sec.t再生する();

                if (NowTime == 10 && TJAPlayer3.Skin.sound10sec.b読み込み成功 && !TJAPlayer3.Skin.sound10sec.b再生中)
                    TJAPlayer3.Skin.sound10sec.t再生する();

                if (NowTime < 10 && NowTime > 0 && TJAPlayer3.Skin.soundTimer.b読み込み成功 && !TJAPlayer3.Skin.soundTimer.b再生中)
                    TJAPlayer3.Skin.soundTimer.t再生する();

                if (NowTime == 5 && TJAPlayer3.Skin.sound5sec.b読み込み成功 && !TJAPlayer3.Skin.sound5sec.b再生中)
                    TJAPlayer3.Skin.sound5sec.t再生する();

                #endregion

                ctCreditAnime.t進行Loop();
                ctBackgroundFade.t進行();
                ctDonchan_Select.t進行();
                ctDonchan_Jump[0].t進行();
                ctDonchan_Jump[1].t進行();
                ctDonchan_Normal.t進行Loop();
                ctPuchiCounter.t進行Loop();
                ctPuchiSineCounter.t進行Loop();

                ct登場時アニメ用共通.t進行();

                if (r現在選択中の曲 != null)
                {
                    if (nStrジャンルtoNum(r現在選択中の曲.strジャンル) != 0 || r現在選択中の曲.eノード種別 == C曲リストノード.Eノード種別.BOX || r現在選択中の曲.eノード種別 == C曲リストノード.Eノード種別.SCORE)
                    {
                        nGenreBack = nStrジャンルtoNum(NowGenre);
                        nOldGenreBack = nStrジャンルtoNum(OldGenre);
                    }
                    if (TJAPlayer3.Tx.SongSelect_GenreBack[nGenreBack] != null)
                    {
                        for (int i = 0; i < (1280 / TJAPlayer3.Tx.SongSelect_Background.szテクスチャサイズ.Width) + 2; i++)
                        {
                            if (TJAPlayer3.Tx.SongSelect_GenreBack[nGenreBack] != null)
                            {
                                TJAPlayer3.Tx.SongSelect_GenreBack[nGenreBack].Opacity = 255;
                                TJAPlayer3.Tx.SongSelect_GenreBack[nGenreBack].t2D描画(TJAPlayer3.app.Device, -(int)ct背景スクロール用タイマー.n現在の値 + TJAPlayer3.Tx.SongSelect_Background.szテクスチャサイズ.Width * i, 0);
                            }
                            if (TJAPlayer3.Tx.SongSelect_GenreBack[nOldGenreBack] != null)
                            {
                                TJAPlayer3.Tx.SongSelect_GenreBack[nOldGenreBack].Opacity = 600 - ctBackgroundFade.n現在の値;
                                TJAPlayer3.Tx.SongSelect_GenreBack[nOldGenreBack].t2D描画(TJAPlayer3.app.Device, -(int)ct背景スクロール用タイマー.n現在の値 + TJAPlayer3.Tx.SongSelect_Background.szテクスチャサイズ.Width * i, 0);
                            }
                        }
                    }
                }

                int y = 0;
                if (ct登場時アニメ用共通.b進行中)
                {
                    double db登場割合 = ((double)ct登場時アニメ用共通.n現在の値) / 100.0;   // 100が最終値
                    double dbY表示割合 = Math.Sin(Math.PI / 2 * db登場割合);
                    //y = ((int)(TJAPlayer3.Tx.SongSelect_Header.sz画像サイズ.Height * dbY表示割合)) - TJAPlayer3.Tx.SongSelect_Header.sz画像サイズ.Height;
                }

                actInformation.On進行描画();
                actPresound.On進行描画();
                actShowCurrentPosition.On進行描画(); // #27648 2011.3.28 yyagi

                if (TJAPlayer3.ConfigIni.bBGM音を発声する && !bBGM再生済み && (eフェーズID == Eフェーズ.共通_通常状態) && !TJAPlayer3.Skin.bgm選曲画面イン.b再生中)
                {
                    if (!TJAPlayer3.Skin.bgm選曲画面.b再生中)
                        TJAPlayer3.Skin.bgm選曲画面.t再生する();
                    bBGM再生済み = true;
                }

                ctDiffSelect移動待ち?.t進行();

                #region [ キー入力 ]
                if (eフェーズID == Eフェーズ.共通_通常状態 && TJAPlayer3.act現在入力を占有中のプラグイン == null)
                {
                    #region [ 簡易CONFIGでMore、またはShift+F1: 詳細CONFIG呼び出し ]
                    if (actQuickConfig.bGotoDetailConfig)
                    {   // 詳細CONFIG呼び出し
                        actQuickConfig.tDeativatePopupMenu();
                        actPresound.tサウンド停止();
                        eフェードアウト完了時の戻り値 = E戻り値.コンフィグ呼び出し;  // #24525 2011.3.16 yyagi: [SHIFT]-[F1]でCONFIG呼び出し
                        actFIFO.tフェードアウト開始();
                        eフェーズID = Eフェーズ.共通_フェードアウト;
                        TJAPlayer3.Skin.sound取消音.t再生する();
                        return 0;
                    }
                    #endregion
                    if (!actSortSongs.bIsActivePopupMenu && !actQuickConfig.bIsActivePopupMenu && !act難易度選択画面.bIsDifficltSelect)
                    {
                        #region [ ESC ]
                        if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.Escape) && (act曲リスト.r現在選択中の曲 != null))
                            if (act曲リスト.r現在選択中の曲.r親ノード == null)
                            {   // [ESC]
                                actPresound.tサウンド停止();
                                TJAPlayer3.Skin.sound取消音.t再生する();
                                eフェードアウト完了時の戻り値 = E戻り値.タイトルに戻る;
                                actFIFO.tフェードアウト開始();
                                eフェーズID = Eフェーズ.共通_フェードアウト;
                                return 0;
                            }
                            else
                            {
                                if (act曲リスト.ctBoxOpen.b終了値に達した || act曲リスト.ctBoxOpen.n現在の値 == 0)
                                {
                                    actPresound.tサウンド停止();
                                    TJAPlayer3.Skin.sound取消音.t再生する();
                                    act曲リスト.ctBarFlash.t開始(0, 2700, 1, TJAPlayer3.Timer);
                                    act曲リスト.ctBoxOpen.t開始(200, 2700, 1.3f, TJAPlayer3.Timer);
                                    act曲リスト.bBoxClose = true;
                                    ctDonchan_Select.t開始(0, TJAPlayer3.Tx.SongSelect_Donchan_Select.Length - 1, 1000 / 45, TJAPlayer3.Timer);
                                }
                            }
                        #endregion
                        #region [ Shift-F1: CONFIG画面 ]
                        if ((TJAPlayer3.Input管理.Keyboard.bキーが押されている((int)SlimDXKeys.Key.RightShift) || TJAPlayer3.Input管理.Keyboard.bキーが押されている((int)SlimDXKeys.Key.LeftShift)) &&
                            TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.F1))
                        {   // [SHIFT] + [F1] CONFIG
                            actPresound.tサウンド停止();
                            eフェードアウト完了時の戻り値 = E戻り値.コンフィグ呼び出し;  // #24525 2011.3.16 yyagi: [SHIFT]-[F1]でCONFIG呼び出し
                            actFIFO.tフェードアウト開始();
                            eフェーズID = Eフェーズ.共通_フェードアウト;
                            TJAPlayer3.Skin.sound取消音.t再生する();
                            return 0;
                        }
                        #endregion
                        #region [ F2 簡易オプション ]
                        if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.F2))
                        {
                            TJAPlayer3.Skin.sound変更音.t再生する();
                            actQuickConfig.tActivatePopupMenu(E楽器パート.DRUMS);
                        }
                        #endregion
                        #region [ F3 1PオートON/OFF ]
                        if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.F3))
                        {
                            TJAPlayer3.Skin.sound変更音.t再生する();
                            C共通.bToggleBoolian(ref TJAPlayer3.ConfigIni.b太鼓パートAutoPlay);
                        }
                        #endregion
                        #region [ F4 2PオートON/OFF ]
                        if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.F4))
                        {
                            if (TJAPlayer3.ConfigIni.nPlayerCount > 1)
                            {
                                TJAPlayer3.Skin.sound変更音.t再生する();
                                C共通.bToggleBoolian(ref TJAPlayer3.ConfigIni.b太鼓パートAutoPlay2P);
                            }
                        }
                        #endregion
                        #region [ F5 スーパーハード ]
                        if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.F5))
                        {
                            TJAPlayer3.Skin.sound変更音.t再生する();
                            C共通.bToggleBoolian(ref TJAPlayer3.ConfigIni.bSuperHard);
                        }
                        #endregion
                        #region [ F6 SCROLL ]
                        if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.F6))
                        {
                            TJAPlayer3.Skin.sound変更音.t再生する();
                            TJAPlayer3.ConfigIni.bスクロールモードを上書き = true;
                            switch ((int)TJAPlayer3.ConfigIni.eScrollMode)
                            {
                                case 0:
                                    TJAPlayer3.ConfigIni.eScrollMode = EScrollMode.BMSCROLL;
                                    break;
                                case 1:
                                    TJAPlayer3.ConfigIni.eScrollMode = EScrollMode.HBSCROLL;
                                    break;
                                case 2:
                                    TJAPlayer3.ConfigIni.eScrollMode = EScrollMode.Normal;
                                    TJAPlayer3.ConfigIni.bスクロールモードを上書き = false;
                                    break;
                            }
                        }
                        #endregion
                        #region [ F7 TokkunMode ]
                        if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.F7))
                        {
                            if (TJAPlayer3.ConfigIni.nPlayerCount != 2)
                            {
                                TJAPlayer3.Skin.sound変更音.t再生する();
                                C共通.bToggleBoolian(ref TJAPlayer3.ConfigIni.bTokkunMode);
                            }
                        }
                        #endregion
                        #region [ F8 ランダム選曲 ]
                        if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.F8))
                        {
                            if (TJAPlayer3.Skin.sound曲決定音.b読み込み成功)
                                TJAPlayer3.Skin.sound曲決定音.t再生する();
                            else
                                TJAPlayer3.Skin.sound決定音.t再生する();
                            t曲をランダム選択する();
                        }
                        #endregion
                        #region [ F9 曲リスト更新 ]
                        if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.F9))
                        {
                            TJAPlayer3.Skin.sound決定音.t再生する();

                            if (TJAPlayer3.EnumSongs.IsEnumerating)
                            {
                                // Debug.WriteLine( "バックグラウンドでEnumeratingSongs中だったので、一旦中断します。" );
                                TJAPlayer3.EnumSongs.Abort();
                                TJAPlayer3.actEnumSongs.On非活性化();
                            }

                            TJAPlayer3.EnumSongs.StartEnumFromDisk();
                            //TJAPlayer3.EnumSongs.ChangeEnumeratePriority(ThreadPriority.Normal);
                            TJAPlayer3.actEnumSongs.bコマンドでの曲データ取得 = true;
                            TJAPlayer3.actEnumSongs.On活性化();
                        }
                        #endregion

                        if (act曲リスト.r現在選択中の曲 != null)
                        {
                            if (act曲リスト.ctBoxOpen.b終了値に達した || act曲リスト.ctBoxOpen.n現在の値 == 0)
                            {
                                if (!bスクロール中)
                                {
                                    #region [ Decide ]
                                    if ((TJAPlayer3.Pad.b押されたDGB(Eパッド.Decide) || (TJAPlayer3.Pad.b押されたDGB(Eパッド.LRed) || TJAPlayer3.Pad.b押されたDGB(Eパッド.RRed)) ||
                                    ((TJAPlayer3.ConfigIni.bEnterがキー割り当てのどこにも使用されていない && TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.Return)))))
                                    {
                                        if (act曲リスト.r現在選択中の曲 != null)
                                        {
                                            switch (act曲リスト.r現在選択中の曲.eノード種別)
                                            {
                                                case C曲リストノード.Eノード種別.SCORE:
                                                    {
                                                        if (n現在選択中の曲の難易度 == (int)Difficulty.Dan)
                                                        {
                                                            TJAPlayer3.Skin.sound決定音.t再生する();
                                                            t曲を選択する();
                                                        }
                                                        else
                                                        {
                                                            TJAPlayer3.Skin.sound決定音.t再生する();
                                                            act難易度選択画面.bIsDifficltSelect = true;
                                                            act難易度選択画面.t選択画面初期化();
                                                            act曲リスト.ctBarFlash.t開始(0, 2700, 1, TJAPlayer3.Timer);
                                                            act曲リスト.ctDifficultyIn.t開始(0, 3200, 1, TJAPlayer3.Timer);
                                                            ctDonchan_Select.t開始(0, TJAPlayer3.Tx.SongSelect_Donchan_Select.Length - 1, 1000 / 45, TJAPlayer3.Timer);
                                                        }
                                                    }
                                                    break;
                                                case C曲リストノード.Eノード種別.BOX:
                                                    {
                                                        TJAPlayer3.Skin.sound決定音.t再生する();
                                                        act曲リスト.ctBarFlash.t開始(0, 2700, 1, TJAPlayer3.Timer);
                                                        act曲リスト.ctBoxOpen.t開始(200, 2700, 1.3f, TJAPlayer3.Timer);
                                                        act曲リスト.bBoxOpen = true;
                                                        ctDonchan_Select.t開始(0, TJAPlayer3.Tx.SongSelect_Donchan_Select.Length - 1, 1000 / 45, TJAPlayer3.Timer);
                                                    }
                                                    break;
                                                case C曲リストノード.Eノード種別.BACKBOX:
                                                    {
                                                        TJAPlayer3.Skin.sound取消音.t再生する();
                                                        act曲リスト.ctBarFlash.t開始(0, 2700, 1, TJAPlayer3.Timer);
                                                        act曲リスト.ctBoxOpen.t開始(200, 2700, 1.3f, TJAPlayer3.Timer);
                                                        act曲リスト.bBoxClose = true;
                                                        ctDonchan_Select.t開始(0, TJAPlayer3.Tx.SongSelect_Donchan_Select.Length - 1, 1000 / 45, TJAPlayer3.Timer);
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                    #endregion
                                }
                                #region [ Up ]
                                if (!bスクロール中)
                                {
                                    ctキー反復用.Up.tキー反復(TJAPlayer3.Input管理.Keyboard.bキーが押されている((int)SlimDXKeys.Key.LeftArrow), new CCounter.DGキー処理(tカーソルを上へ移動する));
                                    if (TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.LBlue))
                                    {
                                        tカーソルを上へ移動する();
                                    }
                                }
                                else
                                {
                                    if (TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.LBlue))
                                    {
                                        ctDonchan_Jump[0].t開始(0, TJAPlayer3.Tx.SongSelect_Donchan_Jump.Length + 8, 1000 / 45, TJAPlayer3.Timer);
                                        ctDonchan_Jump[1].t開始(0, TJAPlayer3.Tx.SongSelect_Donchan_Jump.Length + 8, 1000 / 45, TJAPlayer3.Timer);
                                        for (int i = 0; i < 7; i++) tカーソルスキップ(true);
                                    }
                                }
                                #endregion
                                #region [ Down ]
                                if (!bスクロール中)
                                {
                                    ctキー反復用.Down.tキー反復(TJAPlayer3.Input管理.Keyboard.bキーが押されている((int)SlimDXKeys.Key.RightArrow), new CCounter.DGキー処理(tカーソルを下へ移動する));
                                    if (TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.RBlue))
                                    {
                                        tカーソルを下へ移動する();
                                    }
                                }
                                else
                                {
                                    if (TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.RBlue))
                                    {
                                        ctDonchan_Jump[0].t開始(0, TJAPlayer3.Tx.SongSelect_Donchan_Jump.Length + 8, 1000 / 45, TJAPlayer3.Timer);
                                        ctDonchan_Jump[1].t開始(0, TJAPlayer3.Tx.SongSelect_Donchan_Jump.Length + 8, 1000 / 45, TJAPlayer3.Timer);
                                        for (int i = 0; i < 7; i++) tカーソルスキップ(false);
                                    }
                                }
                                #endregion
                            }
                            #region [ Upstairs ]
                            if (((act曲リスト.r現在選択中の曲 != null) && (act曲リスト.r現在選択中の曲.r親ノード != null)) && (TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.FT) || TJAPlayer3.Pad.b押されたGB(Eパッド.Cancel)))
                            {
                                actPresound.tサウンド停止();
                                TJAPlayer3.Skin.sound取消音.t再生する();
                                act曲リスト.tBOXを出る();
                                t選択曲変更通知();
                            }
                            #endregion
                            #region [ BDx2: 簡易CONFIG ]
                            if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.Space))
                            {
                                TJAPlayer3.Skin.sound変更音.t再生する();
                                actSortSongs.tActivatePopupMenu(E楽器パート.DRUMS, ref act曲リスト);
                            }
                            #endregion
                            #region [ HHx2: 難易度変更 ]
                            if (TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.HH) || TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.HHO))
                            {   // [HH]x2 難易度変更
                                CommandHistory.Add(E楽器パート.DRUMS, EパッドFlag.HH);
                                EパッドFlag[] comChangeDifficulty = new EパッドFlag[] { EパッドFlag.HH, EパッドFlag.HH };
                                if (CommandHistory.CheckCommand(comChangeDifficulty, E楽器パート.DRUMS))
                                {
                                    Debug.WriteLine("ドラムス難易度変更");
                                    act曲リスト.t難易度レベルをひとつ進める();
                                    TJAPlayer3.Skin.sound変更音.t再生する();
                                }
                            }
                            #endregion
                        }
                    }

                    #region [ Minus & Equals Sound Group Level ]
                    KeyboardSoundGroupLevelControlHandler.Handle(
                        TJAPlayer3.Input管理.Keyboard, TJAPlayer3.SoundGroupLevelController, TJAPlayer3.Skin, true);
                    #endregion

                }
                #endregion

                //------------------------------
                if (act難易度選択画面.bIsDifficltSelect)
                {
                    if (act曲リスト.ctDifficultyIn.n現在の値 >= 1255)
                    {
                        act難易度選択画面.On進行描画();
                    }
                }
                //------------------------------

                #region [ キャラクター ]

                if (TJAPlayer3.ConfigIni.nPlayerCount == 1)
                {
                    var opacity = 0;

                    if (ctCreditAnime.n現在の値 <= 510)
                        opacity = ctCreditAnime.n現在の値 / 2;
                    else if (ctCreditAnime.n現在の値 <= 4500 - 510)
                        opacity = 255;
                    else
                        opacity = 255 - ((ctCreditAnime.n現在の値 - (4500 - 510)) / 2);

                    TJAPlayer3.Tx.SongSelect_Credit.Opacity = opacity;

                    TJAPlayer3.Tx.SongSelect_Credit?.t2D描画(TJAPlayer3.app.Device, 1008, 441);
                }
                for (int i = 0; i < 2; i++)
                {
                    if (ctDonchan_Jump[i].n現在の値 >= ctDonchan_Jump[i].n終了値)
                    {
                        ctDonchan_Jump[i].t停止();

                        if (!act難易度選択画面.bIsDifficltSelect)
                        {
                            ctDonchan_Jump[i].n現在の値 = 0;
                        }
                    }
                }

                if (ctDonchan_Select.b終了値に達してない)
                {
                    if (TJAPlayer3.ConfigIni.nPlayerCount == 2)
                        TJAPlayer3.Tx.SongSelect_Donchan_Select[ctDonchan_Select.n現在の値].t2D左右反転描画(TJAPlayer3.app.Device, 667, 237);

                    TJAPlayer3.Tx.SongSelect_Donchan_Select[ctDonchan_Select.n現在の値].t2D描画(TJAPlayer3.app.Device, -320, 237);
                }
                else
                {
                    if (TJAPlayer3.ConfigIni.nPlayerCount == 2)
                    {
                        if (ctDonchan_Jump[1].n現在の値 > 0)
                        {
                            TJAPlayer3.Tx.SongSelect_Donchan_Jump[ctDonchan_Jump[1].n現在の値 >= 15 ? 15 : ctDonchan_Jump[1].n現在の値].t2D左右反転描画(TJAPlayer3.app.Device, 667, 237);//980
                        }
                        else
                        {
                            TJAPlayer3.Tx.SongSelect_Donchan_Normal[ctDonchan_Normal.n現在の値].t2D左右反転描画(TJAPlayer3.app.Device, 667, 237);
                        }
                    }
                    if (ctDonchan_Jump[0].n現在の値 > 0)
                    {
                        TJAPlayer3.Tx.SongSelect_Donchan_Jump[ctDonchan_Jump[0].n現在の値 >= 15 ? 15 : ctDonchan_Jump[0].n現在の値].t2D描画(TJAPlayer3.app.Device, -320, 237);
                    }
                    else
                    {
                        TJAPlayer3.Tx.SongSelect_Donchan_Normal[ctDonchan_Normal.n現在の値].t2D描画(TJAPlayer3.app.Device, -320, 237);//330
                    }
                }

                //TJAPlayer3.Tx.PuchiChara[0].vc拡大縮小倍率.X = 0.75f;
                //TJAPlayer3.Tx.PuchiChara[0].vc拡大縮小倍率.Y = 0.75f;
                var sineY = Math.Sin(ctPuchiSineCounter.n現在の値 * (Math.PI / 180)) * (20 * TJAPlayer3.Skin.Game_PuchiChara_Scale[0]);
                TJAPlayer3.Tx.PuchiChara[0]?.t2D描画(TJAPlayer3.app.Device, -10, 440 + (int)sineY, new Rectangle(ctPuchiCounter.n現在の値 * TJAPlayer3.Skin.Game_PuchiChara[0], TJAPlayer3.Skin.Game_PuchiChara[1], TJAPlayer3.Skin.Game_PuchiChara[0], TJAPlayer3.Skin.Game_PuchiChara[1]));



                #endregion

                act曲リスト.On進行描画();
                actSortSongs.t進行描画();
                actQuickConfig.t進行描画();

                #region [ ネームプレート ]
                for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
                {
                    TJAPlayer3.NamePlate.tNamePlateDraw(TJAPlayer3.Skin.SongSelect_NamePlate_X[i], TJAPlayer3.Skin.SongSelect_NamePlate_Y[i], i);
                }
                #endregion

                #region [ 演奏オプションアイコン ]
                for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
                {
                    ModIcons.tDisplayModsMenu(40 + i * 980, 672, i);
                }
                #endregion

                #region[ 下部テキスト ]

                if (TJAPlayer3.Tx.SongSelect_Auto != null)
                {
                    if (TJAPlayer3.ConfigIni.b太鼓パートAutoPlay)
                    {
                        TJAPlayer3.Tx.SongSelect_Auto.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.SongSelect_Auto_X[0], TJAPlayer3.Skin.SongSelect_Auto_Y[0]);
                    }
                    if (TJAPlayer3.ConfigIni.nPlayerCount > 1 && TJAPlayer3.ConfigIni.b太鼓パートAutoPlay2P)
                    {
                        TJAPlayer3.Tx.SongSelect_Auto.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.SongSelect_Auto_X[1], TJAPlayer3.Skin.SongSelect_Auto_Y[1]);
                    }
                }
                if (TJAPlayer3.ConfigIni.bTokkunMode)
                    TJAPlayer3.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.白, "GAME: TRAINING MODE");
                if (TJAPlayer3.ConfigIni.eGameMode == EGame.完走叩ききりまショー)
                    TJAPlayer3.act文字コンソール.tPrint(0, 16, C文字コンソール.Eフォント種別.白, "GAME: SURVIVAL");
                if (TJAPlayer3.ConfigIni.eGameMode == EGame.完走叩ききりまショー激辛)
                    TJAPlayer3.act文字コンソール.tPrint(0, 16, C文字コンソール.Eフォント種別.白, "GAME: SURVIVAL HARD");
                if (TJAPlayer3.ConfigIni.bSuperHard)
                    TJAPlayer3.act文字コンソール.tPrint(0, 32, C文字コンソール.Eフォント種別.赤, "SUPER HARD MODE : ON");
                if (TJAPlayer3.ConfigIni.eScrollMode == EScrollMode.BMSCROLL)
                    TJAPlayer3.act文字コンソール.tPrint(0, 48, C文字コンソール.Eフォント種別.赤, "BMSCROLL : ON");
                else if (TJAPlayer3.ConfigIni.eScrollMode == EScrollMode.HBSCROLL)
                    TJAPlayer3.act文字コンソール.tPrint(0, 48, C文字コンソール.Eフォント種別.赤, "HBSCROLL : ON");

                TJAPlayer3.Tx.SongSelect_Other?.t2D描画(TJAPlayer3.app.Device, 1081, 163, new RectangleF(0, 129, 179, 40));
                TJAPlayer3.Tx.SongSelect_Other?.t2D描画(TJAPlayer3.app.Device, 17, 209, new RectangleF(0, 0, 212, 129));
                TJAPlayer3.Tx.Entry_Overlay?.t2D描画(TJAPlayer3.app.Device, 1050, 0, new RectangleF(327, 0, 230, 156));

                if (TJAPlayer3.ConfigIni.nPlayerCount == 2)
                {
                    TJAPlayer3.Tx.SongSelect_Other?.t2D描画(TJAPlayer3.app.Device, 1048, 209, new RectangleF(0, 0, 212, 129));
                    //TJAPlayer3.act文字コンソール.tPrint(800, 400, C文字コンソール.Eフォント種別.赤, "演奏履歴データがありません");
                }

                #endregion

                for (int i = 0; i < 10; i++)
                {
                    tBoardNumberDraw(ptBoardNumber[i].X - 10, ptBoardNumber[i].Y, i < 7 ? act曲リスト.ScoreRankCount[i].ToString() : act曲リスト.CrownCount[i - 7].ToString());
                }
                tTimerDraw((100 - ctTimer.n現在の値).ToString());
                tSongNumberDraw(1097, 165, NowSong.ToString());
                tSongNumberDraw(1190, 167, MaxSong.ToString());
                act演奏履歴パネル.On進行描画();

                if (act難易度選択画面.bOption[0]) actPlayOption.On進行描画(0);
                if (act難易度選択画面.bOption[1]) actPlayOption.On進行描画(1);

                switch (eフェーズID)
                {
                    case Eフェーズ.共通_フェードイン:
                        if (actFIFO.On進行描画() != 0)
                        {
                            eフェーズID = Eフェーズ.共通_通常状態;
                        }
                        break;

                    case Eフェーズ.共通_フェードアウト:
                        if (actFIFO.On進行描画() == 0)
                        {
                            break;
                        }
                        return (int)eフェードアウト完了時の戻り値;

                    case Eフェーズ.選曲_結果画面からのフェードイン:
                        if (actFIfrom結果画面.On進行描画() != 0)
                        {
                            eフェーズID = Eフェーズ.共通_通常状態;
                        }
                        break;

                    case Eフェーズ.選曲_NowLoading画面へのフェードアウト:
                        if (actFOtoNowLoading.On進行描画() == 0)
                        {
                            break;
                        }
                        return (int)eフェードアウト完了時の戻り値;
                }
            }
            return 0;
        }
        public enum E戻り値 : int
        {
            継続,
            タイトルに戻る,
            選曲した,
            オプション呼び出し,
            コンフィグ呼び出し,
            スキン変更
        }

        // その他

        #region [ private ]
        //-----------------
        [StructLayout(LayoutKind.Sequential)]
        private struct STキー反復用カウンタ
        {
            public CCounter Up;
            public CCounter Down;
            public CCounter this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0:
                            return Up;

                        case 1:
                            return Down;
                    }
                    throw new IndexOutOfRangeException();
                }
                set
                {
                    switch (index)
                    {
                        case 0:
                            Up = value;
                            return;

                        case 1:
                            Down = value;
                            return;
                    }
                    throw new IndexOutOfRangeException();
                }
            }
        }
        public CCounter ctTimer;
        private CCounter ctCreditAnime;
        private CCounter ctPuchiCounter;
        private CCounter ctPuchiSineCounter;
        private readonly Random[] r = new Random[3];
        public CCounter ctBackgroundFade;
        public string NowGenre;
        public string OldGenre;
        private CActSelectArtistComment actArtistComment;
        private CActFIFOBlack actFIFO;
        private CActFIFOBlack actFIfrom結果画面;
        //private CActFIFOBlack actFOtoNowLoading;
        public CActFIFOStart actFOtoNowLoading;
        private CActSelectInformation actInformation;
        //private CActSelectPreimageパネル actPreimageパネル;
        public CActSelectPresound actPresound;
        //private CActオプションパネル actオプションパネル;
        private CActSelectステータスパネル actステータスパネル;
        public CActSelect演奏履歴パネル act演奏履歴パネル;
        public CActSelect曲リスト act曲リスト;
        public CActSelect曲リスト bBoxClose;
        //public bool bBoxClose;
        private CActSelectShowCurrentPosition actShowCurrentPosition;
        public CActSelect難易度選択画面 act難易度選択画面;
        public CActPlayOption actPlayOption;
        private CPrivateFastFont pfScore;

        public CActSortSongs actSortSongs;
        private CActSelectQuickConfig actQuickConfig;

        public int MaxSong = 3;
        public int NowSong = 1;

        private CCounter ctDonchan_Normal;
        private CCounter ctDonchan_Select;
        public CCounter[] ctDonchan_Jump = new CCounter[2];
        private readonly PuchiChara PuchiChara;
        private int nGenreBack;
        private int nOldGenreBack;
        public bool bBGM再生済み;
        public bool bBGMIn再生した;
        private STキー反復用カウンタ ctキー反復用;
        public CCounter ct登場時アニメ用共通;
        private CCounter ct背景スクロール用タイマー;
        private E戻り値 eフェードアウト完了時の戻り値;
        private Font ftフォント;
        private readonly CCounter ctDiffSelect移動待ち;

        private STNumber[] stTimer = new STNumber[10];
        public STNumber[] stSongNumber = new STNumber[10];
        private STNumber[] stBoardNumber = new STNumber[10];

        public struct STNumber
        {
            public char ch;
            public Point pt;
        }
        private struct STCommandTime        // #24063 2011.1.16 yyagi コマンド入力時刻の記録用
        {
            public E楽器パート eInst;        // 使用楽器
            public EパッドFlag ePad;       // 押されたコマンド(同時押しはOR演算で列挙する)
            public long time;               // コマンド入力時刻
        }

        private Point[] ptBoardNumber =
            { new Point(72, 283), new Point(135, 283), new Point(200, 283), new Point(72, 258), new Point(135, 258), new Point(200, 258), new Point(200, 233), new Point(72, 311), new Point(135, 311), new Point(200, 311) };

        public void tBoardNumberDraw(int x, int y, string str)
        {
            for (int j = 0; j < str.Length; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (str[j] == stSongNumber[i].ch)
                    {
                        TJAPlayer3.Tx.SongSelect_BoardNumber.t2D描画(TJAPlayer3.app.Device, x - (str.Length * 15 + 9 * str.Length - str.Length * 15) / 2 + 15 / 2, (float)y - 17 / 2, new RectangleF(stBoardNumber[i].pt.X, stBoardNumber[i].pt.Y, 15, 17));
                        x += 9;
                    }
                }
            }
        }

        public void tSongNumberDraw(int x, int y, string str)
        {
            for (int j = 0; j < str.Length; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (str[j] == stSongNumber[i].ch)
                    {
                        TJAPlayer3.Tx.SongSelect_Song_Number.t2D描画(TJAPlayer3.app.Device, x - (str.Length * 27 + 27 * str.Length - str.Length * 27) / 2 + 27 / 2, (float)y, new RectangleF(stSongNumber[i].pt.X, stSongNumber[i].pt.Y, 27, 29));
                        x += str.Length >= 2 ? 16 : 27;
                    }
                }
            }
        }

        private void tTimerDraw(string str)
        {
            int x = 1171, y = 57;

            for (int j = 0; j < str.Length; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (TJAPlayer3.ConfigIni.bEnableCountdownTimer)
                    {
                        if (str[j] == stTimer[i].ch)
                        {
                            TJAPlayer3.Tx.SongSelect_Timer.t2D描画(TJAPlayer3.app.Device, x - (str.Length * 46 + 46 * str.Length - str.Length * 46) / 2 + 46 / 2, (float)y, new RectangleF(stTimer[i].pt.X, stTimer[i].pt.Y, 46, 64));
                            x += str.Length >= 3 ? 40 : 46;
                        }
                    }
                }
            }
        }

        private class CCommandHistory       // #24063 2011.1.16 yyagi コマンド入力履歴を保持_確認するクラス
        {
            readonly int buffersize = 16;
            private List<STCommandTime> stct;

            public CCommandHistory()        // コンストラクタ
            {
                stct = new List<STCommandTime>(buffersize);
            }

            /// <summary>
            /// コマンド入力履歴へのコマンド追加
            /// </summary>
            /// <param name="_eInst">楽器の種類</param>
            /// <param name="_ePad">入力コマンド(同時押しはOR演算で列挙すること)</param>
            public void Add(E楽器パート _eInst, EパッドFlag _ePad)
            {
                STCommandTime _stct = new STCommandTime
                {
                    eInst = _eInst,
                    ePad = _ePad,
                    time = TJAPlayer3.Timer.n現在時刻
                };

                if (stct.Count >= buffersize)
                {
                    stct.RemoveAt(0);
                }
                stct.Add(_stct);
                //Debug.WriteLine( "CMDHIS: 楽器=" + _stct.eInst + ", CMD=" + _stct.ePad + ", time=" + _stct.time );
            }
            public void RemoveAt(int index)
            {
                stct.RemoveAt(index);
            }

            /// <summary>
            /// コマンド入力に成功しているか調べる
            /// </summary>
            /// <param name="_ePad">入力が成功したか調べたいコマンド</param>
            /// <param name="_eInst">対象楽器</param>
            /// <returns>コマンド入力成功時true</returns>
            public bool CheckCommand(EパッドFlag[] _ePad, E楽器パート _eInst)
            {
                int targetCount = _ePad.Length;
                int stciCount = stct.Count;
                if (stciCount < targetCount)
                {
                    //Debug.WriteLine("NOT start checking...stciCount=" + stciCount + ", targetCount=" + targetCount);
                    return false;
                }

                long curTime = TJAPlayer3.Timer.n現在時刻;
                //Debug.WriteLine("Start checking...targetCount=" + targetCount);
                for (int i = targetCount - 1, j = stciCount - 1; i >= 0; i--, j--)
                {
                    if (_ePad[i] != stct[j].ePad)
                    {
                        //Debug.WriteLine( "CMD解析: false targetCount=" + targetCount + ", i=" + i + ", j=" + j + ": ePad[]=" + _ePad[i] + ", stci[j] = " + stct[j].ePad );
                        return false;
                    }
                    if (stct[j].eInst != _eInst)
                    {
                        //Debug.WriteLine( "CMD解析: false " + i );
                        return false;
                    }
                    if (curTime - stct[j].time > 500)
                    {
                        //Debug.WriteLine( "CMD解析: false " + i + "; over 500ms" );
                        return false;
                    }
                    curTime = stct[j].time;
                }

                stct.Clear();                                   // #24396 2011.2.13 yyagi Clear all command input history in case you succeeded inputting some command

                return true;
            }
        }
        private CCommandHistory CommandHistory;

        private void tカーソルを下へ移動する()
        {
            if ((act曲リスト.r次の曲(r現在選択中の曲).eノード種別 == C曲リストノード.Eノード種別.SCORE) || act曲リスト.r次の曲(r現在選択中の曲).eノード種別 == C曲リストノード.Eノード種別.BACKBOX)
            {
                TJAPlayer3.stage選曲.bBGMIn再生した = false;
                TJAPlayer3.Skin.bgm選曲画面イン.n位置_現在のサウンド = 0;
                TJAPlayer3.Skin.bgm選曲画面.n位置_現在のサウンド = 0;
                TJAPlayer3.Skin.bgm選曲画面イン.t停止する();
                TJAPlayer3.Skin.bgm選曲画面.t停止する();
            }
            else
            {
                if (!bBGMIn再生した)
                {
                    TJAPlayer3.stage選曲.bBGM再生済み = false;
                    if (TJAPlayer3.ConfigIni.bBGM音を発声する && !TJAPlayer3.Skin.bgm選曲画面イン.b再生中 && !TJAPlayer3.Skin.bgm選曲画面.b再生中)
                        TJAPlayer3.Skin.bgm選曲画面イン.t再生する();
                    bBGMIn再生した = true;
                }
            }
            ctBackgroundFade.t開始(0, 600, 1, TJAPlayer3.Timer);
            if (act曲リスト.ctBarOpen.n現在の値 >= 200 || ctBackgroundFade.n現在の値 >= 600 - 255)
                TJAPlayer3.stage選曲.OldGenre = this.r現在選択中の曲.strジャンル;
            act曲リスト.t次に移動();
            TJAPlayer3.Skin.soundカーソル移動音.t再生する();
        }
        private void tカーソルを上へ移動する()
        {
            if ((act曲リスト.r前の曲(r現在選択中の曲).eノード種別 == C曲リストノード.Eノード種別.SCORE) || act曲リスト.r前の曲(r現在選択中の曲).eノード種別 == C曲リストノード.Eノード種別.BACKBOX)
            {
                TJAPlayer3.stage選曲.bBGMIn再生した = false;
                TJAPlayer3.Skin.bgm選曲画面.t停止する();
                TJAPlayer3.Skin.bgm選曲画面イン.t停止する();
            }
            else
            {
                if (!bBGMIn再生した)
                {
                    TJAPlayer3.stage選曲.bBGM再生済み = false;
                    if (TJAPlayer3.ConfigIni.bBGM音を発声する && !TJAPlayer3.Skin.bgm選曲画面イン.b再生中 && !TJAPlayer3.Skin.bgm選曲画面.b再生中)
                        TJAPlayer3.Skin.bgm選曲画面イン.t再生する();
                    bBGMIn再生した = true;
                }
            }
            ctBackgroundFade.t開始(0, 600, 1, TJAPlayer3.Timer);
            if (act曲リスト.ctBarOpen.n現在の値 >= 200 || ctBackgroundFade.n現在の値 >= 600 - 255)
                TJAPlayer3.stage選曲.OldGenre = r現在選択中の曲.strジャンル;
            act曲リスト.t前に移動();
            TJAPlayer3.Skin.soundカーソル移動音.t再生する();
        }
        private void tカーソルスキップ(bool Up)
        {
            ctBackgroundFade.t開始(0, 600, 1, TJAPlayer3.Timer);
            if (act曲リスト.ctBarOpen.n現在の値 >= 200 || ctBackgroundFade.n現在の値 >= 600 - 255)
                TJAPlayer3.stage選曲.OldGenre = r現在選択中の曲.strジャンル;
            if (Up) act曲リスト.t前に移動();
            else act曲リスト.t次に移動();

            TJAPlayer3.Skin.soundSkip.t再生する();
        }

        private void t曲をランダム選択する()
        {
            C曲リストノード song = act曲リスト.r現在選択中の曲;
            if ((song.stackランダム演奏番号.Count == 0) || (song.listランダム用ノードリスト == null))
            {
                if (song.listランダム用ノードリスト == null)
                {
                    song.listランダム用ノードリスト = t指定された曲が存在する場所の曲を列挙する_子リスト含む(song);
                }
                int count = song.listランダム用ノードリスト.Count;
                if (count == 0)
                {
                    return;
                }
                int[] numArray = new int[count];
                for (int i = 0; i < count; i++)
                {
                    numArray[i] = i;
                }
                for (int j = 0; j < (count * 1.5); j++)
                {
                    int index = TJAPlayer3.Random.Next(count);
                    int num5 = TJAPlayer3.Random.Next(count);
                    (numArray[index], numArray[num5]) = (numArray[num5], numArray[index]);
                }
                for (int k = 0; k < count; k++)
                {
                    song.stackランダム演奏番号.Push(numArray[k]);
                }
                if (TJAPlayer3.ConfigIni.bLogDTX詳細ログ出力)
                {
                    StringBuilder builder = new StringBuilder(0x400);
                    builder.Append(string.Format("ランダムインデックスリストを作成しました: {0}曲: ", song.stackランダム演奏番号.Count));
                    for (int m = 0; m < count; m++)
                    {
                        builder.Append(string.Format("{0} ", numArray[m]));
                    }
                    Trace.TraceInformation(builder.ToString());
                }
            }
            r確定された曲 = song.listランダム用ノードリスト[song.stackランダム演奏番号.Pop()];
            n確定された曲の難易度[0] = act曲リスト.n現在のアンカ難易度レベルに最も近い難易度レベルを返す(r確定された曲);
            r確定されたスコア = r確定された曲.arスコア[n確定された曲の難易度[0]];
            str確定された曲のジャンル = r確定された曲.strジャンル;
            eフェードアウト完了時の戻り値 = E戻り値.選曲した;
            actFOtoNowLoading.tフェードアウト開始();                    // #27787 2012.3.10 yyagi 曲決定時の画面フェードアウトの省略
            eフェーズID = Eフェーズ.選曲_NowLoading画面へのフェードアウト;
            if (TJAPlayer3.ConfigIni.bLogDTX詳細ログ出力)
            {
                int[] numArray2 = song.stackランダム演奏番号.ToArray();
                StringBuilder builder2 = new StringBuilder(0x400);
                builder2.Append("ランダムインデックスリスト残り: ");
                if (numArray2.Length > 0)
                {
                    for (int n = 0; n < numArray2.Length; n++)
                    {
                        builder2.Append(string.Format("{0} ", numArray2[n]));
                    }
                }
                else
                {
                    builder2.Append("(なし)");
                }
                Trace.TraceInformation(builder2.ToString());
            }
            TJAPlayer3.Skin.bgm選曲画面.t停止する();
        }
        private void t曲を選択する()
        {
            r確定された曲 = act曲リスト.r現在選択中の曲;
            r確定されたスコア = act曲リスト.r現在選択中のスコア;
            n確定された曲の難易度[0] = act曲リスト.n現在選択中の曲の現在の難易度レベル;
            str確定された曲のジャンル = r確定された曲.strジャンル;
            if ((r確定された曲 != null) && (r確定されたスコア != null))
            {
                eフェードアウト完了時の戻り値 = E戻り値.選曲した;
                actFOtoNowLoading.tフェードアウト開始();                // #27787 2012.3.10 yyagi 曲決定時の画面フェードアウトの省略
                eフェーズID = Eフェーズ.選曲_NowLoading画面へのフェードアウト;
            }
            TJAPlayer3.Skin.bgm選曲画面.t停止する();
        }
        public void t曲を選択する(int nCurrentLevel, int player)
        {
            r確定された曲 = act曲リスト.r現在選択中の曲;
            r確定されたスコア = act曲リスト.r現在選択中のスコア;
            n確定された曲の難易度[player] = nCurrentLevel;
            str確定された曲のジャンル = r確定された曲.strジャンル;
            if ((r確定された曲 != null) && (r確定されたスコア != null))
            {
                eフェードアウト完了時の戻り値 = E戻り値.選曲した;
                actFOtoNowLoading.tフェードアウト開始();                // #27787 2012.3.10 yyagi 曲決定時の画面フェードアウトの省略
                eフェーズID = Eフェーズ.選曲_NowLoading画面へのフェードアウト;
            }
            TJAPlayer3.Skin.bgm選曲画面.t停止する();
        }
        private List<C曲リストノード> t指定された曲が存在する場所の曲を列挙する_子リスト含む(C曲リストノード song)
        {
            List<C曲リストノード> list = new List<C曲リストノード>();
            song = song.r親ノード;
            if ((song == null) && (TJAPlayer3.Songs管理.list曲ルート.Count > 0))
            {
                foreach (C曲リストノード c曲リストノード in TJAPlayer3.Songs管理.list曲ルート)
                {
                    if ((c曲リストノード.eノード種別 == C曲リストノード.Eノード種別.SCORE) || (c曲リストノード.eノード種別 == C曲リストノード.Eノード種別.SCORE_MIDI))
                    {
                        list.Add(c曲リストノード);
                    }
                    if ((c曲リストノード.list子リスト != null) && TJAPlayer3.ConfigIni.bランダムセレクトで子BOXを検索対象とする)
                    {
                        t指定された曲の子リストの曲を列挙する_孫リスト含む(c曲リストノード, ref list);
                    }
                }
                return list;
            }
            t指定された曲の子リストの曲を列挙する_孫リスト含む(song, ref list);
            return list;
        }
        private void t指定された曲の子リストの曲を列挙する_孫リスト含む(C曲リストノード r親, ref List<C曲リストノード> list)
        {
            if ((r親 != null) && (r親.list子リスト != null))
            {
                foreach (C曲リストノード c曲リストノード in r親.list子リスト)
                {
                    if ((c曲リストノード.eノード種別 == C曲リストノード.Eノード種別.SCORE) || (c曲リストノード.eノード種別 == C曲リストノード.Eノード種別.SCORE_MIDI))
                    {
                        list.Add(c曲リストノード);
                    }
                    if ((c曲リストノード.list子リスト != null) && TJAPlayer3.ConfigIni.bランダムセレクトで子BOXを検索対象とする)
                    {
                        t指定された曲の子リストの曲を列挙する_孫リスト含む(c曲リストノード, ref list);
                    }
                }
            }
        }

        public int nStrジャンルtoNum(string strジャンル)
        {
            int nGenre = 8;
            for (int i = 0; i < TJAPlayer3.Skin.SongSelect_GenreName.Length; i++)
            {
                if (TJAPlayer3.Skin.SongSelect_GenreName[i] == strジャンル)
                {
                    if (i + 1 >= TJAPlayer3.Skin.SongSelect_Genre_Background_Count)
                    {
                        nGenre = 0;
                    }
                    else
                    {
                        nGenre = i + 1;
                    }
                    break;
                }
                else
                {
                    nGenre = 0;
                }
            }
            return nGenre;
        }
        //-----------------
        #endregion
    }
}