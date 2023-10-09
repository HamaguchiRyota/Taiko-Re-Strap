using FDK;
using System.Security.Cryptography.X509Certificates;

namespace TJAPlayer3
{
	internal class CAct演奏Drumsスコア : CAct演奏スコア共通
	{
		// CActivity 実装（共通クラスからの差分のみ）

		public unsafe override int On進行描画()
        {
            if (!base.b活性化してない)
            {
                if (base.b初めての進行描画)
                {
                    base.b初めての進行描画 = false;
                }
                //long num = FDK.CSound管理.rc演奏用タイマ.n現在時刻;

                if (!this.ctTimer.b停止中)
                {
                    this.ctTimer.t進行();
                    if (this.ctTimer.b終了値に達した)
                    {
                        this.ctTimer.t停止();
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    if (!this.ct点数アニメタイマ[i].b停止中)
                    {
                        this.ct点数アニメタイマ[i].t進行();
                        if (this.ct点数アニメタイマ[i].b終了値に達した)
                        {
                            this.ct点数アニメタイマ[i].t停止();
                        }
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    if (!this.ctボーナス加算タイマ[i].b停止中)
                    {
                        this.ctボーナス加算タイマ[i].t進行();
                        if (this.ctボーナス加算タイマ[i].b終了値に達した)
                        {
                            TJAPlayer3.stage演奏ドラム画面.actScore.BonusAdd(i);
                            this.ctボーナス加算タイマ[i].t停止();
                        }
                    }
                }

                base.t小文字表示(TJAPlayer3.Skin.Game_Score_X[0], TJAPlayer3.Skin.Game_Score_Y[0], string.Format("{0,7:######0}", this.n現在表示中のスコア[0].Taiko), 0, 256, 0);
                if (TJAPlayer3.stage演奏ドラム画面.bDoublePlay) base.t小文字表示(TJAPlayer3.Skin.Game_Score_X[1], TJAPlayer3.Skin.Game_Score_Y[1], string.Format("{0,7:######0}", this.n現在表示中のスコア[1].Taiko), 0, 256, 1);

                for (int i = 0; i < 256; i++)
                {
                    if (this.stScore[i].b使用中)
                    {
                        if (!this.stScore[i].ctTimer.b停止中)
                        {
                            this.stScore[i].ctTimer.t進行();
                            if (this.stScore[i].ctTimer.b終了値に達した)
                            {
                                if (this.stScore[i].b表示中 == true)
                                    this.n現在表示中のAddScore--;
                                this.stScore[i].ctTimer.t停止();
                                this.stScore[i].b使用中 = false;
                                TJAPlayer3.stage演奏ドラム画面.actDan.Update();
                            }

                            if (!stScore[i].bAddEnd)
                            {
                                this.n現在表示中のスコア[this.stScore[i].nPlayer].Taiko += (long)this.stScore[i].nAddScore;
                                stScore[i].bAddEnd = true;
                                if (ct点数アニメタイマ[stScore[i].nPlayer].b終了値に達してない)
                                {
                                    this.ct点数アニメタイマ[stScore[i].nPlayer] = new CCounter(0, 11, 13, TJAPlayer3.Timer);
                                    this.ct点数アニメタイマ[stScore[i].nPlayer].n現在の値 = 1;
                                }
                                else
                                {
                                    this.ct点数アニメタイマ[stScore[i].nPlayer] = new CCounter(0, 11, 13, TJAPlayer3.Timer);
                                }
                            }

                            int xAdd = 0;
                            int yAdd = 0;
                            int alpha = 0;
                            int timerValue = this.stScore[i].ctTimer.n現在の値;

                            if (timerValue < 10)
                            {
                                xAdd = 25;
                                alpha = 150;
                            }
                            else if (timerValue < 20)
                            {
                                xAdd = 10;
                                alpha = 200;
                            }
                            else if (timerValue < 30)
                            {
                                xAdd = -5;
                                alpha = 250;
                            }
                            else if (timerValue < 40)
                            {
                                xAdd = -9;
                                alpha = 256;
                            }
                            else if (timerValue < 50)
                            {
                                xAdd = -10;
                                alpha = 256;
                            }
                            else if (timerValue < 60)
                            {
                                xAdd = -9;
                                alpha = 256;
                            }
                            else if (timerValue < 70)
                            {
                                xAdd = -5;
                                alpha = 256;
                            }
                            else if (timerValue < 80)
                            {
                                xAdd = -3;
                                alpha = 256;
                            }
                            else
                            {
                                xAdd = 0;
                                alpha = 256;
                            }

                            if (timerValue > 120)
                            {
                                yAdd = timerValue > 210 ? 20 : timerValue > 180 ? 0 : timerValue > 160 ? -8 : timerValue > 150 ? -8 : timerValue > 140 ? -7 : timerValue > 130 ? -5 : -1;
                                alpha = timerValue > 210 ? 0 : timerValue > 200 ? 150 : timerValue > 190 ? 200 : timerValue > 180 ? 256 : timerValue > 170 ? 256 : timerValue > 160 ? 256 : 256;
                            }

                            if (this.n現在表示中のAddScore < 10 && this.stScore[i].bBonusScore == false)
                                base.t小文字表示(TJAPlayer3.Skin.Game_Score_Add_X[this.stScore[i].nPlayer] + xAdd, this.stScore[i].nPlayer == 0 ? TJAPlayer3.Skin.Game_Score_Add_Y[this.stScore[i].nPlayer] + yAdd : TJAPlayer3.Skin.Game_Score_Add_Y[this.stScore[i].nPlayer] - yAdd, string.Format("{0,7:######0}", this.stScore[i].nAddScore), this.stScore[i].nPlayer + 1, alpha, stScore[i].nPlayer);
                            if (this.n現在表示中のAddScore < 10 && this.stScore[i].bBonusScore == true)
                                base.t小文字表示(TJAPlayer3.Skin.Game_Score_AddBonus_X[this.stScore[i].nPlayer] + xAdd, TJAPlayer3.Skin.Game_Score_AddBonus_Y[this.stScore[i].nPlayer], string.Format("{0,7:######0}", this.stScore[i].nAddScore), this.stScore[i].nPlayer + 1, alpha, stScore[i].nPlayer);
                            else
                            {
                                this.n現在表示中のAddScore--;
                                this.stScore[i].b表示中 = false;
                            }
                        }
                    }
                }

                int[] HighScore = TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nハイスコア;
                int d = TJAPlayer3.stage選曲.n確定された曲の難易度[0];
                //long nb = this.n現在表示中のスコア[0].Taiko - HighScore[d];
                //TJAPlayer3.act文字コンソール.tPrint(20, 5, C文字コンソール.Eフォント種別.白, nb.ToString());
                /*
                if (HighScore[d] >= 1 && nb <= 5000 )
                {
                    TJAPlayer3.act文字コンソール.tPrint(10, 230, C文字コンソール.Eフォント種別.白, "ハイスコア間近".ToString());

                }
                */

                if (HighScore[d] >= 1 && this.n現在表示中のスコア[0].Taiko > HighScore[d])
                {
                    TJAPlayer3.Tx.Taiko_HG?.t2D描画(TJAPlayer3.app.Device, 2, 228);
                }

            }
            return 0;
        }
    }
}


