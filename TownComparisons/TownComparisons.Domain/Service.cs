using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Abstract;
using TownComparisons.Domain.DAL;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Helpers;
using TownComparisons.Domain.Models;
using TownComparisons.Domain.WebServices;
using TownComparisons.Domain.WebServices.Models;

namespace TownComparisons.Domain
{
    public class Service : IService
    {
        private readonly Settings _settings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITownWebService _townWebService;
        private readonly ICache _cache;

        //Constructors
        public Service()
            : this (new Settings(true), new UnitOfWork(), new KoladaTownWebService(), new CacheManager())
        {
            // Empty
        }
        
        public Service(Settings settings, IUnitOfWork unitOfWork, ITownWebService townWebService, ICache cacheManager)
        {
            _settings = settings;
            _unitOfWork = unitOfWork;
            _townWebService = townWebService;
            _cache = cacheManager;
        }

        //Methods
        public List<PropertyQueryGroup> GetAllPropertyQueries()
        {
            var list = new List<PropertyQueryGroup>();
            string cacheKey = "getAllPropertyQueries";

            //returns from cache if value is present, else returns from Webservice
            if (_cache.HasValue(cacheKey))
            {
                return (List<PropertyQueryGroup>)_cache.GetCache(cacheKey);
            }

            //Get from webService
            list = _townWebService.GetAllPropertyQueries();
            //Save to cache
            _cache.SetCache(cacheKey, list, _settings.CacheSeconds_PropertyQueries);

            return list;
        }

        public List<PropertyResult> GetPropertyResults(List<PropertyQuery> queries, List<OrganisationalUnit> organisationalUnits)
        {
            //Get id's from All KpiQuestions and OrganisationalUnits in parameter
            //and compund to an unique cacheKey
            var kpiQuestionIds = from q in queries
                                 select q.QueryId;
            var ouIds = from ou in organisationalUnits
                        select ou.OrganisationalUnitId;

            //adding all KPIQuestionId + ouIds 
            var cacheKey = kpiQuestionIds.Aggregate("", (current, kpi) => current + kpi);
            cacheKey = ouIds.Aggregate(cacheKey, (current, ouId) => current + ouId);

            if (_cache.HasValue(cacheKey))
            {
                return (List<PropertyResult>)_cache.GetCache(cacheKey);
            }

            var returnValue = _townWebService.GetPropertyResults(queries, organisationalUnits);
            _cache.SetCache(cacheKey, returnValue, _settings.CacheSeconds_PropertyResult);

            return returnValue;
        }
        
        public OrganisationalUnit GetOrganisationalUnitByID(string id)
        {
            string cacheKey = $"{"getOrganisationalUnitByID"}{id}";

            if (_cache.HasValue(cacheKey))
            {
                return (OrganisationalUnit)_cache.GetCache(cacheKey);
            }

            var ou = _townWebService.GetOrganisationalUnitByID(id);
            _cache.SetCache(cacheKey, ou, _settings.CacheSeconds_OrganisationalUnits);

            return ou;
        }


        public List<OrganisationalUnit> GetAllOrganisationalUnits()
        {
            string id = _settings.MunicipalityId;
            string cacheKey = $"{"getAllOrganisationalUnits"}{id}";

            if (_cache.HasValue(cacheKey))
            {
                return (List<OrganisationalUnit>)_cache.GetCache(cacheKey);
            }

            var allOU = _townWebService.GetAllOrganisationalUnits(_settings.MunicipalityId);
            _cache.SetCache(cacheKey, allOU, _settings.CacheSeconds_OrganisationalUnits);

            return allOU;
        }
        
        // Just a temp method to use to access some database entitites
        //Saves in cache for 10 seconds
        public List<OrganisationalUnitInfo> GetOrganisationalUnitInfos()
        {
            string cacheKey = "getOrganisationalUnitInfos";

            if (_cache.HasValue(cacheKey))
            {
                return (List<OrganisationalUnitInfo>)_cache.GetCache(cacheKey);
            }

            var returnValue = _unitOfWork.OrganisationalUnitInfoRepository.Get().ToList();
            //Saves in cache for 10 seconds
            _cache.SetCache(cacheKey, returnValue, 10);

            return returnValue;
        }

        public OrganisationalUnitInfo GetOrganisationalUnitInfo(string organisationalUnitId)
        {
            string cacheKey = "getOrganisationalUnitInfo";

            if (_cache.HasValue(cacheKey))
            {
                return (OrganisationalUnitInfo)_cache.GetCache(cacheKey);
            }

            var returnValue = _unitOfWork.OrganisationalUnitInfoRepository.Get(o => o.OrganisationalUnitId == organisationalUnitId).FirstOrDefault();
            //Saves in cache for 10 seconds
            _cache.SetCache(cacheKey, returnValue, 10);

            return returnValue;
        }

        public List<GroupCategory> GetAllCategories()
        {
            string cacheKey = "getAllCategories";

            if (_cache.HasValue(cacheKey))
            {
                return (List<GroupCategory>)_cache.GetCache(cacheKey);
            }

            var listOfAllCategories = _unitOfWork.GroupCategoriesRepository.Get(null, null, "Categories").ToList();

            return listOfAllCategories;

        }

        public Category GetCategory(int id)
        {
            Category category = _unitOfWork.CategoriesRepository.Get(c => c.Id == id).FirstOrDefault();
            return category;
        }
    }
}
