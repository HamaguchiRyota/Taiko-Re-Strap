using System;
using System.Diagnostics;
using FDK;

namespace TJAPlayer3
{
	internal class CActSelectPresound : CActivity
	{
		// メソッド

		public CActSelectPresound()
		{
			base.b活性化してない = true;
		}
		public void tサウンド停止()
		{
			if( sound != null )
			{
				sound.t再生を停止する();
				TJAPlayer3.Sound管理.tサウンドを破棄する( sound );
				sound = null;
			}
		}
		public void t選択曲が変更された()
		{
			Cスコア cスコア = TJAPlayer3.stage選曲.r現在選択中のスコア;
			
            if( ( cスコア != null ) && ( ( !( cスコア.ファイル情報.フォルダの絶対パス + cスコア.譜面情報.strBGMファイル名 ).Equals( str現在のファイル名 ) || ( sound == null ) ) || !sound.b再生中 ) )
			{
				tサウンド停止();
				tBGMフェードイン開始();
                long再生位置 = -1;
				if( ( cスコア.譜面情報.strBGMファイル名 != null ) && ( cスコア.譜面情報.strBGMファイル名.Length > 0 ) )
				{
                    if(TJAPlayer3.Sound管理.GetCurrentSoundDeviceType() != "DirectSound")
                    {
                        ct再生待ちウェイト = new CCounter(0, 1, 270, TJAPlayer3.Timer);
                    }
					else
                    {
                        ct再生待ちウェイト = new CCounter(0, 1, 500, TJAPlayer3.Timer);
                    }
                }
			}
		}

		// CActivity 実装

		public override void On活性化()
		{
			sound = null;
			str現在のファイル名 = "";
			ct再生待ちウェイト = null;
			ctBGMフェードアウト用 = null;
			ctBGMフェードイン用 = null;
            long再生位置 = -1;
            long再生開始時のシステム時刻 = -1;
			base.On活性化();
		}
		public override void On非活性化()
		{
			tサウンド停止();
			ct再生待ちウェイト = null;
			ctBGMフェードイン用 = null;
			ctBGMフェードアウト用 = null;
			base.On非活性化();
		}
		public override int On進行描画()
		{
            if (!b活性化してない)
            {
                if (ctBGMフェードイン用?.b進行中 == true)
                {
                    ctBGMフェードイン用.t進行();
                    TJAPlayer3.Skin.bgm選曲画面.nAutomationLevel_現在のサウンド = ctBGMフェードイン用.n現在の値;
                    if (ctBGMフェードイン用.b終了値に達した)
                    {
                        ctBGMフェードイン用.t停止();
                    }
                }

                if (ctBGMフェードアウト用?.b進行中 == true)
                {
                    ctBGMフェードアウト用.t進行();
                    TJAPlayer3.Skin.bgm選曲画面.nAutomationLevel_現在のサウンド = CSound.MaximumAutomationLevel - ctBGMフェードアウト用.n現在の値;
                    if (ctBGMフェードアウト用.b終了値に達した)
                    {
                        ctBGMフェードアウト用.t停止();
                    }
                }

                t進行処理_プレビューサウンド();

                if (sound != null)
                {
                    Cスコア cスコア = TJAPlayer3.stage選曲.r現在選択中のスコア;

                    if (long再生位置 == -1)
                    {
                        long再生開始時のシステム時刻 = CSound管理.rc演奏用タイマ.nシステム時刻ms;
                        long再生位置 = cスコア.譜面情報.nデモBGMオフセット;
                        sound.t再生位置を変更する(cスコア.譜面情報.nデモBGMオフセット);
                    }
                    else
                    {
                        long再生位置 = CSound管理.rc演奏用タイマ.nシステム時刻ms - long再生開始時のシステム時刻;
                        if (long再生位置 >= sound.n総演奏時間ms - cスコア.譜面情報.nデモBGMオフセット)
                            long再生位置 = -1;
                    }
                }
            }

            return 0;
		}

