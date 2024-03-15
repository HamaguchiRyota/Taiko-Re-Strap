using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using SharpDX;
using System.Drawing.Text;
using FDK;

using RectangleF = System.Drawing.RectangleF;
using Color = System.Drawing.Color;

namespace TJAPlayer3
{
	internal class CStage曲読み込み : CStage
	{
		// コンストラクタ
		public CStage曲読み込み()
		{
			eステージID = Eステージ.曲読み込み;
			eフェーズID = Eフェーズ.共通_通常状態;
			b活性化してない = true;
		}

		// CStage 実装

		public override void On活性化()
		{
			Trace.TraceInformation( "曲読み込みステージを活性化します。" );
			Trace.Indent();
			try
			{
				TJAPlayer3.Tx.LoadSongLoadTex();
				TJAPlayer3.Tx.LoadGameTex();
				str曲タイトル = "";
				strSTAGEFILE = "";
                if( !string.IsNullOrEmpty( TJAPlayer3.ConfigIni.FontName ) )
                {
                    pfTITLE = new CPrivateFastFont( new FontFamily( TJAPlayer3.ConfigIni.FontName ), TJAPlayer3.Skin.SongLoading_Title_FontSize );
                    pfSUBTITLE = new CPrivateFastFont( new FontFamily( TJAPlayer3.ConfigIni.FontName ), TJAPlayer3.Skin.SongLoading_SubTitle_FontSize);
                }
                else
                {
                    pfTITLE = new CPrivateFastFont( new FontFamily("MS UI Gothic"), TJAPlayer3.Skin.SongLoading_Title_FontSize);
                    pfSUBTITLE = new CPrivateFastFont( new FontFamily("MS UI Gothic" ), TJAPlayer3.Skin.SongLoading_SubTitle_FontSize);
                }
				nBGM再生開始時刻 = -1;
				nBGMの総再生時間ms = 0;
				if( sd読み込み音 != null )
				{
					TJAPlayer3.Sound管理.tサウンドを破棄する( sd読み込み音 );
					sd読み込み音 = null;
				}

			    if (TJAPlayer3.bコンパクトモード)
			    {
			        string strDTXファイルパス = TJAPlayer3.strコンパクトモードファイル;
				
			        CDTX cdtx = new CDTX( strDTXファイルパス, true, 1.0, 0, 0 );
			        if( File.Exists( cdtx.strフォルダ名 + @"set.def" ) )
			            cdtx = new CDTX( strDTXファイルパス, true, 1.0, 0, 1 );

			        str曲タイトル = cdtx.TITLE;
			        strサブタイトル = cdtx.SUBTITLE;

			        cdtx.On非活性化();
			    }
			    else
			    {
			        string strDTXファイルパス = TJAPlayer3.stage選曲.r確定されたスコア.ファイル情報.ファイルの絶対パス;

			        var strフォルダ名 = Path.GetDirectoryName(strDTXファイルパス) + @"\";

			        if (File.Exists(strフォルダ名 + @"set.def"))
			        {
			            var cdtx = new CDTX(strDTXファイルパス, true, 1.0, 0, 1);

			            str曲タイトル = cdtx.TITLE;
			            strサブタイトル = cdtx.SUBTITLE;

			            cdtx.On非活性化();
			        }
			        else
			        {
			            var 譜面情報 = TJAPlayer3.stage選曲.r確定されたスコア.譜面情報;
			            str曲タイトル = 譜面情報.タイトル;
			            strサブタイトル = 譜面情報.strサブタイトル;
			        }
			    }

			    TJAPlayer3.IsPerformingCalibration =
			        !TJAPlayer3.ConfigIni.b太鼓パートAutoPlay &&
			        TJAPlayer3.ConfigIni.nPlayerCount == 1 &&
			        str曲タイトル == "Input Calibration" &&
			        strサブタイトル == "TJAPlayer3 Developers";

				strSTAGEFILE = CSkin.Path(@"Graphics\4_SongLoading\Background.png");

				base.On活性化();
			}
			finally
			{
				Trace.TraceInformation( "曲読み込みステージの活性化を完了しました。" );
				Trace.Unindent();
			}
		}
		public override void On非活性化()
		{
			Trace.TraceInformation( "曲読み込みステージを非活性化します。" );
			Trace.Indent();
			try
			{
				//TJAPlayer3.Tx.DisposeTexture();
                TJAPlayer3.t安全にDisposeする(ref pfTITLE);
                TJAPlayer3.t安全にDisposeする(ref pfSUBTITLE);
                base.On非活性化();
			}
			finally
			{
				Trace.TraceInformation( "曲読み込みステージの非活性化を完了しました。" );
				Trace.Unindent();
			}
		}
		public override void OnManagedリソースの作成()
		{
            #region [ old ]
            if ( !b活性化してない )
			{
				tx背景 = TJAPlayer3.tテクスチャの生成( strSTAGEFILE, false );
                ct待機 = new CCounter( 0, TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan ? 1000 : 600, 5, TJAPlayer3.Timer );
                ct曲名表示 = new CCounter( 1, 30, 30, TJAPlayer3.Timer );
				try
				{

				    var タイトル = TJAPlayer3.IsPerformingCalibration
				        ? "Input calibration is about to begin."
				        : str曲タイトル;

				    var サブタイトル = TJAPlayer3.IsPerformingCalibration
				        ? "Please play as accurately as possible."
				        : strサブタイトル;

				    if( !string.IsNullOrEmpty(タイトル) )
					{
					    using (var bmpSongTitle = pfTITLE.DrawPrivateFont( タイトル, TJAPlayer3.Skin.SongLoading_Title_ForeColor, TJAPlayer3.Skin.SongLoading_Title_BackColor ))
					    {
					        txタイトル = new CTexture( TJAPlayer3.app.Device, bmpSongTitle, TJAPlayer3.TextureFormat, false );
					        txタイトル.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref txタイトル, 710);
					    }

					    using (var bmpSongSubTitle = pfSUBTITLE.DrawPrivateFont( サブタイトル, TJAPlayer3.Skin.SongLoading_SubTitle_ForeColor, TJAPlayer3.Skin.SongLoading_SubTitle_BackColor ))
					    {
					        txサブタイトル = new CTexture( TJAPlayer3.app.Device, bmpSongSubTitle, TJAPlayer3.TextureFormat, false );
                            txサブタイトル.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref txサブタイトル, 720);
                        }
                    }
					else
					{
						txタイトル = null;
                        txサブタイトル = null;
                    }

                }
                catch ( CTextureCreateFailedException e )
				{
					Trace.TraceError( e.ToString() );
					Trace.TraceError( "テクスチャの生成に失敗しました。({0})", new object[] { strSTAGEFILE } );
					txタイトル = null;
                    txサブタイトル = null;
                    tx背景 = null;
				}
				base.OnManagedリソースの作成();
			}
            #endregion

