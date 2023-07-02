using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using FDK;
using System.Numerics;
using SharpDX;

using Rectangle = System.Drawing.Rectangle;
using RectangleF = System.Drawing.RectangleF;
using Point = System.Drawing.Point;
using Color = System.Drawing.Color;

namespace TJAPlayer3
{
    internal class CAct演奏Drums演奏終了演出 : CActivity
    {
        /// <summary>
        /// 課題
        /// _クリア失敗 →素材不足(確保はできる。切り出しと加工をしてないだけ。)
        /// _
        /// </summary>
        public CAct演奏Drums演奏終了演出()
        {
            base.b活性化してない = true;
        }

        public void Start()
        {
            // this.ct進行メイン = new CCounter(0, 500, 1000 / 60, TJAPlayer3.Timer);

            this.ct進行メイン = new CCounter(0, 300, 16, TJAPlayer3.Timer);
            this.ctEnd_ClearFailed = new CCounter(0, 69, 30, TJAPlayer3.Timer);
            this.ctEnd_FullCombo = new CCounter(0, 66, 33, TJAPlayer3.Timer);
            this.ctEnd_FullComboLoop = new CCounter(0, 2, 30, TJAPlayer3.Timer);
            this.ctEnd_DondaFullCombo = new CCounter(0, 61, 33, TJAPlayer3.Timer);
            this.ctEnd_DondaFullComboLoop = new CCounter(0, 2, 30, TJAPlayer3.Timer);

            // モードの決定。クリア失敗・フルコンボも事前に作っとく。

            if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan)
            {
                // 段位認定モード。
                if (!TJAPlayer3.stage演奏ドラム画面.actDan.GetFailedAllChallenges())
                {
                    // 段位認定モード、クリア成功
                    this.Mode[0] = EndMode.StageCleared;
                    
                    if (TJAPlayer3.stage演奏ドラム画面.nヒット数_Auto含まない.Drums.Miss == 0)
                    {
                        if (TJAPlayer3.stage演奏ドラム画面.nヒット数_Auto含まない.Drums.Good == 0)
                            this.Mode[0] = EndMode.StageDondaFullCombo;
                        else
                            this.Mode[0] = EndMode.StageFullCombo;
                    }
                    else
                        this.Mode[0] = EndMode.StageCleared;

                }
                else
                {
                    // 段位認定モード、クリア失敗
                    this.Mode[0] = EndMode.StageFailed;
                }
            }
            else
            {
                // 通常のモード。
                // ここでフルコンボフラグをチェックするが現時点ではない。
                // 今の段階では魂ゲージ80%以上でチェック。
                for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
                {
                    if (TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[i] >= 80)
                    {
                        //if (TJAPlayer3.stage演奏ドラム画面.CChartScore[i].nMiss == 0)
                        if (TJAPlayer3.stage演奏ドラム画面.nヒット数_Auto含まない.Drums.Miss == 0)
                        {
                            //if (TJAPlayer3.stage演奏ドラム画面.CChartScore[i].nGood == 0)
                            if (TJAPlayer3.stage演奏ドラム画面.nヒット数_Auto含まない.Drums.Great == 0)
                            {
                                this.Mode[i] = EndMode.StageDondaFullCombo;
                            }
                            else
                            {
                                this.Mode[i] = EndMode.StageFullCombo;
                            }
                        }
                        else
                        {
                            this.Mode[i] = EndMode.StageCleared;
                        }
                    }
                    else
                    {
                        this.Mode[i] = EndMode.StageFailed;
                    }
                }
            }
        }

        public override void On活性化()
        {
            this.bリザルトボイス再生済み = false;
            this.Mode = new EndMode[2];
            base.On活性化();
        }

        public override void On非活性化()
        {
            this.ct進行メイン = null;
            base.On非活性化();
        }

        public override void OnManagedリソースの作成()
        {
            this.b再生済み = false;
            if (!base.b活性化してない)
            {
                this.soundClear = TJAPlayer3.Sound管理.tサウンドを生成する(CSkin.Path(@"Sounds\Clear.ogg"), ESoundGroup.SoundEffect);
                this.soundFailed = TJAPlayer3.Sound管理.tサウンドを生成する(CSkin.Path(@"Sounds\Failed.ogg"), ESoundGroup.SoundEffect);
                this.soundFullCombo = TJAPlayer3.Sound管理.tサウンドを生成する(CSkin.Path(@"Sounds\Full combo.ogg"), ESoundGroup.SoundEffect);
                this.soundDondaFullCombo = TJAPlayer3.Sound管理.tサウンドを生成する(CSkin.Path(@"Sounds\Donda Full Combo.ogg"), ESoundGroup.SoundEffect);
                base.OnManagedリソースの作成();
            }
        }

        public override void OnManagedリソースの解放()
        {
            if (!base.b活性化してない)
            {
                this.soundClear?.t解放する();
                this.soundFailed?.t解放する();
                this.soundFullCombo?.t解放する();
                this.soundDondaFullCombo?.t解放する();
                base.OnManagedリソースの解放();
            }
        }

