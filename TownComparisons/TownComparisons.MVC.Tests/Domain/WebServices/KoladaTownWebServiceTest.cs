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
            _webService = new KoladaTownWebService();
            
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
            var actual = _webService.GetOrganisationalUnit(UnitId);

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
