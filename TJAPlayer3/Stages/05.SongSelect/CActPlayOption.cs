using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using FDK;

namespace TJAPlayer3
{
    internal class CActPlayOption : CActivity
    {
        public CActPlayOption()
        {
            b活性化してない = true;
        }

        public override void On活性化()
        {
            if (b活性化してる)
                return;

            ctOpen = new CCounter();
            ctClose = new CCounter();

            for (int i = 0; i < OptionType.Length; i++)
                OptionType[i] = new CTexture();

            #region [ Speed ]

            txSpeed[0] = OptionTypeTx("0.5", Color.White, Color.Black);
            txSpeed[1] = OptionTypeTx("1.0", Color.White, Color.Black);
            txSpeed[2] = OptionTypeTx("1.1", Color.White, Color.Black);
            txSpeed[3] = OptionTypeTx("1.2", Color.White, Color.Black);
            txSpeed[4] = OptionTypeTx("1.3", Color.White, Color.Black);
            txSpeed[5] = OptionTypeTx("1.4", Color.White, Color.Black);
            txSpeed[6] = OptionTypeTx("1.5", Color.White, Color.Black);
            txSpeed[7] = OptionTypeTx("1.6", Color.White, Color.Black);
            txSpeed[8] = OptionTypeTx("1.7", Color.White, Color.Black);
            txSpeed[9] = OptionTypeTx("1.8", Color.White, Color.Black);
            txSpeed[10] = OptionTypeTx("1.9", Color.White, Color.Black);
            txSpeed[11] = OptionTypeTx("2.0", Color.White, Color.Black);
            txSpeed[12] = OptionTypeTx("2.5", Color.White, Color.Black);
            txSpeed[13] = OptionTypeTx("3.0", Color.White, Color.Black);
            txSpeed[14] = OptionTypeTx("3.5", Color.White, Color.Black);
            txSpeed[15] = OptionTypeTx("4.0", Color.White, Color.Black);


            #endregion

            txSwitch[0] = OptionTypeTx("しない", Color.White, Color.Black);
            txSwitch[1] = OptionTypeTx("する", Color.White, Color.Black);

            txRandom[0] = OptionTypeTx("なし", Color.White, Color.Black);
            txRandom[1] = OptionTypeTx("きまぐれ", Color.White, Color.Black);
            txRandom[2] = OptionTypeTx("でたらめ", Color.White, Color.Black);

            txStealth[0] = OptionTypeTx("なし", Color.White, Color.Black);
            txStealth[1] = OptionTypeTx("ノーツなし", Color.White, Color.Black);
            txStealth[2] = OptionTypeTx("ノーツ+SEなし ", Color.White, Color.Black);

            txGameMode[0] = OptionTypeTx("なし", Color.White, Color.Black);
            txGameMode[1] = OptionTypeTx("特訓モード", Color.White, Color.Black);

            txNone = OptionTypeTx("使用不可", Color.White, Color.Black);

            OptionType[0] = OptionTypeTx("はやさ", Color.White, Color.Black);
            OptionType[1] = OptionTypeTx("ドロン", Color.White, Color.Black);
            OptionType[2] = OptionTypeTx("あべこべ", Color.White, Color.Black);
            OptionType[3] = OptionTypeTx("ランダム", Color.White, Color.Black);
            OptionType[4] = OptionTypeTx("ゲームモード", Color.White, Color.Black);
            OptionType[5] = OptionTypeTx("オート", Color.White, Color.Black);
            OptionType[6] = OptionTypeTx("ボイス", Color.White, Color.Black);
            OptionType[7] = OptionTypeTx("音色", Color.White, Color.Black);

            for (int i = 0; i < OptionType.Length; i++)
                OptionType[i].vc拡大縮小倍率.X = 0.96f;

            base.On活性化();
        }

        public override void On非活性化()
        {
            base.On非活性化();
        }
        public override void OnManagedリソースの作成()
        {
            base.OnManagedリソースの作成();
        }
        public override void OnManagedリソースの解放()
        {
            if (this.b活性化してない)
                return;
            base.OnManagedリソースの解放();
        }

