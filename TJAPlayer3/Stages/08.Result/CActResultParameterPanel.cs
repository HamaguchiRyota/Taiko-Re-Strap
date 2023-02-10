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
			ST文字位置[] st文字位置Array = new ST文字位置[11];
            ST文字位置 st文字位置 = new ST文字位置
            {
                ch = '0',
                pt = new Point(0, 0)
            };
            st文字位置Array[0] = st文字位置;
            ST文字位置 st文字位置2 = new ST文字位置
            {
                ch = '1',
                pt = new Point(32, 0)
            };
            st文字位置Array[1] = st文字位置2;
            ST文字位置 st文字位置3 = new ST文字位置
            {
                ch = '2',
                pt = new Point(64, 0)
            };
            st文字位置Array[2] = st文字位置3;
            ST文字位置 st文字位置4 = new ST文字位置
            {
                ch = '3',
                pt = new Point(96, 0)
            };
            st文字位置Array[3] = st文字位置4;
            ST文字位置 st文字位置5 = new ST文字位置
            {
                ch = '4',
                pt = new Point(128, 0)
            };
            st文字位置Array[4] = st文字位置5;
            ST文字位置 st文字位置6 = new ST文字位置
            {
                ch = '5',
                pt = new Point(160, 0)
            };
            st文字位置Array[5] = st文字位置6;
            ST文字位置 st文字位置7 = new ST文字位置
            {
                ch = '6',
                pt = new Point(192, 0)
            };
            st文字位置Array[6] = st文字位置7;
            ST文字位置 st文字位置8 = new ST文字位置
            {
                ch = '7',
                pt = new Point(224, 0)
            };
            st文字位置Array[7] = st文字位置8;
            ST文字位置 st文字位置9 = new ST文字位置
            {
                ch = '8',
                pt = new Point(256, 0)
            };
            st文字位置Array[8] = st文字位置9;
            ST文字位置 st文字位置10 = new ST文字位置
            {
                ch = '9',
                pt = new Point(288, 0)
            };
            st文字位置Array[9] = st文字位置10;
            ST文字位置 st文字位置11 = new ST文字位置
            {
                ch = ' ',
                pt = new Point(0, 0)
            };
            st文字位置Array[10] = st文字位置11;
			this.st小文字位置 = st文字位置Array;

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
			this.st大文字位置 = st文字位置Array2;

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
            ST文字位置 stScore文字位置10 = new ST文字位置
            {
                ch = '9',
                pt = new Point(459, 0)
            };
            stScore文字位置Array[9] = stScore文字位置10;
			this.stScoreFont = stScore文字位置Array;

			this.ptFullCombo位置 = new Point[] { new Point(0x80, 0xed), new Point(0xdf, 0xed), new Point(0x141, 0xed) };
			base.b活性化してない = true;
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
			this.sdDTXで指定されたフルコンボ音 = null;
			Counter = new CCounter(0, TJAPlayer3.Skin.Game_PuchiChara[2] - 1, TJAPlayer3.Skin.Game_PuchiChara_Timer, TJAPlayer3.Timer);
			SineCounter = new CCounter(0, 360, TJAPlayer3.Skin.Game_PuchiChara_SineTimer, CSound管理.rc演奏用タイマ);
			base.On活性化();
		}
		public override void On非活性化()
		{
			if (this.ct表示用 != null)
			{
				this.ct表示用 = null;
			}

			for(int i = 0; i < this.b音声再生.Length; i++)
            {
				b音声再生[i] = false;
            }

			if (this.sdDTXで指定されたフルコンボ音 != null)
			{
				TJAPlayer3.Sound管理.tサウンドを破棄する(this.sdDTXで指定されたフルコンボ音);
				this.sdDTXで指定されたフルコンボ音 = null;
			}
			Counter = null;
			SineCounter = null;
			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if (!base.b活性化してない)
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
				ctDonchan_Normal = new CCounter(0, TJAPlayer3.Tx.Result_Donchan_Normal.Length - 1, 1000 / 60, TJAPlayer3.Timer);//45


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
			if (!base.b活性化してない)
			{
				Dan_Plate?.Dispose();
				base.OnManagedリソースの解放();
			}
		}
		public override int On進行描画()
		{
			if (base.b活性化してない)
			{
				return 0;
			}
			if (base.b初めての進行描画)
			{
				this.ct表示用 = new CCounter(0, 0x3e7, 2, TJAPlayer3.Timer);
				base.b初めての進行描画 = false;
			}

			ct全体進行.t進行();
			ctゲージアニメ.t進行();
			ctEndAnime.t進行();
			ctBackgroundAnime.t進行Loop();
			ctMountain_ClearIn.t進行();
			ctFlash_Icon.t進行Loop();
			ctDonchan_Normal.t進行Loop();　

			if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)
			{
				#region [ 通常時リザルト ]

				int AnimeCount = 3000 + (int)ctゲージアニメ.n終了値 * 59;
				int ScoreApparitionTimeStamp = AnimeCount + 420 * 4 + 840;

				if (ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 3500)
				{
					TJAPlayer3.Tx.Result_Background?[1].t2D描画(TJAPlayer3.app.Device, 0, 0);

                }

                if (TJAPlayer3.Tx.Result_Header != null && TJAPlayer3.Tx.Result_Mountain[0] != null && TJAPlayer3.Tx.Result_Panel != null)
                {
					TJAPlayer3.Tx.Result_Header.t2D描画(TJAPlayer3.app.Device, 0, 0);
					TJAPlayer3.Tx.Result_Mountain[0].t2D描画(TJAPlayer3.app.Device, 0, 0);
					TJAPlayer3.Tx.Result_Panel.t2D描画(TJAPlayer3.app.Device, 0, 0);
				}
				//bool is1P = (TJAPlayer3.ConfigIni.nPlayerCount == 1);
				//bool is2PSide = TJAPlayer3.P1IsBlue();
				TJAPlayer3.Tx.Result_Diff_Bar.t2D描画(TJAPlayer3.app.Device, 18, 101, new RectangleF(0, TJAPlayer3.stage選曲.n確定された曲の難易度[0] * 54, 185, 54));
				TJAPlayer3.Tx.Result_Gauge_Base.t2D描画(TJAPlayer3.app.Device, 55, 141);

				#region [ キャラクター & ぷち ]

				TJAPlayer3.Tx.Result_Donchan_Normal?[ctDonchan_Normal.n現在の値].t2D描画(TJAPlayer3.app.Device, -156, 348);//+-54,+-28
				TJAPlayer3.Tx.PuchiChara[0]?.t2D描画(TJAPlayer3.app.Device, 20, 485, new RectangleF(0, 0, 240, 240));
				TJAPlayer3.Tx.PuchiChara[0].vc拡大縮小倍率.X = 0.60f;
                TJAPlayer3.Tx.PuchiChara[0].vc拡大縮小倍率.Y = 0.60f;

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

					TJAPlayer3.Tx.Result_Gauge.t2D描画(TJAPlayer3.app.Device, 58, 141, new RectangleF(0, 0, 9.74f * ctゲージアニメ.n現在の値, 36));

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

							ct虹ゲージアニメ.t進行Loop();
							ctSoul.t進行Loop();

							TJAPlayer3.Tx.Result_Rainbow[ct虹ゲージアニメ.n現在の値].t2D描画(TJAPlayer3.app.Device, 58, 145);

							TJAPlayer3.Tx.Result_Soul_Fire.t2D中心基準描画(TJAPlayer3.app.Device, 568, 160, new Rectangle(150 * ctSoul.n現在の値, 0, 150, 131));

							TJAPlayer3.Tx.Result_Soul_Text.t2D中心基準描画(TJAPlayer3.app.Device, 568, 159, new Rectangle(37 * 1, 0, 37, 37));

							if (ctSoul.n現在の値 % 2 == 0)
								TJAPlayer3.Tx.Result_Soul_Text.t2D中心基準描画(TJAPlayer3.app.Device, 568, 159, new Rectangle(37 * 2, 0, 37, 37));
						}
					}

						#endregion
				}

				if (ct全体進行.n現在の値 >= 2000)
				{
					#region [ 成績(スコアを除く)関連 ]

						int Interval = 420;

						float AddCount = 135;

						if (ct全体進行.n現在の値 >= AnimeCount)
						{
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - AnimeCount) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							this.t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 0, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.nPerfect数.ToString()));
							if (!this.b音声再生[1])
							{
								TJAPlayer3.Skin.soundPon.t再生する();
								this.b音声再生[1] = true;
							}
						}
						if (ct全体進行.n現在の値 >= AnimeCount + Interval)
						{
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + Interval + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + Interval + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							this.t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 1, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.nGreat数.ToString()));
							if (!this.b音声再生[2])
							{
								TJAPlayer3.Skin.soundPon.t再生する();
								this.b音声再生[2] = true;
							}
						}
						if (ct全体進行.n現在の値 >= AnimeCount + Interval * 2)
						{
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + Interval * 2 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 2)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + Interval * 2 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 2)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							this.t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 2, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.nMiss数.ToString()));
							if (!this.b音声再生[3])
							{
								TJAPlayer3.Skin.soundPon.t再生する();
								this.b音声再生[3] = true;
							}
						}
						if (ct全体進行.n現在の値 >= AnimeCount + Interval * 3)
						{
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + Interval * 3 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 3)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + Interval * 3 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 3)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							this.t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 3, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.n連打数.ToString()));
							if (!this.b音声再生[4])
							{
								TJAPlayer3.Skin.soundPon.t再生する();
								this.b音声再生[4] = true;
							}
						}
						if (ct全体進行.n現在の値 >= AnimeCount + Interval * 4)
						{
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.X = ct全体進行.n現在の値 <= AnimeCount + Interval * 4 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 4)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							TJAPlayer3.Tx.Result_Number.vc拡大縮小倍率.Y = ct全体進行.n現在の値 <= AnimeCount + Interval * 4 + AddCount ? 1.3f - (float)Math.Sin((ct全体進行.n現在の値 - (AnimeCount + Interval * 4)) / (AddCount / 90) * (Math.PI / 180)) * 0.3f : 1.0f;
							this.t小文字表示(TJAPlayer3.Skin.nResultNumberP1X, TJAPlayer3.Skin.nResultNumberY + TJAPlayer3.Skin.nResultNumberYPadding * 4, string.Format("{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.n最大コンボ数.ToString()));
							if (!this.b音声再生[5])
							{
								TJAPlayer3.Skin.soundPon.t再生する();
								this.b音声再生[5] = true;
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

							this.tスコア文字表示(TJAPlayer3.Skin.nResultScoreP1X, TJAPlayer3.Skin.nResultScoreP1Y, string.Format("{0,7:######0}", TJAPlayer3.stage結果.st演奏記録.Drums.nスコア));

							if (!b音声再生[6])
							{
								TJAPlayer3.Skin.soundScoreDon.t再生する();
								b音声再生[6] = true;
							}
						}

						#endregion
				}

				if (ctゲージアニメ.n現在の値 != 50)
				{
					TJAPlayer3.Tx.Result_Gauge.t2D描画(TJAPlayer3.app.Device, 441, 142, new RectangleF(ctゲージアニメ.n現在の値 < 40 ? 0 : 42, 35, 42, 20));

					TJAPlayer3.Tx.Result_Soul_Text.t2D中心基準描画(TJAPlayer3.app.Device, 568, 159, new Rectangle(37 * (ctゲージアニメ.n現在の値 <= 30 ? 0 : 1), 0, 37, 37));
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


					TJAPlayer3.Tx.Result_ScoreRankEffect.t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, 135, 340, new Rectangle((TJAPlayer3.stage結果.nスコアランク - 1) * 229, CurrentFlash * 194, 229, 194));

					if (!b音声再生[7] && ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 1180)
					{
						TJAPlayer3.Skin.soundRankIn.t再生する();
						b音声再生[7] = true;
					}
				}

				#endregion

				if (ct全体進行.n現在の値 >= 2000)
				{
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

				if (ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 2500)
				{
					#region [ 王冠 ]

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

					int ClearType = TJAPlayer3.stage結果.nクリア - 1;

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

						TJAPlayer3.Tx.Result_CrownEffect.t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, 262, 339, new Rectangle(ClearType * 113, CurrentFlash * 112, 113, 112));

						if (!b音声再生[8] && ct全体進行.n現在の値 >= ScoreApparitionTimeStamp + 2680)
						{
							TJAPlayer3.Skin.soundCrownIn.t再生する();
							b音声再生[8] = true;
						}
					}

					#endregion
				}


				#endregion

			}
			else
			{
				#region [ 段位時リザルト ]

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

				Dan_Plate?.t2D中心基準描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Dan_Plate_XY[0], TJAPlayer3.Skin.Result_Dan_Plate_XY[1]);

				#endregion
			}

			if (!this.ct表示用.b終了値に達した)
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
		private CCounter ctゲージアニメ;
		private CCounter ct虹ゲージアニメ;
		private CCounter ctSoul;
		public CCounter ctEndAnime;
		public CCounter ctMountain_ClearIn;
		public CCounter ctBackgroundAnime;
		public CCounter ctBackgroundAnime_Clear;
		private CCounter ctFlash_Icon;
		private CCounter ctDonchan_Normal;


		public bool[] b音声再生 = { false, false, false, false, false, false, false, false, false };
		
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

					if (this.st小文字位置[i].ch == ch)
					{
						Rectangle rectangle = new Rectangle(this.st小文字位置[i].pt.X, this.st小文字位置[i].pt.Y, 32, 38);
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
				for (int i = 0; i < this.stScoreFont.Length; i++)
				{
					if (this.stScoreFont[i].ch == ch)
					{
						Rectangle rectangle = new Rectangle(this.stScoreFont[i].pt.X, 0, 51, 60);
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
