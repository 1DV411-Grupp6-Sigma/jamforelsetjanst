using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Abstract;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.WebServices;

namespace TownComparisons.Domain
{
    public class Service : IService
    {
        //(detta är huvud-klassen som används från controllers i MVC-projektet)

        ITownWebService _townWebService;

        //Constructors
        public Service()
            : this (new KoladaTownWebService())
        {
            // Empty
        }
        public Service(ITownWebService townWebService)
        {
            _townWebService = townWebService;
        }


        //Methods
        public List<OperationalUnit> GetTownOperators(Municipality municipality, Category category)
        {
            return _townWebService.GetTownOperators(municipality, category);
        }

    }
}
