using System;
using System.IO;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TownComparisons.MVC.Tests.Domain.Settings
{
    [TestClass]
    public class SettingsTest
    {
        private TownComparisons.Domain.SettingsForFile _settings;

        [TestInitialize]
        public void SetUp()
        {
            string path = Directory.GetCurrentDirectory();
            string addDirToPath = Path.Combine(path, "App_Data");
            string fullpath = Path.Combine(addDirToPath, "settingsConfig.json");
            _settings = new TownComparisons.Domain.SettingsForFile(fullpath);
        }

        /// <summary>
        /// Test that Settings will not throw an exception when writing to config file
        /// </summary>
        [TestMethod]
        public void Test_Settings_WriteToSettingsConfigFile()
        {
            string location = "Göteborg";

            _settings.Municipality = location;
            
        }


        /// <summary>
        /// Test reading from config file
        /// </summary>
        [TestMethod]
        public void Test_Settings_ReadSettingsConfigFile()
        {
            string expected = "Växsö";
            _settings.Municipality = expected;

            var actual = _settings.Municipality;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Test_Settings_GetIdForName()
        {
            string city = "Växjö";
            string cityId = "1290";
            _settings.Municipality = city;
            _settings.MunicipalityId = cityId;

            var getCity = _settings.Municipality;
            var getId = _settings.MunicipalityId;

            Assert.AreEqual(getCity, getCity);
            Assert.AreEqual(getId, "1290");
        }

    }
}
