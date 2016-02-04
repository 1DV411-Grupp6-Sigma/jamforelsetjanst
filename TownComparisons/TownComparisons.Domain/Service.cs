using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Abstract;
using TownComparisons.Domain.DAL;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.WebServices;

namespace TownComparisons.Domain
{
    public class Service : IService
    {
        //(detta är huvud-klassen som används från controllers i MVC-projektet)

        private readonly IUnitOfWork _unitOfWork;
        private readonly ITownWebService _townWebService;
       

        //Constructors
        public Service()
            : this (new UnitOfWork(), new KoladaTownWebService())
        {
            // Empty
        }
        public Service(IUnitOfWork unitOfWork, ITownWebService townWebService)
        {
            _unitOfWork = unitOfWork;
            _townWebService = townWebService;
        }

        

        //Methods
        public List<OperationalUnit> GetTownOperators(Municipality municipality, Category category)
        {
            throw new NotImplementedException();
            //return _townWebService.GetTownOperators(municipality, category);
        }
        public List<OrganisationalUnits> GetOrganisationalUnits()
        {
            return this.GetOrganisationalUnits();
        }


        //just a temp method to use to access some database entitites
        public List<OrganisationalUnitInfo> GetOrganisationalUnitInfos()
        {
            return _unitOfWork.OrganisationalUnitInfoRepository.Get().ToList();
        }

    }
}
