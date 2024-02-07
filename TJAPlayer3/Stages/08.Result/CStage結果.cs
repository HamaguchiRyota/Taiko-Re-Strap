using System;
using System.Diagnostics;
using FDK;
using System.Drawing;

namespace TJAPlayer3
{
	internal class CStage結果 : CStage
	{
		// プロパティ

		public STDGBVALUE<bool> b新記録スキル;
		public STDGBVALUE<bool> b新記録スコア;
		public STDGBVALUE<bool> b新記録ランク;
		public STDGBVALUE<float> fPerfect率;
		public STDGBVALUE<float> fGreat率;
		public STDGBVALUE<float> fGood率;
		public STDGBVALUE<float> fPoor率;
		public STDGBVALUE<float> fMiss率;
		public STDGBVALUE<bool> bオート;        // #23596 10.11.16 add ikanick
		public STDGBVALUE<int> nランク値;
		public STDGBVALUE<int> n演奏回数;
		//public STDGBVALUE<int> nScoreRank;
		public int n総合ランク値;
		public int nクリア;        //0:未クリア 1:クリア 2:フルコンボ 3:ドンダフルコンボ
		public int nスコアランク;  //0:未取得 1:白粋 2:銅粋 3:銀粋 4:金雅 5:桃雅 6:紫雅 7:虹極
		public CDTX.CChip[] r空うちドラムチップ;
		public STDGBVALUE<CScoreIni.C演奏記録> st演奏記録;

		// コンストラクタ

		public CStage結果()
		{
			st演奏記録.Drums = new CScoreIni.C演奏記録();
			st演奏記録.Guitar = new CScoreIni.C演奏記録();
			st演奏記録.Bass = new CScoreIni.C演奏記録();
			st演奏記録.Taiko = new CScoreIni.C演奏記録();
			r空うちドラムチップ = new CDTX.CChip[10];
			n総合ランク値 = -1;
			nチャンネル0Atoレーン07 = new int[] { 1, 2, 3, 4, 5, 7, 6, 1, 7, 0 };
			eステージID = CStage.Eステージ.結果;
			eフェーズID = CStage.Eフェーズ.共通_通常状態;
			b活性化してない = true;
			list子Activities.Add(actParameterPanel = new CActResultParameterPanel());
			list子Activities.Add(actSongBar = new CActResultSongBar());
			list子Activities.Add(actOption = new CActオプションパネル());
			list子Activities.Add(actFI = new CActFIFOResult());
			list子Activities.Add(actFO = new CActFIFOBlack());
			for (int i = 0; i < 10; i++)
			{
				stSongNumber[i].ch = i.ToString().ToCharArray()[0];
				stSongNumber[i].pt = new Point(27 * i, 0);
			}

		}

        // CStage 実装

        public override void On活性化()
		{
			if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)
			{
                TJAPlayer3.Skin.bgmリザルトイン音.t再生する();
            }
			else
			{
				TJAPlayer3.Skin.Sound段位リザルトイン音.t再生する();
			}

