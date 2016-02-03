using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TownComparisons.Domain.WebServices;

namespace TownComparisons.MVC.Tests.Domain.WebServices
{
    [TestClass]
    public class KoladaTownWebServiceTest
    {
        private KoladaTownWebService _webService;

        [TestInitialize]
        public void SetUp()
        {
            string path = Directory.GetCurrentDirectory();
            string addDirToPath = Path.Combine(path, "App_Data");
            string fullpath = Path.Combine(addDirToPath, "settingsConfig.json");
            var settings = new TownComparisons.Domain.Settings(fullpath);

            _webService = new KoladaTownWebService(settings);
            
        }

        //For Development, _webService.FetchMunicipalityInfo() is private in production code
        //[TestMethod]
        //public void Test_GetMunicipality_NoExceptionsThrown()
        //{
        //   
        //   _webService.FetchMunicipalityInfo();

        //}
    }
}
