﻿using System.Diagnostics;


namespace TJAPlayer3
{
    /// <summary>
    /// box.defによるスキン変更時に一時的に遷移する、スキン画像の一切無いステージ。
    /// </summary>
    internal class CStageChangeSkin : CStage
    {
        // コンストラクタ

        public CStageChangeSkin()
        {
            base.eステージID = CStage.Eステージ.ChangeSkin;
            base.b活性化してない = true;
        }


        // CStage 実装

        public override void On活性化()
        {
            Trace.TraceInformation("スキン変更ステージを活性化します。");
            Trace.Indent();
            try
            {
                base.On活性化();
                Trace.TraceInformation("スキン変更ステージの活性化を完了しました。");
            }
            finally
            {
                Trace.Unindent();
            }
        }
        public override void On非活性化()
        {
            Trace.TraceInformation("スキン変更ステージを非活性化します。");
            Trace.Indent();
            try
            {
                base.On非活性化();
                Trace.TraceInformation("スキン変更ステージの非活性化を完了しました。");
            }
            finally
            {
                Trace.Unindent();
            }
        }
        public override void OnManagedリソースの作成()
        {
            if (!base.b活性化してない)
            {
                base.OnManagedリソースの作成();
            }
        }
        public override void OnManagedリソースの解放()
        {
            if (!base.b活性化してない)
            {
                base.OnManagedリソースの解放();
            }
        }
        public override int On進行描画()
        {
            if (!base.b活性化してない)
            {
                if (base.b初めての進行描画)
                {
                    base.b初めての進行描画 = false;
                    return 0;
                }

                //スキン変更処理
                TJAPlayer3.app.RefleshSkin();

                return 1;
            }
            return 0;
        }

    }
}
