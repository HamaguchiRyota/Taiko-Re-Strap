using FDK;
using System.Collections.Generic;

namespace TJAPlayer3
{
    class TextureLoader
    {
        const string BASE = @"Graphics\";

        // Stage
        const string TITLE = @"1_Title\";
        const string CONFIG = @"2_Config\";
        const string SONGSELECT = @"3_SongSelect\";
        const string DANISELECT = @"3_DaniSelect\";
        const string SONGLOADING = @"4_SongLoading\";
        const string GAME = @"5_Game\";
        const string RESULT = @"6_Result\";
        const string EXIT = @"7_Exit\";

        // InGame
        const string CHARA = @"1_Chara\";
        const string DANCER = @"2_Dancer\";
        const string MOB = @"3_Mob\";
        const string COURSESYMBOL = @"4_CourseSymbol\";
        const string BACKGROUND = @"5_Background\";
        const string TAIKO = @"6_Taiko\";
        const string GAUGE = @"7_Gauge\";
        const string FOOTER = @"8_Footer\";
        const string END = @"9_End\";
        const string EFFECTS = @"10_Effects\";
        const string BALLOON = @"11_Balloon\";
        const string LANE = @"12_Lane\";
        const string GENRE = @"13_Genre\";
        const string GAMEMODE = @"14_GameMode\";
        const string FAILED = @"15_Failed\";
        const string RUNNER = @"16_Runner\";
        const string PUCHICHARA = @"18_PuchiChara\";
        const string TRAINING = @"19_Training\";
        const string DANC = @"17_DanC\";
        const string MODICONS = @"21_ModIcons\";

        public bool IsLoaded = false;


        public TextureLoader()
        {
            // コンストラクタ
            this.IsLoaded = false;
        }

        internal CTexture TxC(string FileName)
        {
            var tex = TJAPlayer3.tテクスチャの生成(CSkin.Path(BASE + FileName));
            listTexture.Add(tex);
            return tex;
        }
        internal CTextureAf TxCAf(string FileName)
        {
            var tex = TJAPlayer3.tテクスチャの生成Af(CSkin.Path(BASE + FileName));
            listTexture.Add(tex);
            return tex;
        }
        internal CTexture TxCGen(string FileName)
        {
            return TJAPlayer3.tテクスチャの生成(CSkin.Path(BASE + GAME + GENRE + FileName + ".png"));
        }

