using FDK;
using System.Drawing;

namespace TJAPlayer3
{
    class CNamePlate
    {
        public CNamePlate()
        {
            for (int player = 0; player < 2; player++)
            {
                if (TJAPlayer3.NamePlateConfig.data.TitleType[player] < 0) TJAPlayer3.NamePlateConfig.data.TitleType[player] = 0;
                else if (TJAPlayer3.NamePlateConfig.data.TitleType[player] > 2) TJAPlayer3.NamePlateConfig.data.TitleType[player] = 2;

                if (!string.IsNullOrEmpty(TJAPlayer3.ConfigIni.FontName))
                {
                    if (TJAPlayer3.NamePlateConfig.data.Title[player] == "" || TJAPlayer3.NamePlateConfig.data.Title[player] == null)
                        pfName = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 15);
                    else
                        pfName = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 12);

                    pfTitle = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 11);
                }
                else
                {
                    if (TJAPlayer3.NamePlateConfig.data.Title[player] == "" || TJAPlayer3.NamePlateConfig.data.Title[player] == null)
                        pfName = new CPrivateFastFont(new FontFamily("MS UI Gothic"), 15);
                    else
                        pfName = new CPrivateFastFont(new FontFamily("MS UI Gothic"), 12);

                    pfTitle = new CPrivateFastFont(new FontFamily("MS UI Gothic"), 11);
                }

                using (var tex = pfName.DrawPrivateFont(TJAPlayer3.NamePlateConfig.data.Name[player], Color.White, Color.Black, 25))
                    txName[player] = TJAPlayer3.tテクスチャの生成(tex);

