using System.IO;

namespace TJAPlayer3
{
    class NamePlateConfig
    {
        public void tNamePlateConfig()
        {
            if (!File.Exists("NamePlate.json"))
                ConfigManager.SaveConfig(data, "NamePlate.json");

            data = ConfigManager.GetConfig<Data>(@"NamePlate.json");
        }

        public class Data
        {
            public string[] Name = { "どんちゃん", "かっちゃん" };
            public string[] Title = { "どんちゃんですよ！", "かっちゃんですよ！" };
            public string[] Dan = { "達人", "達人" };

            public bool[] DanGold = { false, true };

            public int[] DanType = { 1, 2 };
            public int[] TitleType = { 1, 2 };
        }

        public Data data = new Data();
    }
}
