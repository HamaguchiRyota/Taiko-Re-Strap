using FDK;
using SharpDX;
using System;
using System.Diagnostics;
using System.Drawing;
using Rectangle = System.Drawing.Rectangle;

namespace TJAPlayer3
{
    internal class CActSelectArtistComment : CActivity
    {
        // メソッド

        public CActSelectArtistComment()
        {
            b活性化してない = true;
        }
        public void t選択曲が変更された()
        {
            Cスコア cスコア = TJAPlayer3.stage選曲.r現在選択中のスコア;
            if (cスコア != null)
            {
                Bitmap image = new Bitmap(1, 1);
                TJAPlayer3.tテクスチャの解放(ref txArtist);
                strArtist = cスコア.譜面情報.アーティスト名;
                if ((strArtist != null) && (strArtist.Length > 0))
                {
                    Graphics graphics = Graphics.FromImage(image);
                    graphics.PageUnit = GraphicsUnit.Pixel;
                    SizeF ef = graphics.MeasureString(strArtist, ft描画用フォント);
                    graphics.Dispose();
                    if (ef.Width > SampleFramework.GameWindowSize.Width)
                    {
                        ef.Width = SampleFramework.GameWindowSize.Width;
                    }
                    try
                    {
                        Bitmap bitmap2 = new Bitmap((int)Math.Ceiling((double)ef.Width), (int)Math.Ceiling((double)ft描画用フォント.Size));
                        graphics = Graphics.FromImage(bitmap2);
                        graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        graphics.DrawString(strArtist, ft描画用フォント, Brushes.White, (float)0f, (float)0f);
                        graphics.Dispose();
                        txArtist = new CTexture(TJAPlayer3.app.Device, bitmap2, TJAPlayer3.TextureFormat);
                        txArtist.vc拡大縮小倍率 = new Vector3(0.5f, 0.5f, 1f);
                        bitmap2.Dispose();
                    }
                    catch (CTextureCreateFailedException e)
                    {
                        Trace.TraceError(e.ToString());
                        Trace.TraceError("ARTISTテクスチャの生成に失敗しました。");
                        this.txArtist = null;
                    }
                }
                TJAPlayer3.tテクスチャの解放(ref txComment);
                //this.strComment = cスコア.譜面情報.コメント;
                strComment = cスコア.譜面情報.ジャンル;
                if ((strComment != null) && (strComment.Length > 0))
                {
                    Graphics graphics2 = Graphics.FromImage(image);
                    graphics2.PageUnit = GraphicsUnit.Pixel;
                    SizeF ef2 = graphics2.MeasureString(strComment, ft描画用フォント);
                    Size size = new Size((int)Math.Ceiling((double)ef2.Width), (int)Math.Ceiling((double)ef2.Height));
                    graphics2.Dispose();
                    nテクスチャの最大幅 = TJAPlayer3.app.Device.Capabilities.MaxTextureWidth;
                    int maxTextureHeight = TJAPlayer3.app.Device.Capabilities.MaxTextureHeight;
                    Bitmap bitmap3 = new Bitmap(size.Width, (int)Math.Ceiling((double)ft描画用フォント.Size));
                    graphics2 = Graphics.FromImage(bitmap3);
                    graphics2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    graphics2.DrawString(strComment, ft描画用フォント, Brushes.White, (float)0f, (float)0f);
                    graphics2.Dispose();
                    nComment行数 = 1;
                    nComment最終行の幅 = size.Width;
                    while (nComment最終行の幅 > nテクスチャの最大幅)
                    {
                        nComment行数++;
                        nComment最終行の幅 -= nテクスチャの最大幅;
                    }
                    while ((nComment行数 * ((int)Math.Ceiling((double)ft描画用フォント.Size))) > maxTextureHeight)
                    {
                        nComment行数--;
                        nComment最終行の幅 = nテクスチャの最大幅;
                    }
                    Bitmap bitmap4 = new Bitmap((nComment行数 > 1) ? nテクスチャの最大幅 : nComment最終行の幅, nComment行数 * ((int)Math.Ceiling((double)ft描画用フォント.Size)));
                    graphics2 = Graphics.FromImage(bitmap4);
                    Rectangle srcRect = new Rectangle();
                    Rectangle destRect = new Rectangle();
                    for (int i = 0; i < nComment行数; i++)
                    {
                        srcRect.X = i * nテクスチャの最大幅;
                        srcRect.Y = 0;
                        srcRect.Width = ((i + 1) == nComment行数) ? nComment最終行の幅 : nテクスチャの最大幅;
                        srcRect.Height = bitmap3.Height;
                        destRect.X = 0;
                        destRect.Y = i * bitmap3.Height;
                        destRect.Width = srcRect.Width;
                        destRect.Height = srcRect.Height;
                        graphics2.DrawImage(bitmap3, destRect, srcRect, GraphicsUnit.Pixel);
                    }
                    graphics2.Dispose();
                    try
                    {
                        txComment = new CTexture(TJAPlayer3.app.Device, bitmap4, TJAPlayer3.TextureFormat);
                        txComment.vc拡大縮小倍率 = new Vector3(0.5f, 0.5f, 1f);
                    }
                    catch (CTextureCreateFailedException e)
                    {
                        Trace.TraceError(e.ToString());
                        Trace.TraceError("COMMENTテクスチャの生成に失敗しました。");
                        txComment = null;
                    }
                    bitmap4.Dispose();
                    bitmap3.Dispose();
                }
                image.Dispose();
                if (txComment != null)
                {
                    ctComment = new CCounter(-740, (int)((((nComment行数 - 1) * nテクスチャの最大幅) + nComment最終行の幅) * txComment.vc拡大縮小倍率.X), 10, TJAPlayer3.Timer);
                }
            }
        }


