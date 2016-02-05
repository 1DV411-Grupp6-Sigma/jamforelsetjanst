using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Entities;

namespace TownComparisons.Domain.DAL
{
    public class TownComparisonsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TownComparisonsContext>
    {
        protected override void Seed(TownComparisonsContext context)
        {
            //some test data

            OrganisationalUnitInfo ouInfo1 = new OrganisationalUnitInfo()
            {
                ShortDescription = "En kort beskrivning",
                LongDescription = "En mycket längre beskrivning",
                OrganisationalUnitId = "NÅT_OUID_FRÅN_KOLADA"
            };
            context.OrganisationalUnitInfos.Add(ouInfo1);



            Category c1 = new Category()
            {
                Name = "Grundskola"
            };
            context.Categories.Add(c1);
            Category c2 = new Category()
            {
                Name = "Förskola"
            };
            context.Categories.Add(c2);
            
            GroupCategory gc1 = new GroupCategory()
            {
                Name = "Skola"
            };
            gc1.Categories.Add(c1);
            gc1.Categories.Add(c2);
            context.GroupCategories.Add(gc1);


        }

        /// <summary>
        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        /// </summary>
        /// <param name="context">The context.</param>
        private void SaveChanges(TownComparisonsContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