            if (!b活性化してない)
            {
                tx背景 = TJAPlayer3.tテクスチャの生成(strSTAGEFILE, false);
                int maxCounterValue = TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan ? 1000 : 600;
                ct待機 = new CCounter(0, maxCounterValue, 5, TJAPlayer3.Timer);
                ct曲名表示 = new CCounter(1, 30, 30, TJAPlayer3.Timer);

                if (!TJAPlayer3.IsPerformingCalibration)
                {
                    var タイトル = str曲タイトル;
                    var サブタイトル = strサブタイトル;

                    if (!string.IsNullOrEmpty(タイトル))
                    {
                        using (var bmpSongTitle = pfTITLE.DrawPrivateFont(タイトル, TJAPlayer3.Skin.SongLoading_Title_ForeColor, TJAPlayer3.Skin.SongLoading_Title_BackColor))
                        {
                            txタイトル = new CTexture(TJAPlayer3.app.Device, bmpSongTitle, TJAPlayer3.TextureFormat, false);
                            txタイトル.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref txタイトル, 710);
                        }

                        using (var bmpSongSubTitle = pfSUBTITLE.DrawPrivateFont(サブタイトル, TJAPlayer3.Skin.SongLoading_SubTitle_ForeColor, TJAPlayer3.Skin.SongLoading_SubTitle_BackColor))
                        {
                            txサブタイトル = new CTexture(TJAPlayer3.app.Device, bmpSongSubTitle, TJAPlayer3.TextureFormat, false);
                            txサブタイトル.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref txサブタイトル, 720);
                        }
                    }
                    else
                    {
                        txタイトル = null;
                        txサブタイトル = null;
                    }
                }
                else
                {
                    var タイトル = "Input calibration is about to begin.";
                    var サブタイトル = "Please play as accurately as possible.";

                    using (var bmpSongTitle = pfTITLE.DrawPrivateFont(タイトル, TJAPlayer3.Skin.SongLoading_Title_ForeColor, TJAPlayer3.Skin.SongLoading_Title_BackColor))
                    {
                        txタイトル = new CTexture(TJAPlayer3.app.Device, bmpSongTitle, TJAPlayer3.TextureFormat, false);
                        txタイトル.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref txタイトル, 710);
                    }

                    using (var bmpSongSubTitle = pfSUBTITLE.DrawPrivateFont(サブタイトル, TJAPlayer3.Skin.SongLoading_SubTitle_ForeColor, TJAPlayer3.Skin.SongLoading_SubTitle_BackColor))
                    {
                        txサブタイトル = new CTexture(TJAPlayer3.app.Device, bmpSongSubTitle, TJAPlayer3.TextureFormat, false);
                        txサブタイトル.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref txサブタイトル, 720);
                    }
                }

                base.OnManagedリソースの作成();
            }

        }
        public override void OnManagedリソースの解放()
		{
			if( !b活性化してない )
			{
				TJAPlayer3.tテクスチャの解放( ref tx背景 );
				TJAPlayer3.tテクスチャの解放( ref txタイトル );
                TJAPlayer3.tテクスチャの解放( ref txサブタイトル );
				base.OnManagedリソースの解放();
			}
		}
		public override int On進行描画()
		{
			string str;

			if( b活性化してない )
				return 0;

			#region [ 初めての進行描画 ]
			//-----------------------------
			if( b初めての進行描画 )
			{
				Cスコア cスコア1 = TJAPlayer3.stage選曲.r確定されたスコア;
				if( sd読み込み音 != null )
				{
					if( TJAPlayer3.Skin.sound曲読込開始音.b排他 && ( CSkin.Cシステムサウンド.r最後に再生した排他システムサウンド != null ) )
					{
						CSkin.Cシステムサウンド.r最後に再生した排他システムサウンド.t停止する();
					}
					sd読み込み音.t再生を開始する();
					nBGM再生開始時刻 = CSound管理.rc演奏用タイマ.n現在時刻;
					nBGMの総再生時間ms = sd読み込み音.n総演奏時間ms;
				}
				else
				{
					TJAPlayer3.Skin.sound曲読込開始音.t再生する();
					nBGM再生開始時刻 = CSound管理.rc演奏用タイマ.n現在時刻;
					nBGMの総再生時間ms = TJAPlayer3.Skin.sound曲読込開始音.n長さ_現在のサウンド;
				}
				//this.actFI.tフェードイン開始();							// #27787 2012.3.10 yyagi 曲読み込み画面のフェードインの省略
				eフェーズID = Eフェーズ.共通_フェードイン;
				b初めての進行描画 = false;

				nWAVcount = 1;
				bitmapFilename = new Bitmap( 640, 24 );
				graphicsFilename = Graphics.FromImage( bitmapFilename );
				graphicsFilename.TextRenderingHint = TextRenderingHint.AntiAlias;
				ftFilename = new Font("MS UI Gothic", 24f, FontStyle.Bold, GraphicsUnit.Pixel );
			}
			//-----------------------------
			#endregion
            ct待機.t進行();

			#region [ ESC押下時は選曲画面に戻る ]
			if ( tキー入力() )
			{
				if ( sd読み込み音 != null )
				{
					sd読み込み音.tサウンドを停止する();
					sd読み込み音.t解放する();
				}
				return (int) E曲読込画面の戻り値.読込中止;
			}
			#endregion

			if(TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)
			{
				#region [ 背景、音符＋タイトル表示 ]
				//-----------------------------
				ct曲名表示.t進行();
				if (TJAPlayer3.Tx.SongLoading_BgWait == null)
                {
                }
                else
                    TJAPlayer3.Tx.SongLoading_BgWait.t2D描画(TJAPlayer3.app.Device, 0, 0);
                TJAPlayer3.Tx.SongLoading_Chara?.t2D描画(TJAPlayer3.app.Device, 0, 0);

				if (TJAPlayer3.Tx.SongLoading_Plate != null)
				{
					TJAPlayer3.Tx.SongLoading_Plate.bスクリーン合成 = TJAPlayer3.Skin.SongLoading_Plate_ScreenBlend; //あまりにも出番が無い
					TJAPlayer3.Tx.SongLoading_Plate.Opacity = 255;
					if (TJAPlayer3.Skin.SongLoading_Plate_ReferencePoint == CSkin.ReferencePoint.Left)
					{
						TJAPlayer3.Tx.SongLoading_Plate.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.SongLoading_Plate_X, TJAPlayer3.Skin.SongLoading_Plate_Y - (TJAPlayer3.Tx.SongLoading_Plate.sz画像サイズ.Height / 2));
					}
					else if (TJAPlayer3.Skin.SongLoading_Plate_ReferencePoint == CSkin.ReferencePoint.Right)
					{
						TJAPlayer3.Tx.SongLoading_Plate.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.SongLoading_Plate_X - TJAPlayer3.Tx.SongLoading_Plate.sz画像サイズ.Width, TJAPlayer3.Skin.SongLoading_Plate_Y - (TJAPlayer3.Tx.SongLoading_Plate.sz画像サイズ.Height / 2));
					}
					else
					{
						TJAPlayer3.Tx.SongLoading_Plate.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.SongLoading_Plate_X - (TJAPlayer3.Tx.SongLoading_Plate.sz画像サイズ.Width / 2), TJAPlayer3.Skin.SongLoading_Plate_Y - (TJAPlayer3.Tx.SongLoading_Plate.sz画像サイズ.Height / 2));
					}
				}

				int y = 720 - 45;
				if (this.txタイトル != null)
				{
					int nサブタイトル補正 = string.IsNullOrEmpty(TJAPlayer3.stage選曲.r確定されたスコア.譜面情報.strサブタイトル) ? 15 : 0;

					txタイトル.Opacity = 255;
					if (TJAPlayer3.Skin.SongLoading_Title_ReferencePoint == CSkin.ReferencePoint.Left)
					{
						txタイトル.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.SongLoading_Title_X, TJAPlayer3.Skin.SongLoading_Title_Y - (txタイトル.sz画像サイズ.Height / 2) + nサブタイトル補正);
					}
					else if (TJAPlayer3.Skin.SongLoading_Title_ReferencePoint == CSkin.ReferencePoint.Right)
					{
						txタイトル.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.SongLoading_Title_X - (txタイトル.sz画像サイズ.Width * txタイトル.vc拡大縮小倍率.X), TJAPlayer3.Skin.SongLoading_Title_Y - (txタイトル.sz画像サイズ.Height / 2) + nサブタイトル補正);
					}
					else
					{
						txタイトル.t2D描画(TJAPlayer3.app.Device, (TJAPlayer3.Skin.SongLoading_Title_X - ((txタイトル.sz画像サイズ.Width * txタイトル.vc拡大縮小倍率.X) / 2)), TJAPlayer3.Skin.SongLoading_Title_Y - (txタイトル.sz画像サイズ.Height / 2) + nサブタイトル補正);
					}
				}
				if (txサブタイトル != null)
				{
					txサブタイトル.Opacity = 255;
					if (TJAPlayer3.Skin.SongLoading_SubTitle_ReferencePoint == CSkin.ReferencePoint.Left)
					{
						txサブタイトル.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.SongLoading_SubTitle_X, TJAPlayer3.Skin.SongLoading_SubTitle_Y - (txサブタイトル.sz画像サイズ.Height / 2));
					}
					else if (TJAPlayer3.Skin.SongLoading_Title_ReferencePoint == CSkin.ReferencePoint.Right)
					{
						txサブタイトル.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.SongLoading_SubTitle_X - (txサブタイトル.sz画像サイズ.Width * txタイトル.vc拡大縮小倍率.X), TJAPlayer3.Skin.SongLoading_SubTitle_Y - (txサブタイトル.sz画像サイズ.Height / 2));
					}
					else
					{
						txサブタイトル.t2D描画(TJAPlayer3.app.Device, (TJAPlayer3.Skin.SongLoading_SubTitle_X - ((txサブタイトル.sz画像サイズ.Width * txサブタイトル.vc拡大縮小倍率.X) / 2)), TJAPlayer3.Skin.SongLoading_SubTitle_Y - (txサブタイトル.sz画像サイズ.Height / 2));
					}
				}
				//-----------------------------
				#endregion
			}
            else
            {
				#region [ 段位時の曲読み込み画面　]

				TJAPlayer3.Tx.SongLoading_Bg_Dan.t2D描画(TJAPlayer3.app.Device, 0, 0 - (ct待機.n現在の値 <= 600 ? ct待機.n現在の値 / 10f : 60));
				if(TJAPlayer3.stage段位選択.段位リスト.stバー情報[TJAPlayer3.stage段位選択.段位リスト.n現在の選択行].txDanPlate != null) TJAPlayer3.stage段位選択.段位リスト.stバー情報[TJAPlayer3.stage段位選択.段位リスト.n現在の選択行].txDanPlate.Opacity = (int)(ct待機.n現在の値 <= 51 ? ( ct待機.n現在の値 / 0.2f) : 255 - (ct待機.n現在の値 - 949) / 0.2);
				TJAPlayer3.stage段位選択.段位リスト.stバー情報[TJAPlayer3.stage段位選択.段位リスト.n現在の選択行].txDanPlate?.t2D中心基準描画(TJAPlayer3.app.Device, 1121, 213);

				if (TJAPlayer3.Tx.Tile_Black != null)
				{
					TJAPlayer3.Tx.Tile_Black.Opacity = (int)(ct待機.n現在の値 <= 51 ? (255 - ct待機.n現在の値 / 0.2f) : (ct待機.n現在の値 - 949) / 0.2);
					for (int i = 0; i <= (SampleFramework.GameWindowSize.Width / 64); i++)      // #23510 2010.10.31 yyagi: change "clientSize.Width" to "640" to fix FIFO drawing size
					{
						for (int j = 0; j <= (SampleFramework.GameWindowSize.Height / 64); j++) // #23510 2010.10.31 yyagi: change "clientSize.Height" to "480" to fix FIFO drawing size
						{
							TJAPlayer3.Tx.Tile_Black.t2D描画(TJAPlayer3.app.Device, i * 64, j * 64);
						}
					}
				}

				#endregion
			}

            switch ( eフェーズID )
			{
				case Eフェーズ.共通_フェードイン:
				    eフェーズID = Eフェーズ.NOWLOADING_DTXファイルを読み込む;
					return (int) E曲読込画面の戻り値.継続;

                case Eフェーズ.NOWLOADING_DTXファイルを読み込む:
                    {
                        timeBeginLoad = DateTime.Now;
                        TimeSpan span;
                        str = !TJAPlayer3.bコンパクトモード ? TJAPlayer3.stage選曲.r確定されたスコア.ファイル情報.ファイルの絶対パス : TJAPlayer3.strコンパクトモードファイル;

                        CScoreIni ini = new CScoreIni(str + ".score.ini");
                        ini.t全演奏記録セクションの整合性をチェックし不整合があればリセットする();

                        TJAPlayer3.DTX?.On非活性化();
                        TJAPlayer3.DTX = new CDTX(str, false, 1.0, ini.stファイル.BGMAdjust, 0, 0, true, TJAPlayer3.stage選曲.n確定された曲の難易度[0]);

                        if (TJAPlayer3.ConfigIni.nPlayerCount == 2)
                        {
                            TJAPlayer3.DTX_2P = new CDTX(str, false, 1.0, ini.stファイル.BGMAdjust, 0, 1, true, TJAPlayer3.stage選曲.n確定された曲の難易度[1]);
                        }

                        if (File.Exists(TJAPlayer3.DTX.strフォルダ名 + @"\\set.def"))
                        {
                            TJAPlayer3.DTX_2P = new CDTX(str, false, 1.0, ini.stファイル.BGMAdjust, 0, 1, true, TJAPlayer3.stage選曲.n確定された曲の難易度[0]);

                            if (TJAPlayer3.ConfigIni.nPlayerCount == 2)
                            {
                                TJAPlayer3.DTX_2P = new CDTX(str, false, 1.0, ini.stファイル.BGMAdjust, 0, 1, true, TJAPlayer3.stage選曲.n確定された曲の難易度[1]);
                            }
                        }

                        Trace.TraceInformation("----曲情報-----------------");
                        Trace.TraceInformation("TITLE: {0}", TJAPlayer3.DTX.TITLE);
                        Trace.TraceInformation("FILE: {0}", TJAPlayer3.DTX.strファイル名の絶対パス);
                        Trace.TraceInformation("---------------------------");

                        span = DateTime.Now - timeBeginLoad;
                        Trace.TraceInformation("DTX読込所要時間:           {0}", span.ToString());

                        if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan && TJAPlayer3.DTX.List_DanSongs != null)
                        {
                            var pfTitle = !string.IsNullOrEmpty(TJAPlayer3.ConfigIni.FontName) ? new CPrivateFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 30) : new CPrivateFont(new FontFamily("MS UI Gothic"), 30);
                            var pfSubTitle = !string.IsNullOrEmpty(TJAPlayer3.ConfigIni.FontName) ? new CPrivateFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 22) : new CPrivateFont(new FontFamily("MS UI Gothic"), 22);
                            var titleForeColor = TJAPlayer3.Skin.Game_DanC_Title_ForeColor;
                            var titleBackColor = TJAPlayer3.Skin.Game_DanC_Title_BackColor;
                            var subtitleForeColor = TJAPlayer3.Skin.Game_DanC_SubTitle_ForeColor;
                            var subtitleBackColor = TJAPlayer3.Skin.Game_DanC_SubTitle_BackColor;

                            foreach (var song in TJAPlayer3.DTX.List_DanSongs)
                            {
                                if (!string.IsNullOrEmpty(song.Title))
                                {
                                    using (var bmpSongTitle = pfTitle.DrawPrivateFont(song.Title, titleForeColor, titleBackColor))
                                    {
                                        song.TitleTex = TJAPlayer3.tテクスチャの生成(bmpSongTitle, false);
                                        song.TitleTex.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref song.TitleTex, 710);
                                    }
                                }

                                if (!string.IsNullOrEmpty(song.SubTitle))
                                {
                                    using (var bmpSongSubTitle = pfSubTitle.DrawPrivateFont(song.SubTitle, subtitleForeColor, subtitleBackColor))
                                    {
                                        song.SubTitleTex = TJAPlayer3.tテクスチャの生成(bmpSongSubTitle, false);
                                        song.SubTitleTex.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref song.SubTitleTex, 710);
                                    }
                                }
                            }

                            pfTitle?.Dispose();
                            pfSubTitle?.Dispose();
                        }

                        eフェーズID = Eフェーズ.NOWLOADING_WAV読み込み待機;
                        timeBeginLoadWAV = DateTime.Now;
                        return (int)E曲読込画面の戻り値.継続;
                    }


                /*
            case Eフェーズ.NOWLOADING_DTXファイルを読み込む:
                {
                    timeBeginLoad = DateTime.Now;
                    TimeSpan span;
                    str = null;
                    if( !TJAPlayer3.bコンパクトモード )
                        str = TJAPlayer3.stage選曲.r確定されたスコア.ファイル情報.ファイルの絶対パス;
                    else
                        str = TJAPlayer3.strコンパクトモードファイル;

                    CScoreIni ini = new CScoreIni( str + ".score.ini" );
                    ini.t全演奏記録セクションの整合性をチェックし不整合があればリセットする();

                    if( ( TJAPlayer3.DTX != null ) && TJAPlayer3.DTX.b活性化してる )
                        TJAPlayer3.DTX.On非活性化();

                    //if( CDTXMania.DTX == null )
                    {
                        TJAPlayer3.DTX = new CDTX(str, false, 1.0, ini.stファイル.BGMAdjust, 0, 0, true, TJAPlayer3.stage選曲.n確定された曲の難易度[0]);
                        if ( TJAPlayer3.ConfigIni.nPlayerCount == 2 )
                            TJAPlayer3.DTX_2P = new CDTX(str, false, 1.0, ini.stファイル.BGMAdjust, 0, 1, true, TJAPlayer3.stage選曲.n確定された曲の難易度[1]);
                        if ( File.Exists( TJAPlayer3.DTX.strフォルダ名 + @"\\set.def" ) )
                        {
                            TJAPlayer3.DTX_2P = new CDTX(str, false, 1.0, ini.stファイル.BGMAdjust, 0, 1, true, TJAPlayer3.stage選曲.n確定された曲の難易度[0]);
                            if ( TJAPlayer3.ConfigIni.nPlayerCount == 2 )
                                TJAPlayer3.DTX_2P = new CDTX(str, false, 1.0, ini.stファイル.BGMAdjust, 0, 1, true, TJAPlayer3.stage選曲.n確定された曲の難易度[1]);
                        }

                        Trace.TraceInformation( "----曲情報-----------------" );
                        Trace.TraceInformation( "TITLE: {0}", TJAPlayer3.DTX.TITLE );
                        Trace.TraceInformation( "FILE: {0}",  TJAPlayer3.DTX.strファイル名の絶対パス );
                        Trace.TraceInformation( "---------------------------" );

                        span = DateTime.Now - timeBeginLoad;
                        Trace.TraceInformation( "DTX読込所要時間:           {0}", span.ToString() );

                        // 段位認定モード用。
                        if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan && TJAPlayer3.DTX.List_DanSongs != null)
                        {
                            var pfTitle = new CPrivateFont();
                            var pfSubTitle = new CPrivateFont();
                            if (!string.IsNullOrEmpty(TJAPlayer3.ConfigIni.FontName))
                            {
                                pfTitle = new CPrivateFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 30);
                                pfSubTitle = new CPrivateFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 22);
                            }
                            else
                            {
                                pfTitle = new CPrivateFont(new FontFamily("MS UI Gothic"), 30);
                                pfSubTitle = new CPrivateFont(new FontFamily("MS UI Gothic"), 22);
                            }

                            var titleForeColor = TJAPlayer3.Skin.Game_DanC_Title_ForeColor;
                            var titleBackColor = TJAPlayer3.Skin.Game_DanC_Title_BackColor;
                            var subtitleForeColor = TJAPlayer3.Skin.Game_DanC_SubTitle_ForeColor;
                            var subtitleBackColor = TJAPlayer3.Skin.Game_DanC_SubTitle_BackColor;

                            for (int i = 0; i < TJAPlayer3.DTX.List_DanSongs.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(TJAPlayer3.DTX.List_DanSongs[i].Title))
                                {
                                    using (var bmpSongTitle = pfTitle.DrawPrivateFont(TJAPlayer3.DTX.List_DanSongs[i].Title, titleForeColor, titleBackColor))
                                    {
                                        TJAPlayer3.DTX.List_DanSongs[i].TitleTex = TJAPlayer3.tテクスチャの生成(bmpSongTitle, false);
                                        TJAPlayer3.DTX.List_DanSongs[i].TitleTex.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref TJAPlayer3.DTX.List_DanSongs[i].TitleTex, 710);
                                    }
                                }

                                if (!string.IsNullOrEmpty(TJAPlayer3.DTX.List_DanSongs[i].SubTitle))
                                {
                                    using (var bmpSongSubTitle = pfSubTitle.DrawPrivateFont(TJAPlayer3.DTX.List_DanSongs[i].SubTitle, subtitleForeColor, subtitleBackColor))
                                    {
                                        TJAPlayer3.DTX.List_DanSongs[i].SubTitleTex = TJAPlayer3.tテクスチャの生成(bmpSongSubTitle, false);
                                        TJAPlayer3.DTX.List_DanSongs[i].SubTitleTex.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref TJAPlayer3.DTX.List_DanSongs[i].SubTitleTex, 710);
                                    }
                                }

                            }

                            pfTitle?.Dispose();
                            pfSubTitle?.Dispose();
                        }
                    }

                    eフェーズID = Eフェーズ.NOWLOADING_WAV読み込み待機;
                    timeBeginLoadWAV = DateTime.Now;
                    return (int) E曲読込画面の戻り値.継続;
                }
                */

                case Eフェーズ.NOWLOADING_WAV読み込み待機:
                    {
                        if( ct待機.n現在の値 > 260 )
                        {
						    eフェーズID = Eフェーズ.NOWLOADING_WAVファイルを読み込む;
                        }
						return (int) E曲読込画面の戻り値.継続;
                    }

				case Eフェーズ.NOWLOADING_WAVファイルを読み込む:
					{
						if ( nWAVcount == 1 && TJAPlayer3.DTX.listWAV.Count > 0 )			// #28934 2012.7.7 yyagi (added checking Count)
						{
							ShowProgressByFilename( TJAPlayer3.DTX.listWAV[ nWAVcount ].strファイル名 );
						}
						int looptime = (TJAPlayer3.ConfigIni.b垂直帰線待ちを行う)? 3 : 1;	// VSyncWait=ON時は1frame(1/60s)あたり3つ読むようにする
						for ( int i = 0; i < looptime && nWAVcount <= TJAPlayer3.DTX.listWAV.Count; i++ )
						{
							if ( TJAPlayer3.DTX.listWAV[ nWAVcount ].listこのWAVを使用するチャンネル番号の集合.Count > 0 )	// #28674 2012.5.8 yyagi
							{
								TJAPlayer3.DTX.tWAVの読み込み( TJAPlayer3.DTX.listWAV[ nWAVcount ] );
							}
							nWAVcount++;
						}
						if ( nWAVcount <= TJAPlayer3.DTX.listWAV.Count )
						{
							ShowProgressByFilename( TJAPlayer3.DTX.listWAV[ nWAVcount ].strファイル名 );
						}
						if ( nWAVcount > TJAPlayer3.DTX.listWAV.Count )
						{
							TimeSpan span = DateTime.Now - timeBeginLoadWAV;
							Trace.TraceInformation( "WAV読込所要時間({0,4}):     {1}", TJAPlayer3.DTX.listWAV.Count, span.ToString() );
							timeBeginLoadWAV = DateTime.Now;

							if ( TJAPlayer3.ConfigIni.bDynamicBassMixerManagement )
							{
								TJAPlayer3.DTX.PlanToAddMixerChannel();
							}
                            TJAPlayer3.DTX.t太鼓チップのランダム化( TJAPlayer3.ConfigIni.eRandom.Taiko );

							TJAPlayer3.stage演奏ドラム画面.On活性化();

							span = DateTime.Now - timeBeginLoadWAV;

							eフェーズID = Eフェーズ.NOWLOADING_BMPファイルを読み込む;
						}
						return (int) E曲読込画面の戻り値.継続;
					}

				case Eフェーズ.NOWLOADING_BMPファイルを読み込む:
					{
						TimeSpan span;
						DateTime timeBeginLoadBMPAVI = DateTime.Now;

						if ( TJAPlayer3.ConfigIni.bAVI有効 )
							TJAPlayer3.DTX.tAVIの読み込み();
						span = DateTime.Now - timeBeginLoadBMPAVI;

						span = DateTime.Now - timeBeginLoad;
						Trace.TraceInformation( "総読込時間:                {0}", span.ToString() );

                        if(TJAPlayer3.ConfigIni.FastRender)
                        {
                            var fastRender = new FastRender();
                            fastRender.Render();
                            //fastRender = null;
                        }


						if ( bitmapFilename != null )
						{
							bitmapFilename.Dispose();
							bitmapFilename = null;
						}
						if ( graphicsFilename != null )
						{
							graphicsFilename.Dispose();
							graphicsFilename = null;
						}
						if ( ftFilename != null )
						{
							ftFilename.Dispose();
							ftFilename = null;
						}
						TJAPlayer3.Timer.t更新();
						eフェーズID = Eフェーズ.NOWLOADING_システムサウンドBGMの完了を待つ;
						return (int) E曲読込画面の戻り値.継続;
					}

				case Eフェーズ.NOWLOADING_システムサウンドBGMの完了を待つ:
					{
						long nCurrentTime = TJAPlayer3.Timer.n現在時刻;
						if( nCurrentTime < nBGM再生開始時刻 )
							nBGM再生開始時刻 = nCurrentTime;

						if ( ( nCurrentTime - nBGM再生開始時刻 ) >= ( nBGMの総再生時間ms ) )	// #27787 2012.3.10 yyagi 1000ms == フェードイン分の時間
						{
							if ( !TJAPlayer3.DTXVmode.Enabled )
							{
							}
							eフェーズID = Eフェーズ.共通_フェードアウト;
						}
						return (int) E曲読込画面の戻り値.継続;
					}

				case Eフェーズ.共通_フェードアウト:
					if ( ct待機.b終了値に達してない )		// DTXVモード時は、フェードアウト省略
						return (int)E曲読込画面の戻り値.継続;

					txFilename?.Dispose();
					sd読み込み音?.t解放する();
					return (int) E曲読込画面の戻り値.読込完了;
			}
			return (int) E曲読込画面の戻り値.継続;
		}

		/// <summary>
		/// ESC押下時、trueを返す
		/// </summary>
		/// <returns></returns>
		protected bool tキー入力()
		{
			IInputDevice keyboard = TJAPlayer3.Input管理.Keyboard;
			if 	( keyboard.bキーが押された( (int)SlimDXKeys.Key.Escape ) )		// escape (exit)
			{
				return true;
			}
			return false;
		}


		private void ShowProgressByFilename(string strファイル名 )
		{
			if ( graphicsFilename != null && ftFilename != null )
			{
				graphicsFilename.Clear( Color.Transparent );
				graphicsFilename.DrawString( strファイル名, ftFilename, Brushes.White, new RectangleF( 0, 0, 640, 24 ) );
				txFilename?.Dispose();
                txFilename = new CTexture(TJAPlayer3.app.Device, bitmapFilename, TJAPlayer3.TextureFormat)
                {
                    vc拡大縮小倍率 = new Vector3(0.5f, 0.5f, 1f)
                };
                txFilename.t2D描画( TJAPlayer3.app.Device, 0, 720 - 16 );
			}
		}

		// その他

		#region [ private ]
		//-----------------
		private long nBGMの総再生時間ms;
		private long nBGM再生開始時刻;
		private CSound sd読み込み音;
		private string strSTAGEFILE;
		private string str曲タイトル;
        private string strサブタイトル;
		private CTexture txタイトル;
        private CTexture txサブタイトル;
		private CTexture tx背景;
		private DateTime timeBeginLoad;
		private DateTime timeBeginLoadWAV;
		private int nWAVcount;
		private CTexture txFilename;
		private Bitmap bitmapFilename;
		private Graphics graphicsFilename;
		private Font ftFilename;
        private CCounter ct待機;
        private CCounter ct曲名表示;
        private CPrivateFastFont pfTITLE;
        private CPrivateFastFont pfSUBTITLE;
		//-----------------
		#endregion
	}
}
