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

        // DAL-properties. Commented them because I've got a error when compiled.
        ////private readonly IUnitOfWork _unitOfWork;
        private readonly ITownWebService _townWebService;


        //Constructors
        // Commented: "new UnitOfWork(), "
        public Service()
            : this (new KoladaTownWebService())
        {
            // Empty
        }

        // Commented: "IUnitOfWork unitOfWork, ".
        public Service(ITownWebService townWebService)
        {
            //_unitOfWork = unitOfWork;
            _townWebService = townWebService;
        }

        public List<KpiGroup> GetAllKpiGroups()
        {
            return _townWebService.GetAllKpiGroups();
        }

        public List<KpiAnswer> GetKpiAnswersByKpiQuestionAndOrganisationalUnit(List<KpiQuestion> kpiQuestion, List<OrganisationalUnit> organisationalUnit)
        {
            return _townWebService.GetKpiAnswersByKpiQuestionAndOrganisationalUnit(kpiQuestion, organisationalUnit);
        }

        public List<KpiGroup> GetKpiGroupByCategory(Category category)
        {
            return _townWebService.GetKpiGroupByCategory(category);
        }

        public OrganisationalUnit GetOrganisationalUnitByID(string id)
        {
            return _townWebService.GetOrganisationalUnitByID(id);
        }

        public List<OrganisationalUnit> GetOrganisationalUnitByMunicipalityAndCategory(Municipality municipality, Category category)
        {
            return _townWebService.GetOrganisationalUnitByMunicipalityAndCategory(municipality, category);
        }


        // Commented this method.

        ////Methods
        //public List<OperationalUnit> GetTownOperators(Municipality municipality, Category category)
        //{
        //    throw new NotImplementedException();
        //    //return _townWebService.GetTownOperators(municipality, category);
        //}
        //public List<OrganisationalUnits> GetOrganisationalUnits()
        //{
        //    return this.GetOrganisationalUnits();
        //}


        ////just a temp method to use to access some database entitites
        //public List<OrganisationalUnitInfo> GetOrganisationalUnitInfos()
        //{
        //    return _unitOfWork.OrganisationalUnitInfoRepository.Get().ToList();
        //}

    }
}
