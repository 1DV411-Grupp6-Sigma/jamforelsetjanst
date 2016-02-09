using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Abstract;
using TownComparisons.Domain.DAL;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.WebServices;
using TownComparisons.Domain.WebServices.Models;

namespace TownComparisons.Domain
{
    public class Service : IService
    {
        // DAL-properties.
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

        // Just a temp method to use to access some database entitites
        public List<OrganisationalUnitInfo> GetOrganisationalUnitInfos()
        {
            return _unitOfWork.OrganisationalUnitInfoRepository.Get().ToList();
        }

        public List<GroupCategory> GetAllCategories()
        {
            return _unitOfWork.GroupCategoriesRepository.Get(null, null, "Categories").ToList();
        }
    }
}