            Trace.TraceInformation("結果ステージを活性化します。");
			Trace.Indent();
			b最近遊んだ曲追加済み = false;
			try
			{
				#region [ 初期化 ]
					//---------------------
					eフェードアウト完了時の戻り値 = E戻り値.継続;
					bアニメが完了 = false;
					bIsCheckedWhetherResultScreenShouldSaveOrNot = false;              // #24609 2011.3.14 yyagi
					n最後に再生したHHのWAV番号 = -1;
					n最後に再生したHHのチャンネル番号 = 0;
					
					for (int i = 0; i < 3; i++)
					{
						b新記録スキル[i] = false;
						b新記録スコア[i] = false;
						b新記録ランク[i] = false;
					}
					//---------------------
					#endregion

				#region [ 結果の計算 ]
					//---------------------
					for (int i = 0; i < 3; i++)
					{
						nランク値[i] = -1;
						fPerfect率[i] = fGreat率[i] = fGood率[i] = fPoor率[i] = fMiss率[i] = 0.0f;  // #28500 2011.5.24 yyagi
						if ((((i != 0) || (TJAPlayer3.DTX.bチップがある.Drums))))
						{
							CScoreIni.C演奏記録 part = st演奏記録[i];
							bool bIsAutoPlay = true;
							switch (i)
							{
								case 0:
									bIsAutoPlay = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay;
									break;

								case 1:
									bIsAutoPlay = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay;
									break;

								case 2:
									bIsAutoPlay = TJAPlayer3.ConfigIni.b太鼓パートAutoPlay;
									break;
							}
							fPerfect率[i] = bIsAutoPlay ? 0f : ((100f * part.nPerfect数) / ((float)part.n全チップ数));
							fGreat率[i] = bIsAutoPlay ? 0f : ((100f * part.nGreat数) / ((float)part.n全チップ数));
							fGood率[i] = bIsAutoPlay ? 0f : ((100f * part.nGood数) / ((float)part.n全チップ数));
							fPoor率[i] = bIsAutoPlay ? 0f : ((100f * part.nPoor数) / ((float)part.n全チップ数));
							fMiss率[i] = bIsAutoPlay ? 0f : ((100f * part.nMiss数) / ((float)part.n全チップ数));
							bオート[i] = bIsAutoPlay; // #23596 10.11.16 add ikanick そのパートがオートなら1
							nランク値[i] = CScoreIni.tランク値を計算して返す(part);
						}
					}
					n総合ランク値 = CScoreIni.t総合ランク値を計算して返す(st演奏記録.Drums, st演奏記録.Guitar, st演奏記録.Bass);
					if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan && TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Tower)
					{
						nクリア = (st演奏記録.Drums.nMiss数 == 0 && st演奏記録.Drums.fゲージ == 100) ? st演奏記録.Drums.nGreat数 == 0 ? 3 : 2 : st演奏記録.Drums.fゲージ >= 80 ? 1 : 0;

						if (st演奏記録.Drums.nスコア < 500000)
						{
							nスコアランク = 0;
						}
						else
						{
							for (int i = 0; i < 7; i++)
							{
								if (st演奏記録.Drums.nスコア >= TJAPlayer3.stage演奏ドラム画面.ScoreRank.ScoreRank[i])
								{
									nスコアランク = i + 1;
								}
							}
						}
					}
					//---------------------
					#endregion

				#region [ .score.ini の作成と出力 ]
					//---------------------
					string str = TJAPlayer3.DTX.strファイル名の絶対パス + ".score.ini";
					CScoreIni ini = new CScoreIni(str);

					bool[] b今までにフルコンボしたことがある = new bool[] { false, false, false };

					// フルコンボチェックならびに新記録ランクチェックは、ini.Record[] が、スコアチェックや演奏型スキルチェックの IF 内で書き直されてしまうよりも前に行う。(2010.9.10)

					b今までにフルコンボしたことがある[0] = ini.stセクション[0].bフルコンボである | ini.stセクション[0].bフルコンボである;

					// #24459 上記の条件だと[HiSkill.***]でのランクしかチェックしていないので、BestRankと比較するよう変更。
					if (nランク値[0] >= 0 && ini.stファイル.BestRank[0] > nランク値[0] && !TJAPlayer3.ConfigIni.b太鼓パートAutoPlay)       // #24459 2011.3.1 yyagi update BestRank
					{
						b新記録ランク[0] = true;
						ini.stファイル.BestRank[0] = nランク値[0];
					}

