﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using SharpDX;
using SlimDX;
using FDK;
using Rectangle = System.Drawing.Rectangle;
using Point = System.Drawing.Point;

namespace TJAPlayer3
{
	internal class CActSelect演奏履歴パネル : CActivity
	{
		// メソッド

		public CActSelect演奏履歴パネル()
		{
			
			ST文字位置[] st文字位置Array = new ST文字位置[10];

			ST文字位置 st文字位置 = new ST文字位置();
			st文字位置.ch = '0';
			st文字位置.pt = new Point(0, 0);
			st文字位置Array[0] = st文字位置;
			ST文字位置 st文字位置2 = new ST文字位置();
			st文字位置2.ch = '1';
			st文字位置2.pt = new Point(18, 0);
			st文字位置Array[1] = st文字位置2;
			ST文字位置 st文字位置3 = new ST文字位置();
			st文字位置3.ch = '2';
			st文字位置3.pt = new Point(36, 0);
			st文字位置Array[2] = st文字位置3;
			ST文字位置 st文字位置4 = new ST文字位置();
			st文字位置4.ch = '3';
			st文字位置4.pt = new Point(54, 0);
			st文字位置Array[3] = st文字位置4;
			ST文字位置 st文字位置5 = new ST文字位置();
			st文字位置5.ch = '4';
			st文字位置5.pt = new Point(72, 0);
			st文字位置Array[4] = st文字位置5;
			ST文字位置 st文字位置6 = new ST文字位置();
			st文字位置6.ch = '5';
			st文字位置6.pt = new Point(90, 0);
			st文字位置Array[5] = st文字位置6;
			ST文字位置 st文字位置7 = new ST文字位置();
			st文字位置7.ch = '6';
			st文字位置7.pt = new Point(108, 0);
			st文字位置Array[6] = st文字位置7;
			ST文字位置 st文字位置8 = new ST文字位置();
			st文字位置8.ch = '7';
			st文字位置8.pt = new Point(126, 0);
			st文字位置Array[7] = st文字位置8;
			ST文字位置 st文字位置9 = new ST文字位置();
			st文字位置9.ch = '8';
			st文字位置9.pt = new Point(144, 0);
			st文字位置Array[8] = st文字位置9;
			ST文字位置 st文字位置10 = new ST文字位置();
			st文字位置10.ch = '9';
			st文字位置10.pt = new Point(162, 0);
			st文字位置Array[9] = st文字位置10;
			st小文字位置 = st文字位置Array;
			

			base.b活性化してない = true;
		}
		public void t選択曲が変更された()
		{
			Cスコア cスコア = TJAPlayer3.stage選曲.r現在選択中のスコア;
			if ((cスコア != null) && !TJAPlayer3.stage選曲.bスクロール中)
			{
				try
				{
					Bitmap image = new Bitmap(800, 240);
					Graphics graphics = Graphics.FromImage(image);
					graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
					for (int i = 0; i < (int)Difficulty.Total; i++)
					{
						if ((cスコア.譜面情報.演奏履歴[i] != null) && (cスコア.譜面情報.演奏履歴[i].Length > 0))
						{
							graphics.DrawString(cスコア.譜面情報.演奏履歴[i], ft表示用フォント, Brushes.Yellow, (float)0f, (float)(i * 36f));
						}
					}
					graphics.Dispose();
					if (tx文字列パネル != null)
					{
						tx文字列パネル.Dispose();
					}
					tx文字列パネル = new CTexture(TJAPlayer3.app.Device, image, TJAPlayer3.TextureFormat);
					tx文字列パネル.vc拡大縮小倍率 = new Vector3(0.5f, 0.5f, 1f);
					image.Dispose();
				}
				catch (CTextureCreateFailedException e)
				{
					Trace.TraceError(e.ToString());
					Trace.TraceError("演奏履歴文字列テクスチャの作成に失敗しました。");
					tx文字列パネル = null;
				}
			}
		}


		// CActivity 実装

