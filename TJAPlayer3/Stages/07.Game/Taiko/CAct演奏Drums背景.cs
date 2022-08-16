using System;
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
            this.ct上背景クリアインタイマー[player] = new CCounter(0, 100, 2, TJAPlayer3.Timer);
            this.eFadeMode = EFIFOモード.フェードイン;
        }

        public void ClearIn(int player)
        {
            this.ct上背景クリアインタイマー[player] = new CCounter(0, 100, 2, TJAPlayer3.Timer);
            this.ct上背景クリアインタイマー[player].n現在の値 = 0;
            this.ct上背景FIFOタイマー = new CCounter(0, 100, 2, TJAPlayer3.Timer);
            this.ct上背景FIFOタイマー.n現在の値 = 0;
        }

        public override void On活性化()
        {
            base.On活性化();
        }

        public override void On非活性化()
        {
            TJAPlayer3.t安全にDisposeする(ref this.ct上背景FIFOタイマー);
            for (int i = 0; i < 2; i++)
            {
                //ct上背景スクロール用タイマー1st[i] = null;
                //ct上背景スクロール用タイマー2nd[i] = null;
                //ct上背景スクロール用タイマー3rd[i] = null;
                ct上背景スクロール用タイマー[i] = null;
                ct上背景サブスクロール用タイマー[i] = null;
                ct上背景上下用タイマー[i] = null;
                ct上背景桜用タイマー[i] = null;
                ct上背景桜スクロール用タイマー[i] = null;
            }
            TJAPlayer3.t安全にDisposeする(ref this.ct下背景スクロール用タイマー1);
            TJAPlayer3.t安全にDisposeする(ref this.ct下背景スクロール用タイマー2);
            TJAPlayer3.t安全にDisposeする(ref this.ct下背景スクロール用タイマー3);
            TJAPlayer3.t安全にDisposeする(ref this.ct下背景上下用タイマー);
            //TJAPlayer3.t安全にDisposeする(ref this.ct桜X移動用タイマー1);
            //TJAPlayer3.t安全にDisposeする(ref this.ct桜Y移動用タイマー1);
            //TJAPlayer3.t安全にDisposeする(ref this.ct桜X移動用タイマー2);
            //TJAPlayer3.t安全にDisposeする(ref this.ct桜Y移動用タイマー2);
            //TJAPlayer3.t安全にDisposeする(ref this.ct桜X移動用タイマー3);
            //TJAPlayer3.t安全にDisposeする(ref this.ct桜Y移動用タイマー3);
            base.On非活性化();
        }

        public override void OnManagedリソースの作成()
        {
            this.ct上背景スクロール用タイマー = new CCounter[2];
            this.ct上背景サブスクロール用タイマー = new CCounter[2];
            this.ct上背景上下用タイマー = new CCounter[2];
            this.ct上背景桜用タイマー = new CCounter[2];
            this.ct上背景桜スクロール用タイマー = new CCounter[2];
            //this.ct上背景スクロール用タイマー1st = new CCounter[2];
            //this.ct上背景スクロール用タイマー2nd = new CCounter[2];
            //this.ct上背景スクロール用タイマー3rd = new CCounter[2];
            //this.ct上背景雲0スクロール用タイマー = new CCounter[2];
            //this.ct上背景雲1スクロール用タイマー = new CCounter[2];
            //this.ct上背景クリア雲0スクロール用タイマー = new CCounter[2];
            //this.ct上背景クリア雲1スクロール用タイマー = new CCounter[2];
            this.ct上背景クリアインタイマー = new CCounter[2];
            ct上背景スクロール用タイマー1stDan = new CCounter[4];

            for (int i = 0; i < 2; i++)
            {
                if (TJAPlayer3.Tx.Background_Up[i] != null)
                {
                    this.ct上背景スクロール用タイマー[i] = new CCounter(1, TJAPlayer3.Tx.Background_Up_Clear[i].szテクスチャサイズ.Width, 16, TJAPlayer3.Timer);
                    this.ct上背景サブスクロール用タイマー[i] = new CCounter(1, TJAPlayer3.Tx.Background_Up_YMove[i].szテクスチャサイズ.Width, 16, TJAPlayer3.Timer);
                    this.ct上背景上下用タイマー[i] = new CCounter(1, 100, 25, TJAPlayer3.Timer);
                    this.ct上背景桜用タイマー[i] = new CCounter(0, 400, 9, TJAPlayer3.Timer);
                    if (TJAPlayer3.Tx.Background_Up_Sakura[i] != null)
                        this.ct上背景桜スクロール用タイマー[i] = new CCounter(0, TJAPlayer3.Tx.Background_Up_Sakura[i].szテクスチャサイズ.Width, 8, TJAPlayer3.Timer);

                    //this.ct上背景スクロール用タイマー1st[i] = new CCounter(1, TJAPlayer3.Tx.Background_Up_1st[i].szテクスチャサイズ.Width, 16, TJAPlayer3.Timer);
                    //this.ct上背景スクロール用タイマー2nd[i] = new CCounter(1, TJAPlayer3.Tx.Background_Up_2nd[i].szテクスチャサイズ.Height, 70, TJAPlayer3.Timer);
                    //his.ct上背景スクロール用タイマー3rd[i] = new CCounter(1, 600, 3, TJAPlayer3.Timer);

                    //this.ct上背景雲0スクロール用タイマー[i] = new CCounter(1, TJAPlayer3.Tx.Background_Up_Kumo0[i].szテクスチャサイズ.Width, 16, TJAPlayer3.Timer);
                    //this.ct上背景雲1スクロール用タイマー[i] = new CCounter(1, TJAPlayer3.Tx.Background_Up_Kumo1[i].szテクスチャサイズ.Width, 10, TJAPlayer3.Timer);
                    //this.ct上背景クリア雲0スクロール用タイマー[i] = new CCounter(1, TJAPlayer3.Tx.Background_Up_Clear_Kumo0[i].szテクスチャサイズ.Width, 12, TJAPlayer3.Timer);
                    //this.ct上背景クリア雲1スクロール用タイマー[i] = new CCounter(1, TJAPlayer3.Tx.Background_Up_Clear_Kumo1[i].szテクスチャサイズ.Width, 9, TJAPlayer3.Timer);

                    this.ct下背景上下用タイマー = new CCounter(1, 100, 15, TJAPlayer3.Timer);
                    this.ct上背景クリアインタイマー[i] = new CCounter();
                }
				#region [ 葉 ]
				//this.ct上背景桜用タイマー[i] = new CCounter(0, 400, 8, TJAPlayer3.Timer);
				//if (TJAPlayer3.Tx.Background_Up_Sakura[i] != null)
				//this.ct上背景桜スクロール用タイマー[i] = new CCounter(0, TJAPlayer3.Tx.Background_Up_Sakura[i].szテクスチャサイズ.Width, 8, TJAPlayer3.Timer);
				/*
                if (TJAPlayer3.Tx.Background_Up_Clear_HM0 != null)
                {
                    this.ct桜X移動用タイマー1 = new CCounter(0, 166, 15, TJAPlayer3.Timer);
                    this.ct桜Y移動用タイマー1 = new CCounter(0, 500, 5, TJAPlayer3.Timer);
                    this.ct桜X移動用タイマー2 = new CCounter(0, 250, 10, TJAPlayer3.Timer);
                    this.ct桜Y移動用タイマー2 = new CCounter(0, 500, 5, TJAPlayer3.Timer);
                    this.ct桜X移動用タイマー3 = new CCounter(0, 333, 15, TJAPlayer3.Timer);
                    this.ct桜Y移動用タイマー3 = new CCounter(0, 500, 10, TJAPlayer3.Timer);
                }
                */
				#endregion
			}
			this.ct上背景スクロール用タイマー1stDan[0] = new CCounter(0, TJAPlayer3.Tx.Background_Up_Dan[1].szテクスチャサイズ.Width, 8.453f * 2, TJAPlayer3.Timer);
            this.ct上背景スクロール用タイマー1stDan[1] = new CCounter(0, TJAPlayer3.Tx.Background_Up_Dan[2].szテクスチャサイズ.Width, 10.885f * 2, TJAPlayer3.Timer);
            this.ct上背景スクロール用タイマー1stDan[2] = new CCounter(0, TJAPlayer3.Tx.Background_Up_Dan[3].szテクスチャサイズ.Width, 11.4f * 2, TJAPlayer3.Timer);
            this.ct上背景スクロール用タイマー1stDan[3] = new CCounter(0, TJAPlayer3.Tx.Background_Up_Dan[5].szテクスチャサイズ.Width, 33.88f, TJAPlayer3.Timer);
            this.ct上背景スクロール用タイマー2stDan = new CCounter(0, TJAPlayer3.Tx.Background_Up_Dan[4].szテクスチャサイズ.Width + 200, 10, TJAPlayer3.Timer);

            this.ct点滅0 = new CCounter(0, 100, 20, TJAPlayer3.Timer);
            this.ct点滅1 = new CCounter(0, 100, 1, TJAPlayer3.Timer);
            this.ct点滅2 = new CCounter(0, 100, 60, TJAPlayer3.Timer);

            if (TJAPlayer3.Tx.Background_Down_Sc_0 != null)
                this.ct下背景スクロール用タイマー1 = new CCounter(1, TJAPlayer3.Tx.Background_Down_Sc_0.szテクスチャサイズ.Width, 15, TJAPlayer3.Timer);
            if (TJAPlayer3.Tx.Background_Down_Sc_1 != null)
                this.ct下背景スクロール用タイマー2 = new CCounter(1, TJAPlayer3.Tx.Background_Down_Sc_1.szテクスチャサイズ.Width, 25, TJAPlayer3.Timer);

            /*
            if (TJAPlayer3.Tx.Background_Down_Scroll != null)
                this.ct下背景スクロール用タイマー1 = new CCounter(1, TJAPlayer3.Tx.Background_Down_Scroll.szテクスチャサイズ.Width, 20, TJAPlayer3.Timer);
            if (TJAPlayer3.Tx.Background_Down_Scroll_Matu != null)
                this.ct下背景スクロール用タイマー2 = new CCounter(1, TJAPlayer3.Tx.Background_Down_Scroll_Matu.szテクスチャサイズ.Width, 13, TJAPlayer3.Timer);
            if (TJAPlayer3.Tx.Background_Down_Scroll_Kumo != null)
                this.ct下背景スクロール用タイマー3 = new CCounter(1, TJAPlayer3.Tx.Background_Down_Scroll_Kumo.szテクスチャサイズ.Width, 18, TJAPlayer3.Timer);
            */

            this.ct上背景FIFOタイマー = new CCounter();
            base.OnManagedリソースの作成();
        }

        public override void OnManagedリソースの解放()
        {
            base.OnManagedリソースの解放();
        }

        public override int On進行描画()
        {
            this.ct上背景FIFOタイマー.t進行();

            for (int i = 0; i < 2; i++)
            {
                if (this.ct上背景スクロール用タイマー[i] != null)
                    this.ct上背景スクロール用タイマー[i].t進行Loop();

                if (this.ct上背景サブスクロール用タイマー[i] != null)
                    this.ct上背景サブスクロール用タイマー[i].t進行Loop();

                if (this.ct上背景クリアインタイマー[i] != null)
                    this.ct上背景クリアインタイマー[i].t進行();

                if (this.ct上背景上下用タイマー[i] != null)
                    this.ct上背景上下用タイマー[i].t進行Loop();

                if (this.ct上背景桜用タイマー[i] != null)
                    this.ct上背景桜用タイマー[i].t進行Loop();

                if (this.ct上背景桜スクロール用タイマー[i] != null)
                    this.ct上背景桜スクロール用タイマー[i].t進行Loop();
            }
            if (this.ct下背景スクロール用タイマー1 != null)
                this.ct下背景スクロール用タイマー1.t進行Loop();
            if (this.ct下背景スクロール用タイマー2 != null)
                this.ct下背景スクロール用タイマー2.t進行Loop();
            if (this.ct下背景スクロール用タイマー3 != null)
                this.ct下背景スクロール用タイマー3.t進行Loop();
            if (this.ct下背景上下用タイマー != null)
                this.ct下背景上下用タイマー.t進行Loop();
            if (this.ct上背景スクロール用タイマー2stDan != null)
                this.ct上背景スクロール用タイマー2stDan.t進行Loop();
            #region [ archive ]
            /*
            for (int i = 0; i < 2; i++)
            {
                if (this.ct上背景スクロール用タイマー1st[i] != null)
                    this.ct上背景スクロール用タイマー1st[i].t進行Loop();
            }
            for (int i = 0; i < 2; i++)
            {
                if (this.ct上背景スクロール用タイマー2nd[i] != null)
                    this.ct上背景スクロール用タイマー2nd[i].t進行Loop();
            }
            for (int i = 0; i < 2; i++)
            {
                if (this.ct上背景スクロール用タイマー3rd[i] != null)
                    this.ct上背景スクロール用タイマー3rd[i].t進行Loop();
            }
            */
            /*
            for (int i = 0; i < 2; i++)
            {
                if (this.ct上背景雲0スクロール用タイマー[i] != null)
                    this.ct上背景雲0スクロール用タイマー[i].t進行Loop();
            }
            for (int i = 0; i < 2; i++)
            {
                if (this.ct上背景雲1スクロール用タイマー[i] != null)
                    this.ct上背景雲1スクロール用タイマー[i].t進行Loop();
            }
            for (int i = 0; i < 2; i++)
            {
                if (this.ct上背景クリア雲0スクロール用タイマー[i] != null)
                    this.ct上背景クリア雲0スクロール用タイマー[i].t進行Loop();
            }
            for (int i = 0; i < 2; i++)
            {
                if (this.ct上背景クリア雲1スクロール用タイマー[i] != null)
                    this.ct上背景クリア雲1スクロール用タイマー[i].t進行Loop();
            }
            */
            /*
			if (this.ct桜X移動用タイマー1 != null)
                this.ct桜X移動用タイマー1.t進行Loop();

            if (this.ct桜Y移動用タイマー1 != null)
                this.ct桜Y移動用タイマー1.t進行Loop();

            if (this.ct桜X移動用タイマー2 != null)
                this.ct桜X移動用タイマー2.t進行Loop();

            if (this.ct桜Y移動用タイマー2 != null)
                this.ct桜Y移動用タイマー2.t進行Loop();

            if (this.ct桜X移動用タイマー3 != null)
                this.ct桜X移動用タイマー3.t進行Loop();

            if (this.ct桜Y移動用タイマー3 != null)
                this.ct桜Y移動用タイマー3.t進行Loop();
            */
            #endregion

            #region [ 1P-2P-上背景 ]

            if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)
            {
                #region [ 通常背景 ]

                for (int i = 0; i < 2; i++)
                {
                    #region [ archive ]
                    /*
                    if (this.ct上背景スクロール用タイマー1st[i] != null)
                    {
                        double TexSizeL = 1280 / TJAPlayer3.Tx.Background_Up_1st[i].szテクスチャサイズ.Width;
                        double TexSizeW = 308 / TJAPlayer3.Tx.Background_Up_2nd[i].szテクスチャサイズ.Height;
                        double TexSizeF = 1280 / TJAPlayer3.Tx.Background_Up_3rd[i].szテクスチャサイズ.Width;
                        // 1280をテクスチャサイズで割ったものを切り上げて、プラス+1足す。
                        int ForLoopL = (int)Math.Ceiling(TexSizeL) + 1;
                        int ForLoopW = (int)Math.Ceiling(TexSizeW) + 1;
                        int ForLoopF = (int)Math.Ceiling(TexSizeF) + 1;
                        //int nループ幅 = 328;

                        #region [ 上背景-Back ]

                        for (int W = 1; W < ForLoopW + 1; W++)
                        {
                            TJAPlayer3.Tx.Background_Up_1st[i].t2D描画(TJAPlayer3.app.Device, 0 - this.ct上背景スクロール用タイマー1st[i].n現在の値, (185 + i * 600) - (W * TJAPlayer3.Tx.Background_Up_1st[i].szテクスチャサイズ.Height) + ct上背景スクロール用タイマー2nd[i].n現在の値);
                        }
                        for (int l = 1; l < ForLoopL + 1; l++)
                        {
                            for (int W = 1; W < ForLoopW + 1; W++)
                            {
                                TJAPlayer3.Tx.Background_Up_1st[i].t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Up_1st[i].szテクスチャサイズ.Width) - this.ct上背景スクロール用タイマー1st[i].n現在の値, (185 + i * 600) - (W * TJAPlayer3.Tx.Background_Up_1st[i].szテクスチャサイズ.Height) + ct上背景スクロール用タイマー2nd[i].n現在の値);
                            }
                        }

                        for (int W = 1; W < ForLoopW + 1; W++)
                        {
                            TJAPlayer3.Tx.Background_Up_2nd[i].t2D描画(TJAPlayer3.app.Device, 0 - this.ct上背景スクロール用タイマー1st[i].n現在の値, (370 + i * 600) - (W * TJAPlayer3.Tx.Background_Up_2nd[i].szテクスチャサイズ.Height) - ct上背景スクロール用タイマー2nd[i].n現在の値);
                        }
                        for (int l = 1; l < ForLoopL + 1; l++)
                        {
                            for (int W = 1; W < ForLoopW + 1; W++)
                            {
                                TJAPlayer3.Tx.Background_Up_2nd[i].t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Up_2nd[i].szテクスチャサイズ.Width) - this.ct上背景スクロール用タイマー1st[i].n現在の値, (370 + i * 600) - (W * TJAPlayer3.Tx.Background_Up_2nd[i].szテクスチャサイズ.Height) - ct上背景スクロール用タイマー2nd[i].n現在の値);
                            }
                        }

                        #endregion

                        #region [ 上背景-Front ]

                        float thirdy = 0;
                        float thirdx = 0;

                        if (this.ct上背景スクロール用タイマー3rd[i].n現在の値 <= 270)
                        {
                            thirdx = this.ct上背景スクロール用タイマー3rd[i].n現在の値 * 0.9258f;
                            thirdy = (float)Math.Sin((float)this.ct上背景スクロール用タイマー3rd[i].n現在の値 * (Math.PI / 270.0f)) * 40.0f;
                        }
                        else
                        {
                            thirdx = 250 + (ct上背景スクロール用タイマー3rd[i].n現在の値 - 270) * 0.24f;

                            if (this.ct上背景スクロール用タイマー3rd[i].n現在の値 <= 490) thirdy = -(float)Math.Sin((float)(this.ct上背景スクロール用タイマー3rd[i].n現在の値 - 270) * (Math.PI / 170.0f)) * 15.0f;
                            else thirdy = -((float)Math.Sin((float)220f * (Math.PI / 170.0f)) * 15.0f) + (float)(((this.ct上背景スクロール用タイマー3rd[i].n現在の値 - 490) / 110f) * ((float)Math.Sin((float)220f * (Math.PI / 170.0f)) * 15.0f));
                        }

                        TJAPlayer3.Tx.Background_Up_3rd[i].t2D描画(TJAPlayer3.app.Device, 0 - thirdx, 0 + i * 540 - thirdy);

                        for (int l = 1; l < ForLoopF + 1; l++)
                        {
                            TJAPlayer3.Tx.Background_Up_3rd[i].t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Up_3rd[i].szテクスチャサイズ.Width) - thirdx, 0 + i * 540 - thirdy);
                        }

                        #endregion
                    }

                    if (this.ct上背景スクロール用タイマー1st[i] != null)
                    {
                        if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[i])
                        {
                            TJAPlayer3.Tx.Background_Up_1st[2].Opacity = ((this.ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                            TJAPlayer3.Tx.Background_Up_2nd[2].Opacity = ((this.ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                            TJAPlayer3.Tx.Background_Up_3rd[2].Opacity = ((this.ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                        }
                        else
                        {
                            TJAPlayer3.Tx.Background_Up_1st[2].Opacity = 0;
                            TJAPlayer3.Tx.Background_Up_2nd[2].Opacity = 0;
                            TJAPlayer3.Tx.Background_Up_3rd[2].Opacity = 0;
                        }

                        double TexSizeL = 1280 / TJAPlayer3.Tx.Background_Up_1st[2].szテクスチャサイズ.Width;
                        double TexSizeW = 308 / TJAPlayer3.Tx.Background_Up_2nd[2].szテクスチャサイズ.Height;
                        double TexSizeF = 1280 / TJAPlayer3.Tx.Background_Up_3rd[2].szテクスチャサイズ.Width;
                        // 1280をテクスチャサイズで割ったものを切り上げて、プラス+1足す。
                        int ForLoopL = (int)Math.Ceiling(TexSizeL) + 1;
                        int ForLoopW = (int)Math.Ceiling(TexSizeW) + 1;
                        int ForLoopF = (int)Math.Ceiling(TexSizeF) + 1;

                        #region [ 上背景-Back ]

                        for (int W = 1; W < ForLoopW + 1; W++)
                        {
                            TJAPlayer3.Tx.Background_Up_1st[2].t2D描画(TJAPlayer3.app.Device, 0 - this.ct上背景スクロール用タイマー1st[i].n現在の値, (185 + i * 600) - (W * TJAPlayer3.Tx.Background_Up_1st[2].szテクスチャサイズ.Height) + ct上背景スクロール用タイマー2nd[i].n現在の値);
                        }
                        for (int l = 1; l < ForLoopL + 1; l++)
                        {
                            for (int W = 1; W < ForLoopW + 1; W++)
                            {
                                TJAPlayer3.Tx.Background_Up_1st[2].t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Up_1st[2].szテクスチャサイズ.Width) - this.ct上背景スクロール用タイマー1st[i].n現在の値, (185 + i * 600) - (W * TJAPlayer3.Tx.Background_Up_1st[2].szテクスチャサイズ.Height) + ct上背景スクロール用タイマー2nd[i].n現在の値);
                            }
                        }

                        for (int W = 1; W < ForLoopW + 1; W++)
                        {
                            TJAPlayer3.Tx.Background_Up_2nd[2].t2D描画(TJAPlayer3.app.Device, 0 - this.ct上背景スクロール用タイマー1st[i].n現在の値, (370 + i * 600) - (W * TJAPlayer3.Tx.Background_Up_2nd[2].szテクスチャサイズ.Height) - ct上背景スクロール用タイマー2nd[i].n現在の値);
                        }
                        for (int l = 1; l < ForLoopL + 1; l++)
                        {
                            for (int W = 1; W < ForLoopW + 1; W++)
                            {
                                TJAPlayer3.Tx.Background_Up_2nd[2].t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Up_2nd[2].szテクスチャサイズ.Width) - this.ct上背景スクロール用タイマー1st[i].n現在の値, (370 + i * 600) - (W * TJAPlayer3.Tx.Background_Up_2nd[2].szテクスチャサイズ.Height) - ct上背景スクロール用タイマー2nd[i].n現在の値);
                            }
                        }

                        #endregion

                        #region [ 上背景-Front ]

                        float thirdy = 0;
                        float thirdx = 0;

                        if (this.ct上背景スクロール用タイマー3rd[i].n現在の値 <= 270)
                        {
                            thirdx = this.ct上背景スクロール用タイマー3rd[i].n現在の値 * 0.9258f;
                            thirdy = (float)Math.Sin((float)this.ct上背景スクロール用タイマー3rd[i].n現在の値 * (Math.PI / 270.0f)) * 40.0f;
                        }
                        else
                        {
                            thirdx = 250 + (ct上背景スクロール用タイマー3rd[i].n現在の値 - 270) * 0.24f;

                            if (this.ct上背景スクロール用タイマー3rd[i].n現在の値 <= 490) thirdy = -(float)Math.Sin((float)(this.ct上背景スクロール用タイマー3rd[i].n現在の値 - 270) * (Math.PI / 170.0f)) * 15.0f;
                            else thirdy = -((float)Math.Sin((float)220f * (Math.PI / 170.0f)) * 15.0f) + (float)(((this.ct上背景スクロール用タイマー3rd[i].n現在の値 - 490) / 110f) * ((float)Math.Sin((float)220f * (Math.PI / 170.0f)) * 15.0f));
                        }

                        TJAPlayer3.Tx.Background_Up_3rd[2].t2D描画(TJAPlayer3.app.Device, 0 - thirdx, 0 + i * 540 - thirdy);

                        for (int l = 1; l < ForLoopF + 1; l++)
                        {
                            TJAPlayer3.Tx.Background_Up_3rd[2].t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Up_3rd[2].szテクスチャサイズ.Width) - thirdx, 0 + i * 540 - thirdy);
                        }

                        #endregion
                    }
                    */
                    #endregion

                    #region [ 東方 ]
                    /*
                    if (this.ct上背景雲0スクロール用タイマー[i] != null)
                    {
                        double TexSize = 1280 / TJAPlayer3.Tx.Background_Up_Kumo0[i].szテクスチャサイズ.Width;
                        // 1280をテクスチャサイズで割ったものを切り上げて、プラス+1足す。
                        int ForLoop = (int)Math.Ceiling(TexSize) + 1;
                        //int nループ幅 = 328;
                        TJAPlayer3.Tx.Background_Up_Kumo0[i].t2D描画(TJAPlayer3.app.Device, 0 - this.ct上背景雲0スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);
                        for (int l = 1; l < ForLoop + 1; l++)
                        {
                            TJAPlayer3.Tx.Background_Up_Kumo0[i].t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Up_Kumo0[i].szテクスチャサイズ.Width) - this.ct上背景雲0スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);
                        }
                    }
                    if (this.ct上背景雲1スクロール用タイマー[i] != null)
                    {
                        double TexSize = 1280 / TJAPlayer3.Tx.Background_Up_Kumo1[i].szテクスチャサイズ.Width;
                        // 1280をテクスチャサイズで割ったものを切り上げて、プラス+1足す。
                        int ForLoop = (int)Math.Ceiling(TexSize) + 1;
                        //int nループ幅 = 328;
                        TJAPlayer3.Tx.Background_Up_Kumo1[i].t2D描画(TJAPlayer3.app.Device, 0 - this.ct上背景雲1スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);
                        for (int l = 1; l < ForLoop + 1; l++)
                        {
                            TJAPlayer3.Tx.Background_Up_Kumo1[i].t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Up_Kumo1[i].szテクスチャサイズ.Width) - this.ct上背景雲1スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);
                        }
                    }
                    if (this.ct上背景スクロール用タイマー[i] != null)
                    {
                        if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[i])
                            TJAPlayer3.Tx.Background_Up_Clear[i].Opacity = ((this.ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                        else
                            TJAPlayer3.Tx.Background_Up_Clear[i].Opacity = 0;

                        double TexSize = 1280 / TJAPlayer3.Tx.Background_Up_Clear[i].szテクスチャサイズ.Width;
                        // 1280をテクスチャサイズで割ったものを切り上げて、プラス+1足す。
                        int ForLoop = (int)Math.Ceiling(TexSize) + 1;

                        TJAPlayer3.Tx.Background_Up_Clear[i].t2D描画(TJAPlayer3.app.Device, 0 - this.ct上背景スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);
                        for (int l = 1; l < ForLoop + 1; l++)
                        {
                            TJAPlayer3.Tx.Background_Up_Clear[i].t2D描画(TJAPlayer3.app.Device, (l * TJAPlayer3.Tx.Background_Up_Clear[i].szテクスチャサイズ.Width) - this.ct上背景スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);
                        }
                    }

                    #region 葉モーション
                    if (TJAPlayer3.Tx.Background_Up_Clear_HM0 != null)
                    {
                        if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[i])
                            TJAPlayer3.Tx.Background_Up_Clear_HM0.Opacity = ((this.ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                        else
                            TJAPlayer3.Tx.Background_Up_Clear_HM0.Opacity = 0;

                        if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[i])
                            TJAPlayer3.Tx.Background_Up_Clear_HM1.Opacity = ((this.ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                        else
                            TJAPlayer3.Tx.Background_Up_Clear_HM1.Opacity = 0;

                        TJAPlayer3.Tx.Background_Up_Clear_HM0.t2D描画(TJAPlayer3.app.Device, 140 - this.ct桜X移動用タイマー1.n現在の値, 0 + this.ct桜Y移動用タイマー1.n現在の値);
                        TJAPlayer3.Tx.Background_Up_Clear_HM0.t2D描画(TJAPlayer3.app.Device, 640 + this.ct桜X移動用タイマー1.n現在の値, 0 + this.ct桜Y移動用タイマー1.n現在の値);
                        TJAPlayer3.Tx.Background_Up_Clear_HM0.t2D描画(TJAPlayer3.app.Device, 960 - this.ct桜X移動用タイマー1.n現在の値, 0 + this.ct桜Y移動用タイマー1.n現在の値);
                        TJAPlayer3.Tx.Background_Up_Clear_HM0.t2D描画(TJAPlayer3.app.Device, 1270 - this.ct桜X移動用タイマー2.n現在の値, 0 + this.ct桜Y移動用タイマー2.n現在の値);
                        TJAPlayer3.Tx.Background_Up_Clear_HM1.t2D描画(TJAPlayer3.app.Device, 10 - this.ct桜X移動用タイマー3.n現在の値, 0 + this.ct桜Y移動用タイマー3.n現在の値);
                        TJAPlayer3.Tx.Background_Up_Clear_HM1.t2D描画(TJAPlayer3.app.Device, 260 + this.ct桜X移動用タイマー3.n現在の値, 0 + this.ct桜Y移動用タイマー3.n現在の値);
                        TJAPlayer3.Tx.Background_Up_Clear_HM1.t2D描画(TJAPlayer3.app.Device, 450 - this.ct桜X移動用タイマー1.n現在の値, 0 + this.ct桜Y移動用タイマー1.n現在の値);
                        TJAPlayer3.Tx.Background_Up_Clear_HM1.t2D描画(TJAPlayer3.app.Device, 950 + this.ct桜X移動用タイマー1.n現在の値, 0 + this.ct桜Y移動用タイマー1.n現在の値);
                        TJAPlayer3.Tx.Background_Up_Clear_HM1.t2D描画(TJAPlayer3.app.Device, 1200 - this.ct桜X移動用タイマー1.n現在の値, 0 + this.ct桜Y移動用タイマー1.n現在の値);
                    }
                    #endregion

                    if (this.ct上背景クリア雲0スクロール用タイマー[i] != null)
                    {
                        if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[i])
                            TJAPlayer3.Tx.Background_Up_Clear_Kumo0[i].Opacity = ((this.ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                        else
                            TJAPlayer3.Tx.Background_Up_Clear_Kumo0[i].Opacity = 0;

                        for (int l = 0; l < 1280 / TJAPlayer3.Tx.Background_Up_Clear_Kumo0[i].szテクスチャサイズ.Width + 1; l++)
                            TJAPlayer3.Tx.Background_Up_Clear_Kumo0[i].t2D描画(TJAPlayer3.app.Device, (l * TJAPlayer3.Tx.Background_Up_Clear_Kumo0[i].szテクスチャサイズ.Width) - ct上背景クリア雲0スクロール用タイマー[i].n現在の値, i);

                    }
                    if (this.ct上背景クリア雲1スクロール用タイマー[i] != null)
                    {

                        if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[i])
                            TJAPlayer3.Tx.Background_Up_Clear_Kumo1[i].Opacity = ((this.ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                        else
                            TJAPlayer3.Tx.Background_Up_Clear_Kumo1[i].Opacity = 0;

                        for (int l = 0; l < 1448 / TJAPlayer3.Tx.Background_Up_Clear_Kumo1[i].szテクスチャサイズ.Width + 1; l++)
                            TJAPlayer3.Tx.Background_Up_Clear_Kumo1[i].t2D描画(TJAPlayer3.app.Device, (l * TJAPlayer3.Tx.Background_Up_Clear_Kumo1[i].szテクスチャサイズ.Width) - ct上背景クリア雲1スクロール用タイマー[i].n現在の値, i);

                    }
                    */
                    #endregion

                    #region [ ノーマル ]
                    
                    if (this.ct上背景スクロール用タイマー[i] != null)
                    {
                        if (TJAPlayer3.Tx.Background_Up[i] != null)
                        {
                            double TexSize = 1280 / TJAPlayer3.Tx.Background_Up[i].szテクスチャサイズ.Width;
                            int ForLoop = (int)Math.Ceiling(TexSize) + 1;

                            TJAPlayer3.Tx.Background_Up[i].t2D描画(TJAPlayer3.app.Device, 0 - this.ct上背景スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);
                            for (int l = 1; l < ForLoop + 1; l++)
                            {
                                TJAPlayer3.Tx.Background_Up[i].t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Up[i].szテクスチャサイズ.Width) - this.ct上背景スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);
                            }
                        }
                        if (TJAPlayer3.Tx.Background_Up_Clear[i] != null)
                        {
                            if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[i])
                                TJAPlayer3.Tx.Background_Up_Clear[i].Opacity = ((this.ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                            else
                                TJAPlayer3.Tx.Background_Up_Clear[i].Opacity = 0;

                            double TexSize = 1280 / TJAPlayer3.Tx.Background_Up_Clear[i].szテクスチャサイズ.Width;
                            int ForLoop = (int)Math.Ceiling(TexSize) + 1;

                            TJAPlayer3.Tx.Background_Up_Clear[i].t2D描画(TJAPlayer3.app.Device, 0 - this.ct上背景スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);
                            for (int l = 1; l < ForLoop + 1; l++)
                            {
                                TJAPlayer3.Tx.Background_Up_Clear[i].t2D描画(TJAPlayer3.app.Device, (l * TJAPlayer3.Tx.Background_Up_Clear[i].szテクスチャサイズ.Width) - this.ct上背景スクロール用タイマー[i].n現在の値, TJAPlayer3.Skin.Background_Scroll_Y[i]);
                            }
                        }
                        if (this.ct上背景桜用タイマー[i] != null && this.ct上背景桜スクロール用タイマー[i] != null)
                        {
                            if (TJAPlayer3.Tx.Background_Up_Sakura[i] != null)
                            {
                                int xy = (int)(this.ct上背景桜用タイマー[i].n現在の値 - (this.ct上背景桜用タイマー[i].n終了値 / 2.0));
                                double TexSize = 1280 / TJAPlayer3.Tx.Background_Up_Sakura[i].szテクスチャサイズ.Width;
                                int ForLoop = (int)Math.Ceiling(TexSize) + 1;

                                for (int l = 0; l < 1308 / TJAPlayer3.Tx.Background_Up_Sakura[i].szテクスチャサイズ.Width + 2; l++)
                                {
                                    TJAPlayer3.Tx.Background_Up_Sakura[i].t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Up_Sakura[i].szテクスチャサイズ.Width) - this.ct上背景桜スクロール用タイマー[i].n現在の値 - xy, TJAPlayer3.Skin.Background_Scroll_Y[i] + xy);
                                }
                                
                            }
                            if (TJAPlayer3.Tx.Background_Up_Sakura_Clear[i] != null)
                            {
                                if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[i])
                                    TJAPlayer3.Tx.Background_Up_Sakura_Clear[i].Opacity = ((this.ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                                else
                                    TJAPlayer3.Tx.Background_Up_Sakura_Clear[i].Opacity = 0;

                                int xy = (int)(this.ct上背景桜用タイマー[i].n現在の値 - this.ct上背景桜用タイマー[i].n終了値 / 2.0);
                                double TexSize = 1280 / TJAPlayer3.Tx.Background_Up_Sakura_Clear[i].szテクスチャサイズ.Width;
                                int ForLoop = (int)Math.Ceiling(TexSize) + 1;

                                for (int l = 0; l < 1308 / TJAPlayer3.Tx.Background_Up_Sakura_Clear[i].szテクスチャサイズ.Width + 2; l++)
                                {
                                    TJAPlayer3.Tx.Background_Up_Sakura_Clear[i].t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Up_Sakura_Clear[i].szテクスチャサイズ.Width) - this.ct上背景桜スクロール用タイマー[i].n現在の値 - xy, TJAPlayer3.Skin.Background_Scroll_Y[i] + xy);
                                }
                            }
                            if (this.ct上背景上下用タイマー[i] != null)
                            {
                                if (TJAPlayer3.Tx.Background_Up_YMove[i] != null)
                                {
                                    int ym;
                                    int xm;

                                    if (ct上背景上下用タイマー[i].n現在の値 <= ct上背景上下用タイマー[i].n終了値 * 0.5)
                                        ym = (int)((-ct上背景上下用タイマー[i].n現在の値) * 0.5);
                                    else
                                        ym = (int)((ct上背景上下用タイマー[i].n現在の値 - ct上背景上下用タイマー[i].n終了値) * 0.5); //最初のy軸の高さ
                                    ym -= (int)(ct上背景上下用タイマー[i].n終了値 * 0.0625); //全体の高さ
                                    xm = this.ct上背景サブスクロール用タイマー[i].n現在の値;

                                    for (int l = 0; l < 1304 / TJAPlayer3.Tx.Background_Up_YMove[i].szテクスチャサイズ.Width + 2; l++)
                                    {
                                        TJAPlayer3.Tx.Background_Up_YMove[i].t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Up_YMove[i].szテクスチャサイズ.Width) - xm, TJAPlayer3.Skin.Background_Scroll_Y[i] + ym); //2個目の画像(ループ)
                                    }
                                }
                                if (TJAPlayer3.Tx.Background_Up_YMove_Clear[i] != null)
                                {
                                    int ym;
                                    int xm;

                                    if (ct上背景上下用タイマー[i].n現在の値 <= ct上背景上下用タイマー[i].n終了値 * 0.5)
                                        ym = (int)((-ct上背景上下用タイマー[i].n現在の値) * 0.5);
                                    else
                                        ym = (int)((ct上背景上下用タイマー[i].n現在の値 - ct上背景上下用タイマー[i].n終了値) * 0.5);
                                    ym -= (int)(ct上背景上下用タイマー[i].n終了値 * 0.0625);
                                    xm = this.ct上背景サブスクロール用タイマー[i].n現在の値;

                                    if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[i])
                                        TJAPlayer3.Tx.Background_Up_YMove_Clear[i].Opacity = ((this.ct上背景クリアインタイマー[i].n現在の値 * 0xff) / 100);
                                    else
                                        TJAPlayer3.Tx.Background_Up_YMove_Clear[i].Opacity = 0;

                                    for (int l = 0; l < 1304 / TJAPlayer3.Tx.Background_Up_YMove[i].szテクスチャサイズ.Width + 2; l++)
                                    {
                                        TJAPlayer3.Tx.Background_Up_YMove_Clear[i].t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Up_YMove_Clear[i].szテクスチャサイズ.Width) - xm, TJAPlayer3.Skin.Background_Scroll_Y[i] + ym);
                                    }
                                }
                            }
                        }
                    }
                    
                    #endregion

                }
				#endregion
			}
            else
            {
                #region [ 段位背景 ]
                
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
                
                #endregion
            }
            #endregion

            #region [ 1P-下背景 ]
            if (!TJAPlayer3.stage演奏ドラム画面.bDoublePlay)
            {
                this.ct点滅0.t進行Loop();
                this.ct点滅1.t進行Loop();
                if (TJAPlayer3.Tx.Background_Down != null)
                {
                    TJAPlayer3.Tx.Background_Down.t2D描画(TJAPlayer3.app.Device, 0, 360);
                    //TJAPlayer3.Tx.Background_Down_Light_A.t2D描画(TJAPlayer3.app.Device, 0, 360);
                    //TJAPlayer3.Tx.Background_Down_Light_A.Opacity = (int)(176.0 + 80.0 * Math.Sin((double)(2 * Math.PI * this.ct点滅0.n現在の値 * 2 / 100.0)));//176.0 + 80.0
                    TJAPlayer3.Tx.Background_Down_Light_B.t2D描画(TJAPlayer3.app.Device, 0, 360);
                    TJAPlayer3.Tx.Background_Down_Light_B.Opacity = (int)(176.0 + 30.0 * Math.Sin((double)(2 * Math.PI * this.ct点滅1.n現在の値 * 2 / 500.0)));//176.0 + 80.0
                }
                if (TJAPlayer3.stage演奏ドラム画面.bIsAlreadyCleared[0])
                {
                    #region [ 松 ]
                    /*
					if (TJAPlayer3.Tx.Background_Down_Clear != null && TJAPlayer3.Tx.Background_Down_Scroll != null && ct下背景スクロール用タイマー1 != null && ct下背景スクロール用タイマー2 != null && ct下背景スクロール用タイマー3 != null)
                    {
                        int ym;

                        if (ct下背景上下用タイマー.n現在の値 <= ct下背景上下用タイマー.n終了値 * 0.5)
                            ym = (int)((-ct下背景上下用タイマー.n現在の値) * 0.5);
                        else
                            ym = (int)((ct下背景上下用タイマー.n現在の値 - ct下背景上下用タイマー.n終了値) * 0.5);
                        ym -= (int)(ct下背景上下用タイマー.n終了値 * 0.0625);

                        TJAPlayer3.Tx.Background_Down_Clear.Opacity = ((this.ct上背景FIFOタイマー.n現在の値 * 0xff) / 100);
                        TJAPlayer3.Tx.Background_Down_Scroll.Opacity = ((this.ct上背景FIFOタイマー.n現在の値 * 0xff) / 100);
                        TJAPlayer3.Tx.Background_Down_Scroll_Matu.Opacity = ((this.ct上背景FIFOタイマー.n現在の値 * 0xff) / 100);
                        TJAPlayer3.Tx.Background_Down_Scroll_Kumo.Opacity = ((this.ct上背景FIFOタイマー.n現在の値 * 0xff) / 100);
                        TJAPlayer3.Tx.Background_Down_Koma.Opacity = ((this.ct上背景FIFOタイマー.n現在の値 * 0xff) / 100);

                        double TexSize = 1280 / TJAPlayer3.Tx.Background_Down_Scroll.szテクスチャサイズ.Width;
                        int ForLoop = (int)Math.Ceiling(TexSize) + 1;

                        TJAPlayer3.Tx.Background_Down_Scroll.t2D描画(TJAPlayer3.app.Device, 0 - this.ct下背景スクロール用タイマー1.n現在の値, 360);
                        for (int l = 1; l < ForLoop + 1; l++)
                        {
                            TJAPlayer3.Tx.Background_Down_Scroll.t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Down_Scroll.szテクスチャサイズ.Width) - this.ct下背景スクロール用タイマー1.n現在の値, 360);
                        }
                        TJAPlayer3.Tx.Background_Down_Clear.t2D描画(TJAPlayer3.app.Device, 0, 360);
                        TJAPlayer3.Tx.Background_Down_Scroll_Matu.t2D描画(TJAPlayer3.app.Device, 0 - this.ct下背景スクロール用タイマー2.n現在の値, 360);
                        for (int l = 1; l < ForLoop + 1; l++)
                        {
                            TJAPlayer3.Tx.Background_Down_Scroll_Matu.t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Down_Scroll_Matu.szテクスチャサイズ.Width) - this.ct下背景スクロール用タイマー2.n現在の値, 360);
                        }
                        TJAPlayer3.Tx.Background_Down_Scroll_Kumo.t2D描画(TJAPlayer3.app.Device, 0 - this.ct下背景スクロール用タイマー3.n現在の値, 360);
                        for (int l = 1; l < ForLoop + 1; l++)
                        {
                            TJAPlayer3.Tx.Background_Down_Scroll_Kumo.t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Down_Scroll_Kumo.szテクスチャサイズ.Width) - this.ct下背景スクロール用タイマー3.n現在の値, 360);
                        }
                        TJAPlayer3.Tx.Background_Down_Koma.t2D描画(TJAPlayer3.app.Device, 0, 360 + ym);
                    }
                    */
                    #endregion

                    this.ct点滅2.t進行Loop();

                    if (TJAPlayer3.Tx.Background_Down_Clear != null && ct下背景スクロール用タイマー1 != null)
					{
                        int ym;

                        if (ct下背景上下用タイマー.n現在の値 <= ct下背景上下用タイマー.n終了値 * 0.5)
                            ym = (int)((-ct下背景上下用タイマー.n現在の値) * 0.5);
                        else
                            ym = (int)((ct下背景上下用タイマー.n現在の値 - ct下背景上下用タイマー.n終了値) * 0.5);
                        ym -= (int)(ct下背景上下用タイマー.n終了値 * 0.0625);

                        int ymP = ym * (-1);//int ymを逆走させる

                        int Cin = ((this.ct上背景FIFOタイマー.n現在の値 * 0xff) / 100); //クリアインフェード

                        TJAPlayer3.Tx.Background_Down_Clear.Opacity = Cin;
                        TJAPlayer3.Tx.Background_Down_BG_1.Opacity = Cin;
                        TJAPlayer3.Tx.Background_Down_Sc_0.Opacity = Cin;
                        TJAPlayer3.Tx.Background_Down_Sc_1.Opacity = Cin;
                        TJAPlayer3.Tx.Background_Down_M0.Opacity = Cin;
                        TJAPlayer3.Tx.Background_Down_M1.Opacity = Cin;
                        //TJAPlayer3.Tx.Background_Down_Splash.Opacity = Cin;

                        double TexSize = 1280 / TJAPlayer3.Tx.Background_Down_Scroll.szテクスチャサイズ.Width;
                        int ForLoop = (int)Math.Ceiling(TexSize) + 1;

                        TJAPlayer3.Tx.Background_Down_Clear.t2D描画(TJAPlayer3.app.Device, 0, 360);
                        TJAPlayer3.Tx.Background_Down_BG_1.t2D描画(TJAPlayer3.app.Device, 0, 360);

                        TJAPlayer3.Tx.Background_Down_Sc_0.t2D描画(TJAPlayer3.app.Device, 0 - this.ct下背景スクロール用タイマー1.n現在の値, 360);
                        for (int l = 1; l < ForLoop + 1; l++)
                        {
                            TJAPlayer3.Tx.Background_Down_Sc_0.t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Down_Sc_0.szテクスチャサイズ.Width) - this.ct下背景スクロール用タイマー1.n現在の値, 360);
                        }

                        TJAPlayer3.Tx.Background_Down_M0.t2D描画(TJAPlayer3.app.Device, 0, 300 + ym);

                        TJAPlayer3.Tx.Background_Down_Fune.t2D描画(TJAPlayer3.app.Device, 0, 340 + ymP);

                        TJAPlayer3.Tx.Background_Down_M1.t2D描画(TJAPlayer3.app.Device, 0, 260 + ymP);

                        TJAPlayer3.Tx.Background_Down_FuneX2.t2D描画(TJAPlayer3.app.Device, 0, 340 + ymP);

                        TJAPlayer3.Tx.Background_Down_Sc_1.t2D描画(TJAPlayer3.app.Device, 0 - this.ct下背景スクロール用タイマー2.n現在の値, 619);
                        for (int l = 1; l < ForLoop + 1; l++)
                        {
                            TJAPlayer3.Tx.Background_Down_Sc_1.t2D描画(TJAPlayer3.app.Device, +(l * TJAPlayer3.Tx.Background_Down_Sc_1.szテクスチャサイズ.Width) - this.ct下背景スクロール用タイマー2.n現在の値, 619);
                        }
                        //TJAPlayer3.Tx.Background_Down_Splash.t2D描画(TJAPlayer3.app.Device, 0, 360);
                        //TJAPlayer3.Tx.Background_Down_Splash.Opacity = (int)(100.0 + 80.0 * Math.Sin((double)(2 * Math.PI * this.ct点滅2.n現在の値 * 2 / 100.0)));
                    }
				}
			}
            #endregion

            return base.On進行描画();
        }
        #region[ private ]
        //-----------------
        private CCounter[] ct上背景スクロール用タイマー;
        private CCounter[] ct上背景サブスクロール用タイマー;
        //private CCounter[] ct上背景スクロール用タイマー1st; //上背景のX方向スクロール用
        //private CCounter[] ct上背景スクロール用タイマー2nd; //上背景のY方向スクロール用
        //private CCounter[] ct上背景スクロール用タイマー3rd; //上背景のY方向スクロール用

        private CCounter[] ct上背景上下用タイマー;
        private CCounter[] ct上背景桜用タイマー;
        private CCounter[] ct上背景桜スクロール用タイマー;

        //private CCounter[] ct上背景雲0スクロール用タイマー;
        //private CCounter[] ct上背景雲1スクロール用タイマー;
        //private CCounter[] ct上背景クリア雲0スクロール用タイマー;
        //private CCounter[] ct上背景クリア雲1スクロール用タイマー;

        //private CCounter ct桜X移動用タイマー1;
        //private CCounter ct桜Y移動用タイマー1;
        //private CCounter ct桜X移動用タイマー2;
        //private CCounter ct桜Y移動用タイマー2;
        //private CCounter ct桜X移動用タイマー3;
        //private CCounter ct桜Y移動用タイマー3;

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
