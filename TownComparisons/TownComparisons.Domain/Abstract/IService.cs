using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Entities;

namespace TownComparisons.Domain.Abstract
{
    public interface IService
    {
        List<Operator> GetTownOperators(Municipality municipality, Category category);

    }
}