					// Clear and score ranks
					if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan && TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Tower && !TJAPlayer3.ConfigIni.b太鼓パートAutoPlay)
					{
						st演奏記録[0].nクリア[TJAPlayer3.stage選曲.n確定された曲の難易度[0]] = Math.Max(ini.stセクション[0].nクリア[TJAPlayer3.stage選曲.n確定された曲の難易度[0]], nクリア);
						st演奏記録[0].nスコアランク[TJAPlayer3.stage選曲.n確定された曲の難易度[0]] = Math.Max(ini.stセクション[0].nスコアランク[TJAPlayer3.stage選曲.n確定された曲の難易度[0]], nスコアランク);

						for (int i = 0; i < 5; i++)
						{
							if (i != TJAPlayer3.stage選曲.n確定された曲の難易度[0])
							{
								st演奏記録[0].nクリア[i] = ini.stセクション[0].nクリア[i];
								st演奏記録[0].nスコアランク[i] = ini.stセクション[0].nスコアランク[i];
							}

							ini.stセクション[0].nクリア[i] = st演奏記録[0].nクリア[i];
							ini.stセクション[0].nスコアランク[i] = st演奏記録[0].nスコアランク[i];
						}
					}

					// 新記録スコアチェック
					if ((st演奏記録[0].nスコア > ini.stセクション[0].nスコア) && !TJAPlayer3.ConfigIni.b太鼓パートAutoPlay)
					{
						b新記録スコア[0] = true;
						ini.stセクション[0] = st演奏記録[0];
					}

