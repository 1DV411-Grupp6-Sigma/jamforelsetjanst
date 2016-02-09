using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Abstract;
using TownComparisons.Domain.DAL;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;
using TownComparisons.Domain.WebServices;
using TownComparisons.Domain.WebServices.Models;

namespace TownComparisons.Domain
{
    public class Service : IService
    {
        private readonly SettingsForFile _settings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITownWebService _townWebService;

        //Constructors
        public Service()
            : this (new SettingsForFile(), new UnitOfWork(), new KoladaTownWebService())
        {
            // Empty
        }
        
        public Service(SettingsForFile settings, IUnitOfWork unitOfWork, ITownWebService townWebService)
        {
            _settings = settings;
            _unitOfWork = unitOfWork;
            _townWebService = townWebService;
        }

        public List<PropertyQueryGroup> GetAllPropertyQueries()
        {
            return _townWebService.GetAllPropertyQueries();
        }

        public List<KpiAnswer> GetKpiAnswersByKpiQuestionAndOrganisationalUnit(List<KpiQuestion> kpiQuestion, List<OrganisationalUnit> organisationalUnit)
        {
            return _townWebService.GetKpiAnswersByKpiQuestionAndOrganisationalUnits(kpiQuestion, organisationalUnit);
        }

        public List<KpiGroup> TempGetKpiGroupByCategory(Category category)
        {
            return _townWebService.TempGetKpiGroupByCategory(category);
        }

        public OrganisationalUnit GetOrganisationalUnitByID(string id)
        {
            return _townWebService.GetOrganisationalUnitByID(id);
        }

        public List<OrganisationalUnit> GetAllOrganisationalUnits()
        {
            return _townWebService.GetAllOrganisationalUnits(_settings.MunicipalityId);
        }
        public List<OrganisationalUnit> GetOrganisationalUnitsByCategory(Category category)
        {
            return _townWebService.GetOrganisationalUnitByMunicipalityAndCategory(_settings.MunicipalityId, category);
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
        
        public Category GetCategory(int id)
        {
            return _unitOfWork.CategoriesRepository.Get(c => c.Id == id).FirstOrDefault();
        }
    }
}
