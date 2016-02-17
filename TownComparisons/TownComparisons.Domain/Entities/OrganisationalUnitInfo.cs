using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownComparisons.Domain.Entities
{
    //this class holds the extra info for an "OU"
    public class OrganisationalUnitInfo
    {
        public int Id { get; set; }

        public string OrganisationalUnitId { get; set; }  // this is the external ID from the web service (like Kolada)

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string ImagePath { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string OrganisationalForm { get; set; } // Private, Public or some other form

        public string Website { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Other { get; set; }
    }
}
