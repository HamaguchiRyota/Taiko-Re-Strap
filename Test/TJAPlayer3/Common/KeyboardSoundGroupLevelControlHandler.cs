using FDK;

namespace TJAPlayer3
{
    internal static class KeyboardSoundGroupLevelControlHandler
    {
        internal static void Handle(
            IInputDevice keyboard,
            SoundGroupLevelController soundGroupLevelController,
            CSkin skin,
            bool isSongPreview)
        {
            var isAdjustmentPositive = keyboard.bキーが押された((int)SlimDXKeys.Key.RightBracket);
            if (!(isAdjustmentPositive || keyboard.bキーが押された((int)SlimDXKeys.Key.LeftBracket)))
            {
                return;
            }

            ESoundGroup soundGroup;
            CSkin.Cシステムサウンド システムサウンド = null;

            if (keyboard.bキーが押されている((int)SlimDXKeys.Key.LeftControl) ||
                keyboard.bキーが押されている((int)SlimDXKeys.Key.RightControl))
            {
                soundGroup = ESoundGroup.SoundEffect;
                システムサウンド = skin.sound決定音;
            }
            else if (keyboard.bキーが押されている((int)SlimDXKeys.Key.LeftShift) ||
                     keyboard.bキーが押されている((int)SlimDXKeys.Key.RightShift))
            {
                soundGroup = ESoundGroup.Voice;
                システムサウンド = skin.soundゲーム開始音;
            }
            else if (isSongPreview)
            {
                soundGroup = ESoundGroup.SongPlayback;
            }
            else
            {
                soundGroup = ESoundGroup.SongPlayback;
            }

            soundGroupLevelController.AdjustLevel(soundGroup, isAdjustmentPositive);
            システムサウンド?.t再生する();
        }
    }
}
