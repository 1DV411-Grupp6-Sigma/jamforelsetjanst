using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Abstract;
using TownComparisons.Domain.Entities;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace TownComparisons.Domain.WebServices
{
    public class KoladaTownWebService : TownWebServiceBase
    {
        //(kod för att anropa Kolada API här i olika funktioner)


        public IEnumerable<OperationalUnit> GetTownOperators(Municipality municipality, Category category)
        {
            //Method added becouse project would not compile without it!!
            throw new NotImplementedException();
        }
        public override OperationalUnit GetTownOperatorData(OperationalUnit operator_)
        {

            throw new NotImplementedException();
        }

        public override List<OrganisationalUnit> GetOrganisationalUnits(Municipality municipality)
        {
            var rawJson = string.Empty;

            /*
             * http://api.kolada.se/v2/ou?municipality=1290
             * This is the URL that returns organisational units based on monicipality Id.
             * This is exactly what we need.
             */
            var BaseUrlGetOperators = BaseUrl + "ou?" + "municipality=" + municipality.Id;

            var request = (HttpWebRequest)WebRequest.Create(BaseUrlGetOperators);

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJson = reader.ReadToEnd();
            }

            var OU = JsonConvert.DeserializeObject<OrganisationalUnits>(rawJson).Values;

            return OU;
        }

    }
}
