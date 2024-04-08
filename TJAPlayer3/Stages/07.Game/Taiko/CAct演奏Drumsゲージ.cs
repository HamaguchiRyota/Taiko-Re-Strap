using FDK;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TJAPlayer3
{
    internal class CAct演奏Drumsゲージ : CAct演奏ゲージ共通
    {
        // プロパティ


        // コンストラクタ
        /// <summary>
        /// ゲージの描画クラス。ドラム側。
        /// 
        /// 課題
        /// _ゲージの実装。
        /// _Danger時にゲージの色が変わる演出の実装。
        /// _Danger、MAX時のアニメーション実装。
        /// </summary>
        public CAct演奏Drumsゲージ()
        {
            base.b活性化してない = true;
        }

        public override void Start(int nLane, E判定 judge, int player)
        {
            for (int j = 0; j < 32; j++)
            {
                if (player == 0)
                {
                    if (!this.st花火状態[j].b使用中)
                    {
                        this.st花火状態[j].ct進行 = new CCounter(0, 10, 20, TJAPlayer3.Timer);
                        this.st花火状態[j].nPlayer = player;

                        switch (nLane)
                        {
                            case 0x11:
                            case 0x12:
                            case 0x15:
                                this.st花火状態[j].isBig = false;
                                break;
                            case 0x13:
                            case 0x14:
                            case 0x16:
                            case 0x17:
                                this.st花火状態[j].isBig = true;
                                break;
                        }
                        this.st花火状態[j].nLane = nLane;

                        this.st花火状態[j].b使用中 = true;
                        break;
                    }
                }
                if (player == 1)
                {
                    if (!this.st花火状態2P[j].b使用中)
                    {
                        this.st花火状態2P[j].ct進行 = new CCounter(0, 10, 20, TJAPlayer3.Timer);
                        this.st花火状態2P[j].nPlayer = player;

                        switch (nLane)
                        {
                            case 0x11:
                            case 0x12:
                            case 0x15:
                                this.st花火状態2P[j].isBig = false;
                                break;
                            case 0x13:
                            case 0x14:
                            case 0x16:
                            case 0x17:
                                this.st花火状態2P[j].isBig = true;
                                break;
                        }
                        this.st花火状態2P[j].nLane = nLane;
                        this.st花火状態2P[j].b使用中 = true;
                        break;
                    }
                }
            }
        }

        // CActivity 実装

        public override void On活性化()
        {
            for (int i = 0; i < 32; i++)
            {
                this.st花火状態[i].ct進行 = new CCounter();
                this.st花火状態2P[i].ct進行 = new CCounter();

            }
            this.ct炎 = new CCounter(0, 6, 50, TJAPlayer3.Timer);
            ctSoul = new CCounter();
            base.On活性化();
        }
        public override void On非活性化()
        {
            for (int i = 0; i < 32; i++)
            {
                this.st花火状態[i].ct進行 = null;
                this.st花火状態2P[i].ct進行 = null;
            }
            ct炎 = null;
            ctSoul = null;
        }
        public override void OnManagedリソースの作成()
        {
            if (!base.b活性化してない)
            {
                if (TJAPlayer3.Skin.Game_Gauge_Rainbow_Timer <= 1)
                {
                    throw new DivideByZeroException("SkinConfigの設定\"Game_Gauge_Rainbow_Timer\"を1以下にすることは出来ません。");
                }
                this.ct虹アニメ = new CCounter(0, TJAPlayer3.Skin.Game_Gauge_Rainbow_Ptn - 1, TJAPlayer3.Skin.Game_Gauge_Rainbow_Timer, TJAPlayer3.Timer);
                this.ct虹透明度 = new CCounter(0, TJAPlayer3.Skin.Game_Gauge_Rainbow_Timer - 1, 1, TJAPlayer3.Timer);
                this.ctGaugeFlash = new CCounter(0, 532, 1, TJAPlayer3.Timer);
                this.ctCharaEf = new CCounter(0, 100, 17, TJAPlayer3.Timer);
                this.ctSoulFlash = new CCounter(0, 8, 33, TJAPlayer3.Timer);
                base.OnManagedリソースの作成();
            }
        }
        public override void OnManagedリソースの解放()
        {
            if (!base.b活性化してない)
            {
                this.ct虹アニメ = null;
                base.OnManagedリソースの解放();
            }
        }
        public override int On進行描画()
        {
            if (!base.b活性化してない)
            {

                #region [ 初めての進行描画 ]
                if (base.b初めての進行描画)
                {
                    base.b初めての進行描画 = false;
                }
                #endregion

                this.ctGaugeFlash.t進行Loop();
                this.ctCharaEf.t進行Loop();
                this.ctSoulFlash.t進行Loop();

                int nRectX2P = (int)(this.db現在のゲージ値[1] / 2) * 14;
                int nRectX = (int)(this.db現在のゲージ値[0] / 2) * 14;
                int 虹ベース = ct虹アニメ.n現在の値 + 1;
                if (虹ベース == ct虹アニメ.n終了値 + 1) 虹ベース = 0;

                if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan)
                {
                    TJAPlayer3.Tx.Gauge_Dan[0]?.t2D描画(TJAPlayer3.app.Device, 492, 144, new Rectangle(0, 0, 700, 44));
                    if (TJAPlayer3.Tx.Gauge_Dan[2] != null)
                    {
                        for (int i = 0; i < TJAPlayer3.DTX.Dan_C.Length; i++)
                        {
                            if (TJAPlayer3.DTX.Dan_C[i] != null)
                            {
                                if (TJAPlayer3.DTX.Dan_C[i].GetExamType() == Exam.Type.Gauge)
                                {
                                    TJAPlayer3.Tx.Gauge_Dan[2].t2D描画(TJAPlayer3.app.Device, 492 + (TJAPlayer3.DTX.Dan_C[i].GetValue(false) / 2 * 14), 144, new Rectangle((TJAPlayer3.DTX.Dan_C[i].GetValue(false) / 2 * 14), 0, 700 - (TJAPlayer3.DTX.Dan_C[i].GetValue(false) / 2 * 14), 44));
                                }
                            }
                        }
                    }
                }
                else
                {
                    TJAPlayer3.Tx.Gauge_Base[0]?.t2D描画(TJAPlayer3.app.Device, 492, 144, new Rectangle(0, 0, 700, 44));
                    if (TJAPlayer3.stage演奏ドラム画面.bDoublePlay && TJAPlayer3.Tx.Gauge_Base[1] != null)
                    {
                        TJAPlayer3.Tx.Gauge_Base[1].t2D描画(TJAPlayer3.app.Device, 492, 532, new Rectangle(0, 0, 700, 44));
                    }
                }
                #region[ ゲージ1P ]
                if (TJAPlayer3.Tx.Gauge[0] != null)
                {
                    if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan)
                    {
                        TJAPlayer3.Tx.Gauge_Dan[1]?.t2D描画(TJAPlayer3.app.Device, 492, 144, new Rectangle(0, 0, nRectX, 44));
                    }
                    else
                    {
                        TJAPlayer3.Tx.Gauge[0].t2D描画(TJAPlayer3.app.Device, 492, 144, new Rectangle(0, 0, nRectX, 44));
                    }

                    if (db現在のゲージ値[0] >= 80.0 && db現在のゲージ値[0] < 100.0)
                    {
                        int Opacity = 0;
                        if (this.ctGaugeFlash.n現在の値 <= 365) Opacity = 0;
                        else if (this.ctGaugeFlash.n現在の値 <= 448) Opacity = (int)((this.ctGaugeFlash.n現在の値 - 365) / 83f * 255f);
                        else if (this.ctGaugeFlash.n現在の値 <= 531) Opacity = 255 - (int)((this.ctGaugeFlash.n現在の値 - 448) / 83f * 255f);

                        if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)
                        {
                            TJAPlayer3.Tx.Gauge_Flash.Opacity = Opacity;
                            TJAPlayer3.Tx.Gauge_Flash.t2D描画(TJAPlayer3.app.Device, 492, 144);
                        }
                    }
                    if (TJAPlayer3.Tx.Gauge_Line[0] != null)
                    {
                        if (this.db現在のゲージ値[0] >= 100.0)
                        {
                            this.ct虹アニメ.t進行Loop();
                            this.ct虹透明度.t進行Loop();

                            if (TJAPlayer3.Tx.Gauge_Rainbow[this.ct虹アニメ.n現在の値] != null)
                            {
                                TJAPlayer3.Tx.Gauge_Rainbow[this.ct虹アニメ.n現在の値].Opacity = 255;
                                TJAPlayer3.Tx.Gauge_Rainbow[this.ct虹アニメ.n現在の値].t2D描画(TJAPlayer3.app.Device, 492, 144 + (TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan ? 22 : 0),
                                    new RectangleF(0,
                                    TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan ? 22 : 0,
                                    TJAPlayer3.Tx.Gauge_Rainbow[this.ct虹アニメ.n現在の値].szテクスチャサイズ.Width,
                                    TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan ? TJAPlayer3.Tx.Gauge_Rainbow[this.ct虹アニメ.n現在の値].szテクスチャサイズ.Height - 22 : TJAPlayer3.Tx.Gauge_Rainbow[this.ct虹アニメ.n現在の値].szテクスチャサイズ.Height));
                                TJAPlayer3.Tx.Gauge_Rainbow[虹ベース].Opacity = (ct虹透明度.n現在の値 * 255 / (int)ct虹透明度.n終了値) / 1;
                                TJAPlayer3.Tx.Gauge_Rainbow[虹ベース].t2D描画(TJAPlayer3.app.Device, 492, 144 + (TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan ? 22 : 0),
                                    new RectangleF(0,
                                    TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan ? 22 : 0,
                                    TJAPlayer3.Tx.Gauge_Rainbow[虹ベース].szテクスチャサイズ.Width,
                                    TJAPlayer3.stage選曲.n確定された曲の難易度[0] == (int)Difficulty.Dan ? TJAPlayer3.Tx.Gauge_Rainbow[虹ベース].szテクスチャサイズ.Height - 22 : TJAPlayer3.Tx.Gauge_Rainbow[虹ベース].szテクスチャサイズ.Height));
                            }


                        }
                        TJAPlayer3.Tx.Gauge_Line[0].t2D描画(TJAPlayer3.app.Device, 492, 144);
                    }
                    #region[ 「クリア」文字 ]
                    if (TJAPlayer3.stage選曲.n確定された曲の難易度[0] != (int)Difficulty.Dan)
                    {
                        if (this.db現在のゲージ値[0] >= 80.0)
                        {
                            TJAPlayer3.Tx.Gauge[0].t2D描画(TJAPlayer3.app.Device, 1038, 144, new Rectangle(0, 44, 58, 24));
                        }
                        else
                        {
                            TJAPlayer3.Tx.Gauge[0].t2D描画(TJAPlayer3.app.Device, 1038, 144, new Rectangle(58, 44, 58, 24));
                        }
                    }
                    #endregion
                }
                #endregion

                #region[ ゲージ2P ]
                if (TJAPlayer3.stage演奏ドラム画面.bDoublePlay && TJAPlayer3.Tx.Gauge[1] != null)
                {
                    TJAPlayer3.Tx.Gauge[1].t2D描画(TJAPlayer3.app.Device, 492, 532, new Rectangle(0, 0, nRectX2P, 44));
                    if (db現在のゲージ値[1] >= 80.0 && db現在のゲージ値[1] < 100.0)
                    {
                        int Opacity = 0;
                        if (this.ctGaugeFlash.n現在の値 <= 365) Opacity = 0;
                        else if (this.ctGaugeFlash.n現在の値 <= 448) Opacity = (int)((this.ctGaugeFlash.n現在の値 - 365) / 83f * 255f);
                        else if (this.ctGaugeFlash.n現在の値 <= 531) Opacity = 255 - (int)((this.ctGaugeFlash.n現在の値 - 448) / 83f * 255f);
                        TJAPlayer3.Tx.Gauge_Flash.Opacity = Opacity;
                        TJAPlayer3.Tx.Gauge_Flash.t2D上下反転描画(TJAPlayer3.app.Device, 492, 509);
                    }
                    if (TJAPlayer3.Tx.Gauge[1] != null)
                    {
                        if (this.db現在のゲージ値[1] >= 100.0)
                        {
                            this.ct虹アニメ.t進行Loop();
                            this.ct虹透明度.t進行Loop();
                            if (TJAPlayer3.Tx.Gauge_Rainbow[this.ct虹アニメ.n現在の値] != null)
                            {
                                TJAPlayer3.Tx.Gauge_Rainbow[ct虹アニメ.n現在の値].Opacity = 255;
                                TJAPlayer3.Tx.Gauge_Rainbow[ct虹アニメ.n現在の値].t2D上下反転描画(TJAPlayer3.app.Device, 492, 532);
                                TJAPlayer3.Tx.Gauge_Rainbow[虹ベース].Opacity = (int)(ct虹透明度.n現在の値 * 255 / ct虹透明度.n終了値) / 1;
                                TJAPlayer3.Tx.Gauge_Rainbow[虹ベース].t2D上下反転描画(TJAPlayer3.app.Device, 492, 532);
                            }
                        }
                        TJAPlayer3.Tx.Gauge_Line[1].t2D描画(TJAPlayer3.app.Device, 492, 532);
                    }
                    #region[ 「クリア」文字 ]
                    if (this.db現在のゲージ値[1] >= 80.0)
                    {
                        TJAPlayer3.Tx.Gauge[1].t2D描画(TJAPlayer3.app.Device, 1038, 554, new Rectangle(0, 44, 58, 24));
                    }
                    else
                    {
                        TJAPlayer3.Tx.Gauge[1].t2D描画(TJAPlayer3.app.Device, 1038, 554, new Rectangle(58, 44, 58, 24));
                    }
                    #endregion
                }
                #endregion


                if (TJAPlayer3.Tx.Gauge_Soul_Fire != null)
                {
                    //仮置き
                    int[] nSoulFire = new int[] { 52, 443, 0, 0 };
                    for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
                    {
                        if (this.db現在のゲージ値[i] >= 100.0)
                        {
                            this.ct炎.t進行Loop();
                            TJAPlayer3.Tx.Gauge_Soul_Fire.t2D描画(TJAPlayer3.app.Device, 1112, nSoulFire[i], new Rectangle(230 * (this.ct炎.n現在の値), 0, 230, 230));
                        }
                    }
                }
                if (TJAPlayer3.Tx.Gauge_Soul != null)
                {
                    //仮置き
                    int[] nSoulY = new int[] { 138, 529, 0, 0 };//+13
                    for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
                    {

                        if (this.db現在のゲージ値[i] >= 80.0)
                        {
                            TJAPlayer3.Tx.Gauge_Soul.t2D描画(TJAPlayer3.app.Device, 1196, nSoulY[i], new Rectangle(0, 0, 57, 52));
                        }
                        if (this.db現在のゲージ値[i] >= 100.0)
                        {
                            if (ctSoulFlash.n現在の値 % 2 == 0)
                                TJAPlayer3.Tx.Gauge_Soul.t2D描画(TJAPlayer3.app.Device, 1196, nSoulY[i], new Rectangle(0, 52, 57, 52));
                        }

                    }
                }

                if (TJAPlayer3.Tx.Chara_Ef != null)
                {
                    //仮置き
                    int[] nCharaEf = new int[] { 0, 530, 0, 0 };
                    for (int i = 0; i < TJAPlayer3.ConfigIni.nPlayerCount; i++)
                    {
                        if (this.db現在のゲージ値[i] >= 100.0)
                        {
                            TJAPlayer3.Tx.Chara_Ef.t2D描画(TJAPlayer3.app.Device, 0, nCharaEf[i]);
                            TJAPlayer3.Tx.Chara_Ef.Opacity = (int)(176.0 + 80.0 * Math.Sin((double)(2 * Math.PI * this.ctCharaEf.n現在の値 * 2 / 100.0)));

                        }
                    }
                }


                //仮置き
                int[] nSoulExplosion = new int[] { 73, 468, 0, 0 };
                for (int d = 0; d < 32; d++)
                {
                    if (this.st花火状態[d].b使用中)
                    {
                        this.st花火状態[d].ct進行.t進行();
                        if (this.st花火状態[d].ct進行.b終了値に達した)
                        {
                            this.st花火状態[d].ct進行.t停止();
                            this.st花火状態[d].b使用中 = false;
                        }
                        break;
                    }
                }
                for (int d = 0; d < 32; d++)
                {
                    if (this.st花火状態2P[d].b使用中)
                    {
                        this.st花火状態2P[d].ct進行.t進行();
                        if (this.st花火状態2P[d].ct進行.b終了値に達した)
                        {
                            this.st花火状態2P[d].ct進行.t停止();
                            this.st花火状態2P[d].b使用中 = false;
                        }
                        break;
                    }
                }
            }
            return 0;
        }


        // その他

        #region [ private ]
        //-----------------
        public CAct演奏Drumsキャラクター actChara;

        //public bool[] b風船連打中 = new bool[2];

        private CCounter ctGaugeFlash;

        protected STSTATUS[] st花火状態 = new STSTATUS[32];
        protected STSTATUS[] st花火状態2P = new STSTATUS[32];
        [StructLayout(LayoutKind.Sequential)]
        protected struct STSTATUS
        {
            public CCounter ct進行;
            public bool isBig;
            public bool b使用中;
            public int nPlayer;
            public int nLane;
        }
        private CCounter ctSoul;
        private CCounter ctCharaEf;
        private CCounter ctSoulFlash;
        //-----------------
        #endregion
    }
}
