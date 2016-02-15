using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TownComparisons.Domain.WebServices;
using TownComparisons.Domain.Models;

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
            var settings = new TownComparisons.Domain.SettingsForFile(fullpath);

            _webService = new KoladaTownWebService(); // (settings);
            
        }

        /// <summary>
        /// Test GetOrganisationalUnitById method
        /// </summary>
        [TestMethod]
        public void Test_KoladaTownWebService_GetOrganisationalUnitById()
        {
            string UnitId = "V15E128300201";
            var expected = new OrganisationalUnit("Kolada", "V15E128300201", "Elinebergsskolan");

            _webService = new KoladaTownWebService();
            var actual = _webService.GetOrganisationalUnitByID(UnitId);

            Assert.AreEqual(actual.Name, expected.Name);
            Assert.AreEqual(actual.OrganisationalUnitId, expected.OrganisationalUnitId);

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
