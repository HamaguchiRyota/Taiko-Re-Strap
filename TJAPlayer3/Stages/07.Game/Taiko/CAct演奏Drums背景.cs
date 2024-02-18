using System;
using System.IO.Ports;
using FDK;

namespace TJAPlayer3
{
    internal class CAct演奏Drums背景 : CActivity
    {
        public CAct演奏Drums背景()
        {
            base.b活性化してない = true;
        }

        public void tFadeIn(int player)
        {
            ct上背景クリアインタイマー[player] = new CCounter(0, 100, 2, TJAPlayer3.Timer);
            eFadeMode = EFIFOモード.フェードイン;
        }

        public void ClearIn(int player)
        {
            ct上背景クリアインタイマー[player] = new CCounter(0, 100, 2, TJAPlayer3.Timer);
            ct上背景クリアインタイマー[player].n現在の値 = 0;
            ct上背景FIFOタイマー = new CCounter(0, 100, 2, TJAPlayer3.Timer);
            ct上背景FIFOタイマー.n現在の値 = 0;
        }

        public override void On活性化()
        {
            base.On活性化();
        }

        public override void On非活性化()
        {
            TJAPlayer3.t安全にDisposeする(ref ct上背景FIFOタイマー);
            for (int i = 0; i < 2; i++)
            {
                ct上背景スクロール用タイマー[i] = null;
                ct上背景サブスクロール用タイマー[i] = null;
                ct上背景上下用タイマー[i] = null;
                ct上背景桜用タイマー[i] = null;
                ct上背景桜スクロール用タイマー[i] = null;
            }
            TJAPlayer3.t安全にDisposeする(ref ct上背景スクロール用タイマー);
            TJAPlayer3.t安全にDisposeする(ref ct上背景サブスクロール用タイマー);
            TJAPlayer3.t安全にDisposeする(ref ct上背景上下用タイマー);
            TJAPlayer3.t安全にDisposeする(ref ct上背景桜用タイマー);
            TJAPlayer3.t安全にDisposeする(ref ct上背景桜スクロール用タイマー);
            TJAPlayer3.t安全にDisposeする(ref ct下背景スクロール用タイマー1);
            TJAPlayer3.t安全にDisposeする(ref ct下背景スクロール用タイマー2);
            TJAPlayer3.t安全にDisposeする(ref ct下背景スクロール用タイマー3);
            TJAPlayer3.t安全にDisposeする(ref ct下背景上下用タイマー);

            TJAPlayer3.t安全にDisposeする(ref ct点滅0);
            TJAPlayer3.t安全にDisposeする(ref ct点滅1);
            TJAPlayer3.t安全にDisposeする(ref ct点滅2);

            base.On非活性化();
        }

