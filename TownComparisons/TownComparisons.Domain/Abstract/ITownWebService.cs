﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.Models;
using TownComparisons.Domain.WebServices.Models;

namespace TownComparisons.Domain.Abstract
{
    public interface ITownWebService : IDisposable
    {
        string GetName();

        List<OrganisationalUnit> GetAllOrganisationalUnits(string municipalityId);
        OrganisationalUnit GetOrganisationalUnit(string id);
        List<PropertyResult> GetPropertyResults(List<string> queryIds, List<string> organisationalUnitIds);
        List<PropertyQueryGroup> GetAllPropertyQueries();
    }
}
