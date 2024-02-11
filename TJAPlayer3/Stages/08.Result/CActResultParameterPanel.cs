using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using FDK;

namespace TJAPlayer3
{
	internal class CActResultParameterPanel : CActivity
	{
		// コンストラクタ

		public CActResultParameterPanel()
		{
            #region [ ST小文字 ]

            ST文字位置[] st文字位置Array = new ST文字位置[11];
            ST文字位置 st文字位置 = new ST文字位置();
            st文字位置.ch = '0';
            st文字位置.pt = new Point(4, 0);
            st文字位置Array[0] = st文字位置;
            ST文字位置 st文字位置2 = new ST文字位置();
            st文字位置2.ch = '1';
            st文字位置2.pt = new Point(37, 0);
            st文字位置Array[1] = st文字位置2;
            ST文字位置 st文字位置3 = new ST文字位置();
            st文字位置3.ch = '2';
            st文字位置3.pt = new Point(68, 0);
            st文字位置Array[2] = st文字位置3;
            ST文字位置 st文字位置4 = new ST文字位置();
            st文字位置4.ch = '3';
            st文字位置4.pt = new Point(100, 0);
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
            st文字位置7.pt = new Point(197, 0);
            st文字位置Array[6] = st文字位置7;
            ST文字位置 st文字位置8 = new ST文字位置();
            st文字位置8.ch = '7';
            st文字位置8.pt = new Point(228, 0);
            st文字位置Array[7] = st文字位置8;
            ST文字位置 st文字位置9 = new ST文字位置();
            st文字位置9.ch = '8';
            st文字位置9.pt = new Point(260, 0);
            st文字位置Array[8] = st文字位置9;
            ST文字位置 st文字位置10 = new ST文字位置();
            st文字位置10.ch = '9';
            st文字位置10.pt = new Point(292, 0);
            st文字位置Array[9] = st文字位置10;
            ST文字位置 st文字位置11 = new ST文字位置();
            st文字位置11.ch = ' ';
            st文字位置11.pt = new Point(0, 0);
            st文字位置Array[10] = st文字位置11;
            st小文字位置 = st文字位置Array;

            #endregion

            #region [ ST大文字 ]

            ST文字位置[] st文字位置Array2 = new ST文字位置[11];
			ST文字位置 st文字位置12 = new ST文字位置();
			st文字位置12.ch = '0';
			st文字位置12.pt = new Point(0, 0);
			st文字位置Array2[0] = st文字位置12;
			ST文字位置 st文字位置13 = new ST文字位置();
			st文字位置13.ch = '1';
			st文字位置13.pt = new Point(32, 0);
			st文字位置Array2[1] = st文字位置13;
			ST文字位置 st文字位置14 = new ST文字位置();
			st文字位置14.ch = '2';
			st文字位置14.pt = new Point(64, 0);
			st文字位置Array2[2] = st文字位置14;
			ST文字位置 st文字位置15 = new ST文字位置();
			st文字位置15.ch = '3';
			st文字位置15.pt = new Point(96, 0);
			st文字位置Array2[3] = st文字位置15;
			ST文字位置 st文字位置16 = new ST文字位置();
			st文字位置16.ch = '4';
			st文字位置16.pt = new Point(128, 0);
			st文字位置Array2[4] = st文字位置16;
			ST文字位置 st文字位置17 = new ST文字位置();
			st文字位置17.ch = '5';
			st文字位置17.pt = new Point(160, 0);
			st文字位置Array2[5] = st文字位置17;
			ST文字位置 st文字位置18 = new ST文字位置();
			st文字位置18.ch = '6';
			st文字位置18.pt = new Point(192, 0);
			st文字位置Array2[6] = st文字位置18;
			ST文字位置 st文字位置19 = new ST文字位置();
			st文字位置19.ch = '7';
			st文字位置19.pt = new Point(224, 0);
			st文字位置Array2[7] = st文字位置19;
			ST文字位置 st文字位置20 = new ST文字位置();
			st文字位置20.ch = '8';
			st文字位置20.pt = new Point(256, 0);
			st文字位置Array2[8] = st文字位置20;
			ST文字位置 st文字位置21 = new ST文字位置();
			st文字位置21.ch = '9';
			st文字位置21.pt = new Point(288, 0);
			st文字位置Array2[9] = st文字位置21;
			ST文字位置 st文字位置22 = new ST文字位置();
			st文字位置22.ch = '%';
			st文字位置22.pt = new Point(0x37, 0);
			st文字位置Array2[10] = st文字位置22;
			st大文字位置 = st文字位置Array2;

            #endregion

            #region [ STScore文字 ]

            ST文字位置[] stScore文字位置Array = new ST文字位置[10];
			ST文字位置 stScore文字位置 = new ST文字位置();
			stScore文字位置.ch = '0';
			stScore文字位置.pt = new Point(0, 0);
			stScore文字位置Array[0] = stScore文字位置;
			ST文字位置 stScore文字位置2 = new ST文字位置();
			stScore文字位置2.ch = '1';
			stScore文字位置2.pt = new Point(51, 0);
			stScore文字位置Array[1] = stScore文字位置2;
			ST文字位置 stScore文字位置3 = new ST文字位置();
			stScore文字位置3.ch = '2';
			stScore文字位置3.pt = new Point(102, 0);
			stScore文字位置Array[2] = stScore文字位置3;
			ST文字位置 stScore文字位置4 = new ST文字位置();
			stScore文字位置4.ch = '3';
			stScore文字位置4.pt = new Point(153, 0);
			stScore文字位置Array[3] = stScore文字位置4;
			ST文字位置 stScore文字位置5 = new ST文字位置();
			stScore文字位置5.ch = '4';
			stScore文字位置5.pt = new Point(204, 0);
			stScore文字位置Array[4] = stScore文字位置5;
			ST文字位置 stScore文字位置6 = new ST文字位置();
			stScore文字位置6.ch = '5';
			stScore文字位置6.pt = new Point(255, 0);
			stScore文字位置Array[5] = stScore文字位置6;
			ST文字位置 stScore文字位置7 = new ST文字位置();
			stScore文字位置7.ch = '6';
			stScore文字位置7.pt = new Point(306, 0);
			stScore文字位置Array[6] = stScore文字位置7;
			ST文字位置 stScore文字位置8 = new ST文字位置();
			stScore文字位置8.ch = '7';
			stScore文字位置8.pt = new Point(357, 0);
			stScore文字位置Array[7] = stScore文字位置8;
			ST文字位置 stScore文字位置9 = new ST文字位置();
			stScore文字位置9.ch = '8';
			stScore文字位置9.pt = new Point(408, 0);
			stScore文字位置Array[8] = stScore文字位置9;
            ST文字位置 stScore文字位置10 = new ST文字位置();
            stScore文字位置10.ch = '9';
            stScore文字位置10.pt = new Point(459, 0);
            stScore文字位置Array[9] = stScore文字位置10;
            stScoreFont = stScore文字位置Array;

            #endregion

            ptFullCombo位置 = new Point[] { new Point(0x80, 0xed), new Point(0xdf, 0xed), new Point(0x141, 0xed) };
			b活性化してない = true;
		}