                using (var tex = pfTitle.DrawPrivateFont(TJAPlayer3.NamePlateConfig.data.Title[player], Color.Black, Color.Empty))
                    txTitle[player] = TJAPlayer3.tテクスチャの生成(tex);

            }

            ctNamePlateEffect = new CCounter(0, 120, 16.6f, TJAPlayer3.Timer);
        }

        public void tNamePlateDraw(int x, int y, int player, bool bTitle = false, int Opacity = 255)
        {
            ctNamePlateEffect.t進行Loop();

            txName[player].Opacity = Opacity;
            txTitle[player].Opacity = Opacity;
            TJAPlayer3.Tx.NamePlateBase.Opacity = Opacity;
            for (int i = 0; i < 5; i++)
                TJAPlayer3.Tx.NamePlate_Effect[i].Opacity = Opacity;

            if (bTitle)
            {
                //220, 54
                TJAPlayer3.Tx.NamePlateBase?.t2D描画(TJAPlayer3.app.Device, x, y, new RectangleF(0, 3 * 54, 220, 54));

                //ここが称号背景
                if (TJAPlayer3.NamePlateConfig.data.Dan[player] != "" && TJAPlayer3.NamePlateConfig.data.Dan[player] != null)
                {
                    if (TJAPlayer3.NamePlateConfig.data.Title[player] != "" && TJAPlayer3.NamePlateConfig.data.Title[player] != null) 
                        TJAPlayer3.Tx.NamePlateBase.t2D描画(TJAPlayer3.app.Device, x, y, new RectangleF(0, (4 + TJAPlayer3.NamePlateConfig.data.TitleType[player]) * 54, 220, 54));
                }

                tNamePlateDraw(player, x, y);
  
                if (TJAPlayer3.NamePlateConfig.data.Dan[player] != "" && TJAPlayer3.NamePlateConfig.data.Dan[player] != null)
                {
                    if (txName[player].szテクスチャサイズ.Width >= 120.0f)
                        txName[player].vc拡大縮小倍率.X = 120.0f / txName[player].szテクスチャサイズ.Width;
                }
                else
                {
                    if (txName[player].szテクスチャサイズ.Width >= 220.0f)
                        txName[player].vc拡大縮小倍率.X = 220.0f / txName[player].szテクスチャサイズ.Width;
                }

                if (TJAPlayer3.NamePlateConfig.data.Title[player] != "" && TJAPlayer3.NamePlateConfig.data.Title[player] != null)
                {
                    if (txTitle[player].szテクスチャサイズ.Width >= 160)
                    {
                        txTitle[player].vc拡大縮小倍率.X = 160.0f / txTitle[player].szテクスチャサイズ.Width;
                        txTitle[player].vc拡大縮小倍率.Y = 160.0f / txTitle[player].szテクスチャサイズ.Width;
                    }

                    txTitle[player].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 115 + TJAPlayer3.Skin.UserConfig_NamePlateTitleOffset_X, y + 19 + TJAPlayer3.Skin.UserConfig_NamePlateTitleOffset_Y);
                    if (TJAPlayer3.NamePlateConfig.data.Dan[player] == "" || TJAPlayer3.NamePlateConfig.data.Dan[player] == null)
                        txName[player].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 100 + TJAPlayer3.Skin.UserConfig_NamePlateNameOffset_X, y + 45 + TJAPlayer3.Skin.UserConfig_NamePlateNameOffset_Y);
                    else
                        txName[player].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 115 + TJAPlayer3.Skin.UserConfig_NamePlateNameOffset_X, y + 45 + TJAPlayer3.Skin.UserConfig_NamePlateNameOffset_Y);
                }
                else
                    txName[player].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 121 + TJAPlayer3.Skin.UserConfig_NamePlateNameOffset_X, y + 36 + TJAPlayer3.Skin.UserConfig_NamePlateNameOffset_Y);
            }
            else
            {
                //220, 54
                TJAPlayer3.Tx.NamePlateBase.t2D描画(TJAPlayer3.app.Device, x, y, new RectangleF(0, 3 * 54, 220, 54));

                if (TJAPlayer3.NamePlateConfig.data.Dan[player] != "" && TJAPlayer3.NamePlateConfig.data.Dan[player] != null)
                {
                    if (TJAPlayer3.NamePlateConfig.data.Title[player] != "" && TJAPlayer3.NamePlateConfig.data.Title[player] != null)
                        TJAPlayer3.Tx.NamePlateBase.t2D描画(TJAPlayer3.app.Device, x, y, new RectangleF(0, (4 + TJAPlayer3.NamePlateConfig.data.TitleType[player]) * 54, 220, 54));
                }

                tNamePlateDraw(player, x, y);

                TJAPlayer3.Tx.NamePlateBase.t2D描画(TJAPlayer3.app.Device, x, y, new RectangleF(0, player == 1 ? 2 * 54 : 0, 220, 54));

                if (TJAPlayer3.NamePlateConfig.data.Dan[player] != "" && TJAPlayer3.NamePlateConfig.data.Dan[player] != null)
                {
                    if (txName[player].szテクスチャサイズ.Width >= 120.0f)
                        txName[player].vc拡大縮小倍率.X = 120.0f / txName[player].szテクスチャサイズ.Width;
                }
                else
                {
                    if (txName[player].szテクスチャサイズ.Width >= 220.0f)
                        txName[player].vc拡大縮小倍率.X = 220.0f / txName[player].szテクスチャサイズ.Width;
                }

                if (TJAPlayer3.NamePlateConfig.data.Title[player] != "" && TJAPlayer3.NamePlateConfig.data.Title[player] != null)
                {
                    if (txTitle[player].szテクスチャサイズ.Width >= 160)
                    {
                        txTitle[player].vc拡大縮小倍率.X = 160.0f / txTitle[player].szテクスチャサイズ.Width;
                        txTitle[player].vc拡大縮小倍率.Y = 160.0f / txTitle[player].szテクスチャサイズ.Width;
                    }

                    txTitle[player].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 124 + TJAPlayer3.Skin.UserConfig_NamePlateTitleOffset_X, y + 20 + TJAPlayer3.Skin.UserConfig_NamePlateTitleOffset_Y);
                    if (TJAPlayer3.NamePlateConfig.data.Dan[player] == "" || TJAPlayer3.NamePlateConfig.data.Dan[player] == null)//124.144,144,122
                        txName[player].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 124 + TJAPlayer3.Skin.UserConfig_NamePlateNameOffset_X, y + 44 + TJAPlayer3.Skin.UserConfig_NamePlateNameOffset_Y);
                    else
                        txName[player].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 124 + TJAPlayer3.Skin.UserConfig_NamePlateNameOffset_X, y + 44 + TJAPlayer3.Skin.UserConfig_NamePlateNameOffset_Y);
                }
                else
                    txName[player].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 124 + TJAPlayer3.Skin.UserConfig_NamePlateNameOffset_X, y + 36 + TJAPlayer3.Skin.UserConfig_NamePlateNameOffset_Y);
            }
        }

        private void tNamePlateDraw(int player, int x, int y)
        {
            if(TJAPlayer3.NamePlateConfig.data.TitleType[player] != 0 && TJAPlayer3.NamePlateConfig.data.Title[player] != "")
            {
                int Type = TJAPlayer3.NamePlateConfig.data.TitleType[player] - 1;
                if (ctNamePlateEffect.n現在の値 <= 10)
                {
                    tNamePlateStarDraw(player, 1.0f - (ctNamePlateEffect.n現在の値 / 10f * 1.0f), x + 63, y + 25);
                }
                if (ctNamePlateEffect.n現在の値 >= 3 && ctNamePlateEffect.n現在の値 <= 10)
                {
                    tNamePlateStarDraw(player, 1.0f - ((ctNamePlateEffect.n現在の値 - 3) / 7f * 1.0f), x + 38, y + 7);
                }
                if (ctNamePlateEffect.n現在の値 >= 6 && ctNamePlateEffect.n現在の値 <= 10)
                {
                    tNamePlateStarDraw(player, 1.0f - ((ctNamePlateEffect.n現在の値 - 6) / 4f * 1.0f), x + 51, y + 5);
                }
                if (ctNamePlateEffect.n現在の値 >= 8 && ctNamePlateEffect.n現在の値 <= 10)
                {
                    tNamePlateStarDraw(player, 0.3f - ((ctNamePlateEffect.n現在の値 - 8) / 2f * 0.3f), x + 110, y + 25);
                }
                if (ctNamePlateEffect.n現在の値 >= 11 && ctNamePlateEffect.n現在の値 <= 13)
                {
                    tNamePlateStarDraw(player, 1.0f - ((ctNamePlateEffect.n現在の値 - 11) / 2f * 1.0f), x + 38, y + 7);
                }
                if (ctNamePlateEffect.n現在の値 >= 11 && ctNamePlateEffect.n現在の値 <= 15)
                {
                    tNamePlateStarDraw(player, 1.0f, x + 51, y + 5);
                }
                if (ctNamePlateEffect.n現在の値 >= 11 && ctNamePlateEffect.n現在の値 <= 17)
                {
                    tNamePlateStarDraw(player, 1.0f - ((ctNamePlateEffect.n現在の値 - 11) / 7f * 1.0f), x + 110, y + 25);
                }
                if (ctNamePlateEffect.n現在の値 >= 16 && ctNamePlateEffect.n現在の値 <= 20)
                {
                    tNamePlateStarDraw(player, 0.2f - ((ctNamePlateEffect.n現在の値 - 16) / 4f * 0.2f), x + 63, y + 25);
                }
                if (ctNamePlateEffect.n現在の値 >= 17 && ctNamePlateEffect.n現在の値 <= 20)
                {
                    tNamePlateStarDraw(player, 1.0f - ((ctNamePlateEffect.n現在の値 - 17) / 3f * 1.0f), x + 99, y + 1);
                }
                if (ctNamePlateEffect.n現在の値 >= 20 && ctNamePlateEffect.n現在の値 <= 24)
                {
                    tNamePlateStarDraw(player, 0.4f, x + 63, y + 25);
                }
                if (ctNamePlateEffect.n現在の値 >= 20 && ctNamePlateEffect.n現在の値 <= 25)
                {
                    tNamePlateStarDraw(player, 1.0f, x + 99, y + 1);
                }
                if (ctNamePlateEffect.n現在の値 >= 20 && ctNamePlateEffect.n現在の値 <= 30)
                {
                    tNamePlateStarDraw(player, 0.5f - ((this.ctNamePlateEffect.n現在の値 - 20) / 10f * 0.5f), x + 152, y + 7);
                }
                if (ctNamePlateEffect.n現在の値 >= 31 && ctNamePlateEffect.n現在の値 <= 37)
                {
                    tNamePlateStarDraw(player, 0.5f - ((this.ctNamePlateEffect.n現在の値 - 31) / 6f * 0.5f), x + 176, y + 8);
                    tNamePlateStarDraw(player, 1.0f - ((this.ctNamePlateEffect.n現在の値 - 31) / 6f * 1.0f), x + 175, y + 25);
                }
                if (ctNamePlateEffect.n現在の値 >= 31 && ctNamePlateEffect.n現在の値 <= 40)
                {
                    tNamePlateStarDraw(player, 0.9f - ((this.ctNamePlateEffect.n現在の値 - 31) / 9f * 0.9f), x + 136, y + 24);
                }
                if (ctNamePlateEffect.n現在の値 >= 34 && ctNamePlateEffect.n現在の値 <= 40)
                {
                    tNamePlateStarDraw(player, 0.7f - ((this.ctNamePlateEffect.n現在の値 - 34) / 6f * 0.7f), x + 159, y + 25);
                }
                if (ctNamePlateEffect.n現在の値 >= 41 && ctNamePlateEffect.n現在の値 <= 42)
                {
                    tNamePlateStarDraw(player, 0.7f, x + 159, y + 25);
                }
                if (ctNamePlateEffect.n現在の値 >= 43 && ctNamePlateEffect.n現在の値 <= 50)
                {
                    tNamePlateStarDraw(player, 0.8f - ((this.ctNamePlateEffect.n現在の値 - 43) / 7f * 0.8f), x + 196, y + 23);
                }
                if (ctNamePlateEffect.n現在の値 >= 51 && ctNamePlateEffect.n現在の値 <= 57)
                {
                    tNamePlateStarDraw(player, 0.8f - ((this.ctNamePlateEffect.n現在の値 - 51) / 6f * 0.8f), x + 51, y + 5);
                }
                if (ctNamePlateEffect.n現在の値 >= 51 && ctNamePlateEffect.n現在の値 <= 52)
                {
                    tNamePlateStarDraw(player, 0.2f, x + 166, y + 22);
                }
                if (ctNamePlateEffect.n現在の値 >= 51 && ctNamePlateEffect.n現在の値 <= 53)
                {
                    tNamePlateStarDraw(player, 0.8f, x + 136, y + 24);
                }
                if (ctNamePlateEffect.n現在の値 >= 51 && ctNamePlateEffect.n現在の値 <= 55)
                {
                    tNamePlateStarDraw(player, 1.0f, x + 176, y + 8);
                }
                if (ctNamePlateEffect.n現在の値 >= 51 && ctNamePlateEffect.n現在の値 <= 55)
                {
                    tNamePlateStarDraw(player, 1.0f, x + 176, y + 8);
                }
                if (ctNamePlateEffect.n現在の値 >= 61 && ctNamePlateEffect.n現在の値 <= 70)
                {
                    tNamePlateStarDraw(player, 1.0f - ((this.ctNamePlateEffect.n現在の値 - 61) / 9f * 1.0f), x + 196, y + 23);
                }
                if (ctNamePlateEffect.n現在の値 >= 61 && ctNamePlateEffect.n現在の値 <= 67)
                {
                    tNamePlateStarDraw(player, 0.7f - ((this.ctNamePlateEffect.n現在の値 - 61) / 6f * 0.7f), x + 214, y + 14);
                }
                if (ctNamePlateEffect.n現在の値 >= 63 && ctNamePlateEffect.n現在の値 <= 70)
                {
                    tNamePlateStarDraw(player, 0.5f - ((this.ctNamePlateEffect.n現在の値 - 63) / 7f * 0.5f), x + 129, y + 24);
                }
                if (ctNamePlateEffect.n現在の値 >= 63 && ctNamePlateEffect.n現在の値 <= 70)
                {
                    tNamePlateStarDraw(player, 0.5f - ((this.ctNamePlateEffect.n現在の値 - 63) / 7f * 0.5f), x + 129, y + 24);
                }
                if (ctNamePlateEffect.n現在の値 >= 65 && ctNamePlateEffect.n現在の値 <= 70)
                {
                    tNamePlateStarDraw(player, 0.8f - ((this.ctNamePlateEffect.n現在の値 - 65) / 5f * 0.8f), x + 117, y + 7);
                }
                if (ctNamePlateEffect.n現在の値 >= 71 && ctNamePlateEffect.n現在の値 <= 72)
                {
                    tNamePlateStarDraw(player, 0.8f, x + 151, y + 25);
                }
                if (ctNamePlateEffect.n現在の値 >= 71 && ctNamePlateEffect.n現在の値 <= 74)
                {
                    tNamePlateStarDraw(player, 0.8f, x + 117, y + 7);
                }
                if (ctNamePlateEffect.n現在の値 >= 85 && ctNamePlateEffect.n現在の値 <= 112)
                {
                    TJAPlayer3.Tx.NamePlate_Effect[4].Opacity = (int)(1400 - (this.ctNamePlateEffect.n現在の値 - 85) * 50f);
                    TJAPlayer3.Tx.NamePlate_Effect[4].t2D描画(TJAPlayer3.app.Device, x + ((this.ctNamePlateEffect.n現在の値 - 85) * (150f / 27f)), y + 7);
                }
                if (ctNamePlateEffect.n現在の値 >= 105 && ctNamePlateEffect.n現在の値 <= 120)
                {
                    TJAPlayer3.Tx.NamePlate_Effect[TJAPlayer3.NamePlateConfig.data.TitleType[player] + 1].Opacity = this.ctNamePlateEffect.n現在の値 >= 112 ? (int)(255 - (this.ctNamePlateEffect.n現在の値 - 112) * 31.875f) : 255;
                    TJAPlayer3.Tx.NamePlate_Effect[TJAPlayer3.NamePlateConfig.data.TitleType[player] + 1].vc拡大縮小倍率.X = this.ctNamePlateEffect.n現在の値 >= 112 ? 1.0f : (this.ctNamePlateEffect.n現在の値 - 105) / 8f;
                    TJAPlayer3.Tx.NamePlate_Effect[TJAPlayer3.NamePlateConfig.data.TitleType[player] + 1].vc拡大縮小倍率.Y = this.ctNamePlateEffect.n現在の値 >= 112 ? 1.0f : (this.ctNamePlateEffect.n現在の値 - 105) / 8f;
                    TJAPlayer3.Tx.NamePlate_Effect[TJAPlayer3.NamePlateConfig.data.TitleType[player] + 1].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x + 193, y + 6);
                }
            }
        }

        private void tNamePlateStarDraw(int player, float Scale, int x, int y)
        {
            TJAPlayer3.Tx.NamePlate_Effect[TJAPlayer3.NamePlateConfig.data.TitleType[player] - 1].vc拡大縮小倍率.X = Scale;
            TJAPlayer3.Tx.NamePlate_Effect[TJAPlayer3.NamePlateConfig.data.TitleType[player] - 1].vc拡大縮小倍率.Y = Scale;
            TJAPlayer3.Tx.NamePlate_Effect[TJAPlayer3.NamePlateConfig.data.TitleType[player] - 1].t2D拡大率考慮中央基準描画(TJAPlayer3.app.Device, x, y);
        }

        private CPrivateFastFont pfName;
        private CPrivateFastFont pfTitle;
        //private CPrivateFastFont pfdan;
        private CCounter ctNamePlateEffect;
        private CTexture[] txName = new CTexture[2];
        private CTexture[] txTitle = new CTexture[2];
        //private CTexture[] txdan = new CTexture[2];
    }
}
