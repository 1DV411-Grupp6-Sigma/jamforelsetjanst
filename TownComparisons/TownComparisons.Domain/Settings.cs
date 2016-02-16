using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TownComparisons.Domain
{
    public class Settings
    {

        public string MunicipalityName { get; set; }
        public string MunicipalityId { get; set; } // id from Kolada API

        public string CountyName { get; set; }
        public string CountyId { get; set; } // id from Kolada API

    }
}