					//Header hi-score
					if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan && TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Tower && !TJAPlayer3.ConfigIni.b太鼓パートAutoPlay)
						if (st演奏記録[0].nスコア > ini.stセクション[0].nスコア)
							st演奏記録[0].nハイスコア[TJAPlayer3.stage選曲.n確定された曲の難易度[0]] = (int)st演奏記録[0].nスコア;

                    // 新記録スキルチェック
                    if (st演奏記録[0].db演奏型スキル値 > ini.stセクション[0].db演奏型スキル値)
					{
						b新記録スキル[0] = true;
						ini.stセクション[0] = st演奏記録[0];
					}

					// ラストプレイ #23595 2011.1.9 ikanick
					// オートじゃなければプレイ結果を書き込む
					if (TJAPlayer3.ConfigIni.b太鼓パートAutoPlay == false)
					{
						ini.stセクション[0] = st演奏記録[0];
					}

					// #23596 10.11.16 add ikanick オートじゃないならクリア回数を1増やす
					//        11.02.05 bオート to t更新条件を取得する use      ikanick
					bool[] b更新が必要か否か = new bool[3];
					CScoreIni.t更新条件を取得する(out b更新が必要か否か[0], out b更新が必要か否か[1], out b更新が必要か否か[2]);

					if (b更新が必要か否か[0])
					{
						ini.stファイル.ClearCountDrums++;
					}
					//---------------------------------------------------------------------/
					if (TJAPlayer3.ConfigIni.bScoreIniを出力する)
						ini.t書き出し(str);

					//---------------------
					#endregion

				#region [ リザルト画面への演奏回数の更新 #24281 2011.1.30 yyagi]
					if (TJAPlayer3.ConfigIni.bScoreIniを出力する)
					{
						n演奏回数.Drums = ini.stファイル.PlayCountDrums;
						n演奏回数.Guitar = ini.stファイル.PlayCountGuitar;
						n演奏回数.Bass = ini.stファイル.PlayCountBass;
					}
				#endregion

				// Discord Presenseの更新
				Discord.UpdatePresence(TJAPlayer3.DTX.TITLE + ".tja", Properties.Discord.Stage_Result + (TJAPlayer3.ConfigIni.b太鼓パートAutoPlay == true ? " (" + Properties.Discord.Info_IsAuto + ")" : ""), TJAPlayer3.StartupTime);

				base.On活性化();
			}
			finally
			{
				Trace.TraceInformation("結果ステージの活性化を完了しました。");
				Trace.Unindent();
			}
		}
		public override void On非活性化()
		{
			if (rResultSound != null)
			{
				TJAPlayer3.Sound管理.tサウンドを破棄する(rResultSound);
				rResultSound = null;
			}
			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if (!b活性化してない)
			{
				b音声再生 = false;
				EndAnime = false;
				base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if (!b活性化してない)
			{
				if (ct登場用 != null)
				{
					ct登場用 = null;
				}
				base.OnManagedリソースの解放();
			}
		}
		public override int On進行描画()
		{
			if (!b活性化してない)
			{
				//int num;
				if (b初めての進行描画)
				{
					ct登場用 = new CCounter(0, 100, 5, TJAPlayer3.Timer);
					actFI.tフェードイン開始();
					eフェーズID = CStage.Eフェーズ.共通_フェードイン;
					rResultSound?.t再生を開始する();
					b初めての進行描画 = false;
				}
				bアニメが完了 = true;
				if (ct登場用.b進行中)
				{
					ct登場用.t進行();
					if (ct登場用.b終了値に達した)
					{
						ct登場用.t停止();
					}
					else
					{
						bアニメが完了 = false;
					}
				}

				if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)
				{
                    if (!b音声再生 && !TJAPlayer3.Skin.bgmリザルトイン音.b再生中)
                    {
                        TJAPlayer3.Skin.bgmリザルト音.t再生する();
                        b音声再生 = true;
                    }
                }
				else
				{
                    if (!b音声再生 && !TJAPlayer3.Skin.Sound段位リザルトイン音.b再生中)
                    {
                        TJAPlayer3.Skin.bgm段位リザルト音.t再生する();
                        b音声再生 = true;
                    }
					else
					{

					}
                }

                // 描画
				if (actParameterPanel.On進行描画() == 0)
				{
					bアニメが完了 = false;
				}

				if (actSongBar.On進行描画() == 0)
				{
					bアニメが完了 = false;
				}

				if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)//何曲目?
				{
					tSongNumberDraw(1111, 14, NowSong.ToString());
					tSongNumberDraw(1204, 14, MaxSong.ToString());
				}

                #region [ ネームプレート ]
                for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
				{
                    TJAPlayer3.NamePlate.tNamePlateDraw(TJAPlayer3.Skin.Result_NamePlate_X[i], TJAPlayer3.Skin.Result_NamePlate_Y[i], i);
                }
				#endregion

				if (eフェーズID == CStage.Eフェーズ.共通_フェードイン)
				{
					if (actFI.On進行描画() != 0)
					{
						eフェーズID = CStage.Eフェーズ.共通_通常状態;
					}
				}
				else if ((eフェーズID == CStage.Eフェーズ.共通_フェードアウト))
				{
					return (int)eフェードアウト完了時の戻り値;
				}

				#region [ #24609 2011.3.14 yyagi ランク更新or演奏型スキル更新時、リザルト画像をpngで保存する ]
				if (bアニメが完了 == true && bIsCheckedWhetherResultScreenShouldSaveOrNot == false  // #24609 2011.3.14 yyagi; to save result screen in case BestRank or HiSkill.
					&& TJAPlayer3.ConfigIni.bScoreIniを出力する
					&& TJAPlayer3.ConfigIni.bIsAutoResultCapture)// #25399 2011.6.9 yyagi
				{
					CheckAndSaveResultScreen(true);
					bIsCheckedWhetherResultScreenShouldSaveOrNot = true;
				}
				#endregion

				// キー入力

				if (TJAPlayer3.act現在入力を占有中のプラグイン == null)
				{
					if (eフェーズID == CStage.Eフェーズ.共通_通常状態)
					{
						if (TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.Escape))
						{
							TJAPlayer3.Skin.bgmリザルト音.t停止する();
							TJAPlayer3.Skin.bgm段位リザルト音.t停止する();
							TJAPlayer3.Skin.sound決定音.t再生する();
							actFI.tフェードアウト開始();

							t後処理();
							eフェーズID = CStage.Eフェーズ.共通_フェードアウト;
							eフェードアウト完了時の戻り値 = E戻り値.完了;
						}
						if (((TJAPlayer3.Pad.b押されたDGB(Eパッド.CY) || TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.RD)) || (TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.LC) 
							|| (TJAPlayer3.Pad.b押されたDGB(Eパッド.LRed) || (TJAPlayer3.Pad.b押されたDGB(Eパッド.RRed) || TJAPlayer3.Input管理.Keyboard.bキーが押された((int)SlimDXKeys.Key.Return))))))
						{
                            TJAPlayer3.Skin.bgm段位リザルト音.t停止する();
                            TJAPlayer3.Skin.sound決定音.t再生する();
							#region [ Skip animations ]

							if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] < (int)Difficulty.Tower
								&& actParameterPanel.ct全体進行.n現在の値 < actParameterPanel.MountainAppearValue)
							{
								actParameterPanel.tSkipResultAnimations();
							}
                            else if (TJAPlayer3.ConfigIni.nPlayerCount == 1)
                            {
                                #region [ Return to song select screen ]
                                actFI.tフェードアウト開始();

                                if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)
                                    if (TJAPlayer3.stage選曲.r現在選択中の曲.r親ノード != null)
                                        TJAPlayer3.stage選曲.act曲リスト.tBOXを出る();

                                {
                                    eフェーズID = CStage.Eフェーズ.共通_フェードアウト;
                                    eフェードアウト完了時の戻り値 = E戻り値.完了;
                                    TJAPlayer3.Skin.bgmリザルト音.t停止する();
                                    TJAPlayer3.Skin.sound決定音.t再生する();
                                }
                                t後処理();

                                #endregion
                            }
							else if (TJAPlayer3.ConfigIni.nPlayerCount == 2)
							{
                                #region [ Return to song select screen ]
                                actFI.tフェードアウト開始();

                                if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)
                                    if (TJAPlayer3.stage選曲.r現在選択中の曲.r親ノード != null)
                                        TJAPlayer3.stage選曲.act曲リスト.tBOXを出る();

                                {
                                    eフェーズID = CStage.Eフェーズ.共通_フェードアウト;
                                    eフェードアウト完了時の戻り値 = E戻り値.完了;
                                    TJAPlayer3.Skin.bgmリザルト音.t停止する();
                                    TJAPlayer3.Skin.sound決定音.t再生する();
                                }
                                t後処理();

                                #endregion
                            }

                            #endregion
                        }
                    }

				}
			}
			return 0;
		}

		public void t後処理()
        {
			if (!TJAPlayer3.ConfigIni.bAutoPlay[0])
			{
				if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan && TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Tower)
				{
					if (nスコアランク != 0)
					{
						if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nスコアランク[TJAPlayer3.stage選曲.n確定された曲の難易度[0]] == 0)
						{
							TJAPlayer3.stage選曲.act曲リスト.ScoreRankCount[nスコアランク - 1] += 1;
						}
						else if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nスコアランク[TJAPlayer3.stage選曲.n確定された曲の難易度[0]] < nスコアランク)
						{
							TJAPlayer3.stage選曲.act曲リスト.ScoreRankCount[nスコアランク - 1] += 1;
							TJAPlayer3.stage選曲.act曲リスト.ScoreRankCount[TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nスコアランク[TJAPlayer3.stage選曲.n確定された曲の難易度[0]] - 1] -= 1;
						}
					}

					if (nクリア != 0)
					{
						if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nクリア[TJAPlayer3.stage選曲.n確定された曲の難易度[0]] == 0)
						{
							TJAPlayer3.stage選曲.act曲リスト.CrownCount[nクリア - 1] += 1;
						}
						else if (TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nクリア[TJAPlayer3.stage選曲.n確定された曲の難易度[0]] < nクリア)
						{
							TJAPlayer3.stage選曲.act曲リスト.CrownCount[nクリア - 1] += 1;
							TJAPlayer3.stage選曲.act曲リスト.CrownCount[TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.nクリア[TJAPlayer3.stage選曲.n確定された曲の難易度[0]] - 1] -= 1;
						}

					}
				}
			}

			if (!b最近遊んだ曲追加済み)
			{
				#region [ 選曲画面の譜面情報の更新 ]
				//---------------------
				if (!TJAPlayer3.bコンパクトモード)
				{
					if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan && TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Tower)
					{
						Cスコア cスコア = TJAPlayer3.stage選曲.r確定されたスコア;

						if (cスコア.譜面情報.nクリア[TJAPlayer3.stage選曲.n確定された曲の難易度[0]] < nクリア)
							cスコア.譜面情報.nクリア[TJAPlayer3.stage選曲.n確定された曲の難易度[0]] = nクリア;

						if (cスコア.譜面情報.nスコアランク[TJAPlayer3.stage選曲.n確定された曲の難易度[0]] < nスコアランク)
							cスコア.譜面情報.nスコアランク[TJAPlayer3.stage選曲.n確定された曲の難易度[0]] = nスコアランク;
					}
				}
				//---------------------
				#endregion

				foreach (var song in TJAPlayer3.Songs管理.list曲ルート)
				{
					if (song.strジャンル == "最近遊んだ曲" && song.eノード種別 == C曲リストノード.Eノード種別.BOX)
					{
						song.list子リスト.Add(TJAPlayer3.stage選曲.r確定された曲.Clone());

						foreach (var song2 in song.list子リスト)
						{
							song2.r親ノード = song;
							song2.strジャンル = "最近遊んだ曲";

							if (song2.eノード種別 != C曲リストノード.Eノード種別.BACKBOX)
								song2.BackColor = ColorTranslator.FromHtml("#164748");
						}

						if (song.list子リスト.Count >= 6)
						{
							song.list子リスト.RemoveAt(1);
						}
					}
				}
				b最近遊んだ曲追加済み = true;
			}
		}

		public enum E戻り値 : int
		{
			継続,
			完了
		}

		// その他

		#region [ private ]
		//-----------------

		public bool b最近遊んだ曲追加済み;
		public bool b音声再生;
		public bool EndAnime;
		private CCounter ct登場用;
		private E戻り値 eフェードアウト完了時の戻り値;
		private readonly CActFIFOResult actFI;
		private readonly CActFIFOBlack actFO;
		private readonly CActオプションパネル actOption;
		public CAct演奏Drumsスコア actGameScore;
		private readonly CActResultParameterPanel actParameterPanel;
		private readonly CActResultSongBar actSongBar;
		private bool bアニメが完了;
		private bool bIsCheckedWhetherResultScreenShouldSaveOrNot;              // #24509 2011.3.14 yyagi
		private readonly int[] nチャンネル0Atoレーン07;
		private int n最後に再生したHHのWAV番号;
		private int n最後に再生したHHのチャンネル番号;
		private CSound rResultSound;
		//private CTexture txオプションパネル;
		private const int MaxSong = 3;
		public int NowSong = 1;
		private readonly STNumber[] stSongNumber = new STNumber[10];
		public struct STNumber
		{
			public char ch;
			public Point pt;
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

        #region [ #24609 リザルト画像をpngで保存する ]		// #24609 2011.3.14 yyagi; to save result screen in case BestRank or HiSkill.
        /// <summary>
        /// リザルト画像のキャプチャと保存。
        /// 自動保存モード時は、ランク更新or演奏型スキル更新時に自動保存。
        /// 手動保存モード時は、ランクに依らず保存。
        /// </summary>
        /// <param name="bIsAutoSave">true=自動保存モード, false=手動保存モード</param>
        private void CheckAndSaveResultScreen(bool bIsAutoSave)
		{
			//string path = Path.GetDirectoryName(TJAPlayer3.DTX.strファイル名の絶対パス);
			string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
			if (bIsAutoSave)
			{
				// リザルト画像を自動保存するときは、dtxファイル名.yyMMddHHmmss_DRUMS_SS.png という形式で保存。
				for (int i = 0; i < 3; i++)
				{
					if (b新記録ランク[i] == true || b新記録スキル[i] == true)
					{
						string strPart = ((E楽器パート)(i)).ToString();
						string strRank = ((CScoreIni.ERANK)(this.nランク値[i])).ToString();
						string strFullPath = TJAPlayer3.DTX.strファイル名の絶対パス + "." + datetime + "_" + strPart + "_" + strRank + ".png";
						TJAPlayer3.app.SaveResultScreen(strFullPath);
					}
				}
			}
		}
		#endregion

		//-----------------
		#endregion
	}
}