        public int On進行描画(int player)
        {
            if (b活性化してない)
                return 0;

            if (ctOpen.n現在の値 == 0)
                Init(player);

            ctOpen.t進行();
            ctClose.t進行();

            if (!ctOpen.b進行中) ctOpen.t開始(0, 50, 6, TJAPlayer3.Timer);

            var act難易度 = TJAPlayer3.stage選曲.act難易度選択画面;
            var danAct = TJAPlayer3.stage段位選択.段位挑戦選択画面;

            #region [ Open & Close ]

            float oy1 = ctOpen.n現在の値 * 18;
            float oy2 = (ctOpen.n現在の値 - 30) * 4;
            float oy3 = ctOpen.n現在の値 < 30 ? 410 - oy1 : -80 + oy2;

            float cy1 = ctClose.n現在の値 * 3;
            float cy2 = (ctClose.n現在の値 - 20) * 16;
            float cy3 = ctClose.n現在の値 < 20 ? 0 - cy1 : 20 + cy2;

            float y = oy3 + cy3;

            #endregion

            // Temporary textures, to reimplement to fit the new menu
            TJAPlayer3.Tx.Difficulty_Option?.t2D描画(TJAPlayer3.app.Device, 0, y);

            TJAPlayer3.Tx.Difficulty_Option_Select?.t2D描画(TJAPlayer3.app.Device, 0, y + NowCount * 40.7f);

            for (int i = 0; i < OptionType.Length; i++)
            {
                OptionType?[i].t2D描画(TJAPlayer3.app.Device, 16, 375 + i * 40.7f + y);
            }

            txSpeed[nSpeedCount].t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.Up, 200, 375 + y);
            txStealth[nStealth].t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.Up, 200, 375 + y + 1 * 40.7f);
            txSwitch[nAbekobe].t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.Up, 200, 375 + y + 2 * 40.7f);
            txRandom[nRandom].t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.Up, 200, 375 + y + 3 * 40.7f);
            txGameMode[nGameMode].t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.Up, 200, 375 + y + 4 * 40.7f);
            txSwitch[nAutoMode].t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.Up, 200, 375 + y + 5 * 40.7f);

            for (int i = 6; i < 8; i++)
            {
                txNone?.t2D拡大率考慮描画(TJAPlayer3.app.Device, CTexture.RefPnt.Up, 200, 375 + y + i * 40.7f);
            }

            if (ctClose.n現在の値 >= 50)
            {
                Decision(player);
                NowCount = 0;
                ctOpen.t停止();
                ctOpen.n現在の値 = 0;
                ctClose.t停止();
                ctClose.n現在の値 = 0;
                bEnd = false;
                act難易度.bOption[player] = false;
                danAct.bOption = false;
            }

            #region [ Key ]

            if (!ctClose.b進行中)
            {
                if (TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.LBlue)) { OptionSelect(true); TJAPlayer3.Skin.sound変更音.t再生する(); };
                if (TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.RBlue)) { OptionSelect(false); TJAPlayer3.Skin.sound変更音.t再生する(); };

                if ((TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.LRed) || TJAPlayer3.Pad.b押された(E楽器パート.DRUMS, Eパッド.RRed)) && ctOpen.n現在の値 >= ctOpen.n終了値)
                {
                    TJAPlayer3.Skin.sound決定音.t再生する();
                    if (NowCount < 7)
                    {
                        NowCount++;
                    }
                    else if (NowCount >= 7 && !bEnd)
                    {
                        bEnd = true;
                        ctClose.t開始(0, 50, 6, TJAPlayer3.Timer);
                    }
                }
            }


            #endregion

            return 0;
        }

        public int nOptionCount = 8;

        public CCounter ctOpen;
        public CCounter ctClose;
        public CTexture[] OptionType = new CTexture[8];

        public int NowCount;
        public int[] NowCountType = new int[8];

        public bool bEnd;

        public CTexture[] txSpeed = new CTexture[16];
        public int nSpeedCount = 1;

        public CTexture[] txStealth = new CTexture[3];
        public int nStealth = 0;
        public int nAbekobe = 0;

        public CTexture[] txRandom = new CTexture[3];
        public int nRandom = 0;

        public CTexture[] txGameMode = new CTexture[2];
        public int nGameMode;

        public CTexture[] txAutoMode = new CTexture[2];
        public int nAutoMode = 0;
        public CTexture txNone = new CTexture();

        public CTexture[] txSwitch = new CTexture[2];

        //public CTexture[] txTiming = new CTexture[5];
        //public int nTiming = 2;

        public CTexture OptionTypeTx(string str文字, Color forecolor, Color backcolor)
        {
            using (var bmp = new CPrivateFastFont(new FontFamily(TJAPlayer3.ConfigIni.FontName), 13).DrawPrivateFont(str文字, forecolor, backcolor))
            {
                return TJAPlayer3.tテクスチャの生成(bmp);
            }
        }

        private void ShiftVal(bool left, ref int value, int capUp, int capDown)
        {
            if (left)
            {
                if (value > capDown) value--;
                else value = capUp;
            }
            else
            {
                if (value < capUp) value++;
                else value = capDown;
            }
        }

        public void OptionSelect(bool left)
        {
            switch (NowCount)
            {
                case 0:
                    ShiftVal(left, ref nSpeedCount, 15, 0);
                    break;
                case 1:
                    ShiftVal(left, ref nStealth, 2, 0);
                    break;
                case 2:
                    if (nAbekobe == 0) nAbekobe = 1;
                    else nAbekobe = 0;
                    break;
                case 3:
                    ShiftVal(left, ref nRandom, 2, 0);
                    break;
                case 4:
                    if (nGameMode == 0) nGameMode = 1;
                    else nGameMode = 0;
                    break;
                case 5:
                    if (nAutoMode == 0) nAutoMode = 1;
                    else nAutoMode = 0;
                    break;

            }
        }

        public void Init(int player)
        {
            int actual = TJAPlayer3.GetActualPlayer(player);

            #region [ Speed ]

            int speed = TJAPlayer3.ConfigIni.nScrollSpeed[actual];
            nSpeedCount = GetSpeedCount(speed);

            #endregion

            #region [ Doron ]

            nStealth = (int)TJAPlayer3.ConfigIni.eSTEALTH;

            #endregion

            #region [ Random ]

            var rand_ = TJAPlayer3.ConfigIni.eRandom.Taiko;
            (nRandom, nAbekobe) = GetRandomValues(rand_);

            #endregion

            #region [ Timing ]

            //nTiming = TJAPlayer3.ConfigIni.nTimingZones[actual];

            #endregion

            #region [ GameMode ]

            nGameMode = TJAPlayer3.ConfigIni.bTokkunMode ? 1 : 0;

            #endregion

            #region [ AutoMode ]

            bool _auto = (player == 0) ? TJAPlayer3.ConfigIni.b太鼓パートAutoPlay : TJAPlayer3.ConfigIni.b太鼓パートAutoPlay2P;
            nAutoMode = _auto ? 1 : 0;

            #endregion
        }

        public void Decision(int player)
        {
            int actual = TJAPlayer3.GetActualPlayer(player);

            #region [ Speed ]

            int scrollSpeed = GetScrollSpeed(nSpeedCount);
            TJAPlayer3.ConfigIni.nScrollSpeed[actual] = scrollSpeed;

            #endregion

            #region [ Doron ]

            TJAPlayer3.ConfigIni.eSTEALTH = (Eステルスモード)nStealth;

            #endregion

            #region [ Random ]

            Eランダムモード randomMode = GetRandomMode(nRandom, nAbekobe);
            TJAPlayer3.ConfigIni.eRandom.Taiko = randomMode;

            #endregion

            #region [ Timing ]

            //TJAPlayer3.ConfigIni.nTimingZones[actual] = nTiming;

            #endregion

            #region [ GameMode ]

            TJAPlayer3.ConfigIni.bTokkunMode = (nGameMode == 1);

            #endregion

            #region [ AutoMode ]

            bool autoMode = (nAutoMode == 1);
            if (player == 0)
                TJAPlayer3.ConfigIni.b太鼓パートAutoPlay = autoMode;
            else
                TJAPlayer3.ConfigIni.b太鼓パートAutoPlay2P = autoMode;

            #endregion
        }

        private int GetSpeedCount(int speed)
        {
            if (speed <= 4)
                return 0;
            else if (speed <= 19)
                return speed - 8;
            else if (speed <= 24)
                return 12;
            else if (speed <= 29)
                return 13;
            else if (speed <= 34)
                return 14;
            else
                return 15;
        }

        private int GetScrollSpeed(int speedCount)
        {
            if (speedCount == 0)
                return 4;
            else if (speedCount <= 11)
                return speedCount + 8;
            else if (speedCount == 12)
                return 24;
            else if (speedCount == 13)
                return 29;
            else if (speedCount == 14)
                return 34;
            else
                return 39;
        }

        private (int, int) GetRandomValues(Eランダムモード randomMode)
        {
            int nRandom, nAbekobe;

            switch (randomMode)
            {
                case Eランダムモード.HYPERRANDOM:
                    nRandom = 2;
                    nAbekobe = 1;
                    break;
                case Eランダムモード.SUPERRANDOM:
                    nRandom = 2;
                    nAbekobe = 0;
                    break;
                case Eランダムモード.RANDOM:
                    nRandom = 1;
                    nAbekobe = 0;
                    break;
                case Eランダムモード.MIRROR:
                    nRandom = 0;
                    nAbekobe = 1;
                    break;
                case Eランダムモード.OFF:
                    nRandom = 0;
                    nAbekobe = 0;
                    break;
                default:
                    nRandom = 0;
                    nAbekobe = 0;
                    break;
            }

            return (nRandom, nAbekobe);
        }

        private Eランダムモード GetRandomMode(int nRandom, int nAbekobe)
        {
            if (nRandom == 2 && nAbekobe == 1)
                return Eランダムモード.HYPERRANDOM;
            else if (nRandom == 2 && nAbekobe == 0)
                return Eランダムモード.SUPERRANDOM;
            else if (nRandom == 1 && nAbekobe == 1)
                return Eランダムモード.RANDOM;
            else if (nRandom == 1 && nAbekobe == 0)
                return Eランダムモード.RANDOM;
            else if (nRandom == 0 && nAbekobe == 1)
                return Eランダムモード.MIRROR;
            else
                return Eランダムモード.OFF;
        }


    }
}