        public void LoadTexture()
        {
            #region 共通
            Tile_Black = TxC(@"Tile_Black.png");
            Menu_Title = TxC(@"Menu_Title.png");
            Menu_Highlight = TxC(@"Menu_Highlight.png");
            Enum_Song = TxC(@"Enum_Song.png");
            Enum_Song_Load = TxC(@"Enum_Song.png");
            Scanning_Loudness = TxC(@"Scanning_Loudness.png");
            Overlay = TxC(@"Overlay.png");
            Network_Connection = TxC(@"Network_Connection.png");
            NamePlate = new CTexture[2];
            NamePlateBase = TxC(@"NamePlate.png");
            NamePlate_Effect[0] = TxC(@"9_NamePlateEffect\GoldMStar.png");
            NamePlate_Effect[1] = TxC(@"9_NamePlateEffect\PurpleMStar.png");
            NamePlate_Effect[2] = TxC(@"9_NamePlateEffect\GoldBStar.png");
            NamePlate_Effect[3] = TxC(@"9_NamePlateEffect\PurpleBStar.png");
            NamePlate_Effect[4] = TxC(@"9_NamePlateEffect\Slash.png");
            #endregion

            #region 1_タイトル画面
            Title_Background = TxC(TITLE + @"Background.png");
            Entry_Overlay = TxC(TITLE + @"Overlay.png");
            Entry_Bar = TxC(TITLE + @"Entry_Bar.png");
            Entry_Bar_Text = TxC(TITLE + @"Entry_Bar_Text.png");
            Entry_Bar_Select = TxC(TITLE + @"Bar_Select.png");

            Banapas_Load[0] = TxC(TITLE + @"Banapas_Load.png");
            Banapas_Load[1] = TxC(TITLE + @"Banapas_Load_Text.png");
            Banapas_Load[2] = TxC(TITLE + @"Banapas_Load_Anime.png");

            Banapas_Load_Clear[0] = TxC(TITLE + @"Banapas_Load_Clear.png");
            Banapas_Load_Clear[1] = TxC(TITLE + @"Banapas_Load_Clear_Anime.png");

            Banapas_Load_Failure[0] = TxC(TITLE + @"Banapas_Load_Failure.png");
            Banapas_Load_Failure[1] = TxC(TITLE + @"Banapas_Load_Clear_Anime.png");

            Entry_Player[0] = TxC(TITLE + @"Entry_Player.png");
            Entry_Player[1] = TxC(TITLE + @"Entry_Player_Select_Bar.png");
            Entry_Player[2] = TxC(TITLE + @"Entry_Player_Select.png");

            for (int i = 0; i < Donchan_Entry.Length; i++)
            {
                Donchan_Entry[i] = TxC(TITLE + @"Donchan_Entry\" + i.ToString() + ".png");
            }

            for (int i = 0; i < Entry_Donchan_Normal.Length; i++)
            {
                Entry_Donchan_Normal[i] = TxC(TITLE + @"Donchan_Normal\" + i.ToString() + ".png");
            }

            for (int i = 0; i < 2; i++)
            {
                ModeSelect_Bar[i] = TxC(TITLE + @"ModeSelect_Bar_" + i.ToString() + ".png");
            }

            for (int i = 0; i < 2; i++)
            {
                ModeSelect_Bar_Chara[i] = TxC(TITLE + @"ModeSelect_Bar_Chara_" + i.ToString() + ".png");
            }

            for (int i = 0; i < 2; i++)
            {
                ModeSelect_Bar_Text[i] = TxC(TITLE + @"ModeSelect_Bar_Text_" + i.ToString() + ".png");
            }

            ModeSelect_Bar[2] = TxC(TITLE + @"ModeSelect_Bar_Overlay.png");

            #endregion

            #region 2_コンフィグ画面
            Config_Background = TxC(CONFIG + @"Background.png");
            Config_Header = TxC(CONFIG + @"Header.png");
            Config_Cursor = TxC(CONFIG + @"Cursor.png");
            Config_ItemBox = TxC(CONFIG + @"ItemBox.png");
            Config_Arrow = TxC(CONFIG + @"Arrow.png");
            Config_KeyAssign = TxC(CONFIG + @"KeyAssign.png");
            Config_Font = TxC(CONFIG + @"Font.png");
            Config_Font_Bold = TxC(CONFIG + @"Font_Bold.png");
            Config_Enum_Song = TxC(CONFIG + @"Enum_Song.png");
            #endregion

            #region 3_選曲画面
            SongSelect_Background = TxC(SONGSELECT + @"Background.png");
            SongSelect_Other = TxC(SONGSELECT + @"Other.png");
            SongSelect_HighScore = TxC(SONGSELECT + @"High_Score.png");
            SongSelect_Auto = TxC(SONGSELECT + @"Auto.png");
            SongSelect_Level = TxC(SONGSELECT + @"Level.png");
            SongSelect_Branch = TxC(SONGSELECT + @"Branch.png");
            SongSelect_Bar_Center = TxC(SONGSELECT + @"Bar_Center.png");
            SongSelect_Frame_Score = TxC(SONGSELECT + @"Frame_Score.png");
            SongSelect_Frame_Box = TxC(SONGSELECT + @"Frame_Box.png");
            SongSelect_Frame_BackBox = TxC(SONGSELECT + @"Frame_BackBox.png");
            SongSelect_Frame_Random = TxC(SONGSELECT + @"Frame_Random.png");
            SongSelect_Bar_Genre_Back = TxC(SONGSELECT + @"Bar_Genre_Back.png");
            SongSelect_Bar_Genre_RecentryPlaySong = TxC(SONGSELECT + @"Bar_Genre_RecentryPlaySong.png");
            SongSelect_Bar_Select = TxC(SONGSELECT + @"Bar_Select.png");
            SongSelect_Bar_Shadow = TxC(SONGSELECT + @"Bar_Shadow.png");
            SongSelect_Box_Shadow = TxC(SONGSELECT + @"Box_Shadow.png");
            SongSelect_Level_Number = TxC(SONGSELECT + @"Level_Number.png");
            SongSelect_Credit = TxC(SONGSELECT + @"Credit.png");
            SongSelect_Timer = TxC(SONGSELECT + @"Timer.png");
            SongSelect_Song_Number = TxC(SONGSELECT + @"Song_Number.png");
            SongSelect_Bar_Genre_Overlay = TxC(SONGSELECT + @"Bar_Genre_Overlay.png");
            SongSelect_Crown = TxC(SONGSELECT + @"SongSelect_Crown.png");
            SongSelect_ScoreRank = TxC(SONGSELECT + @"ScoreRank.png");
            SongSelect_BoardNumber = TxC(SONGSELECT + @"BoardNumber.png");
            SongSelect_ScoreNumber = TxC(SONGSELECT + @"ScoreNumber.png");
            SongSelect_HighScore_Difficult = TxC(SONGSELECT + @"High_Score_Difficult.png");
            SongSelect_Unplayed = TxC(SONGSELECT + @"Unplayed.png");
            SongSelect_Counter = TxC(SONGSELECT + @"Counter.png");

            for (int i = 0; i < (int)Difficulty.Total; i++)
            {
                SongSelect_ScoreWindow[i] = TxC(SONGSELECT + @"ScoreWindow_" + i.ToString() + ".png");
            }
            for (int i = 0; i < SongSelect_Donchan_Select.Length; i++)
            {
                SongSelect_Donchan_Select[i] = TxC(SONGSELECT + @"Donchan\Select\" + i.ToString() + ".png");
            }
            for (int i = 0; i < SongSelect_Donchan_Normal.Length; i++)
            {
                SongSelect_Donchan_Normal[i] = TxC(SONGSELECT + @"Donchan\Loop\" + i.ToString() + ".png");
            }
            for (int i = 0; i < SongSelect_Donchan_Jump.Length; i++)
            {
                SongSelect_Donchan_Jump[i] = TxC(SONGSELECT + @"Donchan\Start\" + i.ToString() + ".png");
            }

            TJAPlayer3.Skin.SongSelect_Bar_Genre_Count = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + SONGSELECT + @"Bar_Genre\"), "Bar_Genre_");

            if (TJAPlayer3.Skin.SongSelect_Bar_Genre_Count != 0)
            {
                SongSelect_Bar_Genre = new CTexture[TJAPlayer3.Skin.SongSelect_Bar_Genre_Count];
                for (int i = 0; i < SongSelect_Bar_Genre.Length; i++)
                {
                    SongSelect_Bar_Genre[i] = TxC(SONGSELECT + @"Bar_Genre\Bar_Genre_" + i.ToString() + ".png");
                }
            }

            TJAPlayer3.Skin.SongSelect_Genre_Background_Count = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + SONGSELECT + @"Genre_Background\"), "GenreBackground_");

            if (TJAPlayer3.Skin.SongSelect_Genre_Background_Count != 0)
            {
                SongSelect_GenreBack = new CTexture[TJAPlayer3.Skin.SongSelect_Genre_Background_Count];
                for (int i = 0; i < SongSelect_GenreBack.Length; i++)
                {
                    SongSelect_GenreBack[i] = TxC(SONGSELECT + @"Genre_Background\GenreBackground_" + i.ToString() + ".png");
                }
            }

            TJAPlayer3.Skin.SongSelect_Box_Chara_Count = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + SONGSELECT + @"Box_Chara\"), "Box_Chara_");

            if (TJAPlayer3.Skin.SongSelect_Box_Chara_Count != 0)
            {
                SongSelect_Box_Chara = new CTexture[TJAPlayer3.Skin.SongSelect_Box_Chara_Count];
                for (int i = 0; i < SongSelect_Box_Chara.Length; i++)
                {
                    SongSelect_Box_Chara[i] = TxC(SONGSELECT + @"Box_Chara\Box_Chara_" + i.ToString() + ".png");
                }
            }

            #region [ 難易度選択画面 ]
            Difficulty_Bar = TxC(SONGSELECT + @"Difficulty_Select\Difficulty_Bar.png");
            Difficulty_Number = TxC(SONGSELECT + @"Difficulty_Select\Difficulty_Number.png");
            Difficulty_Star = TxC(SONGSELECT + @"Difficulty_Select\Difficulty_Star.png");
            Difficulty_Crown = TxC(SONGSELECT + @"Difficulty_Select\Difficulty_Crown.png");
            Difficulty_Option = TxC($"{SONGSELECT}Difficulty_Select/Difficulty_Option.png");
            Difficulty_Option_Select = TxC($"{SONGSELECT}Difficulty_Select/Difficulty_Option_Select.png");
            //Difficulty_Mark = TxC(SONGSELECT + @"Difficulty_Select\Difficulty_Mark.png");

            Difficulty_Select_Bar[0] = TxC(SONGSELECT + @"Difficulty_Select\Difficulty_Select_Bar.png");
            Difficulty_Select_Bar[1] = TxC(SONGSELECT + @"Difficulty_Select\Difficulty_Select_Bar2.png");

            Ctr = TxC(SONGSELECT + @"Difficulty_Select\Ctr.png");
            Ctr_Ef = TxC(SONGSELECT + @"Difficulty_Select\Ctr_Ef.png");
            SongSelect_Branch_Text = TxC(SONGSELECT + @"Difficulty_Select\Branch_Text.png");


            TJAPlayer3.Skin.SongSelect_Difficulty_Background_Count = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + SONGSELECT + @"Difficulty_Select\Difficulty_Back\"), "Difficulty_Back_");

            if (TJAPlayer3.Skin.SongSelect_Difficulty_Background_Count != 0)
            {
                Difficulty_Back = new CTexture[TJAPlayer3.Skin.SongSelect_Difficulty_Background_Count];
                for (int i = 0; i < Difficulty_Back.Length; i++)
                {
                    Difficulty_Back[i] = TxC(SONGSELECT + @"Difficulty_Select\Difficulty_Back\Difficulty_Back_" + i.ToString() + ".png");
                }
            }
            for (int i = 0; i < Difficulty_Mark.Length; i++)
            {
                Difficulty_Mark[i] = TxC(SONGSELECT + @"Difficulty_Select\Difficulty_Mark_" + i.ToString() + ".png");
            }

            #endregion

            #endregion

            #region 3_段位選択画面

            Dani_Background = TxC(DANISELECT + "Background.png");
            Dani_Difficulty_Cymbol = TxC(DANISELECT + "Difficulty_Cymbol.png");
            Dani_Level_Number = TxC(DANISELECT + "Level_Number.png");
            Dani_Soul_Number = TxC(DANISELECT + "SoulNumber.png");
            Dani_Exam_Number = TxC(DANISELECT + "ExamNumber.png");
            Dani_Bar_Center = TxC(DANISELECT + "Bar_Center.png");
            Dani_Plate = TxC(DANISELECT + "Plate.png");
            Dani_Header = TxC(DANISELECT + "header.png");

            Dani_Dan_In = TxC(DANISELECT + "Dan_In.png");
            Dani_Dan_Text = TxC(DANISELECT + "Dan_Text.png");

            for (int i = 0; i < 3; i++)
                Challenge_Select[i] = TxC(DANISELECT + "Challenge_Select_" + i.ToString() + ".png");

            for (int i = 0; i < DaniSelect_Donchan_Normal.Length; i++)
            {
                DaniSelect_Donchan_Normal[i] = TxC(DANISELECT + @"Loop\" + i.ToString() + ".png");
            }

            #endregion

            #region 4_読み込み画面
            SongLoading_Plate = TxC(SONGLOADING + @"Plate.png");
            SongLoading_Bg = TxC(SONGLOADING + @"Bg.png");
            SongLoading_BgWait = TxC(SONGLOADING + @"Bg_Wait.png");
            SongLoading_Chara = TxC(SONGLOADING + @"Chara.png");
            SongLoading_Fade = TxC(SONGLOADING + @"Fade.png");
            SongLoading_Bg_Dan = TxC(SONGLOADING + @"Bg_Dan.png");
            #endregion

            #region 5_演奏画面
            #region 共通
            Notes = TxC(GAME + @"Notes.png");
            Judge_Frame = TxC(GAME + @"Notes.png");
            SENotes = TxC(GAME + @"SENotes.png");
            Notes_Arm = TxC(GAME + @"Notes_Arm.png");
            Judge = TxC(GAME + @"Judge.png");
            ChipEffect = TxC(GAME + @"ChipEffect.png");
            ScoreRank = TxC(GAME + @"ScoreRank.png");

            Judge_Meter = TxC(GAME + @"Judge_Meter.png");
            Bar = TxC(GAME + @"Bar.png");
            Bar_Branch = TxC(GAME + @"Bar_Branch.png");

            Song_Number_Ingame = TxC(GAME + GENRE + @"Song_Number_Ingame.png");

            #endregion
            #region キャラクター
            TJAPlayer3.Skin.Game_Chara_Ptn_Normal = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"Normal\"));
            if (TJAPlayer3.Skin.Game_Chara_Ptn_Normal != 0)
            {
                Chara_Normal = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_Normal];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Normal; i++)
                {
                    Chara_Normal[i] = TxC(GAME + CHARA + @"Normal\" + i.ToString() + ".png");
                }
            }
            TJAPlayer3.Skin.Game_Chara_Ptn_Clear = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"Clear\"));
            if (TJAPlayer3.Skin.Game_Chara_Ptn_Clear != 0)
            {
                Chara_Normal_Cleared = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_Clear];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Clear; i++)
                {
                    Chara_Normal_Cleared[i] = TxC(GAME + CHARA + @"Clear\" + i.ToString() + ".png");
                }
            }
            if (TJAPlayer3.Skin.Game_Chara_Ptn_Clear != 0)
            {
                Chara_Normal_Maxed = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_Clear];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Clear; i++)
                {
                    Chara_Normal_Maxed[i] = TxC(GAME + CHARA + @"Clear_Max\" + i.ToString() + ".png");
                }
            }
            TJAPlayer3.Skin.Game_Chara_Ptn_GoGo = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"GoGo\"));
            if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGo != 0)
            {
                Chara_GoGoTime = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_GoGo];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGo; i++)
                {
                    Chara_GoGoTime[i] = TxC(GAME + CHARA + @"GoGo\" + i.ToString() + ".png");
                }
            }
            if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGo != 0)
            {
                Chara_GoGoTime_Maxed = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_GoGo];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGo; i++)
                {
                    Chara_GoGoTime_Maxed[i] = TxC(GAME + CHARA + @"GoGo_Max\" + i.ToString() + ".png");
                }
            }
            TJAPlayer3.Skin.Game_Chara_Ptn_10combo = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"10combo\"));
            if (TJAPlayer3.Skin.Game_Chara_Ptn_10combo != 0)
            {
                Chara_10Combo = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_10combo];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_10combo; i++)
                {
                    Chara_10Combo[i] = TxC(GAME + CHARA + @"10combo\" + i.ToString() + ".png");
                }
            }
            TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"10combo_Max\"));
            if (TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max != 0)
            {
                Chara_10Combo_Maxed = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max; i++)
                {
                    Chara_10Combo_Maxed[i] = TxC(GAME + CHARA + @"10combo_Max\" + i.ToString() + ".png");
                }
            }

            TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"GoGoStart\"));
            if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart != 0)
            {
                Chara_GoGoStart = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart; i++)
                {
                    Chara_GoGoStart[i] = TxC(GAME + CHARA + @"GoGoStart\" + i.ToString() + ".png");
                }
            }
            TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"GoGoStart_Max\"));
            if (TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max != 0)
            {
                Chara_GoGoStart_Maxed = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max; i++)
                {
                    Chara_GoGoStart_Maxed[i] = TxC(GAME + CHARA + @"GoGoStart_Max\" + i.ToString() + ".png");
                }
            }
            TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"ClearIn\"));
            if (TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn != 0)
            {
                Chara_Become_Cleared = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn; i++)
                {
                    Chara_Become_Cleared[i] = TxC(GAME + CHARA + @"ClearIn\" + i.ToString() + ".png");
                }
            }
            TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"SoulIn\"));
            if (TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn != 0)
            {
                Chara_Become_Maxed = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn; i++)
                {
                    Chara_Become_Maxed[i] = TxC(GAME + CHARA + @"SoulIn\" + i.ToString() + ".png");
                }
            }
            TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"Balloon_Breaking\"));
            if (TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking != 0)
            {
                Chara_Balloon_Breaking = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking; i++)
                {
                    Chara_Balloon_Breaking[i] = TxC(GAME + CHARA + @"Balloon_Breaking\" + i.ToString() + ".png");
                }
            }
            TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"Balloon_Broke\"));
            if (TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke != 0)
            {
                Chara_Balloon_Broke = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke; i++)
                {
                    Chara_Balloon_Broke[i] = TxC(GAME + CHARA + @"Balloon_Broke\" + i.ToString() + ".png");
                }
            }
            TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + CHARA + @"Balloon_Miss\"));
            if (TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss != 0)
            {
                Chara_Balloon_Miss = new CTexture[TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss; i++)
                {
                    Chara_Balloon_Miss[i] = TxC(GAME + CHARA + @"Balloon_Miss\" + i.ToString() + ".png");
                }
            }
            Chara_Ef = TxC(GAME + @"EF0.png");

            #endregion
            #region 踊り子
            TJAPlayer3.Skin.Game_Dancer_Ptn = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + DANCER + @"1\"));
            if (TJAPlayer3.Skin.Game_Dancer_Ptn != 0)
            {
                Dancer = new CTexture[5][];
                for (int i = 0; i < 5; i++)
                {
                    Dancer[i] = new CTexture[TJAPlayer3.Skin.Game_Dancer_Ptn];
                    for (int p = 0; p < TJAPlayer3.Skin.Game_Dancer_Ptn; p++)
                    {
                        Dancer[i][p] = TxC(GAME + DANCER + (i + 1) + @"\" + p.ToString() + ".png");
                    }
                }
            }
            #endregion
            #region モブ
            TJAPlayer3.Skin.Game_Mob_Ptn = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + MOB));
            Mob = new CTexture[TJAPlayer3.Skin.Game_Mob_Ptn];
            for (int i = 0; i < TJAPlayer3.Skin.Game_Mob_Ptn; i++)
            {
                Mob[i] = TxC(GAME + MOB + i.ToString() + ".png");
            }
            #endregion
            #region フッター
            Mob_Footer = TxC(GAME + FOOTER + @"0.png");
            #endregion
            #region 背景

            Background = TxC(GAME + Background + @"0\" + @"Background.png");
            Background_Up = new CTexture[2];
            Background_Up[0] = TxC(GAME + BACKGROUND + @"0/" + @"1P_Up.png");
            Background_Up[1] = TxC(GAME + BACKGROUND + @"0/" + @"2P_Up.png");
            Background_Up_Clear = new CTexture[2];
            Background_Up_Clear[0] = TxC(GAME + BACKGROUND + @"0\" + @"1P_Up_Clear.png");
            Background_Up_Clear[1] = TxC(GAME + BACKGROUND + @"0\" + @"2P_Up_Clear.png");

            Background_Up_YMove = new CTexture[2];
            Background_Up_YMove[0] = TxC(GAME + BACKGROUND + @"0/" + @"1P_Up_YMove.png");
            Background_Up_YMove[1] = TxC(GAME + BACKGROUND + @"0/" + @"2P_Up_YMove.png");
            Background_Up_YMove_Clear = new CTexture[2];
            Background_Up_YMove_Clear[0] = TxC(GAME + BACKGROUND + @"0/" + @"1P_Up_YMove_Clear.png");
            Background_Up_YMove_Clear[1] = TxC(GAME + BACKGROUND + @"0/" + @"2P_Up_YMove_Clear.png");
            Background_Up_Sakura = new CTexture[2];
            Background_Up_Sakura[0] = TxC(GAME + BACKGROUND + @"0/" + @"1P_Up_Sakura.png");
            Background_Up_Sakura[1] = TxC(GAME + BACKGROUND + @"0/" + @"2P_Up_Sakura.png");
            Background_Up_Sakura_Clear = new CTexture[2];
            Background_Up_Sakura_Clear[0] = TxC(GAME + BACKGROUND + @"0/" + @"1P_Up_Sakura_Clear.png");
            Background_Up_Sakura_Clear[1] = TxC(GAME + BACKGROUND + @"0/" + @"2P_Up_Sakura_Clear.png");

            /*
            Background_Up_1st = new CTexture[3];
            Background_Up_1st[0] = TxC(GAME + BACKGROUND + @"0\" + @"1P_Up_1st.png");
            Background_Up_1st[1] = TxC(GAME + BACKGROUND + @"0\" + @"2P_Up_1st.png");
            Background_Up_1st[2] = TxC(GAME + BACKGROUND + @"0\" + @"Clear_Up_1st.png");

            Background_Up_2nd = new CTexture[3];
            Background_Up_2nd[0] = TxC(GAME + BACKGROUND + @"0\" + @"1P_Up_2nd.png");
            Background_Up_2nd[1] = TxC(GAME + BACKGROUND + @"0\" + @"2P_Up_2nd.png");
            Background_Up_2nd[2] = TxC(GAME + BACKGROUND + @"0\" + @"Clear_Up_2nd.png");

            Background_Up_3rd = new CTexture[3];
            Background_Up_3rd[0] = TxC(GAME + BACKGROUND + @"0\" + @"1P_Up_3rd.png");
            Background_Up_3rd[1] = TxC(GAME + BACKGROUND + @"0\" + @"2P_Up_3rd.png");
            Background_Up_3rd[2] = TxC(GAME + BACKGROUND + @"0\" + @"Clear_Up_3rd.png");
            */
            for (int i = 0; i < Background_Up_Dan.Length; i++)
                Background_Up_Dan[i] = TxC(GAME + BACKGROUND + @"1\" + i.ToString() + @".png");
            Background_Down = TxC(GAME + BACKGROUND + @"0\" + @"Down.png");
            Background_Down_Clear = TxC(GAME + BACKGROUND + @"0\" + @"Down_Clear.png");
            //Background_Down_Clear_Light = TxC(GAME + BACKGROUND + @"0\" + @"Down_Clear_Light.png");
            Background_Down_Light_B = TxC(GAME + BACKGROUND + @"0\" + @"Down_Clear_Light_B.png");
            Background_Down_Scroll = TxC(GAME + BACKGROUND + @"0\" + @"Down_Scroll.png");
            Background_Down_Scroll_Matu = TxC(GAME + BACKGROUND + @"0\" + @"Down_Scroll_Matu.png");
            Background_Down_Scroll_Kumo = TxC(GAME + BACKGROUND + @"0\" + @"Down_Scroll_Kumo.png");
            Background_Down_Koma = TxC(GAME + BACKGROUND + @"0\" + @"Down_Koma.png");

            #endregion
            #region 太鼓
            Taiko_Background = new CTexture[3];
            Taiko_Background[0] = TxC(GAME + TAIKO + @"1P_Background.png");
            Taiko_Background[1] = TxC(GAME + TAIKO + @"2P_Background.png");
            Taiko_Background[2] = TxC(GAME + TAIKO + @"Dan_Background.png");
            Taiko_Frame = new CTexture[2];
            Taiko_Frame[0] = TxC(GAME + TAIKO + @"1P_Frame.png");
            Taiko_Frame[1] = TxC(GAME + TAIKO + @"2P_Frame.png");
            Taiko_NamePlate = new CTexture[2];
            Taiko_NamePlate[0] = TxC(GAME + TAIKO + @"1P_NamePlate.png");
            Taiko_NamePlate[1] = TxC(GAME + TAIKO + @"2P_NamePlate.png");
            Taiko_Base = TxC(GAME + TAIKO + @"Taiko_M.png");
            Taiko_Don_Left = TxC(GAME + TAIKO + @"Taiko_M.png");
            Taiko_Don_Right = TxC(GAME + TAIKO + @"Taiko_M.png");
            Taiko_Ka_Left = TxC(GAME + TAIKO + @"Taiko_M.png");
            Taiko_Ka_Right = TxC(GAME + TAIKO + @"Taiko_M.png");
            STP = TxC(GAME + TAIKO + @"SectionTime_Panel.png");
            STB = TxC(GAME + TAIKO + @"SectionTime_Bar.png");
            STBF = TxC(GAME + TAIKO + @"SectionTime_Bar_Finish.png");
            Taiko_HG = TxC(GAME + TAIKO + @"HG.png");

            Taiko_LevelUp = TxC(GAME + TAIKO + @"Level.png");
            Taiko_LevelDown = TxC(GAME + TAIKO + @"Level.png");
            Couse_Symbol = new CTexture[(int)Difficulty.Total + 1]; // +1は真打ちモードの分
            string[] Couse_Symbols = new string[(int)Difficulty.Total + 1] { "Easy", "Normal", "Hard", "Oni", "Edit", "Tower", "Dan", "Shin" };
            for (int i = 0; i < (int)Difficulty.Total + 1; i++)
            {
                Couse_Symbol[i] = TxC(GAME + COURSESYMBOL + Couse_Symbols[i] + ".png");
            }
            Taiko_Score = new CTexture[3];
            Taiko_Score[0] = TxC(GAME + TAIKO + @"Score.png");
            Taiko_Score[1] = TxC(GAME + TAIKO + @"Score_1P.png");
            Taiko_Score[2] = TxC(GAME + TAIKO + @"Score_2P.png");
            Taiko_Combo = new CTexture[3];
            Taiko_Combo[0] = TxC(GAME + TAIKO + @"Combo.png");
            Taiko_Combo[1] = TxC(GAME + TAIKO + @"Combo_Big.png");
            Taiko_Combo[2] = TxC(GAME + TAIKO + @"Combo_Midium.png");
            Taiko_Combo_Effect = TxC(GAME + TAIKO + @"Combo_Effect.png");
            Taiko_Combo_Text = TxC(GAME + TAIKO + @"Combo_Text.png");
            #endregion
            #region ゲージ
            Gauge = new CTexture[2];
            Gauge[0] = TxC(GAME + GAUGE + @"1P.png");
            Gauge[1] = TxC(GAME + GAUGE + @"2P.png");
            Gauge_Base = new CTexture[2];
            Gauge_Base[0] = TxC(GAME + GAUGE + @"1P_Base.png");
            Gauge_Base[1] = TxC(GAME + GAUGE + @"2P_Base.png");
            Gauge_Line = new CTexture[2];
            Gauge_Line[0] = TxC(GAME + GAUGE + @"1P_Line.png");
            Gauge_Line[1] = TxC(GAME + GAUGE + @"2P_Line.png");
            TJAPlayer3.Skin.Game_Gauge_Rainbow_Ptn = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + GAUGE + @"Rainbow\"));
            if (TJAPlayer3.Skin.Game_Gauge_Rainbow_Ptn != 0)
            {
                Gauge_Rainbow = new CTexture[TJAPlayer3.Skin.Game_Gauge_Rainbow_Ptn];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Gauge_Rainbow_Ptn; i++)
                {
                    Gauge_Rainbow[i] = TxC(GAME + GAUGE + @"Rainbow\" + i.ToString() + ".png");
                }
            }

            TJAPlayer3.Skin.Game_Gauge_Dan_Rainbow_Ptn = TJAPlayer3.t連番画像の枚数を数える(CSkin.Path(BASE + GAME + DANC + @"Rainbow\"));
            if (TJAPlayer3.Skin.Game_Gauge_Dan_Rainbow_Ptn != 0)
            {
                Gauge_Dan_Rainbow = new CTexture[TJAPlayer3.Skin.Game_Gauge_Dan_Rainbow_Ptn];
                for (int i = 0; i < TJAPlayer3.Skin.Game_Gauge_Dan_Rainbow_Ptn; i++)
                {
                    Gauge_Dan_Rainbow[i] = TxC(GAME + DANC + @"Rainbow\" + i.ToString() + ".png");
                }
            }
            Gauge_Dan = new CTexture[4];

            Gauge_Dan[0] = TxC(GAME + GAUGE + @"1P_Dan_Base.png");
            Gauge_Dan[1] = TxC(GAME + GAUGE + @"1P_Dan.png");
            Gauge_Dan[2] = TxC(GAME + GAUGE + @"1P_Dan_Clear_Base.png");
            Gauge_Dan[3] = TxC(GAME + GAUGE + @"1P_Dan_Clear.png");

            Gauge_Soul = TxC(GAME + GAUGE + @"Soul.png");
            Gauge_Flash = TxC(GAME + GAUGE + @"Flash.png");
            Gauge_Soul_Fire = TxC(GAME + GAUGE + @"Fire.png");
            Gauge_Soul_Explosion = new CTexture[2];
            Gauge_Soul_Explosion[0] = TxC(GAME + GAUGE + @"1P_Explosion.png");
            Gauge_Soul_Explosion[1] = TxC(GAME + GAUGE + @"2P_Explosion.png");
            #endregion
            #region 吹き出し
            Balloon_Combo = new CTexture[2];
            Balloon_Combo[0] = TxC(GAME + BALLOON + @"Combo_1P.png");
            Balloon_Combo[1] = TxC(GAME + BALLOON + @"Combo_2P.png");
            Balloon_Roll = TxC(GAME + BALLOON + @"Roll.png");
            Balloon_Balloon = TxC(GAME + BALLOON + @"Balloon.png");
            Balloon_Number_Roll = TxC(GAME + BALLOON + @"Number_Roll.png");
            Balloon_Number_Combo = TxC(GAME + BALLOON + @"Number_Combo.png");

            Balloon_Breaking = new CTexture[6];
            for (int i = 0; i < 6; i++)
            {
                Balloon_Breaking[i] = TxC(GAME + BALLOON + @"Breaking_" + i.ToString() + ".png");
            }
            #endregion
            #region エフェクト
            Effects_Hit_Explosion = TxCAf(GAME + EFFECTS + @"Hit\Explosion.png");
            if (Effects_Hit_Explosion != null) Effects_Hit_Explosion.b加算合成 = TJAPlayer3.Skin.Game_Effect_HitExplosion_AddBlend;
            Effects_Hit_Explosion_Big = TxC(GAME + EFFECTS + @"Hit\Explosion_Big.png");
            if (Effects_Hit_Explosion_Big != null) Effects_Hit_Explosion_Big.b加算合成 = TJAPlayer3.Skin.Game_Effect_HitExplosionBig_AddBlend;
            Effects_Hit_FireWorks = TxC(GAME + EFFECTS + @"Hit\FireWorks.png");
            if (Effects_Hit_FireWorks != null) Effects_Hit_FireWorks.b加算合成 = TJAPlayer3.Skin.Game_Effect_FireWorks_AddBlend;


            Effects_Fire = TxC(GAME + EFFECTS + @"Fire.png");
            if (Effects_Fire != null) Effects_Fire.b加算合成 = TJAPlayer3.Skin.Game_Effect_Fire_AddBlend;

            Effects_Rainbow = TxC(GAME + EFFECTS + @"Rainbow.png");

            Effects_GoGoSplash = TxC(GAME + EFFECTS + @"GoGoSplash.png");
            if (Effects_GoGoSplash != null) Effects_GoGoSplash.b加算合成 = TJAPlayer3.Skin.Game_Effect_GoGoSplash_AddBlend;
            Effects_Hit_Great = new CTexture[15];
            Effects_Hit_Great_Big = new CTexture[15];
            Effects_Hit_Good = new CTexture[15];
            Effects_Hit_Good_Big = new CTexture[15];
            for (int i = 0; i < 15; i++)
            {
                Effects_Hit_Great[i] = TxC(GAME + EFFECTS + @"Hit\" + @"Great\" + i.ToString() + ".png");
                Effects_Hit_Great_Big[i] = TxC(GAME + EFFECTS + @"Hit\" + @"Great_Big\" + i.ToString() + ".png");
                Effects_Hit_Good[i] = TxC(GAME + EFFECTS + @"Hit\" + @"Good\" + i.ToString() + ".png");
                Effects_Hit_Good_Big[i] = TxC(GAME + EFFECTS + @"Hit\" + @"Good_Big\" + i.ToString() + ".png");
            }
            Effects_Roll = TxC(GAME + EFFECTS + @"Roll\" + "0.png");
            Effects_Roll_2P = TxC(GAME + EFFECTS + @"Roll\" + "1.png");
            #endregion
            #region レーン
            Lane_Base = new CTexture[3];
            Lane_Text = new CTexture[3];
            string[] Lanes = new string[3] { "Normal", "Expert", "Master" };
            for (int i = 0; i < 3; i++)
            {
                Lane_Base[i] = TxC(GAME + LANE + "Base_" + Lanes[i] + ".png");
                Lane_Text[i] = TxC(GAME + LANE + "Text_" + Lanes[i] + ".png");
            }
            Lane_Red = TxC(GAME + LANE + @"Red.png");
            Lane_Blue = TxC(GAME + LANE + @"Blue.png");
            Lane_Yellow = TxC(GAME + LANE + @"Yellow.png");
            Lane_Background_Main = TxC(GAME + LANE + @"Background_Main.png");
            Lane_Background_Sub = TxC(GAME + LANE + @"Background_Sub.png");
            Lane_Background_GoGo = TxC(GAME + LANE + @"Background_GoGo.png");

            #endregion
            #region 終了演出
            End_Clear_Chara = TxC(GAME + END + @"Clear_Chara.png");
            End_Star = TxC(GAME + END + @"Star.png");

            End_Clear_Text = new CTexture[2];
            End_Clear_Text[0] = TxC(GAME + END + @"Clear_Text.png");
            End_Clear_Text[1] = TxC(GAME + END + @"Clear_Text_End.png");

            End_FullCombo_Text = new CTexture[2];
            End_FullCombo_Text[0] = TxC(GAME + END + @"FullCombo_Text.png");
            End_FullCombo_Text[1] = TxC(GAME + END + @"FullCombo_Text_End.png");

            ClearFailed = TxC(GAME + END + @"ClearFailed\" + "Clear_Failed.png");
            ClearFailed1 = TxC(GAME + END + @"ClearFailed\" + "Clear_Failed1.png");
            ClearFailed2 = TxC(GAME + END + @"ClearFailed\" + "Clear_Failed2.png");
            End_ClearFailed = new CTexture[26];
            for (int i = 0; i < 26; i++)
                End_ClearFailed[i] = TxC(GAME + END + @"ClearFailed\" + i.ToString() + ".png");

            End_FullCombo = new CTexture[67];
            for (int i = 0; i < 67; i++)
                End_FullCombo[i] = TxC(GAME + END + @"FullCombo\" + i.ToString() + ".png");
            End_FullComboLoop = new CTexture[3];
            for (int i = 0; i < 3; i++)
                End_FullComboLoop[i] = TxC(GAME + END + @"FullCombo\" + "loop_" + i.ToString() + ".png");

            End_DondaFullComboBg = TxC(GAME + END + @"DondaFullCombo\" + "bg.png");
            End_DondaFullCombo = new CTexture[62];
            for (int i = 0; i < 62; i++)
                End_DondaFullCombo[i] = TxC(GAME + END + @"DondaFullCombo\" + i.ToString() + ".png");
            End_DondaFullComboLoop = new CTexture[3];
            for (int i = 0; i < 3; i++)
                End_DondaFullComboLoop[i] = TxC(GAME + END + @"DondaFullCombo\" + "loop_" + i.ToString() + ".png");


            End_Goukaku = new CTexture[3];

            for (int i = 0; i < End_Goukaku.Length; i++)
            {
                End_Goukaku[i] = TxC(GAME + END + @"Dan" + i.ToString() + ".png");
            }
            #endregion
            #region ゲームモード
            GameMode_Timer_Tick = TxC(GAME + GAMEMODE + @"Timer_Tick.png");
            GameMode_Timer_Frame = TxC(GAME + GAMEMODE + @"Timer_Frame.png");
            #endregion
            #region ステージ失敗
            Failed_Game = TxC(GAME + FAILED + @"Game.png");
            Failed_Stage = TxC(GAME + FAILED + @"Stage.png");
            #endregion
            #region ランナー
            //Runner = TxC(GAME + RUNNER + @"0.png");
            #endregion
            #region DanC
            DanC_Background = TxC(GAME + DANC + @"Background.png");
            DanC_Gauge = new CTexture[4];
            var type = new string[] { "Normal", "Reach", "Clear", "Flush" };
            for (int i = 0; i < 4; i++)
            {
                DanC_Gauge[i] = TxC(GAME + DANC + @"Gauge_" + type[i] + ".png");
            }
            DanC_Base = TxC(GAME + DANC + @"Base.png");
            DanC_Base_Small = TxC(GAME + DANC + @"Base_Small.png");
            DanC_Gauge_Base = TxC(GAME + DANC + @"Gauge_Base.png");
            DanC_Failed = TxC(GAME + DANC + @"Failed.png");
            DanC_Number = TxC(GAME + DANC + @"Number.png");
            DanC_Small_Number = TxC(GAME + DANC + @"Small_Number.png");
            DanC_ExamType = TxC(GAME + DANC + @"ExamType.png");
            DanC_ExamRange = TxC(GAME + DANC + @"ExamRange.png");
            //DanC_ExamUnit = TxC(GAME + DANC + @"ExamUnit.png");
            DanC_Screen = TxC(GAME + DANC + @"Screen.png");
            DanC_SmallBase = TxC(GAME + DANC + @"SmallBase.png");
            DanC_Small_ExamCymbol = TxC(GAME + DANC + @"Small_ExamCymbol.png");
            DanC_ExamCymbol = TxC(GAME + DANC + @"ExamCymbol.png");
            DanC_MiniNumber = TxC(GAME + DANC + @"MiniNumber.png");
            #endregion
            #region PuichiChara
            PuchiChara = new CTexture[2];
            for (int i = 0; i < 2; i++)
            {
                PuchiChara[i] = TxC(GAME + PUCHICHARA + i.ToString() + @".png");
            }
            #endregion
            #region Training

            Tokkun_DownBG = TxC(GAME + TRAINING + @"Down.png");
            Tokkun_BigTaiko = TxC(GAME + TRAINING + @"BigTaiko.png");
            Tokkun_BigDon_Left = TxC(GAME + TRAINING + @"BigDon.png");
            Tokkun_BigDon_Right = TxC(GAME + TRAINING + @"BigDon.png");
            Tokkun_BigKa_Left = TxC(GAME + TRAINING + @"BigKa.png");
            Tokkun_BigKa_Right = TxC(GAME + TRAINING + @"BigKa.png");
            Tokkun_ProgressBar = TxC(GAME + TRAINING + @"ProgressBar_Red.png");
            Tokkun_ProgressBarWhite = TxC(GAME + TRAINING + @"ProgressBar_White.png");
            Tokkun_GoGoPoint = TxC(GAME + TRAINING + @"GoGoPoint.png");
            Tokkun_JumpPoint = TxC(GAME + TRAINING + @"JumpPoint.png");
            Tokkun_Background_Up = TxC(GAME + TRAINING + @"Background_Up.png");
            Tokkun_BigNumber = TxC(GAME + TRAINING + @"BigNumber.png");
            Tokkun_SmallNumber = TxC(GAME + TRAINING + @"SmallNumber.png");
            Tokkun_Speed_Measure = TxC(GAME + TRAINING + @"Speed_Measure.png");

            #endregion

            #region [21_ModIcons]
            HiSp = new CTexture[14];
            for (int i = 0; i < HiSp.Length; i++)
            {
                HiSp[i] = TxC(GAME + MODICONS + @"HS\" + i.ToString() + @".png");
            }

            Mod_Timing = new CTexture[5];
            for (int i = 0; i < Mod_Timing.Length; i++)
            {
                Mod_Timing[i] = TxC(GAME + MODICONS + @"Timing\" + i.ToString() + @".png");
            }

            Mod_SongSpeed = new CTexture[2];
            for (int i = 0; i < Mod_SongSpeed.Length; i++)
            {
                Mod_SongSpeed[i] = TxC(GAME + MODICONS + @"SongSpeed\" + i.ToString() + @".png");
            }

            Mod_Doron = TxC(GAME + MODICONS + @"Doron.png");
            Mod_Stealth = TxC(GAME + MODICONS + @"Stealth.png");
            Mod_Mirror = TxC(GAME + MODICONS + @"Mirror.png");
            Mod_Super = TxC(GAME + MODICONS + @"Super.png");
            Mod_Hyper = TxC(GAME + MODICONS + @"Hyper.png");
            Mod_Random = TxC(GAME + MODICONS + @"Random.png");
            Mod_Auto = TxC(GAME + MODICONS + @"Auto.png");
            Mod_None = TxC(GAME + MODICONS + @"None.png");

            #endregion

            #endregion

            #region 6_結果発表
            Result_Gauge = TxC(RESULT + @"Gauge.png");
            Result_Gauge_Base = TxC(RESULT + @"Gauge_Base.png");
            Result_Gauge_Flash = TxC(RESULT + @"Flash.png");
            Result_Header = TxC(RESULT + @"Header.png");
            Result_Number = TxC(RESULT + @"Number.png");
            //Result_Panel = TxC(RESULT + @"Panel.png");
            Result_Soul_Text = TxC(RESULT + @"Soul_Text.png");
            Result_Soul_Fire = TxC(RESULT + @"Result_Soul_Fire.png");
            Result_Diff_Bar = TxC(RESULT + @"DifficultyBar.png");

            Result_HighScore = TxC(RESULT + @"HighScore.png");

            Result_CrownEffect = TxC(RESULT + @"CrownEffect.png");
            Result_ScoreRankEffect = TxC(RESULT + @"ScoreRankEffect.png");

            Result_Score_Number = TxC(RESULT + @"Score_Number.png");
            Result_Dan_Judge = TxC(RESULT + @"Dan_Judge.png");
            Result_Background_Dan = TxC(RESULT + @"Background_Dan.png");

            Result_Dan_SectionBasePanel = TxC(RESULT + @"Dan_SectionBasePanel.png");
            Result_Dan_Panel = TxC(RESULT + @"Dan_Panel.png");
            Result_Dan_SectionPanel = TxC(RESULT + @"Dan_SectionPanel.png");
            Result_Dan_Number = TxC(RESULT + @"Dan_Number.png");


            Result_Background_Double = TxC(RESULT + @"Background_Double.png");

            for (int i = 0; i < 41; i++)
                Result_Rainbow[i] = TxC(RESULT + @"Rainbow\" + i.ToString() + ".png");

            for (int i = 0; i < 4; i++)
                Result_Background[i] = TxC(RESULT + @"Background_" + i.ToString() + ".png");

            for (int i = 0; i < 2; i++)
                Result_Panel[i] = TxC(RESULT + @"Panel_" + i.ToString() + ".png");

            for (int i = 0; i < 2; i++)
                Result_Mountain[i] = TxC(RESULT + @"Background_Mountain_" + i.ToString() + ".png");

            for (int i = 0; i < Result_Chara_Normal.Length; i++)
                Result_Chara_Normal[i] = TxC(RESULT + @"Result_Chara_Normal\" + i.ToString() + ".png");

            for (int i = 0; i < Result_Chara_Clear.Length; i++)
                Result_Chara_Clear[i] = TxC(RESULT + @"Result_Chara_Clear\" + i.ToString() + ".png");
            #endregion

            #region 7_終了画面
            Exit_Curtain = TxC(EXIT + @"Curtain.png");
            Exit_Text = TxC(EXIT + @"Text.png");
            Exit_BG = TxC(EXIT + @"BG.png");
            #endregion

            this.IsLoaded = true;

        }

        /*
        public void DisposeTexture()
        {
            foreach (var tex in listTexture)
            {
                var texture = tex;
                TJAPlayer3.tテクスチャの解放(ref texture);
                texture?.Dispose();
                texture = null;
            }
            listTexture.Clear();
        }
        */

        public void DisposeTexture()
        {
            for (int i = 0; i < listTexture.Count; i++)
            {
                var texture = listTexture[i];
                TJAPlayer3.tテクスチャの解放(ref texture);
                texture?.Dispose();
                listTexture[i] = null; // 参照をクリアする
            }
            listTexture.Clear();
        }



        #region 共通
        public CTexture Tile_Black,
            Menu_Title,
            Menu_Highlight,
            Enum_Song,
            Enum_Song_Load,
            Scanning_Loudness,
            NamePlateBase,
            Overlay,
            //Readme,
            Network_Connection;
        public CTexture[] NamePlate;

        public CTexture[] NamePlate_Effect = new CTexture[5];
        #endregion

        #region 1_タイトル画面
        public CTexture Title_Background,
            Entry_Bar_Select,
            Entry_Overlay,
            Entry_Bar,
            Entry_Bar_Text;

        public CTexture[] Banapas_Load = new CTexture[3];
        public CTexture[] Banapas_Load_Clear = new CTexture[2];
        public CTexture[] Banapas_Load_Failure = new CTexture[2];
        public CTexture[] Entry_Player = new CTexture[3];
        public CTexture[] Donchan_Entry = new CTexture[41];
        public CTexture[] Entry_Donchan_Normal = new CTexture[30];
        public CTexture[] ModeSelect_Bar = new CTexture[3];
        public CTexture[] ModeSelect_Bar_Chara = new CTexture[2];
        public CTexture[] ModeSelect_Bar_Text = new CTexture[2];
        #endregion

        #region 2_コンフィグ画面
        public CTexture Config_Background,
            Config_Header,
            Config_Cursor,
            Config_ItemBox,
            Config_Arrow,
            Config_KeyAssign,
            Config_Font,
            Config_Font_Bold,
            Config_Enum_Song;
        #endregion

        #region 3_選曲画面

        public CTexture SongSelect_Background,
            SongSelect_Other,
            SongSelect_HighScore,
            SongSelect_Unplayed,
            SongSelect_HighScore_Difficult,
            SongSelect_Auto,
            SongSelect_Level,
            SongSelect_Branch,
            SongSelect_Branch_Text,
            SongSelect_Frame_Score,
            SongSelect_Frame_Box,
            SongSelect_Frame_BackBox,
            SongSelect_Frame_Random,
            SongSelect_Bar_Center,
            SongSelect_Bar_Genre_Back,
            SongSelect_Bar_Genre_RecentryPlaySong,
            SongSelect_Level_Number,
            SongSelect_Bar_Select,
            SongSelect_Bar_Shadow,
            SongSelect_Box_Shadow,
            SongSelect_Bar_Genre_Overlay,
            SongSelect_Credit,
            SongSelect_Timer,
            SongSelect_Crown,
            SongSelect_ScoreRank,
            SongSelect_Song_Number,
            SongSelect_BoardNumber,
            SongSelect_Counter,
            SongSelect_ScoreNumber;
        public CTexture[]
            SongSelect_GenreBack,
            SongSelect_Bar_Genre,
            SongSelect_Box_Chara,
            SongSelect_ScoreWindow = new CTexture[(int)Difficulty.Total],
            SongSelect_Donchan_Select = new CTexture[65],
            SongSelect_Donchan_Normal = new CTexture[61],
            SongSelect_Donchan_Jump = new CTexture[25],
            SongSelect_NamePlate = new CTexture[1];

        #region [ 難易度選択画面 ]
        public CTexture Difficulty_Bar,
            Difficulty_Number,
            Difficulty_Star,
            Difficulty_Crown,
            Difficulty_Option,
            Difficulty_Option_Select,
            Ctr,
            Ctr_Ef;

        public CTexture[] Difficulty_Select_Bar = new CTexture[2];
        public CTexture[] Difficulty_Back;
        public CTexture[] Difficulty_Mark = new CTexture[5];
        #endregion

        #endregion

        #region 3_段位選択画面

        public CTexture Dani_Background;
        public CTexture Dani_Difficulty_Cymbol;
        public CTexture Dani_Level_Number;
        public CTexture Dani_Soul_Number;
        public CTexture Dani_Exam_Number;
        public CTexture Dani_Bar_Center;
        public CTexture Dani_Plate;
        public CTexture Dani_Header;

        public CTexture Dani_Dan_In;
        public CTexture Dani_Dan_Text;

        public CTexture[] Challenge_Select = new CTexture[3];
        public CTexture[] DaniSelect_Donchan_Normal = new CTexture[61];

        #endregion

        #region 4_読み込み画面
        public CTexture SongLoading_Plate,
            SongLoading_Bg,
            SongLoading_BgWait,
            SongLoading_Chara,
            SongLoading_Bg_Dan,
            SongLoading_Fade;
        #endregion

        #region 5_演奏画面
        #region 共通
        public CTexture Notes,
            Judge_Frame,
            SENotes,
            Notes_Arm,
            ChipEffect,
            ScoreRank,
            Song_Number_Ingame,
            Judge;
        //NowStages;
        public CTexture Bar,
            Judge_Meter,
            Bar_Branch;
        #endregion
        #region キャラクター
        public CTexture[] Chara_Normal,
            Chara_Normal_Cleared,
            Chara_Normal_Maxed,
            //Chara_Ef,
            Chara_GoGoTime,
            Chara_GoGoTime_Maxed,
            Chara_10Combo,
            Chara_10Combo_Maxed,
            Chara_GoGoStart,
            Chara_GoGoStart_Maxed,
            Chara_Become_Cleared,
            Chara_Become_Maxed,
            //Chara_MAX,
            Chara_Balloon_Breaking,
            Chara_Balloon_Broke,
            Chara_Balloon_Miss;
        public CTexture Chara_Ef;
        #endregion
        #region 踊り子
        public CTexture[][] Dancer;
        #endregion
        #region モブ
        public CTexture[] Mob;
        public CTexture Mob_Footer;
        #endregion
        #region 背景
        public CTexture Background,
        //Background_Up_Clear_HM0,
        //Background_Up_Clear_HM1,
          Background_Down,
            Background_Down_Clear,
            //Background_Down_BG_0,
            //Background_Down_BG_1,
            //Background_Down_Sc_0,
            //Background_Down_Sc_1,
            //Background_Down_M0,
            //Background_Down_M1,
            //Background_Down_Splash,
            //Background_Down_Fune,
            //Background_Down_FuneX2,
            //Background_Down_Clear_Light,
            Background_Down_Light_B,
            Background_Down_Scroll,
            Background_Down_Scroll_Matu,
            Background_Down_Scroll_Kumo,
            Background_Down_Koma;
        public CTexture[] Background_Up,
            //Background_Up_1st,
            //Background_Up_2nd,
            //Background_Up_3rd,
            //Background_Up_Chara,
            //Background_Up_Kumo0,
            //Background_Up_Kumo1,
            Background_Up_Clear,
            Background_Up_YMove,
            Background_Up_YMove_Clear,
            Background_Up_Sakura,
            Background_Up_Sakura_Clear,
            //Background_Up_Clear_Kumo0,
            //Background_Up_Clear_Kumo1,
            Background_Up_Dan = new CTexture[6];
        #endregion
        #region 太鼓
        public CTexture[] Taiko_Frame, // MTaiko下敷き
            Taiko_Background;
        public CTexture Taiko_Base,
            Taiko_Don_Left,
            Taiko_Don_Right,
            Taiko_Ka_Left,
            Taiko_Ka_Right,
            Taiko_LevelUp,
            Taiko_LevelDown,
            STP,
            STB,
            STBF,
            Taiko_HG,
            Taiko_Combo_Effect,
            Taiko_Combo_Text;
        public CTexture[] Couse_Symbol,// コースシンボル
                                       //Taiko_PlayerNumber,
            Taiko_NamePlate; // ネームプレート
        public CTexture[] Taiko_Score,
            Taiko_Combo;
        #endregion
        #region ゲージ
        public CTexture[] Gauge,
            Gauge_Base,
            Gauge_Line,
            Gauge_Rainbow,
            Gauge_Soul_Explosion;
        public CTexture Gauge_Soul,
            Gauge_Flash,
            Gauge_Soul_Fire;
        public CTexture[] Gauge_Dan;
        public CTexture[] Gauge_Dan_Rainbow;
        #endregion
        #region 吹き出し
        public CTexture[] Balloon_Combo;
        public CTexture Balloon_Roll,
            Balloon_Balloon,
            Balloon_Number_Roll,
            Balloon_Number_Combo/*,*/
                                /*Balloon_Broken*/;
        public CTexture[] Balloon_Breaking;
        #endregion
        #region エフェクト
        public CTexture Effects_Hit_Explosion,
            Effects_Hit_Explosion_Big,
            Effects_Fire,
            Effects_Rainbow,
            Effects_GoGoSplash,
            Effects_Hit_FireWorks;
        public CTexture[] Effects_Hit_Great,
            Effects_Hit_Good,
            Effects_Hit_Great_Big,
            Effects_Hit_Good_Big;
        public CTexture Effects_Roll,
                     Effects_Roll_2P;
        #endregion
        #region レーン
        public CTexture[] Lane_Base,
            Lane_Text;
        public CTexture Lane_Red,
            Lane_Blue,
            Lane_Yellow;
        public CTexture Lane_Background_Main,
            Lane_Background_Sub,
            Lane_Background_GoGo;
        #endregion
        #region 終了演出
        public CTexture End_Clear_Chara;
        public CTexture[] End_Clear_Text;
        public CTexture End_Star;
        public CTexture[] End_FullCombo_Text;

        public CTexture[] End_ClearFailed,
            End_FullCombo,
            End_FullComboLoop,
            End_DondaFullCombo,
            End_DondaFullComboLoop,
            End_Goukaku;
        public CTexture ClearFailed,
            ClearFailed1,
            ClearFailed2,
            End_DondaFullComboBg;
        #endregion
        #region ゲームモード
        public CTexture GameMode_Timer_Frame,
            GameMode_Timer_Tick;
        #endregion
        #region ステージ失敗
        public CTexture Failed_Game,
            Failed_Stage;
        #endregion
        #region ランナー
        //public CTexture Runner;
        #endregion
        #region DanC
        public CTexture DanC_Background;
        public CTexture[] DanC_Gauge;
        public CTexture DanC_Base;
        public CTexture DanC_Gauge_Base;
        public CTexture DanC_Failed;
        public CTexture DanC_Base_Small;
        public CTexture DanC_Number,
            DanC_Small_Number,
            DanC_SmallBase,
            DanC_ExamType,
            DanC_ExamRange,
            DanC_Small_ExamCymbol,
            DanC_ExamCymbol,
            DanC_MiniNumber,
            DanC_ExamUnit;
        public CTexture DanC_Screen;
        #endregion
        #region PuchiChara
        public CTexture[] PuchiChara;
        #endregion
        #region Training
        public CTexture Tokkun_DownBG,
            Tokkun_BigTaiko,
            Tokkun_BigDon_Left,
            Tokkun_BigDon_Right,
            Tokkun_BigKa_Left,
            Tokkun_BigKa_Right,
            Tokkun_ProgressBar,
            Tokkun_ProgressBarWhite,
            Tokkun_GoGoPoint,
            Tokkun_JumpPoint,
            Tokkun_Background_Up,
            Tokkun_BigNumber,
            Tokkun_SmallNumber,
            Tokkun_Speed_Measure;
        #endregion
        #region [21_ModIcons]
        public CTexture[] Mod_Timing,
            Mod_SongSpeed,
            HiSp;
        public CTexture Mod_None,
            Mod_Doron,
            Mod_Stealth,
            Mod_Mirror,
            Mod_Random,
            Mod_Super,
            Mod_Hyper,
            Mod_Auto;

        #endregion
        #endregion

        #region 6_結果発表
        public CTexture Result_Gauge,
            Result_Gauge_Flash,
            Result_Gauge_Base,
            Result_Header,
            Result_Number,
            Result_Soul_Text,
            Result_Soul_Fire,
            Result_Diff_Bar,
            Result_HighScore,
            Result_CrownEffect,
            Result_ScoreRankEffect,
            Result_Score_Number,
            Result_Background_Dan,
            Result_Dan_SectionBasePanel,
            Result_Dan_Panel,
            Result_Dan_SectionPanel,
            Result_Background_Double,
            Result_Dan_Number,
            Result_Dan_Judge;
        public CTexture[]
            Result_Rainbow = new CTexture[41],
            Result_Background = new CTexture[4],
            Result_Panel = new CTexture[2],
            Result_Chara_Normal = new CTexture[30],
            Result_Chara_Clear = new CTexture[51],
            Result_Mountain = new CTexture[2];
        #endregion

        #region 7_終了画面
        public CTexture Exit_Curtain,
                        Exit_Text,
                        Exit_BG;
        #endregion

        #region [ 解放用 ]
        public List<CTexture> listTexture = new List<CTexture>();
        #endregion
    }
}
