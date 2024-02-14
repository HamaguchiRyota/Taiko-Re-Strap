using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FDK;

namespace TJAPlayer3
{
    #region [ old ]
    /*

    class FastRender
    {
        public FastRender()
        {
            
        }

        public void Render()
        {
            for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_10combo; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Chara_10Combo[i]);
            }
            for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Chara_10Combo_Maxed[i]);
            }
            for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Chara_GoGoStart[i]);
            }
            for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Chara_GoGoStart_Maxed[i]);
            }
            for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Normal; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Normal[i]);
            }
            for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Clear; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Normal_Cleared[i]);
            }
            for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Become_Cleared[i]);
            }
            for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Become_Maxed[i]);
            }
            for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Balloon_Breaking[i]);
            }
            for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Balloon_Broke[i]);
            }
            for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Balloon_Miss[i]);
            }

            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < TJAPlayer3.Skin.Game_Dancer_Ptn; k++)
                {
                    NullCheckAndRender(ref TJAPlayer3.Tx.Dancer[i][k]);
                }
            }

            NullCheckAndRender(ref TJAPlayer3.Tx.Effects_GoGoSplash);
            NullCheckAndRender(ref TJAPlayer3.Tx.Runner);
            for (int i = 0; i < TJAPlayer3.Skin.Game_Mob_Ptn; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Mob[i]);
            }

            for (int i = 0; i < 2; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.PuchiChara[i]);
            }
        }

        private void NullCheckAndRender(ref CTexture tx)
        {
            if (tx == null) return;
            tx.Opacity = 0;
            tx.t2D描画(TJAPlayer3.app.Device, 0, 0);
            tx.Opacity = 255;
        }
    }
    */
    #endregion

    class FastRender
    {
        public FastRender()
        {
        }

        public void Render()
        {
            RenderCharaTextures(TJAPlayer3.Skin.Game_Chara_Ptn_10combo, TJAPlayer3.Tx.Chara_10Combo);
            RenderCharaTextures(TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max, TJAPlayer3.Tx.Chara_10Combo_Maxed);
            RenderCharaTextures(TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart, TJAPlayer3.Tx.Chara_GoGoStart);
            RenderCharaTextures(TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max, TJAPlayer3.Tx.Chara_GoGoStart_Maxed);
            RenderCharaTextures(TJAPlayer3.Skin.Game_Chara_Ptn_Normal, TJAPlayer3.Tx.Chara_Normal);
            RenderCharaTextures(TJAPlayer3.Skin.Game_Chara_Ptn_Clear, TJAPlayer3.Tx.Chara_Normal_Cleared);
            RenderCharaTextures(TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn, TJAPlayer3.Tx.Chara_Become_Cleared);
            RenderCharaTextures(TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn, TJAPlayer3.Tx.Chara_Become_Maxed);
            RenderCharaTextures(TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking, TJAPlayer3.Tx.Chara_Balloon_Breaking);
            RenderCharaTextures(TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke, TJAPlayer3.Tx.Chara_Balloon_Broke);
            RenderCharaTextures(TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss, TJAPlayer3.Tx.Chara_Balloon_Miss);

            for (int i = 0; i < 5; i++)
            {
                RenderDancerTextures(i);
            }

            NullCheckAndRender(ref TJAPlayer3.Tx.Effects_GoGoSplash);
            //NullCheckAndRender(ref TJAPlayer3.Tx.Runner);

            RenderMobTextures(TJAPlayer3.Skin.Game_Mob_Ptn, TJAPlayer3.Tx.Mob);

            for (int i = 0; i < 2; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.PuchiChara[i]);
            }
        }

        private void RenderCharaTextures(int count, CTexture[] textures)
        {
            for (int i = 0; i < count; i++)
            {
                NullCheckAndRender(ref textures[i]);
            }
        }

        private void RenderDancerTextures(int index)
        {
            for (int k = 0; k < TJAPlayer3.Skin.Game_Dancer_Ptn; k++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Dancer[index][k]);
            }
        }

        private void RenderMobTextures(int count, CTexture[] textures)
        {
            for (int i = 0; i < count; i++)
            {
                NullCheckAndRender(ref textures[i]);
            }
        }

        private void NullCheckAndRender(ref CTexture tx)
        {
            if (tx != null)
            {
                tx.Opacity = 0;
                tx.t2D描画(TJAPlayer3.app.Device, 0, 0);
                tx.Opacity = 255;
            }
        }
    }

}