		public void tSkipResultAnimations()
		{
			ct全体進行.n現在の値 = (int)MountainAppearValue;

			for (int i = 0; i < 9; i++)
			{
				b音声再生[i] = true;
			}

			for (int i = 0; i < 2; i++)
			{
				if (!ctゲージアニメ.b進行中)
					ctゲージアニメ.t開始(0, gaugeValues[i] / 2, 59, TJAPlayer3.Timer);
				ctゲージアニメ.n現在の値 = (int)ctゲージアニメ.n終了値;
			}

			TJAPlayer3.Skin.soundGauge.t停止する();
		}

		// CActivity 実装

		public override void On活性化()
		{
			sdDTXで指定されたフルコンボ音 = null;
			Counter = new CCounter(0, TJAPlayer3.Skin.Game_PuchiChara[2] - 1, TJAPlayer3.Skin.Game_PuchiChara_Timer, TJAPlayer3.Timer);
			SineCounter = new CCounter(0, 360, TJAPlayer3.Skin.Game_PuchiChara_SineTimer, CSound管理.rc演奏用タイマ);
			base.On活性化();
		}
		public override void On非活性化()
		{
			if (ct表示用 != null)
			{
				ct表示用 = null;
			}

			for(int i = 0; i < b音声再生.Length; i++)
            {
				b音声再生[i] = false;
            }

			if (sdDTXで指定されたフルコンボ音 != null)
			{
				TJAPlayer3.Sound管理.tサウンドを破棄する(sdDTXで指定されたフルコンボ音);
				sdDTXで指定されたフルコンボ音 = null;
			}
			Counter = null;
			SineCounter = null;
			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if (!b活性化してない)
			{
				ct全体進行 = new CCounter(0, 50000, 1, TJAPlayer3.Timer);
				ctゲージアニメ = new CCounter();
				ct虹ゲージアニメ = new CCounter();
				ctSoul = new CCounter();
				ctEndAnime = new CCounter();
				ctBackgroundAnime = new CCounter(0, 1000, 1, TJAPlayer3.Timer);
				ctBackgroundAnime_Clear = new CCounter(0, 1000, 1, TJAPlayer3.Timer);
				ctMountain_ClearIn = new CCounter();
				ctFlash_Icon = new CCounter(0, 3000, 1, TJAPlayer3.Timer);
                ctChara_Normal = new CCounter(0, TJAPlayer3.Tx.Result_Chara_Normal.Length - 1, 1000 / 60, TJAPlayer3.Timer);//45
                ctChara_Clear = new CCounter(0, TJAPlayer3.Tx.Result_Chara_Clear.Length - 1, 1000 / 60, TJAPlayer3.Timer);//45

                ctGaugeFlash = new CCounter();

                Dan_Plate = TJAPlayer3.tテクスチャの生成(Path.GetDirectoryName(TJAPlayer3.DTX.strファイル名の絶対パス) + @"\Dan_Plate.png");

                gaugeValues = new int[2];
				for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
				{
					gaugeValues[i] = (int)TJAPlayer3.stage演奏ドラム画面.actGauge.db現在のゲージ値[i];
				}
				// Replace by max between 2 gauges if 2p
				GaugeFactor = Math.Max(gaugeValues[0], gaugeValues[1]) / 2;
				MountainAppearValue = 10275 + (66 * GaugeFactor);

				base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if (!b活性化してない)
			{
                TJAPlayer3.t安全にDisposeする(ref Dan_Plate);
                base.OnManagedリソースの解放();
			}
		}
		public override int On進行描画()
		{
			if (b活性化してない)
			{
				return 0;
			}
			if (b初めての進行描画)
			{
				ct表示用 = new CCounter(0, 0x3e7, 2, TJAPlayer3.Timer);
				b初めての進行描画 = false;
			}

			ct全体進行.t進行();
			ctゲージアニメ.t進行();
			ctEndAnime.t進行();
			ctBackgroundAnime.t進行Loop();
			ctMountain_ClearIn.t進行();
			ctFlash_Icon.t進行Loop();

            if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)
			{
                #region [ 通常時リザルト ]

                int AnimeCount = 3000 + (int)ctゲージアニメ.n終了値 * 59;
                int ScoreApparitionTimeStamp = AnimeCount + 420 * 4 + 840;
                int ClearType = TJAPlayer3.stage結果.nクリア - 1;
				int RankType = TJAPlayer3.stage結果.nスコアランク;
                bool is2P = (TJAPlayer3.ConfigIni.nPlayerCount == 2);

                #region [ 背景と音声 ]

                //クリア以上で背景転調
                if (ClearType >= -1 && TJAPlayer3.Tx.Result_Background[0] != null && TJAPlayer3.Tx.Result_Background[1] != null && TJAPlayer3.Tx.Result_Background[3] != null)
				{
					if (!is2P)
					{
                        TJAPlayer3.Tx.Result_Background[0].t2D描画(TJAPlayer3.app.Device, 0, 0);
                    }
					else
					{
                        TJAPlayer3.Tx.Result_Background[2].t2D描画(TJAPlayer3.app.Device, 0, 0);
                    }

                    //音声
                    if (ClearType >= 0 && ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 3500)
					{
                        TJAPlayer3.Tx.Result_Background[3].t2D描画(TJAPlayer3.app.Device, 0, 0);
                        if (!b音声再生[9])
                        {
                            TJAPlayer3.Skin.soundクリア音.t再生する();
                            b音声再生[9] = true;
                        }
                    }
					else if (ClearType <= -1 && ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 2800)//スコアランク取得+王冠未取得の場合
					{
                        if (!b音声再生[10])
                        {
                            TJAPlayer3.Skin.sound失敗音.t再生する();
                            b音声再生[10] = true;
                        }
                    }
                    else if (ClearType <= -1 && RankType <= 0 && ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 2000)//スコアランク未取得+王冠未取得の場合
                    {
                        if (!b音声再生[10])
                        {
                            TJAPlayer3.Skin.sound失敗音.t再生する();
                            b音声再生[10] = true;
                        }
                    }
                }

                #endregion

                #region [ パネル ]

                if (TJAPlayer3.Tx.Result_Header != null && TJAPlayer3.Tx.Result_Mountain[0] != null && TJAPlayer3.Tx.Result_Panel != null)
                {
					TJAPlayer3.Tx.Result_Header?.t2D描画(TJAPlayer3.app.Device, 0, 0);

					if (is2P)
					{
						TJAPlayer3.Tx.Result_Panel?[1].t2D描画(TJAPlayer3.app.Device, 0, 0);
						TJAPlayer3.Tx.Result_Gauge_Base?.t2D描画(TJAPlayer3.app.Device, 686, 141);
						TJAPlayer3.Tx.Result_Diff_Bar?.t2D描画(TJAPlayer3.app.Device, 655, 101, new RectangleF(0, TJAPlayer3.stage選曲.n確定された曲の難易度[1] * 54, 185, 54));
					}
					else 
					{
						if (ClearType >= -1)
						{
                            TJAPlayer3.Tx.Result_Mountain?[0].t2D描画(TJAPlayer3.app.Device, 0, 0);
                            if (ClearType >= 0 && ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 3500)
                            {
                                TJAPlayer3.Tx.Result_Mountain?[1].t2D描画(TJAPlayer3.app.Device, 0, 0);
                            }
                        }
					}
                    TJAPlayer3.Tx.Result_Panel?[0].t2D描画(TJAPlayer3.app.Device, 0, 0);

                }
				TJAPlayer3.Tx.Result_Diff_Bar?.t2D描画(TJAPlayer3.app.Device, 18, 101, new RectangleF(0, TJAPlayer3.stage選曲.n確定された曲の難易度[0] * 54, 185, 54));
                TJAPlayer3.Tx.Result_Gauge_Base?.t2D描画(TJAPlayer3.app.Device, 55, 141);

                #endregion

                #region [ キャラクター & ぷち ]

                if (ClearType >= -1)
                {
					if (!(ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 3500) && TJAPlayer3.Tx.Result_Chara_Normal != null)
					{
                        ctChara_Normal.t進行Loop();
                        TJAPlayer3.Tx.Result_Chara_Normal?[ctChara_Normal.n現在の値].t2D描画(TJAPlayer3.app.Device, -156, 348);//+-54,+-28
                        if (is2P)
                            TJAPlayer3.Tx.Result_Chara_Normal?[ctChara_Normal.n現在の値].t2D左右反転描画(TJAPlayer3.app.Device, 809, 348);
                    }
                    else if (ClearType >= 0 && ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 3500 && TJAPlayer3.Tx.Result_Chara_Clear != null)
                    {
						ctChara_Clear.t進行Loop();
						TJAPlayer3.Tx.Result_Chara_Clear?[ctChara_Clear.n現在の値].t2D描画(TJAPlayer3.app.Device, -156, 348);
						if (is2P)
                            TJAPlayer3.Tx.Result_Chara_Clear[ctChara_Clear.n現在の値].t2D左右反転描画(TJAPlayer3.app.Device, 809, 348);

                    }
					else if (ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 3000)
					{
						//スコアランクは獲得したが王冠は未獲得の場合
                    }
					else if (RankType <= 0 && ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 2000)
					{
						//スコアランク,王冠ともに未獲得の場合
					}

                }


                //TJAPlayer3.Tx.PuchiChara[0]?.t2D描画(TJAPlayer3.app.Device, 26, 485, new RectangleF(0, 0, 240, 240));

                #endregion


                #region [ 桜アニメーション ]

				/*
                if (gaugeValues[p] >= 80.0f && TJAPlayer3.ConfigIni.nPlayerCount <= 2)
                {
                    TJAPlayer3.Tx.Result_Flower.vc拡大縮小倍率.X = 0.6f * (ct全体進行.n現在の値 <= MountainAppearValue + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - MountainAppearValue) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f);
                    TJAPlayer3.Tx.Result_Flower.vc拡大縮小倍率.Y = 0.6f * (ct全体進行.n現在の値 <= MountainAppearValue + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - MountainAppearValue) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f);

                    int flower_width = TJAPlayer3.Tx.Result_Flower.szテクスチャサイズ.Width;
                    int flower_height = TJAPlayer3.Tx.Result_Flower.szテクスチャサイズ.Height / 2;

                    TJAPlayer3.Tx.Result_Flower.t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Flower_X[pos], TJAPlayer3.Skin.Result_Flower_Y[pos],
                        new Rectangle(0, 0, flower_width, flower_height));
                }
				*/

                #endregion

                #region [ 桜回転アニメーション ]

				/*
                if (gaugeValues[p] >= 80.0f && TJAPlayer3.ConfigIni.nPlayerCount <= 2)
                {
                    float FlowerTime = ctRotate_Flowers.n現在の値;

                    for (int i = 0; i < 5; i++)
                    {

                        if ((int)FlowerTime < ApparitionTimeStamps[i] || (int)FlowerTime > ApparitionTimeStamps[i] + 2 * ApparitionFade + ApparitionDuration)
                            TJAPlayer3.Tx.Result_Flower_Rotate[i].Opacity = 0;
                        else if ((int)FlowerTime <= ApparitionTimeStamps[i] + ApparitionDuration + ApparitionFade && (int)FlowerTime >= ApparitionTimeStamps[i] + ApparitionFade)
                            TJAPlayer3.Tx.Result_Flower_Rotate[i].Opacity = 255;
                        else
                        {
                            int CurrentGradiant = 0;
                            if ((int)FlowerTime >= ApparitionTimeStamps[i] + ApparitionFade + ApparitionDuration)
                                CurrentGradiant = ApparitionFade - ((int)FlowerTime - ApparitionTimeStamps[i] - ApparitionDuration - ApparitionFade);
                            else
                                CurrentGradiant = (int)FlowerTime - ApparitionTimeStamps[i];


                            TJAPlayer3.Tx.Result_Flower_Rotate[i].Opacity = (255 * CurrentGradiant) / ApparitionFade;
                        }

                        TJAPlayer3.Tx.Result_Flower_Rotate[i].vc拡大縮小倍率.X = 0.6f;
                        TJAPlayer3.Tx.Result_Flower_Rotate[i].vc拡大縮小倍率.Y = 0.6f;
                        TJAPlayer3.Tx.Result_Flower_Rotate[i].fZ軸中心回転 = (float)(FlowerTime - ApparitionTimeStamps[i]) / (FlowerRotationSpeeds[i] * 360f);

                        TJAPlayer3.Tx.Result_Flower_Rotate[i].t2D中心基準描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Flower_Rotate_X[pos][i], TJAPlayer3.Skin.Result_Flower_Rotate_Y[pos][i]);
                    }

                }
				*/

                #endregion

                #region [ パネルのキラキラ ]

				/*
                if (gaugeValues[p] >= 80.0f && TJAPlayer3.ConfigIni.nPlayerCount <= 2)
                {
                    int ShineTime = (int)ctShine_Plate.n現在の値;
                    int Quadrant500 = ShineTime % 500;

                    for (int i = 0; i < TJAPlayer3.Skin.Result_PlateShine_Count; i++)
                    {
                        if (i < 3 && ShineTime >= 500 || i >= 3 && ShineTime < 500)
                            TJAPlayer3.Tx.Result_Shine.Opacity = 0;
                        else if (Quadrant500 >= ShinePFade && Quadrant500 <= 500 - ShinePFade)
                            TJAPlayer3.Tx.Result_Shine.Opacity = 255;
                        else
                            TJAPlayer3.Tx.Result_Shine.Opacity = (255 * Math.Min(Quadrant500, 500 - Quadrant500)) / ShinePFade;

                        TJAPlayer3.Tx.Result_Shine.vc拡大縮小倍率.X = 0.15f;
                        TJAPlayer3.Tx.Result_Shine.vc拡大縮小倍率.Y = 0.15f;

                        TJAPlayer3.Tx.Result_Shine.t2D中心基準描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_PlateShine_X[pos][i], TJAPlayer3.Skin.Result_PlateShine_Y[pos][i]);
                    }

                }
				*/

                #endregion


                #region [ オプションアイコン・ModIcons ]
                for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
				{
					ModIcons.tDisplayModsMenu(185 + i * 980, 130, i);
				}

				#endregion

				if (ct全体進行.n現在の値 >= 2000)
				{
					#region [ ゲージ関連 ]

					if (!b音声再生[0])
					{
						TJAPlayer3.Skin.soundGauge.t再生する();
						b音声再生[0] = true;
					}

					if (!ctゲージアニメ.b進行中)
						ctゲージアニメ.t開始(0, (int)TJAPlayer3.stage結果.st演奏記録.Drums.fゲージ / 2, 59, TJAPlayer3.Timer);

					TJAPlayer3.Tx.Result_Gauge?.t2D描画(TJAPlayer3.app.Device, 58, 141, new RectangleF(0, 0, 9.74f * ctゲージアニメ.n現在の値, 36));

                    if (ctゲージアニメ.b終了値に達した)
					{
						if (ctゲージアニメ.n現在の値 != 50)
							TJAPlayer3.Skin.soundGauge.t停止する();
						else
						{
							if (!TJAPlayer3.Skin.soundGauge.b再生中)
								TJAPlayer3.Skin.soundGauge.t停止する();

							if (!ct虹ゲージアニメ.b進行中)
								ct虹ゲージアニメ.t開始(0, 40, 1000 / 60, TJAPlayer3.Timer);

							if (!ctSoul.b進行中)
								ctSoul.t開始(0, 8, 33, TJAPlayer3.Timer);

                            //if (!ctGaugeFlash.b進行中)
                            //    ctGaugeFlash.t開始(0, 20, 40, TJAPlayer3.Timer);

                            ct虹ゲージアニメ.t進行Loop();
							ctSoul.t進行Loop();
							//ctGaugeFlash.t進行Loop();
							/*
                            if (ctゲージアニメ.n現在の値 >= 80 && ctゲージアニメ.n現在の値 <= 100)
                            {
                                int Opacity = 0;
                                if (this.ctGaugeFlash.n現在の値 <= 365) Opacity = 0;
                                else if (this.ctGaugeFlash.n現在の値 <= 448) Opacity = (int)((this.ctGaugeFlash.n現在の値 - 365) / 83f * 255f);
                                else if (this.ctGaugeFlash.n現在の値 <= 531) Opacity = 255 - (int)((this.ctGaugeFlash.n現在の値 - 448) / 83f * 255f);
                                TJAPlayer3.Tx.Result_Gauge_Flash.Opacity = Opacity;
                                TJAPlayer3.Tx.Result_Gauge_Flash?.t2D描画(TJAPlayer3.app.Device, 58, 141);
                            }
							*/

                            TJAPlayer3.Tx.Result_Rainbow?[ct虹ゲージアニメ.n現在の値].t2D描画(TJAPlayer3.app.Device, 58, 145);
							TJAPlayer3.Tx.Result_Soul_Fire?.t2D中心基準描画(TJAPlayer3.app.Device, 568, 160, new Rectangle(150 * ctSoul.n現在の値, 0, 150, 131));
							TJAPlayer3.Tx.Result_Soul_Text?.t2D中心基準描画(TJAPlayer3.app.Device, 568, 159, new Rectangle(37 * 1, 0, 37, 37));

							if (ctSoul.n現在の値 % 2 == 0)
								TJAPlayer3.Tx.Result_Soul_Text?.t2D中心基準描画(TJAPlayer3.app.Device, 568, 159, new Rectangle(37 * 2, 0, 37, 37));
						}
					}

					#endregion

					#region [ 成績(スコアを除く)関連 ]

						int Interval = 420;
						float AddCount = 135;

						if (ct全体進行.n現在の値 >= AnimeCount)
						{
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 0, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.nPerfect数.ToString()));
							if (!b音声再生[1])
							{
								TJAPlayer3.Skin.soundPon.t再生する();
								b音声再生[1] = true;
							}
						}
						if (ct全体進行.n現在の値 >= AnimeCount + Interval)
						{
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + Interval + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + Interval + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 1, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.nGreat数.ToString()));
							if (!b音声再生[2])
							{
								TJAPlayer3.Skin.soundPon.t再生する();
								b音声再生[2] = true;
							}
						}
						if (ct全体進行.n現在の値 >= AnimeCount + Interval * 2)
						{
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + Interval * 2 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 2)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + Interval * 2 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 2)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 2, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.nMiss数.ToString()));
							if (!b音声再生[3])
							{
								TJAPlayer3.Skin.soundPon.t再生する();
								b音声再生[3] = true;
							}
						}
						if (ct全体進行.n現在の値 >= AnimeCount + Interval * 3)
						{
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + Interval * 3 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 3)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + Interval * 3 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 3)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 3, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.n連打数.ToString()));
							if (!b音声再生[4])
							{
								TJAPlayer3.Skin.soundPon.t再生する();
								b音声再生[4] = true;
							}
						}
						if (ct全体進行.n現在の値 >= AnimeCount + Interval * 4)
						{
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + Interval * 4 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 4)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + Interval * 4 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 4)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 4, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.n最大コンボ数.ToString()));
							if (!b音声再生[5])
							{
								TJAPlayer3.Skin.soundPon.t再生する();
								b音声再生[5] = true;
							}
						}

                    #endregion

                    #region [ スコア関連 ]

                    if (ct全体進行.n現在の値 >= AnimeCount + Interval * 4 + 840)
                    {
                        int AnimeCount1 = AnimeCount + Interval * 4 + 840;

                        TJAPlayer3.Tx.Result_Score_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount1 + 270 ? 1.0f + (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount1) / 1.5f * (Math.PI / 180)) * 0.65f :
                                                                             ct全体進行.n現在の値 <= AnimeCount1 + 360 ? 1.0f - (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount1 - 270) * (Math.PI / 180)) * 0.1f : 1.0f;
                        TJAPlayer3.Tx.Result_Score_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount1 + 270 ? 1.0f + (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount1) / 1.5f * (Math.PI / 180)) * 0.65f :
																			 ct全体進行.n現在の値 <= AnimeCount1 + 360 ? 1.0f - (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount1 - 270) * (Math.PI / 180)) * 0.1f : 1.0f;

                        tスコア文字表示(TJAPlayer3.Skin.nResultScoreP1X, TJAPlayer3.Skin.nResultScoreP1Y, string.Format("{0,7:######0}", TJAPlayer3.stage結果.st演奏記録.Drums.nスコア));

                        if (!b音声再生[6])
                        {
                            TJAPlayer3.Skin.soundScoreDon.t再生する();
                            b音声再生[6] = true;
                        }
                    }

                    #endregion

                    #region [ 山アニメーションカウンターのセットアップ ]
                    /*
					if (!this.ctMountain_ClearIn.b進行中)
						this.ctMountain_ClearIn.t開始(0, 515, 3, TJAPlayer3.Timer);

					if (gaugeValues[p] >= 80.0f)
					{
						if (!CResultCharacter.tIsCounterProcessing(p, CResultCharacter.ECharacterResult.CLEAR))
							CResultCharacter.tMenuResetTimer(p, CResultCharacter.ECharacterResult.CLEAR);
					}
					else
					{
						if (!CResultCharacter.tIsCounterProcessing(p, CResultCharacter.ECharacterResult.FAILED_IN))
							CResultCharacter.tMenuResetTimer(p, CResultCharacter.ECharacterResult.FAILED_IN);
						else if (CResultCharacter.tIsCounterEnded(p, CResultCharacter.ECharacterResult.FAILED_IN)
							&& !CResultCharacter.tIsCounterProcessing(p, CResultCharacter.ECharacterResult.FAILED))
							CResultCharacter.tMenuResetTimer(p, CResultCharacter.ECharacterResult.FAILED);
					}
					*/
                    #endregion

                }

				if (ctゲージアニメ.n現在の値 != 50)
				{
					//魂の光
                    TJAPlayer3.Tx.Result_Soul_Text?.t2D中心基準描画(TJAPlayer3.app.Device, 568, 159, new Rectangle(37 * (ctゲージアニメ.n現在の値 <= 30 ? 0 : 1), 0, 37, 37));
                }

                if (ctゲージアニメ.n現在の値 != 80)
				{
					//ゲージのクリアテキスト
					TJAPlayer3.Tx.Result_Gauge?.t2D描画(TJAPlayer3.app.Device, 441, 142, new RectangleF(ctゲージアニメ.n現在の値 < 40 ? 0 : 42, 35, 42, 20));
				}

				#region [ スコアランク ]

				if (ct全体進行.n現在の値 <= ScoreApparitionTimeStamp + 1180)
				{
					TJAPlayer3.Tx.Result_ScoreRankEffect.Opacity = (int)((ct全体進行.n現在の値 - (ScoreApparitionTimeStamp + 1000)) / 180.0f * 255.0f);
					TJAPlayer3.Tx.Result_ScoreRankEffect.vc拡大縮小倍率.X = 1.0f + (float)Math.Sin((float)(ct全体進行.n現在の値 - (ScoreApparitionTimeStamp + 910)) / 1.5f * (Math.PI / 180)) * 1.4f;
					TJAPlayer3.Tx.Result_ScoreRankEffect.vc拡大縮小倍率.Y = 1.0f + (float)Math.Sin((float)(ct全体進行.n現在の値 - (ScoreApparitionTimeStamp + 910)) / 1.5f * (Math.PI / 180)) * 1.4f;
				}
				else if (ct全体進行.n現在の値 <= ScoreApparitionTimeStamp + 1270)
				{
					TJAPlayer3.Tx.Result_ScoreRankEffect.vc拡大縮小倍率.X = 0.5f + (float)Math.Sin((float)(ct全体進行.n現在の値 - (ScoreApparitionTimeStamp + 1180)) * (Math.PI / 180)) * 0.5f;
					TJAPlayer3.Tx.Result_ScoreRankEffect.vc拡大縮小倍率.Y = 0.5f + (float)Math.Sin((float)(ct全体進行.n現在の値 - (ScoreApparitionTimeStamp + 1180)) * (Math.PI / 180)) * 0.5f;
				}
				else
				{
					TJAPlayer3.Tx.Result_ScoreRankEffect.Opacity = 255;
					TJAPlayer3.Tx.Result_ScoreRankEffect.vc拡大縮小倍率.X = 0.95f;
					TJAPlayer3.Tx.Result_ScoreRankEffect.vc拡大縮小倍率.Y = 0.95f;
				}

				if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan && TJAPlayer3.stage結果.nスコアランク > 0)
				{
					int CurrentFlash = 0;
					int[] FlashTimes = { 1500, 1540, 1580, 1620, 0, 0, 0, 0 };

					if (ctFlash_Icon.n現在の値 >= FlashTimes[0] && ctFlash_Icon.n現在の値 <= FlashTimes[1] || ctFlash_Icon.n現在の値 >= FlashTimes[4] && ctFlash_Icon.n現在の値 <= FlashTimes[5])
						CurrentFlash = 1;
					else if (ctFlash_Icon.n現在の値 >= FlashTimes[1] && ctFlash_Icon.n現在の値 <= FlashTimes[2] || ctFlash_Icon.n現在の値 >= FlashTimes[5] && ctFlash_Icon.n現在の値 <= FlashTimes[6])
						CurrentFlash = 2;
					else if (ctFlash_Icon.n現在の値 >= FlashTimes[2] && ctFlash_Icon.n現在の値 <= FlashTimes[3] || ctFlash_Icon.n現在の値 >= FlashTimes[6] && ctFlash_Icon.n現在の値 <= FlashTimes[7])
						CurrentFlash = 3;


					TJAPlayer3.Tx.Result_ScoreRankEffect?.t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, 135, 340, new Rectangle((TJAPlayer3.stage結果.nスコアランク - 1) * 229, CurrentFlash * 194, 229, 194));

					if (!b音声再生[7] && ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 1180)
					{
						TJAPlayer3.Skin.soundRankIn.t再生する();
						b音声再生[7] = true;
					}
				}

				#endregion

				#region [ 王冠 ]
				if (ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 2500)
				{
					

					if (ct全体進行.n現在の値 <= ScoreApparitionTimeStamp + 2680)
					{
						TJAPlayer3.Tx.Result_CrownEffect.Opacity = (int)((ct全体進行.n現在の値 - (ScoreApparitionTimeStamp + 2500)) / 180.0f * 255.0f);
						TJAPlayer3.Tx.Result_CrownEffect.vc拡大縮小倍率.X = 1.0f + (float)Math.Sin((float)(ct全体進行.n現在の値 - (ScoreApparitionTimeStamp + 2410)) / 1.5f * (Math.PI / 180)) * 1.4f;
						TJAPlayer3.Tx.Result_CrownEffect.vc拡大縮小倍率.Y = 1.0f + (float)Math.Sin((float)(ct全体進行.n現在の値 - (ScoreApparitionTimeStamp + 2410)) / 1.5f * (Math.PI / 180)) * 1.4f;
					}
					else if (ct全体進行.n現在の値 <= ScoreApparitionTimeStamp + 2770)
					{
						TJAPlayer3.Tx.Result_CrownEffect.vc拡大縮小倍率.X = 0.5f + (float)Math.Sin((float)(ct全体進行.n現在の値 - (ScoreApparitionTimeStamp + 2680)) * (Math.PI / 180)) * 0.5f;
						TJAPlayer3.Tx.Result_CrownEffect.vc拡大縮小倍率.Y = 0.5f + (float)Math.Sin((float)(ct全体進行.n現在の値 - (ScoreApparitionTimeStamp + 2680)) * (Math.PI / 180)) * 0.5f;
					}
					else
					{
						TJAPlayer3.Tx.Result_CrownEffect.Opacity = 255;
						TJAPlayer3.Tx.Result_CrownEffect.vc拡大縮小倍率.X = 1.1f;
						TJAPlayer3.Tx.Result_CrownEffect.vc拡大縮小倍率.Y = 1.1f;
					}

					if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)(Difficulty.Dan) && ClearType >= 0)
					{
						int CurrentFlash = 0;
						int[] FlashTimes = { 0, 0, 0, 0, 2000, 2040, 2080, 2120 };

						if (ctFlash_Icon.n現在の値 >= FlashTimes[0] && ctFlash_Icon.n現在の値 <= FlashTimes[1] || ctFlash_Icon.n現在の値 >= FlashTimes[4] && ctFlash_Icon.n現在の値 <= FlashTimes[5])
							CurrentFlash = 1;
						else if (ctFlash_Icon.n現在の値 >= FlashTimes[1] && ctFlash_Icon.n現在の値 <= FlashTimes[2] || ctFlash_Icon.n現在の値 >= FlashTimes[5] && ctFlash_Icon.n現在の値 <= FlashTimes[6])
							CurrentFlash = 2;
						else if (ctFlash_Icon.n現在の値 >= FlashTimes[2] && ctFlash_Icon.n現在の値 <= FlashTimes[3] || ctFlash_Icon.n現在の値 >= FlashTimes[6] && ctFlash_Icon.n現在の値 <= FlashTimes[7])
							CurrentFlash = 3;

						TJAPlayer3.Tx.Result_CrownEffect?.t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, 262, 339, new Rectangle(ClearType * 113, CurrentFlash * 112, 113, 112));

						if (!b音声再生[8] && ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 2680)
						{
							TJAPlayer3.Skin.soundCrownIn.t再生する();
							b音声再生[8] = true;
						}
					}


				}
				#endregion

				#endregion

			}
			else
			{
                #region [ 段位時リザルト ]
                TJAPlayer3.Tx.Result_Background_Dan?.t2D描画(TJAPlayer3.app.Device, 0, 0);
                Dan_Plate?.t2D描画(TJAPlayer3.app.Device, 50, 50);
				switch (TJAPlayer3.stage演奏ドラム画面.actDan.GetExamStatus(TJAPlayer3.stage結果.st演奏記録.Drums.Dan_C))
				{
					case Exam.Status.Failure:
						TJAPlayer3.Tx.Result_Dan?.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Dan_XY[0], TJAPlayer3.Skin.Result_Dan_XY[1], new Rectangle(0, 0, TJAPlayer3.Skin.Result_Dan[0], TJAPlayer3.Skin.Result_Dan[1]));
						break;
					case Exam.Status.Success:
						TJAPlayer3.Tx.Result_Dan?.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Dan_XY[0], TJAPlayer3.Skin.Result_Dan_XY[1], new Rectangle(TJAPlayer3.Skin.Result_Dan[0], 0, TJAPlayer3.Skin.Result_Dan[0], TJAPlayer3.Skin.Result_Dan[1]));
						break;
					case Exam.Status.Better_Success:
						TJAPlayer3.Tx.Result_Dan?.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Dan_XY[0], TJAPlayer3.Skin.Result_Dan_XY[1], new Rectangle(TJAPlayer3.Skin.Result_Dan[0] * 2, 0, TJAPlayer3.Skin.Result_Dan[0], TJAPlayer3.Skin.Result_Dan[1]));
						break;
					default:
						break;
				}

				#endregion
			}

			if (!ct表示用.b終了値に達した)
			{
				return 0;
			}
			return 1;
		}

		// その他

		#region [ private ]
		//-----------------
		[StructLayout(LayoutKind.Sequential)]
		private struct ST文字位置
		{
			public char ch;
			public Point pt;
		}
		private CCounter Counter;
		private CCounter SineCounter;

		public CCounter ct全体進行;
		//private CCounter ct全体進行;
		public CCounter ctゲージアニメ;
		private CCounter ct虹ゲージアニメ;
		private CCounter ctSoul;
		private CCounter ctGaugeFlash;
		public CAct演奏Drumsスコア CActScore;

        public CCounter ctEndAnime;
		public CCounter ctMountain_ClearIn;
		public CCounter ctBackgroundAnime;
		public CCounter ctBackgroundAnime_Clear;
		private CCounter ctFlash_Icon;
		private CCounter ctChara_Normal;
		private CCounter ctChara_Clear;

		public bool[] b音声再生 = { false, false, false, false, false, false, false, false, false, false, false };
		
		private CCounter ct表示用;
		private readonly Point[] ptFullCombo位置;
		private CSound sdDTXで指定されたフルコンボ音;
		private readonly ST文字位置[] st小文字位置;
		private readonly ST文字位置[] st大文字位置;
		private readonly ST文字位置[] stScoreFont;

		private CTexture Dan_Plate;

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

					if (st小文字位置[i].ch == ch)
					{
						Rectangle rectangle = new Rectangle(st小文字位置[i].pt.X, st小文字位置[i].pt.Y, 23, 38);
						TJAPlayer3.Tx.Result_Number?.t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 16, y + 19, rectangle);
						break;
					}
				}
				x += 22;
			}
		}

		protected void tスコア文字表示(int x, int y, string str)
		{
			foreach (char ch in str)
			{
				for (int i = 0; i < stScoreFont.Length; i++)
				{
					if (stScoreFont[i].ch == ch)
					{
						Rectangle rectangle = new Rectangle(stScoreFont[i].pt.X, 0, 51, 60);
						TJAPlayer3.Tx.Result_Score_Number?.t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x - (str.Length * 33) + 25, y + 30, rectangle);
						break;
					}
				}
				x += 33;
			}
		}

		public int[] gaugeValues;
		public int[] ApparitionTimeStamps = { 10, 30, 50, 100, 190 };

		public float MountainAppearValue;
		private int GaugeFactor;
		//-----------------
		#endregion
	}
}
