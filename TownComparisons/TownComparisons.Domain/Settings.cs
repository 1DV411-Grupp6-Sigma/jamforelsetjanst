using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TownComparisons.Domain
{
    public class Settings
    {
        //Path to folder 'App_Data'
        private readonly string _pathAppData;
        //Full path to settingsConfig.json
        private static string _settingsConfig;
        private JObject _settings;
        private string _municipality = "municipality";
        private string _location = "location";

        public string Municipality
        {
            get { return _settings[_location].Value<string>(_municipality); }
            set { SaveSettings(_location, _municipality, value); }
        }

        /// <summary>
        /// Will use settingsConfig.json in folder App_Data in current project
        /// </summary>
        public Settings()
        {
            _pathAppData = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/");
            string configFile = "settingsConfig.json";
             _settingsConfig = Path.Combine(_pathAppData, configFile);

            //Load settingsConfig.json to _settings variable
            LoadSettings();
        }

        /// <summary>
        /// Will use a custom path to config file
        /// </summary>
        /// <param name="filePath">Physical path to config file</param>
        public Settings(string filePath)
        {
            _settingsConfig = filePath;
            //Load settingsConfig.json to _settings variable
            LoadSettings();
        }

        /// <summary>
        /// Read settingsConfig.json and saves to _settings
        /// </summary>
        private void LoadSettings()
        {
            using (StreamReader file = File.OpenText(_settingsConfig))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                _settings = (JObject)JToken.ReadFrom(reader);
            }
        }

        /// <summary>
        /// Saves value to _settingsConfig.json
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        private void SaveSettings(string pathInJsonFile, string key, string value)
        {
            try
            {
                _settings[pathInJsonFile][key] = value;
                using (StreamWriter file = File.CreateText(_settingsConfig))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    _settings.WriteTo(writer);
                }

                //Refresh _settings variable 
                LoadSettings();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not write to settingsConfig.json. " + ex);
            }
        }


    }
}
