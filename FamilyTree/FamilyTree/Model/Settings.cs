using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace FamilyTree
{
    class Settings
    {
        public bool darkMode;
        public bool isRussian;
        public static Settings settings;

        public Settings(bool darkMode, bool isRussian)
        {
            this.darkMode = darkMode;
            this.isRussian = isRussian;
        }

        public static void Save()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sets.json");
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(Settings.settings);
            File.WriteAllText(fileName, output);
        }

        public static void Load()
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sets.json");
            string info = File.ReadAllText(fileName);
            Settings set = Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(info);
            Settings.settings = set;
        }

        public static Color GetMainPageColor()
        {
            return Settings.settings.darkMode ? Color.FromHex("#455a64") : Color.FromHex("#85d0cd");
        }

        public static Color GetBarBackgroundColor()
        {
            return Settings.settings.darkMode ? Color.FromHex("#283593") : Color.FromHex("#2b8200");
        }

    }



}