		// その他

		#region [ private ]
		//-----------------
		private CCounter ctBGMフェードアウト用;
		private CCounter ctBGMフェードイン用;
		private CCounter ct再生待ちウェイト;
        private long long再生位置;
        private long long再生開始時のシステム時刻;
		private CSound sound;
		private string str現在のファイル名;
		
		private void tBGMフェードアウト開始()
		{
			ctBGMフェードイン用?.t停止();
			ctBGMフェードアウト用 = new CCounter( 0, 100, 10, TJAPlayer3.Timer );
			ctBGMフェードアウト用.n現在の値 = 100 - TJAPlayer3.Skin.bgm選曲画面.nAutomationLevel_現在のサウンド;
		}
		private void tBGMフェードイン開始()
		{
			ctBGMフェードアウト用?.t停止();
			ctBGMフェードイン用 = new CCounter( 0, 100, 20, TJAPlayer3.Timer );
			ctBGMフェードイン用.n現在の値 = TJAPlayer3.Skin.bgm選曲画面.nAutomationLevel_現在のサウンド;
		}
		private void tプレビューサウンドの作成()
		{
			Cスコア cスコア = TJAPlayer3.stage選曲.r現在選択中のスコア;
			if( ( cスコア != null ) && !string.IsNullOrEmpty( cスコア.譜面情報.strBGMファイル名 ) && TJAPlayer3.stage選曲.eフェーズID != CStage.Eフェーズ.選曲_NowLoading画面へのフェードアウト )
			{
				string strPreviewFilename = cスコア.ファイル情報.フォルダの絶対パス + cスコア.譜面情報.Presound;
				try
                {
                    strPreviewFilename = cスコア.ファイル情報.フォルダの絶対パス + cスコア.譜面情報.strBGMファイル名;
					if(TJAPlayer3.ConfigIni.bBGM音を発声する)
                    sound = TJAPlayer3.Sound管理.tサウンドを生成する( strPreviewFilename, ESoundGroup.SongPlayback );

                    var loudnessMetadata = cスコア.譜面情報.SongLoudnessMetadata
                                           ?? LoudnessMetadataScanner.LoadForAudioPath(strPreviewFilename);
                    TJAPlayer3.SongGainController.Set( cスコア.譜面情報.SongVol, loudnessMetadata, sound );

                    sound.t再生を開始する( true );

                    if( long再生位置 == -1 )
                    {
                        long再生開始時のシステム時刻 = CSound管理.rc演奏用タイマ.nシステム時刻ms;
                        long再生位置 = cスコア.譜面情報.nデモBGMオフセット;
                        sound.t再生位置を変更する( cスコア.譜面情報.nデモBGMオフセット );
                        long再生位置 = CSound管理.rc演奏用タイマ.nシステム時刻ms - long再生開始時のシステム時刻;
                    }

                    str現在のファイル名 = strPreviewFilename;
                    tBGMフェードアウト開始();
                    Trace.TraceInformation( "プレビューサウンドを生成しました。({0})", strPreviewFilename );
                }
				catch (Exception e)
				{
					Trace.TraceError( e.ToString() );
					Trace.TraceError( "プレビューサウンドの生成に失敗しました。({0})", strPreviewFilename );
					sound?.Dispose();
					sound = null;
				}
			}
		}
		private void t進行処理_プレビューサウンド()
		{
			if( ( ct再生待ちウェイト != null ) && !ct再生待ちウェイト.b停止中 )
			{
				ct再生待ちウェイト.t進行();
				if( !ct再生待ちウェイト.b終了値に達してない )
				{
					ct再生待ちウェイト.t停止();
					if( !TJAPlayer3.stage選曲.bスクロール中 )
					{
                        tプレビューサウンドの作成();
					}
				}
			}
		}
		//-----------------
		#endregion
	}
}