        public override void OnManagedリソースの作成()
        {
            ct上背景スクロール用タイマー = new CCounter[2];
            ct上背景サブスクロール用タイマー = new CCounter[2];
            ct上背景上下用タイマー = new CCounter[2];
            ct上背景桜用タイマー = new CCounter[2];
            ct上背景桜スクロール用タイマー = new CCounter[2];
            ct上背景クリアインタイマー = new CCounter[2];
            ct上背景スクロール用タイマー1stDan = new CCounter[4];

            for (int i = 0; i < 2; i++)
            {
                if (TJAPlayer3.Tx.Background_Up[i] != null)
                {
                    ct上背景スクロール用タイマー[i] = new CCounter(1, TJAPlayer3.Tx.Background_Up_Clear[i].szテクスチャサイズ.Width, 16, TJAPlayer3.Timer);
                    ct上背景サブスクロール用タイマー[i] = new CCounter(1, TJAPlayer3.Tx.Background_Up_YMove[i].szテクスチャサイズ.Width, 16, TJAPlayer3.Timer);
                    ct上背景上下用タイマー[i] = new CCounter(1, 100, 25, TJAPlayer3.Timer);
                    ct上背景桜用タイマー[i] = new CCounter(0, 400, 9, TJAPlayer3.Timer);
                    if (TJAPlayer3.Tx.Background_Up_Sakura[i] != null)
                        ct上背景桜スクロール用タイマー[i] = new CCounter(0, TJAPlayer3.Tx.Background_Up_Sakura[i].szテクスチャサイズ.Width, 8, TJAPlayer3.Timer);

                    ct下背景上下用タイマー = new CCounter(1, 100, 15, TJAPlayer3.Timer);
                    ct上背景クリアインタイマー[i] = new CCounter();
                }
			}
            if (TJAPlayer3.Tx.Background_Up_Dan != null)
            {
                ct上背景スクロール用タイマー1stDan[0] = new CCounter(0, TJAPlayer3.Tx.Background_Up_Dan[1].szテクスチャサイズ.Width, 8.453f * 2, TJAPlayer3.Timer);
                ct上背景スクロール用タイマー1stDan[1] = new CCounter(0, TJAPlayer3.Tx.Background_Up_Dan[2].szテクスチャサイズ.Width, 10.885f * 2, TJAPlayer3.Timer);
                ct上背景スクロール用タイマー1stDan[2] = new CCounter(0, TJAPlayer3.Tx.Background_Up_Dan[3].szテクスチャサイズ.Width, 11.4f * 2, TJAPlayer3.Timer);
                ct上背景スクロール用タイマー1stDan[3] = new CCounter(0, TJAPlayer3.Tx.Background_Up_Dan[5].szテクスチャサイズ.Width, 33.88f, TJAPlayer3.Timer);
                ct上背景スクロール用タイマー2stDan = new CCounter(0, TJAPlayer3.Tx.Background_Up_Dan[4].szテクスチャサイズ.Width + 200, 10, TJAPlayer3.Timer);
            }

            ct点滅0 = new CCounter(0, 100, 20, TJAPlayer3.Timer);
            ct点滅1 = new CCounter(0, 100, 1, TJAPlayer3.Timer);
            ct点滅2 = new CCounter(0, 100, 60, TJAPlayer3.Timer);

            if (TJAPlayer3.Tx.Background_Down_Scroll != null && TJAPlayer3.Tx.Background_Down_Scroll_Matu != null && TJAPlayer3.Tx.Background_Down_Scroll_Kumo != null)
            {
                ct下背景スクロール用タイマー1 = new CCounter(1, TJAPlayer3.Tx.Background_Down_Scroll.szテクスチャサイズ.Width, 20, TJAPlayer3.Timer);
                ct下背景スクロール用タイマー2 = new CCounter(1, TJAPlayer3.Tx.Background_Down_Scroll_Matu.szテクスチャサイズ.Width, 13, TJAPlayer3.Timer);
                ct下背景スクロール用タイマー3 = new CCounter(1, TJAPlayer3.Tx.Background_Down_Scroll_Kumo.szテクスチャサイズ.Width, 18, TJAPlayer3.Timer);
            }

            ct上背景FIFOタイマー = new CCounter();
            base.OnManagedリソースの作成();
        }

        public override void OnManagedリソースの解放()
        {
            base.OnManagedリソースの解放();
        }