        #region [ メイン ]
        // ------------------------------------
        private void showEndEffect_Failed(int i)
        {
            #region [ クリア失敗 ]
            int[] y = new int[] { 0, 176 };

            this.ctEnd_ClearFailed.t進行();
            int currentValue = this.ctEnd_ClearFailed.n現在の値;
            int lastIndex = TJAPlayer3.Tx.End_ClearFailed.Length - 1;

            if (currentValue <= 20 || TJAPlayer3.Tx.ClearFailed == null)
            {
                TJAPlayer3.Tx.End_ClearFailed[Math.Min(currentValue, lastIndex)]?.t2D描画(TJAPlayer3.app.Device, 505, y[i] + 145);
            }
            else if (currentValue >= 20 && currentValue <= 67)
            {
                TJAPlayer3.Tx.ClearFailed?.t2D描画(TJAPlayer3.app.Device, 502, y[i] + 192);
            }
            else if (currentValue == 68)
            {
                TJAPlayer3.Tx.ClearFailed1?.t2D描画(TJAPlayer3.app.Device, 502, y[i] + 192);
            }
            else if (currentValue >= 69)
            {
                TJAPlayer3.Tx.ClearFailed2?.t2D描画(TJAPlayer3.app.Device, 502, y[i] + 192);
            }

            #endregion
        }
        private void showEndEffect_Clear(int i)
        {
            #region [ クリア成功 ]

            #region[ 文字 ]

            float[] f文字拡大率 = new float[] { 1.04f, 1.11f, 1.15f, 1.19f, 1.23f, 1.26f, 1.30f, 1.31f, 1.32f, 1.32f, 1.32f, 1.30f, 1.30f, 1.26f, 1.25f, 1.19f, 1.15f, 1.11f, 1.05f, 1.0f };
            int[] n透明度 = new int[] { 43, 85, 128, 170, 213, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 };

            int[] y = new int[] { 300, 386 };

            for (int j = 0; j < 5; j++)
            {
                if (this.ct進行メイン.n現在の値 >= 25 + j * 3)
                {
                    if (this.ct進行メイン.n現在の値 <= 44 + j * 3)
                    {
                        TJAPlayer3.Tx.End_Clear_Text[0].vc拡大縮小倍率.Y = f文字拡大率[this.ct進行メイン.n現在の値 - (25 + j * 3)];
                        TJAPlayer3.Tx.End_Clear_Text[0].Opacity = n透明度[this.ct進行メイン.n現在の値 - (25 + j * 3)];
                        TJAPlayer3.Tx.End_Clear_Text[0].t2D拡大率考慮下基準描画(TJAPlayer3.app.Device, 634 + (j < 3 ? j * 58 : 2 * 58 + (j - 2) * 65), y[i], new Rectangle(90 * j, 0, 90, 90));
                    }
                    else
                    {
                        if (this.ct進行メイン.n現在の値 <= 78)
                        {
                            TJAPlayer3.Tx.End_Clear_Text[0].vc拡大縮小倍率.Y = 1.0f;
                            TJAPlayer3.Tx.End_Clear_Text[0].Opacity = 255;
                            TJAPlayer3.Tx.End_Clear_Text[0].t2D拡大率考慮下基準描画(TJAPlayer3.app.Device, 634 + (j < 3 ? j * 58 : 2 * 58 + (j - 2) * 65), y[i], new Rectangle(90 * j, 0, 90, 90));
                        }
                        else
                        {
                            TJAPlayer3.Tx.End_Clear_Text[1].Opacity = 255;
                            TJAPlayer3.Tx.End_Clear_Text[1].t2D描画(TJAPlayer3.app.Device, 641, y[i] - 85, new Rectangle(0, 0, 334, 84));
                        }
                    }
                }

                if (this.ct進行メイン.n現在の値 >= 67)
                {
                    if (this.ct進行メイン.n現在の値 <= 78)
                    {
                        TJAPlayer3.Tx.End_Clear_Text[0].Opacity = (int)((this.ct進行メイン.n現在の値 - 67) * 23.18181f);
                        TJAPlayer3.Tx.End_Clear_Text[0].t2D拡大率考慮下基準描画(TJAPlayer3.app.Device, 634 + (j < 3 ? j * 58 : 2 * 58 + (j - 2) * 65), y[i], new Rectangle(90 * j, 90, 90, 90));
                    }
                    else if (this.ct進行メイン.n現在の値 <= 89)
                    {
                        TJAPlayer3.Tx.End_Clear_Text[0].Opacity = 0;
                        TJAPlayer3.Tx.End_Clear_Text[1].Opacity = (int)(255 - ((this.ct進行メイン.n現在の値 - 78) * 23.18181f));
                        TJAPlayer3.Tx.End_Clear_Text[1].t2D描画(TJAPlayer3.app.Device, 641, y[i] - 85, new Rectangle(0, 84, 334, 84));
                    }
                }
            }
            #endregion

            #region[ バチお ]

            if (this.ct進行メイン.n現在の値 <= 13)   //35
            {
                if (TJAPlayer3.Tx.End_Clear_Chara != null)
                {
                    TJAPlayer3.Tx.End_Clear_Chara.Opacity = (int)(this.ct進行メイン.n現在の値 * 19.7f);
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 694, 178, new RectangleF(180, 0, 180, 180));
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 727, 178, new RectangleF(180, 180, 180, 180));
                }
            }
            else if (this.ct進行メイン.n現在の値 <= 48)
            {
                if (TJAPlayer3.Tx.End_Clear_Chara != null)
                {
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - (float)Math.Sin((this.ct進行メイン.n現在の値 - 13) * 2.57142 * (Math.PI / 180)) * 218, y[i] - 122, new RectangleF(0, 0, 180, 180));
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + (float)Math.Sin((this.ct進行メイン.n現在の値 - 13) * 2.57142 * (Math.PI / 180)) * 218, y[i] - 122, new RectangleF(0, 180, 180, 180));
                }
            }
            else if (this.ct進行メイン.n現在の値 <= 52)
            {
                if (TJAPlayer3.Tx.End_Clear_Chara != null)
                {
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - 218, y[i] - 122, new RectangleF(180, 0, 180, 180));
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + 218, y[i] - 122, new RectangleF(180, 180, 180, 180));
                }
            }
            else if (this.ct進行メイン.n現在の値 <= 55)
            {
                if (TJAPlayer3.Tx.End_Clear_Chara != null)
                {
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - 218, 178, new RectangleF(360, 0, 180, 180));
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + 218, 178, new RectangleF(360, 180, 180, 180));
                }
            }
            else if (this.ct進行メイン.n現在の値 <= 58)
            {
                if (TJAPlayer3.Tx.End_Clear_Chara != null)
                {
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - 218, 178, new RectangleF(540, 0, 180, 180));
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + 218, 178, new RectangleF(540, 0, 180, 180));
                }
            }
            else if (this.ct進行メイン.n現在の値 <= 62)
            {
                if (TJAPlayer3.Tx.End_Clear_Chara != null)
                {
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - 218, 178, new RectangleF(720, 0, 180, 180));
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + 218, 178, new RectangleF(720, 180, 180, 180));
                }
            }
            else
            {
                if (TJAPlayer3.Tx.End_Clear_Chara != null)
                {
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - 218, 178, new RectangleF(900, 0, 180, 180));
                    TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + 218, 178, new RectangleF(900, 180, 180, 180));
                }
            }

            #endregion

            #region [ 星アニメ ]

            if (this.ct進行メイン.n現在の値 >= 123)
            {
                if (this.ct進行Loop == null)
                    ct進行Loop = new CCounter(0, 93, 1000 / 60, TJAPlayer3.Timer);

                ct進行Loop.t進行Loop();

                int currentLoopValue = ct進行Loop.n現在の値;

                StarDraw(683, 209, currentLoopValue, 0, 12);
                StarDraw(683, 209, currentLoopValue - 12);

                StarDraw(803, 208, currentLoopValue, 10);
                StarDraw(803, 208, currentLoopValue - 12, 0, 8);

                StarDraw(926, 208, currentLoopValue - 6, 14);
                StarDraw(926, 208, currentLoopValue - 12, 0, 14);

                StarDraw(644, 287, currentLoopValue - 26, 18);
                StarDraw(644, 287, currentLoopValue - 30, 0, 14);

                StarDraw(726, 305, currentLoopValue - 15, 7);
                StarDraw(726, 305, currentLoopValue - 30, 0, 4);

                StarDraw(874, 305, currentLoopValue);

                StarDraw(962, 291, currentLoopValue - 21, 13);
                StarDraw(962, 291, currentLoopValue - 30, 0, 9);
            }

            #endregion

            #endregion
        }

        private void showEndEffect_FullCombo(int i)
        {
            #region [ フルコンボ ]
            
            int[] y = new int[] { 0, 176 };

            this.ctEnd_FullCombo.t進行();
            TJAPlayer3.Tx.End_FullCombo[this.ctEnd_FullCombo.n現在の値].t2D描画(TJAPlayer3.app.Device, 330, y[i] + 50);

            if (this.ctEnd_FullCombo.b終了値に達した && TJAPlayer3.Tx.End_FullComboLoop[0] != null)
            {
                this.ctEnd_FullComboLoop.t進行Loop();
                TJAPlayer3.Tx.End_FullComboLoop[this.ctEnd_FullComboLoop.n現在の値].t2D描画(TJAPlayer3.app.Device, 330, y[i] + 196);
            }
            
            #endregion

            #region [ Dev ]
			//if (TJAPlayer3.Tx.End_Clear_Text != null && TJAPlayer3.Tx.End_FullCombo_Text != null )
            {
                //float[] f文字拡大率 = new float[] { 1.04f, 1.11f, 1.15f, 1.19f, 1.23f, 1.26f, 1.30f, 1.31f, 1.32f, 1.32f, 1.32f, 1.30f, 1.30f, 1.26f, 1.25f, 1.19f, 1.15f, 1.11f, 1.05f, 1.0f };
                //int[] n透明度 = new int[] { 43, 85, 128, 170, 213, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255 };
                //int[] y = new int[] { 300, 386 };

                #region[ 文字 ]
                /*
                for (int j = 0; j < 5; j++)
                {
                    if (this.ct進行メイン.n現在の値 >= 25 + j * 3)
                    {
                        if (this.ct進行メイン.n現在の値 <= 44 + j * 3)
                        {
                            TJAPlayer3.Tx.End_Clear_Text[0].vc拡大縮小倍率.Y = f文字拡大率[this.ct進行メイン.n現在の値 - (25 + j * 3)];
                            TJAPlayer3.Tx.End_Clear_Text[0].Opacity = n透明度[this.ct進行メイン.n現在の値 - (25 + j * 3)];
                            TJAPlayer3.Tx.End_Clear_Text[0].t2D拡大率考慮下基準描画(TJAPlayer3.app.Device, 634 + (j < 3 ? j * 58 : 2 * 58 + (j - 2) * 65), y[i], new Rectangle(90 * j, 0, 90, 90));
                        }
                        else
                        {
                            if (this.ct進行メイン.n現在の値 <= 78)
                            {
                                TJAPlayer3.Tx.End_Clear_Text[0].vc拡大縮小倍率.Y = 1.0f;
                                TJAPlayer3.Tx.End_Clear_Text[0].Opacity = 255;
                                TJAPlayer3.Tx.End_Clear_Text[0].t2D拡大率考慮下基準描画(TJAPlayer3.app.Device, 634 + (j < 3 ? j * 58 : 2 * 58 + (j - 2) * 65), y[i], new Rectangle(90 * j, 0, 90, 90));
                            }
                            else
                            {
                                TJAPlayer3.Tx.End_Clear_Text[1].Opacity = 255;
                                TJAPlayer3.Tx.End_Clear_Text[1].t2D描画(TJAPlayer3.app.Device, 641, y[i] - 85, new Rectangle(0, 0, 334, 84));
                            }
                        }
                    }
                    int ydiff = 0;
                    TJAPlayer3.Tx.End_FullCombo_Text[0].vc拡大縮小倍率.Y = 1f;
                    TJAPlayer3.Tx.End_FullCombo_Text[1].vc拡大縮小倍率.Y = 1f;
                    if (this.ct進行メイン.n現在の値 >= 70 && this.ct進行メイン.n現在の値 < 90)
                    {
                        double ratio = Math.Sin(((this.ct進行メイン.n現在の値 - 70) / 10.0) * Math.PI);
                        if (ratio > 0)
                        {
                            ydiff = (int)(ratio * 10.0);
                        }
                        else
                        {
                            TJAPlayer3.Tx.End_FullCombo_Text[0].vc拡大縮小倍率.Y = 0.8f + (float)(ratio + 1.0) * 0.2f;
                            TJAPlayer3.Tx.End_FullCombo_Text[1].vc拡大縮小倍率.Y = 0.8f + (float)(ratio + 1.0) * 0.2f;
                        }
                    }
                    if (this.ct進行メイン.n現在の値 >= 70)
                    {
                        if (this.ct進行メイン.n現在の値 < 80)
                        {
                            TJAPlayer3.Tx.End_FullCombo_Text[0].Opacity = (this.ct進行メイン.n現在の値 - 70) * (255 / 10);
                        }
                        else
                        {
                            TJAPlayer3.Tx.End_FullCombo_Text[0].Opacity = 255;
                        }
                        TJAPlayer3.Tx.End_FullCombo_Text[0].t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.Down, 810, y[i] - ydiff + TJAPlayer3.Tx.End_FullCombo_Text[0].szテクスチャサイズ.Height);
                    }
                    if (this.ct進行メイン.n現在の値 >= 70 && this.ct進行メイン.n現在の値 < 90)
                    {
                        if (this.ct進行メイン.n現在の値 < 80)
                        {
                            TJAPlayer3.Tx.End_FullCombo_Text[1].Opacity = (this.ct進行メイン.n現在の値 - 70) * (255 / 10);
                        }
                        else
                        {
                            TJAPlayer3.Tx.End_FullCombo_Text[1].Opacity = 255 - ((this.ct進行メイン.n現在の値 - 80) * (255 / 10));
                        }
                        TJAPlayer3.Tx.End_FullCombo_Text[1].t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.Down, 810, y[i] - ydiff + TJAPlayer3.Tx.End_FullCombo_Text[1].szテクスチャサイズ.Height);
                    }


                }
                */


                #endregion
                const int leftfan = 356;
                const int rightfan = 956;
                #region[ 扇2 ]
                //レイヤー変更用に扇の個所を2箇所に分ける
                /*
                if (this.ct進行メイン.n現在の値 >= 79 && TJAPlayer3.Tx.End_Fan[3] != null)
                {
                    int x補正値, y補正値;
                    if ((this.ct進行メイン.n現在の値 / 2) % 2 == 0)
                    {
                        TJAPlayer3.Tx.End_Fan[3].vcScaling.Y = 1f;
                        x補正値 = 0;
                        y補正値 = 0;
                    }
                    else
                    {
                        TJAPlayer3.Tx.End_Fan[3].vcScaling.Y = 0.99f;
                        x補正値 = 1;
                        y補正値 = 1;
                    }
                    TJAPlayer3.Tx.End_Fan[3].fRotation = -20f * (float)Math.PI / 180f;
                    TJAPlayer3.Tx.End_Fan[3].t2D描画(TJAPlayer3.app.Device, leftfan - x補正値, y[i] - 15 + y補正値);
                    TJAPlayer3.Tx.End_Fan[3].fRotation = 20f * (float)Math.PI / 180f;
                    TJAPlayer3.Tx.End_Fan[3].t2D描画(TJAPlayer3.app.Device, rightfan + x補正値, y[i] - 15 + y補正値);
                }
                */
                #endregion
                #region[ バチお ]
                /*
                if (TJAPlayer3.Tx.End_Clear_L[4] != null)
                    TJAPlayer3.Tx.End_Clear_L[4].vcScaling.Y = 1.0f;
                if (TJAPlayer3.Tx.End_Clear_R[4] != null)
                    TJAPlayer3.Tx.End_Clear_R[4].vcScaling.Y = 1.0f;
                if (this.ct進行メイン.n現在の値 <= 11)
                {
                    if (TJAPlayer3.Tx.End_Clear_L[1] != null)
                    {
                        TJAPlayer3.Tx.End_Clear_L[1].t2D描画(TJAPlayer3.app.Device, 697, y[i] - 30);
                        TJAPlayer3.Tx.End_Clear_L[1].Opacity = (int)(11.0 / this.ct進行メイン.n現在の値) * 255;
                    }
                    if (TJAPlayer3.Tx.End_Clear_R[1] != null)
                    {
                        TJAPlayer3.Tx.End_Clear_R[1].t2D描画(TJAPlayer3.app.Device, 738, y[i] - 30);
                        TJAPlayer3.Tx.End_Clear_R[1].Opacity = (int)(11.0 / this.ct進行メイン.n現在の値) * 255;
                    }
                }
                else if (this.ct進行メイン.n現在の値 <= 35)
                {
                    if (TJAPlayer3.Tx.End_Clear_L[0] != null)
                        TJAPlayer3.Tx.End_Clear_L[0].t2D描画(TJAPlayer3.app.Device, 697 - (int)((this.ct進行メイン.n現在の値 - 12) * 10), y[i] - 30);
                    if (TJAPlayer3.Tx.End_Clear_R[0] != null)
                        TJAPlayer3.Tx.End_Clear_R[0].t2D描画(TJAPlayer3.app.Device, 738 + (int)((this.ct進行メイン.n現在の値 - 12) * 10), y[i] - 30);
                }
                else if (this.ct進行メイン.n現在の値 <= 46)
                {
                    if (TJAPlayer3.Tx.End_Clear_L[0] != null)
                    {
                        //2016.07.16 kairera0467 またも原始的...
                        float[] fRet = new float[] { 1.0f, 0.99f, 0.98f, 0.97f, 0.96f, 0.95f, 0.96f, 0.97f, 0.98f, 0.99f, 1.0f };
                        TJAPlayer3.Tx.End_Clear_L[0].t2D描画(TJAPlayer3.app.Device, 466, y[i] - 30);
                        TJAPlayer3.Tx.End_Clear_L[0].vcScaling = new Vector3(fRet[this.ct進行メイン.n現在の値 - 36], 1.0f, 1.0f);
                        //CDTXMania.Tx.End_Clear_R[ 0 ].t2D描画( CDTXMania.app.Device, 956 + (( this.ct進行メイン.n現在の値 - 36 ) / 2), 180 );
                        TJAPlayer3.Tx.End_Clear_R[0].t2D描画(TJAPlayer3.app.Device, 1136 - 180 * fRet[this.ct進行メイン.n現在の値 - 36], y[i] - 30);
                        TJAPlayer3.Tx.End_Clear_R[0].vcScaling = new Vector3(fRet[this.ct進行メイン.n現在の値 - 36], 1.0f, 1.0f);
                    }
                }
                else if (this.ct進行メイン.n現在の値 <= 49)
                {
                    if (TJAPlayer3.Tx.End_Clear_L[1] != null)
                        TJAPlayer3.Tx.End_Clear_L[1].t2D描画(TJAPlayer3.app.Device, 466, y[i] - 30);
                    if (TJAPlayer3.Tx.End_Clear_R[1] != null)
                        TJAPlayer3.Tx.End_Clear_R[1].t2D描画(TJAPlayer3.app.Device, 956, y[i] - 30);
                }
                else if (this.ct進行メイン.n現在の値 <= 54)
                {
                    if (TJAPlayer3.Tx.End_Clear_L[2] != null)
                        TJAPlayer3.Tx.End_Clear_L[2].t2D描画(TJAPlayer3.app.Device, 466, y[i] - 30);
                    if (TJAPlayer3.Tx.End_Clear_R[2] != null)
                        TJAPlayer3.Tx.End_Clear_R[2].t2D描画(TJAPlayer3.app.Device, 956, y[i] - 30);
                }
                else if (this.ct進行メイン.n現在の値 <= 58)
                {
                    if (TJAPlayer3.Tx.End_Clear_L[3] != null)
                        TJAPlayer3.Tx.End_Clear_L[3].t2D描画(TJAPlayer3.app.Device, 466, y[i] - 30);
                    if (TJAPlayer3.Tx.End_Clear_R[3] != null)
                        TJAPlayer3.Tx.End_Clear_R[3].t2D描画(TJAPlayer3.app.Device, 956, y[i] - 30);
                }
                else if (this.ct進行メイン.n現在の値 <= 68)
                {
                    if (this.ct進行メイン.n現在の値 >= 58)
                    {
                        float xratio = (float)Math.Abs(Math.Cos(((this.ct進行メイン.n現在の値 - 58) / 10.0) * Math.PI));
                        if (TJAPlayer3.Tx.End_Clear_L[4] != null)
                            TJAPlayer3.Tx.End_Clear_L[4].vcScaling.Y = 0.8f + xratio * 0.2f;
                        if (TJAPlayer3.Tx.End_Clear_R[4] != null)
                            TJAPlayer3.Tx.End_Clear_R[4].vcScaling.Y = 0.8f + xratio * 0.2f;
                    }
                    if (TJAPlayer3.Tx.End_Clear_L[4] != null)
                        TJAPlayer3.Tx.End_Clear_L[4].t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.DownLeft, 466, y[i] + TJAPlayer3.Tx.End_Clear_L[4].szTextureSize.Height - 30);
                    if (TJAPlayer3.Tx.End_Clear_R[4] != null)
                        TJAPlayer3.Tx.End_Clear_R[4].t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.DownLeft, 956, y[i] + TJAPlayer3.Tx.End_Clear_L[4].szTextureSize.Height - 30);
                }
                else if (this.ct進行メイン.n現在の値 <= 88)
                {
                    int ysin = (int)(Math.Sin((this.ct進行メイン.n現在の値 - 68) / 20.0 * Math.PI) * 150.0);
                    if (TJAPlayer3.Tx.End_Clear_L[4] != null)
                        TJAPlayer3.Tx.End_Clear_L[4].t2D描画(TJAPlayer3.app.Device, 466 - ((this.ct進行メイン.n現在の値 - 68) * 8), y[i] - ysin - 30);
                    if (TJAPlayer3.Tx.End_Clear_R[4] != null)
                        TJAPlayer3.Tx.End_Clear_R[4].t2D描画(TJAPlayer3.app.Device, 956 + ((this.ct進行メイン.n現在の値 - 68) * 8), y[i] - ysin - 30);
                }
                else
                {
                    if (this.ct進行メイン.n現在の値 <= 98)
                    {
                        float xratio = (float)Math.Abs(Math.Cos(((this.ct進行メイン.n現在の値 - 89) / 10.0) * Math.PI));
                        if (TJAPlayer3.Tx.End_Clear_L[4] != null)
                            TJAPlayer3.Tx.End_Clear_L[4].vcScaling.Y = 0.8f + xratio * 0.2f;
                        if (TJAPlayer3.Tx.End_Clear_R[4] != null)
                            TJAPlayer3.Tx.End_Clear_R[4].vcScaling.Y = 0.8f + xratio * 0.2f;
                    }
                    if (TJAPlayer3.Tx.End_Clear_L[4] != null)
                        TJAPlayer3.Tx.End_Clear_L[4].t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.DownLeft, 306, y[i] + TJAPlayer3.Tx.End_Clear_L[4].szTextureSize.Height - 30);
                    if (TJAPlayer3.Tx.End_Clear_R[4] != null)
                        TJAPlayer3.Tx.End_Clear_R[4].t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.DownLeft, 1116, y[i] + TJAPlayer3.Tx.End_Clear_L[4].szTextureSize.Height - 30);
                }
                */
                #endregion
                #region[ 扇1 ]
                /*
                if (this.ct進行メイン.n現在の値 >= 70 && this.ct進行メイン.n現在の値 < 79 && TJAPlayer3.Tx.End_Fan != null)
                {
                    int num = 0;
                    if (this.ct進行メイン.n現在の値 < 73)
                    {
                        TJAPlayer3.Tx.End_Fan[0].Opacity = (this.ct進行メイン.n現在の値 - 70) * (255 / 3);
                        num = 0;
                    }
                    else if (this.ct進行メイン.n現在の値 < 76)
                    {
                        num = 1;
                    }
                    else if (this.ct進行メイン.n現在の値 < 79)
                    {
                        num = 2;
                    }
                    if (TJAPlayer3.Tx.End_Fan[num] != null)
                    {
                        TJAPlayer3.Tx.End_Fan[num].fRotation = -20f * (float)Math.PI / 180f;
                        TJAPlayer3.Tx.End_Fan[num].t2D描画(TJAPlayer3.app.Device, leftfan, y[i] - 15);
                        TJAPlayer3.Tx.End_Fan[num].fRotation = 20f * (float)Math.PI / 180f;
                        TJAPlayer3.Tx.End_Fan[num].t2D描画(TJAPlayer3.app.Device, rightfan, y[i] - 15);
                    }
                }
                */
                #endregion
            }
            #endregion

        }

        private void showEndEffect_DondaFullCombo(int i)
        {
            #region [ ドンダフルコンボ ]
            int[] y = new int[] { 0, 176 };

            this.ctEnd_DondaFullCombo.t進行();
            if (this.ctEnd_DondaFullCombo.n現在の値 >= 34) TJAPlayer3.Tx.End_DondaFullComboBg.t2D描画(TJAPlayer3.app.Device, 332, y[i] + 192);
            TJAPlayer3.Tx.End_DondaFullCombo[this.ctEnd_DondaFullCombo.n現在の値].t2D描画(TJAPlayer3.app.Device, 330, y[i] + 50);

            if (this.ctEnd_DondaFullCombo.b終了値に達した && TJAPlayer3.Tx.End_DondaFullComboLoop[0] != null)
            {
                TJAPlayer3.Tx.End_DondaFullComboBg.t2D描画(TJAPlayer3.app.Device, 332, y[i] + 192);
                this.ctEnd_DondaFullComboLoop.t進行Loop();
                TJAPlayer3.Tx.End_DondaFullComboLoop[this.ctEnd_DondaFullComboLoop.n現在の値].t2D描画(TJAPlayer3.app.Device, 330, y[i] + 50);
            }
			#endregion

			#region [ Dev ]
			/*
			//case EndMode.StageDonderFullCombo:
			if (TJAPlayer3.Tx.End_Clear_Text != null && TJAPlayer3.Tx.End_Clear_Text != null)
            {
                #region[ BG ]
                if (this.ct進行メイン.n現在の値 >= 70)
                {
                    if (this.ct進行メイン.n現在の値 < 80)
                    {
                        TJAPlayer3.Tx.End_DonderFullCombo_Lane.Opacity = (this.ct進行メイン.n現在の値 - 70) * (255 / 10);
                    }
                    else
                    {
                        TJAPlayer3.Tx.End_DonderFullCombo_Lane.Opacity = 255;
                    }
                    TJAPlayer3.Tx.End_DonderFullCombo_Lane.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.nScrollFieldBGX[i], TJAPlayer3.Skin.nScrollFieldY[i]);
                }
                #endregion
                #region[ 文字 ]
                if (this.ct進行メイン.n現在の値 >= 17)
                {
                    if (this.ct進行メイン.n現在の値 <= 36)
                    {
                        TJAPlayer3.Tx.End_Clear_Text.vcScaling.Y = f文字拡大率[this.ct進行メイン.n現在の値 - 17];
                        TJAPlayer3.Tx.End_Clear_Text.Opacity = n透明度[this.ct進行メイン.n現在の値 - 17];
                        TJAPlayer3.Tx.End_Clear_Text.t2D描画(TJAPlayer3.app.Device, 634, (int)(y[i] - ((90 * f文字拡大率[this.ct進行メイン.n現在の値 - 17]) - 90)), new Rectangle(0, 0, 90, 90));
                    }
                    else if (this.ct進行メイン.n現在の値 < 70)
                    {
                        TJAPlayer3.Tx.End_Clear_Text.vcScaling.Y = 1.0f;
                        TJAPlayer3.Tx.End_Clear_Text.t2D描画(TJAPlayer3.app.Device, 634, y[i], new Rectangle(0, 0, 90, 90));
                    }
                }
                if (this.ct進行メイン.n現在の値 >= 19)
                {
                    if (this.ct進行メイン.n現在の値 <= 38)
                    {
                        TJAPlayer3.Tx.End_Clear_Text.vcScaling.Y = f文字拡大率[this.ct進行メイン.n現在の値 - 19];
                        TJAPlayer3.Tx.End_Clear_Text.Opacity = n透明度[this.ct進行メイン.n現在の値 - 19];
                        TJAPlayer3.Tx.End_Clear_Text.t2D描画(TJAPlayer3.app.Device, 692, (int)(y[i] - ((90 * f文字拡大率[this.ct進行メイン.n現在の値 - 19]) - 90)), new Rectangle(90, 0, 90, 90));
                    }
                    else if (this.ct進行メイン.n現在の値 < 70)
                    {
                        TJAPlayer3.Tx.End_Clear_Text.vcScaling.Y = 1.0f;
                        TJAPlayer3.Tx.End_Clear_Text.t2D描画(TJAPlayer3.app.Device, 692, y[i], new Rectangle(90, 0, 90, 90));
                    }
                }
                TJAPlayer3.Tx.End_Clear_Text.vcScaling.Y = 1.0f;
                if (this.ct進行メイン.n現在の値 >= 21)
                {
                    if (this.ct進行メイン.n現在の値 <= 40)
                    {
                        TJAPlayer3.Tx.End_Clear_Text.vcScaling.Y = f文字拡大率[this.ct進行メイン.n現在の値 - 21];
                        TJAPlayer3.Tx.End_Clear_Text.Opacity = n透明度[this.ct進行メイン.n現在の値 - 21];
                        TJAPlayer3.Tx.End_Clear_Text.t2D描画(TJAPlayer3.app.Device, 750, y[i] - (int)((90 * f文字拡大率[this.ct進行メイン.n現在の値 - 21]) - 90), new Rectangle(180, 0, 90, 90));
                    }
                    else if (this.ct進行メイン.n現在の値 < 70)
                    {
                        TJAPlayer3.Tx.End_Clear_Text.vcScaling.Y = 1.0f;
                        TJAPlayer3.Tx.End_Clear_Text.t2D描画(TJAPlayer3.app.Device, 750, y[i], new Rectangle(180, 0, 90, 90));
                    }
                }
                if (this.ct進行メイン.n現在の値 >= 23)
                {
                    if (this.ct進行メイン.n現在の値 <= 42)
                    {
                        TJAPlayer3.Tx.End_Clear_Text.vcScaling.Y = f文字拡大率[this.ct進行メイン.n現在の値 - 23];
                        TJAPlayer3.Tx.End_Clear_Text.Opacity = n透明度[this.ct進行メイン.n現在の値 - 23];
                        TJAPlayer3.Tx.End_Clear_Text.t2D描画(TJAPlayer3.app.Device, 819, y[i] - (int)((90 * f文字拡大率[this.ct進行メイン.n現在の値 - 23]) - 90), new Rectangle(270, 0, 90, 90));
                    }
                    else if (this.ct進行メイン.n現在の値 < 70)
                    {
                        TJAPlayer3.Tx.End_Clear_Text.vcScaling.Y = 1.0f;
                        TJAPlayer3.Tx.End_Clear_Text.t2D描画(TJAPlayer3.app.Device, 819, y[i], new Rectangle(270, 0, 90, 90));
                    }
                }
                if (this.ct進行メイン.n現在の値 >= 25)
                {
                    if (this.ct進行メイン.n現在の値 <= 44)
                    {
                        TJAPlayer3.Tx.End_Clear_Text.vcScaling.Y = f文字拡大率[this.ct進行メイン.n現在の値 - 25];
                        TJAPlayer3.Tx.End_Clear_Text.Opacity = n透明度[this.ct進行メイン.n現在の値 - 25];
                        TJAPlayer3.Tx.End_Clear_Text.t2D描画(TJAPlayer3.app.Device, 890, (y[i] + 2) - (int)((90 * f文字拡大率[this.ct進行メイン.n現在の値 - 25]) - 90), new Rectangle(360, 0, 90, 90));
                    }
                    else if (this.ct進行メイン.n現在の値 < 70)
                    {
                        TJAPlayer3.Tx.End_Clear_Text.vcScaling.Y = 1.0f;
                        TJAPlayer3.Tx.End_Clear_Text.t2D描画(TJAPlayer3.app.Device, 890, y[i] + 2, new Rectangle(360, 0, 90, 90));
                    }
                }
                if (this.ct進行メイン.n現在の値 >= 50 && this.ct進行メイン.n現在の値 < 90)
                {
                    if (this.ct進行メイン.n現在の値 < 70)
                    {
                        //TJAPlayer3.Tx.End_Clear_Text_Effect.Opacity = (this.ct進行メイン.n現在の値 - 50) * (255 / 20);
                        //TJAPlayer3.Tx.End_Clear_Text_Effect.t2D描画(TJAPlayer3.app.Device, 634, y[i] - 2);
                    }
                    else
                    {
                        //TJAPlayer3.Tx.End_Clear_Text_Effect.Opacity = 255 - ((this.ct進行メイン.n現在の値 - 70) * (255 / 20));
                        //TJAPlayer3.Tx.End_Clear_Text_Effect.t2D描画(TJAPlayer3.app.Device, 634, y[i] - 2);
                    }
                }

                #endregion
                const int leftfan = 356;
                const int rightfan = 956;
                #region[ 扇2 ]
                //レイヤー変更用に扇の個所を2箇所に分ける
                if (this.ct進行メイン.n現在の値 >= 79 && TJAPlayer3.Tx.End_Fan[3] != null)
                {
                    int x補正値, y補正値;
                    if ((this.ct進行メイン.n現在の値 / 2) % 2 == 0)
                    {
                        TJAPlayer3.Tx.End_Fan[3].vcScaling.Y = 1f;
                        x補正値 = 0;
                        y補正値 = 0;
                    }
                    else
                    {
                        TJAPlayer3.Tx.End_Fan[3].vcScaling.Y = 0.99f;
                        x補正値 = 1;
                        y補正値 = 1;
                    }
                    TJAPlayer3.Tx.End_Fan[3].fRotation = -20f * (float)Math.PI / 180f;
                    TJAPlayer3.Tx.End_Fan[3].t2D描画(TJAPlayer3.app.Device, leftfan - x補正値, y[i] - 15 + y補正値);
                    TJAPlayer3.Tx.End_Fan[3].fRotation = 20f * (float)Math.PI / 180f;
                    TJAPlayer3.Tx.End_Fan[3].t2D描画(TJAPlayer3.app.Device, rightfan + x補正値, y[i] - 15 + y補正値);
                }
                #endregion

                #region[ バチお ]
                if (this.ct進行メイン.n現在の値 <= 13)   //35
                {
                    if (TJAPlayer3.Tx.End_Clear_Chara != null)
                    {
                        TJAPlayer3.Tx.End_Clear_Chara.Opacity = (int)(this.ct進行メイン.n現在の値 * 19.7f);
                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 694, 178, new RectangleF(180, 0, 180, 180));
                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 727, 178, new RectangleF(180, 180, 180, 180));
                    }
                }
                else if (this.ct進行メイン.n現在の値 <= 48)
                {
                    if (TJAPlayer3.Tx.End_Clear_Chara != null)
                    {
                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - (float)Math.Sin((this.ct進行メイン.n現在の値 - 13) * 2.57142 * (Math.PI / 180)) * 218, y[i] - 122, new RectangleF(0, 0, 180, 180));
                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + (float)Math.Sin((this.ct進行メイン.n現在の値 - 13) * 2.57142 * (Math.PI / 180)) * 218, y[i] - 122, new RectangleF(0, 180, 180, 180));
                    }
                }
                else if (this.ct進行メイン.n現在の値 <= 52)
                {
                    if (TJAPlayer3.Tx.End_Clear_Chara != null)
                    {
                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - 218, y[i] - 122, new RectangleF(180, 0, 180, 180));
                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + 218, y[i] - 122, new RectangleF(180, 180, 180, 180));
                    }
                }
                else if (this.ct進行メイン.n現在の値 <= 55)
                {
                    if (TJAPlayer3.Tx.End_Clear_Chara != null)
                    {
                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - 218, 178, new RectangleF(360, 0, 180, 180));
                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + 218, 178, new RectangleF(360, 180, 180, 180));
                    }
                }
                else if (this.ct進行メイン.n現在の値 <= 58)
                {
                    if (TJAPlayer3.Tx.End_Clear_Chara != null)
                    {
                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 684 - 218, 178, new RectangleF(540, 0, 180, 180));
                        TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 736 + 218, 178, new RectangleF(540, 0, 180, 180));
                    }
                }

                else if (this.ct進行メイン.n現在の値 <= 88)
                {
                    int ysin = (int)(Math.Sin((this.ct進行メイン.n現在の値 - 68) / 20.0 * Math.PI) * 150.0);
                    if (this.ct進行メイン.n現在の値 <= 78)
                    {
                        if (TJAPlayer3.Tx.End_Clear_Chara != null)
                            TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 466 - ((this.ct進行メイン.n現在の値 - 68) * 8), y[i] - ysin - 30, new RectangleF(720, 0, 180, 180));
                        if (TJAPlayer3.Tx.End_Clear_Chara != null)
                            TJAPlayer3.Tx.End_Clear_Chara.t2D描画(TJAPlayer3.app.Device, 956 + ((this.ct進行メイン.n現在の値 - 68) * 8), y[i] - ysin - 30, new RectangleF(720, 180, 180, 180));
                    }
                    else
                    {
                        if (TJAPlayer3.Tx.End_DonderFullCombo_L != null)
                            TJAPlayer3.Tx.End_DonderFullCombo_L.t2D描画(TJAPlayer3.app.Device, 466 - ((this.ct進行メイン.n現在の値 - 68) * 8), y[i] - ysin - 30);
                        if (TJAPlayer3.Tx.End_DonderFullCombo_R != null)
                            TJAPlayer3.Tx.End_DonderFullCombo_R.t2D描画(TJAPlayer3.app.Device, 956 + ((this.ct進行メイン.n現在の値 - 68) * 8), y[i] - ysin - 30);
                    }
                }
                else
                {
                    if (this.ct進行メイン.n現在の値 <= 98)
                    {
                        float xratio = (float)Math.Abs(Math.Cos(((this.ct進行メイン.n現在の値 - 89) / 10.0) * Math.PI));
                        if (TJAPlayer3.Tx.End_DonderFullCombo_L != null)
                            TJAPlayer3.Tx.End_DonderFullCombo_L.vcScaling.Y = 0.8f + xratio * 0.2f;
                        if (TJAPlayer3.Tx.End_DonderFullCombo_R != null)
                            TJAPlayer3.Tx.End_DonderFullCombo_R.vcScaling.Y = 0.8f + xratio * 0.2f;
                    }
                    if (TJAPlayer3.Tx.End_DonderFullCombo_L != null)
                        TJAPlayer3.Tx.End_DonderFullCombo_L.t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.DownLeft, 306, y[i] + TJAPlayer3.Tx.End_Clear_L[4].szTextureSize.Height - 30);
                    if (TJAPlayer3.Tx.End_DonderFullCombo_R != null)
                        TJAPlayer3.Tx.End_DonderFullCombo_R.t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.DownLeft, 1116, y[i] + TJAPlayer3.Tx.End_Clear_L[4].szTextureSize.Height - 30);
                }
                #endregion
                #region[ 扇1 ]
                if (this.ct進行メイン.n現在の値 >= 70 && this.ct進行メイン.n現在の値 < 79 && TJAPlayer3.Tx.End_Fan != null)
                {
                    int num = 0;
                    if (this.ct進行メイン.n現在の値 < 73)
                    {
                        TJAPlayer3.Tx.End_Fan[0].Opacity = (this.ct進行メイン.n現在の値 - 70) * (255 / 3);
                        num = 0;
                    }
                    else if (this.ct進行メイン.n現在の値 < 76)
                    {
                        num = 1;
                    }
                    else if (this.ct進行メイン.n現在の値 < 79)
                    {
                        num = 2;
                    }
                    if (TJAPlayer3.Tx.End_Fan[num] != null)
                    {
                        TJAPlayer3.Tx.End_Fan[num].fRotation = -20f * (float)Math.PI / 180f;
                        TJAPlayer3.Tx.End_Fan[num].t2D描画(TJAPlayer3.app.Device, leftfan, y[i] - 15);
                        TJAPlayer3.Tx.End_Fan[num].fRotation = 20f * (float)Math.PI / 180f;
                        TJAPlayer3.Tx.End_Fan[num].t2D描画(TJAPlayer3.app.Device, rightfan, y[i] - 15);
                    }
                }
                #endregion
                #region[ ドンダフル文字 ]
                int ydiff = 0;
                TJAPlayer3.Tx.End_DonderFullCombo_Text.vcScaling.Y = 1f;
                TJAPlayer3.Tx.End_DonderFullCombo_Text_Effect.vcScaling.Y = 1f;
                if (this.ct進行メイン.n現在の値 >= 70 && this.ct進行メイン.n現在の値 < 90)
                {
                    double ratio = Math.Sin(((this.ct進行メイン.n現在の値 - 70) / 10.0) * Math.PI);
                    if (ratio > 0)
                    {
                        ydiff = (int)(ratio * 10.0);
                    }
                    else
                    {
                        TJAPlayer3.Tx.End_DonderFullCombo_Text.vcScaling.Y = 0.8f + (float)(ratio + 1.0) * 0.2f;
                        TJAPlayer3.Tx.End_DonderFullCombo_Text_Effect.vcScaling.Y = 0.8f + (float)(ratio + 1.0) * 0.2f;
                    }
                }
                if (this.ct進行メイン.n現在の値 >= 70)
                {
                    if (this.ct進行メイン.n現在の値 < 80)
                    {
                        TJAPlayer3.Tx.End_DonderFullCombo_Text.Opacity = (this.ct進行メイン.n現在の値 - 70) * (255 / 10);
                    }
                    else
                    {
                        TJAPlayer3.Tx.End_DonderFullCombo_Text.Opacity = 255;
                    }
                    TJAPlayer3.Tx.End_DonderFullCombo_Text.t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.Down, 810, y[i] - ydiff + TJAPlayer3.Tx.End_DonderFullCombo_Text.szTextureSize.Height);
                }
                if (this.ct進行メイン.n現在の値 >= 70 && this.ct進行メイン.n現在の値 < 90)
                {
                    if (this.ct進行メイン.n現在の値 < 80)
                    {
                        TJAPlayer3.Tx.End_DonderFullCombo_Text_Effect.Opacity = (this.ct進行メイン.n現在の値 - 70) * (255 / 10);
                    }
                    else
                    {
                        TJAPlayer3.Tx.End_DonderFullCombo_Text_Effect.Opacity = 255 - ((this.ct進行メイン.n現在の値 - 80) * (255 / 10));
                    }
                    TJAPlayer3.Tx.End_DonderFullCombo_Text_Effect.t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.Down, 810, y[i] - ydiff + TJAPlayer3.Tx.End_DonderFullCombo_Text_Effect.szTextureSize.Height);
                }
                #endregion




            }
            */
			#endregion

		}
		// ------------------------------------
		#endregion

		public override int On進行描画()
        {
            if (base.b初めての進行描画)
            {
                base.b初めての進行描画 = false;
            }
            if (this.ct進行メイン != null && (TJAPlayer3.stage演奏ドラム画面.eフェーズID == CStage.Eフェーズ.演奏_演奏終了演出 || TJAPlayer3.stage演奏ドラム画面.eフェーズID == CStage.Eフェーズ.演奏_STAGE_CLEAR_フェードアウト))
            {
                this.ct進行メイン.t進行();

                //CDTXMania.act文字コンソール.tPrint( 0, 0, C文字コンソール.Eフォント種別.灰, this.ct進行メイン.n現在の値.ToString() );
                //仮置き
                for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
                {
                    switch (this.Mode[i])
                    {
                        case EndMode.StageFailed:
                            //this.ct進行メイン.n現在の値 = 18;
                            if (this.soundFailed != null && !this.b再生済み)
                            {
                                this.soundFailed.t再生を開始する();
                                this.b再生済み = true;
                            }
                            this.showEndEffect_Failed(i);
                            break;
                        case EndMode.StageCleared:
                            //this.ct進行メイン.n現在の値 = 18;
                            if (this.soundClear != null && !this.b再生済み)
                            {
                                this.soundClear.t再生を開始する();
                                this.b再生済み = true;
                            }
                            this.showEndEffect_Clear(i);
                            break;
                        case EndMode.StageFullCombo:
                            //this.ct進行メイン.n現在の値 = 18;
                            if (this.soundFullCombo != null && !this.b再生済み)
                            {
                                this.soundFullCombo.t再生を開始する();
                                this.b再生済み = true;
                            }
                            this.showEndEffect_FullCombo(i);
                            break;
                        case EndMode.StageDondaFullCombo:
                            //this.ct進行メイン.n現在の値 = 18;
                            if (this.soundDondaFullCombo != null && !this.b再生済み)
                            {
                                this.soundDondaFullCombo.t再生を開始する();
                                this.b再生済み = true;
                            }
                            this.showEndEffect_DondaFullCombo(i);
                            break;
                        default:
                            break;
                    }

                }



                if (this.ct進行メイン.b終了値に達した)
                {
                    return 1;
                }
            }

            return 0;
        }

        #region[ private ]
        //-----------------
        bool b再生済み;
        private bool bリザルトボイス再生済み;
        CCounter ct進行メイン;

        CCounter ctEnd_ClearFailed;
        CCounter ctEnd_FullCombo;
        CCounter ctEnd_FullComboLoop;
        CCounter ctEnd_DondaFullCombo;
        CCounter ctEnd_DondaFullComboLoop;

        CCounter ct進行Loop;
        CSound soundClear;
        CSound soundFailed;
        CSound soundFullCombo;
        CSound soundDondaFullCombo;
        EndMode[] Mode;
        enum EndMode
        {
            StageFailed,
            StageCleared,
            StageFullCombo,
            StageDondaFullCombo
        }

        void StarDraw(int x, int y, int count, int starttime = 0, int endtime = 20)
        {
            if (count >= 0 && count <= endtime)
            {
                count += starttime;

                if (count <= 11)
                {
                    float scale = count * 0.09f;
                    DrawStar(x, y, scale, scale, 255);
                }
                else if (count <= 20)
                {
                    int opacity = (int)(255 - (255.0f / 9.0f) * (count - 11));
                    DrawStar(x, y, 1.0f, 1.0f, opacity);
                }
            }
        }

        void DrawStar(int x, int y, float scaleX, float scaleY, int opacity)
        {
            TJAPlayer3.Tx.End_Star.vc拡大縮小倍率.X = scaleX;
            TJAPlayer3.Tx.End_Star.vc拡大縮小倍率.Y = scaleY;
            TJAPlayer3.Tx.End_Star.Opacity = opacity;
            TJAPlayer3.Tx.End_Star.t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x, y);
        }


        //-----------------
        #endregion
    }
}