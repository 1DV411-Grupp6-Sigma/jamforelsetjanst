using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Abstract;
using TownComparisons.Domain.Entities;

namespace TownComparisons.Domain.DAL
{
    public class TownComparisonsContext : DbContext, ITownComparisonsContext
    {
        public IDbSet<OrganisationalUnitInfo> OrganisationalUnitInfos { get; set; }
        //public IDbSet<Settings> Settings { get; set; }
        public IDbSet<GroupCategory> GroupCategories { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<WebServiceQuery> WebServiceQueries { get; set; }


        public TownComparisonsContext()
            : base("TownComparisonsContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //removes plural to table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //if we want to use (automatically created) stored procedures (might enhance performance a little)
            //modelBuilder.Entity<OrganisationalUnitInfo>().MapToStoredProcedures();

            //### an example of how to make cascade delete work if needed:
            /* modelBuilder.Entity<WeatherDataPoint>().HasKey(d => d.Id)
                                                .HasRequired(d => d.WeatherForecast)
                                                .WithMany(f => f.DataPoints)
                                                .WillCascadeOnDelete(true); */

            //not sure if this needs to be run?
            //base.OnModelCreating(modelBuilder);
        }
    }
}