        // CActivity 実装

        public override void On活性化()
        {
            ft描画用フォント = new Font("MS UI Gothic", 26f, GraphicsUnit.Pixel);
            txArtist = null;
            txComment = null;
            strArtist = "";
            strComment = "";
            nComment最終行の幅 = 0;
            nComment行数 = 0;
            nテクスチャの最大幅 = 0;
            ctComment = new CCounter();
            base.On活性化();
        }
        public override void On非活性化()
        {
            TJAPlayer3.tテクスチャの解放(ref txArtist);
            TJAPlayer3.tテクスチャの解放(ref txComment);
            if (ft描画用フォント != null)
            {
                ft描画用フォント.Dispose();
                ft描画用フォント = null;
            }
            ctComment = null;
            base.On非活性化();
        }
        public override void OnManagedリソースの作成()
        {
            if (!b活性化してない)
            {
                t選択曲が変更された();
                base.OnManagedリソースの作成();
            }
        }
        public override void OnManagedリソースの解放()
        {
            if (!b活性化してない)
            {
                TJAPlayer3.tテクスチャの解放(ref txArtist);
                TJAPlayer3.tテクスチャの解放(ref txComment);
                base.OnManagedリソースの解放();
            }
        }
        public override int On進行描画()
        {
            if (!b活性化してない)
            {
                if (ctComment.b進行中)
                {
                    ctComment.t進行Loop();
                }
                if (txArtist != null)
                {
                    int x = 1260 - ((int)(txArtist.szテクスチャサイズ.Width * txArtist.vc拡大縮小倍率.X));        // #27648 2012.3.14 yyagi: -12 for scrollbar
                    int y = 322;
                    txArtist?.t2D描画(TJAPlayer3.app.Device, x, y);
                }
                if ((txComment != null) && ((this.ctComment.n現在の値 + 750) >= 0))
                {
                    int num3 = 510;
                    int num4 = 342;
                    Rectangle rectangle = new Rectangle(this.ctComment.n現在の値, 0, 750, (int)this.ft描画用フォント.Size);
                    if (rectangle.X < 0)
                    {
                        num3 += -rectangle.X;
                        rectangle.Width -= -rectangle.X;
                        rectangle.X = 0;
                    }
                    int num5 = ((int)(((float)rectangle.X) / this.txComment.vc拡大縮小倍率.X)) / this.nテクスチャの最大幅;
                    Rectangle rectangle2 = new Rectangle();
                    while (rectangle.Width > 0)
                    {
                        rectangle2.X = ((int)(((float)rectangle.X) / this.txComment.vc拡大縮小倍率.X)) % this.nテクスチャの最大幅;
                        rectangle2.Y = num5 * ((int)this.ft描画用フォント.Size);
                        int num6 = ((num5 + 1) == this.nComment行数) ? this.nComment最終行の幅 : this.nテクスチャの最大幅;
                        int num7 = num6 - rectangle2.X;
                        rectangle2.Width = num7;
                        rectangle2.Height = (int)this.ft描画用フォント.Size;
                        txComment?.t2D描画(TJAPlayer3.app.Device, num3, num4, rectangle2);
                        if (++num5 == this.nComment行数)
                        {
                            break;
                        }
                        int num8 = (int)(rectangle2.Width * this.txComment.vc拡大縮小倍率.X);
                        rectangle.X += num8;
                        rectangle.Width -= num8;
                        num3 += num8;
                    }
                }
            }
            return 0;
        }


        // その他

        #region [ private ]
        //-----------------
        private CCounter ctComment;
        private Font ft描画用フォント;
        private int nComment行数;
        private int nComment最終行の幅;
        private const int nComment表示幅 = 750;
        private int nテクスチャの最大幅;
        private string strArtist;
        private string strComment;
        private CTexture txArtist;
        private CTexture txComment;
        //-----------------
        #endregion
    }
}