        public override int On進行描画()
        {
            ct上背景FIFOタイマー.t進行();

            for (int i = 0; i < 2; i++)
            {
                ct上背景スクロール用タイマー[i]?.t進行Loop();
                ct上背景サブスクロール用タイマー[i]?.t進行Loop();
                ct上背景クリアインタイマー[i]?.t進行();
                ct上背景上下用タイマー[i]?.t進行Loop();
                ct上背景桜用タイマー[i]?.t進行Loop();
                ct上背景桜スクロール用タイマー[i]?.t進行Loop();
            }
            ct下背景スクロール用タイマー1?.t進行Loop();
            ct下背景スクロール用タイマー2?.t進行Loop();
            ct下背景スクロール用タイマー3?.t進行Loop();
            ct下背景上下用タイマー?.t進行Loop();
            ct上背景スクロール用タイマー2stDan?.t進行Loop();

            #region [ 1P-2P-上背景 ]

            if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)
            {
                #region [ 通常背景 ]

                for (int i = 0; i < 2; i++)
                {
                    int ym;
                    int xm;
                    double textureSizeRatio = 1280.0;
                    int loopCount = (int)Math.Ceiling(textureSizeRatio) + 1;

                    #region [ 新 ]
                    if (ct上背景スクロール用タイマー[i] != null && TJAPlayer3.Tx.Background_Up[i] != null)
                    {
                        _ = 1280.0 / TJAPlayer3.Tx.Background_Up[i].szテクスチャサイズ.Width;

                        TJAPlayer3.Tx.Background_Up[i].t2D描画(TJAPlayer3.app.Device, 0 - ct上背景スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);

                        for (int l = 1; l < loopCount + 1; l++)
                        {
                            TJAPlayer3.Tx.Background_Up[i].t2D描画(TJAPlayer3.app.Device, (l * TJAPlayer3.Tx.Background_Up[i].szテクスチャサイズ.Width) - ct上背景スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);
                        }
                    }

                    if (ct上背景桜用タイマー[i] != null && ct上背景桜スクロール用タイマー[i] != null && TJAPlayer3.Tx.Background_Up_Sakura[i] != null)
                    {
                        int xy = (int)(ct上背景桜用タイマー[i].n現在の値 - (ct上背景桜用タイマー[i].n終了値 / 2.0));
                        _ = 1280.0 / TJAPlayer3.Tx.Background_Up_Sakura[i].szテクスチャサイズ.Width;

                        for (int l = 0; l < 1308 / TJAPlayer3.Tx.Background_Up_Sakura[i].szテクスチャサイズ.Width + 2; l++)
                        {
                            TJAPlayer3.Tx.Background_Up_Sakura[i].t2D描画(TJAPlayer3.app.Device, (l * TJAPlayer3.Tx.Background_Up_Sakura[i].szテクスチャサイズ.Width) - ct上背景桜スクロール用タイマー[i].n現在の値 - xy, TJAPlayer3.Skin.Background_Scroll_Y[i] + xy);
                        }
                    }

                    if (ct上背景上下用タイマー[i] != null && TJAPlayer3.Tx.Background_Up_YMove[i] != null)
                    {

                        if (ct上背景上下用タイマー[i].n現在の値 <= ct上背景上下用タイマー[i].n終了値 * 0.5)
                            ym = (int)((-ct上背景上下用タイマー[i].n現在の値) * 0.5);
                        else
                            ym = (int)((ct上背景上下用タイマー[i].n現在の値 - ct上背景上下用タイマー[i].n終了値) * 0.5);
                        ym -= (int)(ct上背景上下用タイマー[i].n終了値 * 0.0625);
                        xm = ct上背景サブスクロール用タイマー[i].n現在の値;

                        for (int l = 0; l < 1304 / TJAPlayer3.Tx.Background_Up_YMove[i].szテクスチャサイズ.Width + 2; l++)
                        {
                            TJAPlayer3.Tx.Background_Up_YMove[i].t2D描画(TJAPlayer3.app.Device, (l * TJAPlayer3.Tx.Background_Up_YMove[i].szテクスチャサイズ.Width) - xm, TJAPlayer3.Skin.Background_Scroll_Y[i] + ym);
                        }
                    }

                    if (ct上背景クリアインタイマー[i] != null && TJAPlayer3.Tx.Background_Up_Clear[i] != null)
                    {
                        if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[i])
                            TJAPlayer3.Tx.Background_Up_Clear[i].Opacity = ((ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                        else
                            TJAPlayer3.Tx.Background_Up_Clear[i].Opacity = 0;

                        _ = 1280.0 / TJAPlayer3.Tx.Background_Up_Clear[i].szテクスチャサイズ.Width;

                        TJAPlayer3.Tx.Background_Up_Clear[i].t2D描画(TJAPlayer3.app.Device, 0 - ct上背景スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);

                        for (int l = 1; l < loopCount + 1; l++)
                        {
                            TJAPlayer3.Tx.Background_Up_Clear[i].t2D描画(TJAPlayer3.app.Device, (l * TJAPlayer3.Tx.Background_Up_Clear[i].szテクスチャサイズ.Width) - ct上背景スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);
                        }
                    }

                    if (ct上背景クリアインタイマー[i] != null && TJAPlayer3.Tx.Background_Up_Sakura_Clear[i] != null)
                    {
                        if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[i])
                            TJAPlayer3.Tx.Background_Up_Sakura_Clear[i].Opacity = ((ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                        else
                            TJAPlayer3.Tx.Background_Up_Sakura_Clear[i].Opacity = 0;

                        int xy = (int)(ct上背景桜用タイマー[i].n現在の値 - ct上背景桜用タイマー[i].n終了値 / 2.0);
                        _ = 1280.0 / TJAPlayer3.Tx.Background_Up_Sakura_Clear[i].szテクスチャサイズ.Width;

                        for (int l = 0; l < 1308 / TJAPlayer3.Tx.Background_Up_Sakura_Clear[i].szテクスチャサイズ.Width + 2; l++)
                        {
                            TJAPlayer3.Tx.Background_Up_Sakura_Clear[i].t2D描画(TJAPlayer3.app.Device, (l * TJAPlayer3.Tx.Background_Up_Sakura_Clear[i].szテクスチャサイズ.Width) - ct上背景桜スクロール用タイマー[i].n現在の値 - xy, TJAPlayer3.Skin.Background_Scroll_Y[i] + xy);
                        }
                    }

                    if (ct上背景上下用タイマー[i] != null && TJAPlayer3.Tx.Background_Up_YMove_Clear[i] != null)
                    {
                        if (ct上背景上下用タイマー[i].n現在の値 <= ct上背景上下用タイマー[i].n終了値 * 0.5)
                            ym = (int)((-ct上背景上下用タイマー[i].n現在の値) * 0.5);
                        else
                            ym = (int)((ct上背景上下用タイマー[i].n現在の値 - ct上背景上下用タイマー[i].n終了値) * 0.5);
                        ym -= (int)(ct上背景上下用タイマー[i].n終了値 * 0.0625);
                        xm = ct上背景サブスクロール用タイマー[i].n現在の値;

                        if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[i])
                            TJAPlayer3.Tx.Background_Up_YMove_Clear[i].Opacity = ((ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                        else
                            TJAPlayer3.Tx.Background_Up_YMove_Clear[i].Opacity = 0;

                        for (int l = 0; l < 1304 / TJAPlayer3.Tx.Background_Up_YMove[i].szテクスチャサイズ.Width + 2; l++)
                        {
                            TJAPlayer3.Tx.Background_Up_YMove_Clear[i].t2D描画(TJAPlayer3.app.Device, (l * TJAPlayer3.Tx.Background_Up_YMove_Clear[i].szテクスチャサイズ.Width) - xm, TJAPlayer3.Skin.Background_Scroll_Y[i] + ym);
                        }
                    }
                    #endregion

                }
                #endregion
            }
            else
            {
                #region [ 段位背景 ]
                /*
                TJAPlayer3.Tx.Background_Up_Dan[0].t2D描画(TJAPlayer3.app.Device, 0, 0);

                for(int i = 0; i < 1280 / TJAPlayer3.Tx.Background_Up_Dan[1].szテクスチャサイズ.Width + 2; i++)
                        TJAPlayer3.Tx.Background_Up_Dan[1].t2D描画(TJAPlayer3.app.Device, (i * TJAPlayer3.Tx.Background_Up_Dan[1].szテクスチャサイズ.Width) - ct上背景スクロール用タイマー1stDan[0].n現在の値, 0);

                for(int i = 0; i < 1280 / TJAPlayer3.Tx.Background_Up_Dan[2].szテクスチャサイズ.Width + 2; i++)
                        TJAPlayer3.Tx.Background_Up_Dan[2].t2D描画(TJAPlayer3.app.Device, (i * TJAPlayer3.Tx.Background_Up_Dan[2].szテクスチャサイズ.Width) - ct上背景スクロール用タイマー1stDan[1].n現在の値, 0);

                for(int i = 0; i < 1280 / TJAPlayer3.Tx.Background_Up_Dan[3].szテクスチャサイズ.Width + 2; i++)
                        TJAPlayer3.Tx.Background_Up_Dan[3].t2D描画(TJAPlayer3.app.Device, (i * TJAPlayer3.Tx.Background_Up_Dan[3].szテクスチャサイズ.Width) - ct上背景スクロール用タイマー1stDan[2].n現在の値, 0);

                for(int i = 0; i < 1280 / TJAPlayer3.Tx.Background_Up_Dan[4].szテクスチャサイズ.Width + 2; i++)
                        TJAPlayer3.Tx.Background_Up_Dan[4].t2D描画(TJAPlayer3.app.Device, + (i * TJAPlayer3.Tx.Background_Up_Dan[4].szテクスチャサイズ.Width) - ct上背景スクロール用タイマー2stDan.n現在の値, -200 + ct上背景スクロール用タイマー2stDan.n現在の値);

                for(int i = 0; i < 1280 / TJAPlayer3.Tx.Background_Up_Dan[5].szテクスチャサイズ.Width + 2; i++)
                        TJAPlayer3.Tx.Background_Up_Dan[5].t2D描画(TJAPlayer3.app.Device, (i * TJAPlayer3.Tx.Background_Up_Dan[5].szテクスチャサイズ.Width) - ct上背景スクロール用タイマー1stDan[3].n現在の値, 0);
                */



                #endregion
            }
            #endregion

            #region [ 下背景 ]
            if (!TJAPlayer3.stage演奏ドラム画面.bDoublePlay)
            {
                ct点滅0.t進行Loop();
                ct点滅1.t進行Loop();
                ct点滅2.t進行Loop();

                if (TJAPlayer3.Tx.Background_Down != null)
                {
                    TJAPlayer3.Tx.Background_Down?.t2D描画(TJAPlayer3.app.Device, 0, 360);
                    TJAPlayer3.Tx.Background_Down_Light_B?.t2D描画(TJAPlayer3.app.Device, 0, 360);
                    //TJAPlayer3.Tx.Background_Down_Light_B.Opacity = (int)(176.0 + 30.0 * Math.Sin((double)(2 * Math.PI * ct点滅1.n現在の値 * 2 / 500.0)));//176.0 + 80.0
                }

                if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[0] && TJAPlayer3.Tx.Background_Down_Clear != null && TJAPlayer3.Tx.Background_Down_Scroll != null && ct下背景スクロール用タイマー1 != null && ct下背景スクロール用タイマー2 != null && ct下背景スクロール用タイマー3 != null)
                {
                    int ym;
                    int opacity = (ct上背景FIFOタイマー.n現在の値 * 0xff) / 100;
                    double texSize = 1280.0 / TJAPlayer3.Tx.Background_Down_Scroll.szテクスチャサイズ.Width;
                    int forLoop = (int)Math.Ceiling(texSize) + 1;

                    if (ct下背景上下用タイマー.n現在の値 <= ct下背景上下用タイマー.n終了値 * 0.5)
                        ym = (int)((-ct下背景上下用タイマー.n現在の値) * 0.5);
                    else
                        ym = (int)((ct下背景上下用タイマー.n現在の値 - ct下背景上下用タイマー.n終了値) * 0.5);
                    ym -= (int)(ct下背景上下用タイマー.n終了値 * 0.0625);

                    TJAPlayer3.Tx.Background_Down_Clear.Opacity = opacity;
                    TJAPlayer3.Tx.Background_Down_Scroll.Opacity = opacity;
                    TJAPlayer3.Tx.Background_Down_Scroll_Matu.Opacity = opacity;
                    TJAPlayer3.Tx.Background_Down_Scroll_Kumo.Opacity = opacity;
                    TJAPlayer3.Tx.Background_Down_Koma.Opacity = opacity;

                    TJAPlayer3.Tx.Background_Down_Scroll?.t2D描画(TJAPlayer3.app.Device, 0 - ct下背景スクロール用タイマー1.n現在の値, 360);
                    for (int l = 1; l < forLoop + 1; l++)
                    {
                        TJAPlayer3.Tx.Background_Down_Scroll?.t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Down_Scroll.szテクスチャサイズ.Width) - ct下背景スクロール用タイマー1.n現在の値, 360);
                    }
                    TJAPlayer3.Tx.Background_Down_Clear?.t2D描画(TJAPlayer3.app.Device, 0, 360);
                    TJAPlayer3.Tx.Background_Down_Scroll_Matu?.t2D描画(TJAPlayer3.app.Device, 0 - ct下背景スクロール用タイマー2.n現在の値, 360);
                    for (int l = 1; l < forLoop + 1; l++)
                    {
                        TJAPlayer3.Tx.Background_Down_Scroll_Matu?.t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Down_Scroll_Matu.szテクスチャサイズ.Width) - ct下背景スクロール用タイマー2.n現在の値, 360);
                    }
                    TJAPlayer3.Tx.Background_Down_Scroll_Kumo?.t2D描画(TJAPlayer3.app.Device, 0 - ct下背景スクロール用タイマー3.n現在の値, 360);
                    for (int l = 1; l < forLoop + 1; l++)
                    {
                        TJAPlayer3.Tx.Background_Down_Scroll_Kumo?.t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Down_Scroll_Kumo.szテクスチャサイズ.Width) - ct下背景スクロール用タイマー3.n現在の値, 360);
                    }
                    TJAPlayer3.Tx.Background_Down_Koma?.t2D描画(TJAPlayer3.app.Device, 0, 360 + ym);
                }
            }
            #endregion

            return base.On進行描画();
        }
        #region[ private ]
        //-----------------
        private CCounter[] ct上背景スクロール用タイマー;
        private CCounter[] ct上背景サブスクロール用タイマー;

        private CCounter[] ct上背景上下用タイマー;
        private CCounter[] ct上背景桜用タイマー;
        private CCounter[] ct上背景桜スクロール用タイマー;

        private CCounter ct点滅0;
        private CCounter ct点滅1;
        private CCounter ct点滅2;

        private CCounter ct下背景スクロール用タイマー1;//下背景パーツ1のX方向スクロール用
        private CCounter ct下背景スクロール用タイマー2;//Kumo
        private CCounter ct下背景スクロール用タイマー3;//Matu
        private CCounter ct下背景上下用タイマー;//koma
        private CCounter ct上背景FIFOタイマー;
        private CCounter[] ct上背景クリアインタイマー;
        private CCounter[] ct上背景スクロール用タイマー1stDan;   //上背景のX方向スクロール用
        private CCounter ct上背景スクロール用タイマー2stDan;   //上背景のY方向スクロール用
        private EFIFOモード eFadeMode;
        //-----------------
        #endregion
    }
}
