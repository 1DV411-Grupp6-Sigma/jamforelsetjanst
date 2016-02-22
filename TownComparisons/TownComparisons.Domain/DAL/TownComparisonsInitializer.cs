using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownComparisons.Domain.Entities;
using TownComparisons.Domain.WebServices;

namespace TownComparisons.Domain.DAL
{
    public class TownComparisonsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TownComparisonsContext>
    {
        protected override void Seed(TownComparisonsContext context)
        {
            //some test data

            string koladaWebServiceName = new KoladaTownWebService().GetName();

            OrganisationalUnitInfo ouInfo1 = new OrganisationalUnitInfo()
            {
                ShortDescription = "Lorem ipsum dolor sit amet," +
                                   "consectetur adipiscing elit, sed do eiusmod tempor" +
                                   "incididunt ut labore et dolore magna aliqua. Ut enim ad" +
                                   "minim veniam, quis nostrud exercitation ullamco laboris nisi" +
                                   "ut aliquip ex ea commodo consequat. Duis aute irure dolor in" +
                                   "reprehenderit in voluptate velit esse cillum dolore eu fugiat" +
                                   "nulla pariatur. Excepteur sint occaecat cupidatat non proident," +
                                   "sunt in culpa qui officia deserunt mollit anim id est laborum.",
                LongDescription = "Lorem ipsum dolor sit amet," +
                                   "consectetur adipiscing elit, sed do eiusmod tempor" +
                                   "incididunt ut labore et dolore magna aliqua. Ut enim ad" +
                                   "minim veniam, quis nostrud exercitation ullamco laboris nisi" +
                                   "ut aliquip ex ea commodo consequat. Duis aute irure dolor in" +
                                   "reprehenderit in voluptate velit esse cillum dolore eu fugiat" +
                                   "nulla pariatur. Excepteur sint occaecat cupidatat non proident," +
                                   "sunt in culpa qui officia deserunt mollit anim id est laborum." +
                                   "Lorem ipsum dolor sit amet," +
                                   "consectetur adipiscing elit, sed do eiusmod tempor" +
                                   "incididunt ut labore et dolore magna aliqua. Ut enim ad" +
                                   "minim veniam, quis nostrud exercitation ullamco laboris nisi" +
                                   "ut aliquip ex ea commodo consequat. Duis aute irure dolor in" +
                                   "reprehenderit in voluptate velit esse cillum dolore eu fugiat" +
                                   "nulla pariatur. Excepteur sint occaecat cupidatat non proident," +
                                   "sunt in culpa qui officia deserunt mollit anim id est laborum." +
                                   "Lorem ipsum dolor sit amet," +
                                   "consectetur adipiscing elit, sed do eiusmod tempor" +
                                   "incididunt ut labore et dolore magna aliqua. Ut enim ad" +
                                   "minim veniam, quis nostrud exercitation ullamco laboris nisi" +
                                   "ut aliquip ex ea commodo consequat. Duis aute irure dolor in" +
                                   "reprehenderit in voluptate velit esse cillum dolore eu fugiat" +
                                   "nulla pariatur. Excepteur sint occaecat cupidatat non proident," +
                                   "sunt in culpa qui officia deserunt mollit anim id est laborum.",
                OrganisationalUnitId = "V15E128300201",
                ImagePath = "",
                Address = "Essingestråket 24 112 66 Stockholm",
                Telephone = "08-441 30 30",
                Contact = "Sophie Maraux, rektor gymnasium",
                Email = "secretariat@​lfsl.net",
                OrganisationalForm = "Fristående/privat",
                Website= "http:/​/​www.​lfsl.​net/ ",
                Latitude="",
                Longitude="",
                Other= "Gymnasieskola",
            };
            context.OrganisationalUnitInfos.Add(ouInfo1);


            #region CategoryStuff

            // Some queries for category
            CategoryPropertyQuery query1 = new CategoryPropertyQuery()
            {
                WebServiceName = koladaWebServiceName,
                QueryId = "N15030",
                Title = "Lärare med pedagogisk högskoleexamen i grundskola, lägeskommun, (%)"
            };
            CategoryPropertyQuery query2 = new CategoryPropertyQuery()
            {
                WebServiceName = koladaWebServiceName,
                QueryId = "N15033",
                Title = "Elever/lärare (årsarbetare) i grundskola, lägeskommun, antal"
            };
            CategoryPropertyQuery query3 = new CategoryPropertyQuery()
            {
                WebServiceName = koladaWebServiceName,
                QueryId = "N15406",
                Title = "Elever i åk. 9 som minst uppnått kunskapskraven för Godkänd i ämnesprovet i matematik, kommunala skolor, andel (%)"
            };
            //and some Organisational units for category
            OrganisationalUnitInfo ou1 = new OrganisationalUnitInfo()
            {
                OrganisationalUnitId = "V15E108000701",
                Name = "Rödebyskolan 7-9"
            };
            OrganisationalUnitInfo ou2 = new OrganisationalUnitInfo()
            {
                OrganisationalUnitId = "V15E108000801",
                Name = "Nättrabyskolan 7-9"
            };
            OrganisationalUnitInfo ou3 = new OrganisationalUnitInfo()
            {
                OrganisationalUnitId = "V15E108000901",
                Name = "Fridlevstads skola F-6"
            };

            //main categories
            Category c1 = new Category()
            {
                Name = "Grundskola"
            };
            c1.Queries.Add(query1);
            c1.Queries.Add(query2);
            c1.Queries.Add(query3);
            c1.OrganisationalUnits.Add(ou1);
            c1.OrganisationalUnits.Add(ou2);
            c1.OrganisationalUnits.Add(ou3);
            context.Categories.Add(c1);

            Category c2 = new Category()
            {
                Name = "Förskola"
            };
            context.Categories.Add(c2);
            
            //group categories
            GroupCategory gc1 = new GroupCategory()
            {
                Name = "Skola"
            };
            gc1.Categories.Add(c1);
            gc1.Categories.Add(c2);
            context.GroupCategories.Add(gc1);

            Category c3 = new Category()
            {
                Name = "Sjukhus"
            };
            context.Categories.Add(c3);

            GroupCategory gc2 = new GroupCategory()
            {
                Name = "Sjukvård & hälsa"
            };
            gc2.Categories.Add(c3);
            context.GroupCategories.Add(gc2);


            #endregion

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
