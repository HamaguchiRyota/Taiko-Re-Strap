﻿using FDK;

namespace TJAPlayer3
{
    internal class CActResultRank : CActivity
    {
        // コンストラクタ

        public CActResultRank()
        {
            base.b活性化してない = true;
        }

        // CActivity 実装

        public override void On活性化()
        {
            base.On活性化();
        }
        public override void On非活性化()
        {

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
                b初めての進行描画 = false;
            }

            return 1;
        }


        // その他

        #region [ private ]
        //-----------------
        //-----------------
        #endregion
    }
}