		public override void On活性化()
		{
			n本体X = 810;
			n本体Y = 558;
			ft表示用フォント = new Font("Arial", 30f, FontStyle.Bold, GraphicsUnit.Pixel);
			base.On活性化();
		}
		public override void On非活性化()
		{
			if (ft表示用フォント != null)
			{
				ft表示用フォント.Dispose();
				ft表示用フォント = null;
			}
			ct登場アニメ用 = null;
			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if (!b活性化してない)
			{
				t選択曲が変更された();
				base.OnManagedリソースの作成();
			}
            this.ctDiff_fe = new CCounter(0, 100, 60, TJAPlayer3.Timer);


        }
		public override void OnManagedリソースの解放()
		{
			if (!b活性化してない)
			{
				base.OnManagedリソースの解放();
			}
		}
		public override int On進行描画()
		{
			if (!b活性化してない)
			{
				if (b初めての進行描画)
				{
					ct登場アニメ用 = new CCounter(0, 3, 1, TJAPlayer3.Timer);
					b初めての進行描画 = false;
				}
				ct登場アニメ用.t進行();
				int x = 80;
				int y = 410;

                //int OcF = (int)(176.0 + 80.0 * Math.Sin((double)(2 * Math.PI * this.ctDiff_fe.n現在の値 * 2 / 100.0)));//176.0 + 80.0



                if (TJAPlayer3.stage選曲.r現在選択中のスコア != null && ct登場アニメ用.n現在の値 >= 1 && TJAPlayer3.stage選曲.r現在選択中の曲.eノード種別 == C曲リストノード.Eノード種別.SCORE)
				{
                    TJAPlayer3.Tx.SongSelect_Counter?.t2D描画(TJAPlayer3.app.Device, x - 80, y - 75);
                    t小文字表示(x - 119, y - 60, string.Format("{0,9}", ((uint)TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.Bpm).ToString()));
                    t小文字表示(x + 20, y - 60, string.Format("{0,7:##0}", TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.演奏回数.Drums.ToString()));

                    TJAPlayer3.Tx.SongSelect_HighScore?.t2D描画(TJAPlayer3.app.Device, 11, 375);

					if (TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nハイスコア[3] < TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nハイスコア[4])
				    {
                        //裏鬼。テスト用にズレ入り
                        t小文字表示(x, y, string.Format("{0,7:#######0}", TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nハイスコア[4].ToString()));
                        TJAPlayer3.Tx.SongSelect_HighScore_Difficult?.t2D描画(TJAPlayer3.app.Device, x - 50, y - 4, new Rectangle(164, 0, TJAPlayer3.Tx.SongSelect_HighScore_Difficult.szテクスチャサイズ.Width / 5, TJAPlayer3.Tx.SongSelect_HighScore_Difficult.szテクスチャサイズ.Height));

                    }
					else
				    {
                        //鬼
                        t小文字表示(x, y, string.Format("{0,7:#######0}", TJAPlayer3.stage選曲.r現在選択中のスコア.譜面情報.nハイスコア[3].ToString()));
                        TJAPlayer3.Tx.SongSelect_HighScore_Difficult?.t2D描画(TJAPlayer3.app.Device, x - 50, y - 4, new Rectangle(123, 0, TJAPlayer3.Tx.SongSelect_HighScore_Difficult.szテクスチャサイズ.Width / 5, TJAPlayer3.Tx.SongSelect_HighScore_Difficult.szテクスチャサイズ.Height));

                    }

                }
            }
			return 0;
		}


		// その他

		#region [ private ]
		//-----------------
		private CCounter ct登場アニメ用;
		private readonly CCounter ctスコアボード登場アニメ;
		private Font ft表示用フォント;
		private int n本体X;
		private int n本体Y;
		//private CTexture txパネル本体;
		private CTexture tx文字列パネル;
        //      private CTexture[] txスコアボード = new CTexture[4];
        //      private CTexture tx文字;
        //-----------------

        private CCounter ctDiff_fe;

        [StructLayout(LayoutKind.Sequential)]
		
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
                        Rectangle rectangle = new Rectangle(this.st小文字位置[i].pt.X, this.st小文字位置[i].pt.Y, 18, 21);
                        if (TJAPlayer3.Tx.SongSelect_ScoreNumber != null)
                        {
                            TJAPlayer3.Tx.SongSelect_ScoreNumber.t2D描画(TJAPlayer3.app.Device, x, y, rectangle);
                        }
                        break;
                    }
                }
                x += 16;
				//22
            }
        }
        public void tSongChange()
		{
			this.ct登場アニメ用 = new CCounter(0, 3000, 1, TJAPlayer3.Timer);
		}


		#endregion
	}
}
