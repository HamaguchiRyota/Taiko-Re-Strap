using FDK;
using System.Drawing;

namespace TJAPlayer3
{
    internal class CActResultSongBar : CActivity
    {
        // コンストラクタ

        public CActResultSongBar()
        {
            b活性化してない = true;
        }

        // CActivity 実装

        public override void On活性化()
        {
            if (!string.IsNullOrEmpty(TJAPlayer3.ConfigIni.FontName))
            {
                pfTitle = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), TJAPlayer3.Skin.Result_MusicName_FontSize);
                pfSubTitle = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 12);
                pfGaidenTitle = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 20);

            }
            else
            {
                pfTitle = new CPrivateFastFont(new FontFamily("MS UI Gothic"), TJAPlayer3.Skin.Result_MusicName_FontSize);
                pfSubTitle = new CPrivateFastFont(new FontFamily("MS UI Gothic"), 12);
                pfGaidenTitle = new CPrivateFastFont(new FontFamily("MS UI Gothic"), 20);
            }

            var title = TJAPlayer3.IsPerformingCalibration
                ? $"Calibration complete. InputAdjustTime is now {TJAPlayer3.ConfigIni.nInputAdjustTimeMs}ms"
                : TJAPlayer3.DTX.TITLE;

            var subtitle = TJAPlayer3.IsPerformingCalibration
                ? $"Calibration complete. InputAdjustTime is now {TJAPlayer3.ConfigIni.nInputAdjustTimeMs}ms"
                : TJAPlayer3.DTX.SUBTITLE;


            var Gaidentitle = TJAPlayer3.IsPerformingCalibration
                ? $"Calibration complete. InputAdjustTime is now {TJAPlayer3.ConfigIni.nInputAdjustTimeMs}ms"
                : TJAPlayer3.DTX.TITLE;


            this.txTitle = TJAPlayer3.tテクスチャの生成(pfTitle.DrawPrivateFont(title, Color.White, Color.Black));
            {
                this.txTitle.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref txTitle, 760);
                this.txTitle.vc拡大縮小倍率.Y = TJAPlayer3.GetSongNameXScaling(ref txTitle, 760);
            }
            this.txSubTitle = TJAPlayer3.tテクスチャの生成(pfSubTitle.DrawPrivateFont(subtitle, Color.White, Color.Black));
            {
                this.txSubTitle.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref txSubTitle, 760);
                this.txSubTitle.vc拡大縮小倍率.Y = TJAPlayer3.GetSongNameXScaling(ref txSubTitle, 760);
            }
            this.txGaidenTitle = TJAPlayer3.tテクスチャの生成(pfGaidenTitle.DrawPrivateFont(title, Color.White, Color.Black));
            {
                this.txGaidenTitle.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref txTitle, 760);
                this.txGaidenTitle.vc拡大縮小倍率.Y = TJAPlayer3.GetSongNameXScaling(ref txTitle, 760);
            }

            base.On活性化();
        }
        public override void On非活性化()
        {
            if (ct登場用 != null)
            {
                ct登場用 = null;
            }
            base.On非活性化();
        }
        public override void OnManagedリソースの作成()
        {
            if (!b活性化してない)
            {
                base.OnManagedリソースの作成();
            }
        }
        public override void OnManagedリソースの解放()
        {
            if (!b活性化してない)
            {
                TJAPlayer3.t安全にDisposeする(ref pfTitle);
                TJAPlayer3.tテクスチャの解放(ref txTitle);
                TJAPlayer3.t安全にDisposeする(ref pfSubTitle);
                TJAPlayer3.tテクスチャの解放(ref txSubTitle);
                TJAPlayer3.t安全にDisposeする(ref pfGaidenTitle);
                TJAPlayer3.tテクスチャの解放(ref txGaidenTitle);

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
                ct登場用 = new CCounter(0, 270, 4, TJAPlayer3.Timer);
                b初めての進行描画 = false;
            }
            ct登場用.t進行();

            if (TJAPlayer3.Skin.Result_MusicName_ReferencePoint == CSkin.ReferencePoint.Center && TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)
            {
                txTitle.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_MusicName_X - ((txTitle.szテクスチャサイズ.Width * txTitle.vc拡大縮小倍率.X) / 2), TJAPlayer3.Skin.Result_MusicName_Y);
                txSubTitle.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_MusicName_X - ((txSubTitle.szテクスチャサイズ.Width * txSubTitle.vc拡大縮小倍率.X) / 2), TJAPlayer3.Skin.Result_MusicName_Y + 50);
            }
            else if (TJAPlayer3.DTX.GENRE == "段位-外伝")
            {
                TJAPlayer3.Tx.Dani_Header?.t2D描画(TJAPlayer3.app.Device, 244, 18);

                txGaidenTitle.t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.Left, TJAPlayer3.Skin.Result_MusicName_X - ((txTitle.szテクスチャサイズ.Width * txTitle.vc拡大縮小倍率.X) / 2), TJAPlayer3.Skin.Result_MusicName_Y);
            }

            if (!ct登場用.b終了値に達した)
            {
                return 0;
            }
            return 1;
        }

        // その他

        #region [ private ]
        //-----------------
        private CCounter ct登場用;
        private CTexture txTitle;
        private CTexture txSubTitle;
        private CTexture txGaidenTitle;
        private CPrivateFastFont pfTitle;
        private CPrivateFastFont pfSubTitle;
        private CPrivateFastFont pfGaidenTitle;
        //-----------------
        #endregion
    }
}
