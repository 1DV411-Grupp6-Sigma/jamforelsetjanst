using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TownComparisons.Domain
{
    public class SettingsManager
    {
        private readonly string _filePath;

        public Settings Settings { get; private set; }

        public SettingsManager()
        {
            string pathAppData = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/");
            string configFile = "settingsConfig.json";
            _filePath = Path.Combine(pathAppData, configFile);

            LoadSettings();
        }
        public SettingsManager(string filePath)
        {
            _filePath = filePath;

            LoadSettings();
        }

        private void LoadSettings()
        {
            using (StreamReader file = File.OpenText(_filePath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                //JsonConvert.DeserializeObject<BlogEntry>(json);
                //Settings = (JObject)JToken.ReadFrom(reader);
            }
        }
    }
}
