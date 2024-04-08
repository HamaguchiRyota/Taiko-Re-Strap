using FDK;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TJAPlayer3
{
    public class CActLVLNFont : CActivity
    {
        // コンストラクタ

        const int numWidth = 15;
        const int numHeight = 19;

        public CActLVLNFont()
        {
            string numChars = "0123456789?-";
            st数字 = new ST数字[12, 4];

            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 12; i++)
                {
                    this.st数字[i, j].ch = numChars[i];
                    this.st数字[i, j].rc = new Rectangle(
                                                (i % 4) * numWidth + (j % 2) * 64,
                                                (i / 4) * numHeight + (j / 2) * 64,
                                                numWidth,
                                                numHeight
                    );
                }
            }
        }


        // CActivity 実装

        public override void OnManagedリソースの作成()
        {
            if (!base.b活性化してない)
            {
                this.tx数値 = TJAPlayer3.tテクスチャの生成(CSkin.Path(@"Graphics\ScreenSelect level numbers.png"));
                base.OnManagedリソースの作成();
            }
        }
        public override void OnManagedリソースの解放()
        {
            if (!base.b活性化してない)
            {
                if (this.tx数値 != null)
                {
                    this.tx数値.Dispose();
                    this.tx数値 = null;
                }
                base.OnManagedリソースの解放();
            }
        }


        // その他

        #region [ private ]
        //-----------------
        [StructLayout(LayoutKind.Sequential)]
        private struct ST数字
        {
            public char ch;
            public Rectangle rc;
        }
        private ST数字[,] st数字;
        private CTexture tx数値;
        //-----------------
        #endregion
    }
}
