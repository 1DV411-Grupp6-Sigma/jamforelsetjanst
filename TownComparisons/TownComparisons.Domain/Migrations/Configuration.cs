using TownComparisons.Domain.Entities;
using TownComparisons.Domain.WebServices;

namespace TownComparisons.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TownComparisons.Domain.DAL.TownComparisonsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false; 
        }

        protected override void Seed(TownComparisons.Domain.DAL.TownComparisonsContext context)
        {

            string koladaWebServiceName = new KoladaTownWebService().GetName();

            
            
            #region CategoryStuff

            foreach(var groupCategory in context.GroupCategories)
            {
                context.GroupCategories.Remove(groupCategory);
            }

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
                OrganisationalUnitId = "V15E18784702",
                Name = "Vasaskolan",
                ShortDescription = "Vi stöttar och utvecklar våra barn och elever till trygga, hälso-medvetna och ansvarstagande individer som är kreativa och vågar göra aktiva val i livet.",
                LongDescription = "Vi stöttar och utvecklar våra barn och elever till trygga, hälso-medvetna och ansvarstagande individer som är kreativa och vågar göra aktiva val i livet. Vi satsar på att nå varje individ på rätt nivå genom att utveckla barnets/elevens styrkor på bästa sätt. För oss är det viktigt att alla i vår verksamhet har respekt för olikheter och vågar stå upp för andra människors värde och unikhet. Vi tror detta leder till livslång kunskap. Inom vårt skolområde görs en särskild satsning på de naturvetenskapliga ämnena från 1-16 år. Detta för att stärka individen i sin världsuppfattning.",
                ImagePath = "",
                Address = "Germundsgatan 7-9, 392 45, Kalmar",
                Telephone = "0480-45 33 50",
                Contact = "Andreas Hjortenkrans, rektor",
                Email = "andreas.hjortenkrans@kalmar.se",
                OrganisationalForm = "Kommunal",
                Website = "http://www.kalmar.se/vasaskolan/",
                Latitude = "56.660693 ",
                Longitude = "16.342839",
                Other = "Grundskola",
            };
            OrganisationalUnitInfo ou2 = new OrganisationalUnitInfo()
            {
                OrganisationalUnitId = "V15E088003301",
                Name = "Falkenbergsskolan",
                ShortDescription = "Falkenbergsskolan arbetar för att alla våra elever ska utvecklas maximalt mot god måluppfyllelse såväl när det gäller kunskaper som det sociala välmåendet.",
                LongDescription = "Falkenbergsskolan arbetar för att alla våra elever ska utvecklas maximalt mot god måluppfyllelse såväl när det gäller kunskaper som det sociala välmåendet.Som elev vill vi att du ska vara förberedd för vidare studier, arbetslivet och livet i stort.Viktiga ledord i vårt arbete är kunskap, kommunikation, kultur samt idrott och hälsa. Samverkan med arbetslivet, föreningslivet och samhället lokalt som globalt är en viktig del av vårt arbete tillsammans med våra elever och medarbetare.",
                ImagePath = "",
                Address = "Falkenbergsvägen 12, 392 44, Kalmar",
                Telephone = "0480-45 33 00",
                Contact = "Per-Ola Jacobson, rektor",
                Email = "per-ola.jacobson@kalmar.se",
                OrganisationalForm = "Kommunal",
                Website = "http://www.kalmar.se/falkenbergsskolan",
                Latitude = "56.662207",
                Longitude = "16.327105",
                Other = "Grundskola",
            };
            OrganisationalUnitInfo ou3 = new OrganisationalUnitInfo()
            {
                OrganisationalUnitId = "V15E088003701",
                Name = "Lindöskolan",
                ShortDescription = "Lindöskolan har ett centralt och naturnära läge, där vi använder oss av områdets utbud av kultur, natur och näringsliv.",
                LongDescription = "Lindöskolan har ett centralt och naturnära läge, där vi använder oss av områdets utbud av kultur, natur och näringsliv. Tack vare vårt centrala läge har vi gång- och cykelavstånd till exempelvis muséer, Kalmar slott, ishall och simhall. Skolan omfattas av förskoleklass och grundskola 1-5 samt fritidshem.",
                ImagePath = "",
                Address = "Lindövägen 3, 392 35 Kalmar",
                Telephone = "0480-45 32 70",
                Contact = "Karin Berggren, rektor",
                Email = "karin.berggren@kalmar.se",
                OrganisationalForm = "Kommunal",
                Website = "http://www.kalmar.se/lindoskolan",
                Latitude = "56.673646",
                Longitude = "16.357482",
                Other = "Grundskola",
            };
            OrganisationalUnitInfo ou4 = new OrganisationalUnitInfo()
            {
                OrganisationalUnitId = "V15E018001701",
                Name = "Gärdesskolan",
                ShortDescription = "Gärdesskolan är F-9 skola med ca 750 elever på Gärdet/Östermalm. Gärdesskolan har låg- mellan- och högstadium. Skolans övergripande profiler är hälsa och läsning. ",
                LongDescription = "Gärdesskolan är F-9 skola med ca 750 elever på Gärdet/Östermalm. Gärdesskolan har låg- mellan- och högstadium. Skolans övergripande profiler är hälsa och läsning. ",
                ImagePath = "",
                Address = "Banergatan 56, 115 53, Stockholm",
                Telephone = "08-508 44 250",
                Contact = "Maria Radway, rektor",
                Email = "maria.radway@stockholm.se",
                OrganisationalForm = "Kommunal",
                Website = "http://http://gardesskolan.stockholm.se/",
                Latitude = "59.34019 ",
                Longitude = "18.098517",
                Other = "Grundskola",
            };
            OrganisationalUnitInfo ou5 = new OrganisationalUnitInfo()
            {
                OrganisationalUnitId = "V15E078000201",
                Name = "Fagrabäckskolan",
                ShortDescription = "Fagrabäckskolans elever kommer från Högstorpskolan, Lillestadskolan, Östregårdskolan, Furuby skola, Åryd skola, Sandsbro skola, Centrumskolan och Ulriksbergskolan.",
                LongDescription = "Fagrabäckskolans elever kommer från Högstorpskolan, Lillestadskolan, Östregårdskolan, Furuby skola, Åryd skola, Sandsbro skola, Centrumskolan och Ulriksbergskolan. Detta läsår har vi cirka 650 elever och ungefär 100 av dem går på skolans Naturvetenskapliga och Tekniska inriktning, NoT, som är förlagd på Teknikum.",
                ImagePath = "",
                Address = "Österleden 70, 352 42, Växjö",
                Telephone = "0470-416 95",
                Contact = "Caroline Hedenbergh, rektor",
                Email = "caroline.hedenbergh@vaxjo.se",
                OrganisationalForm = "Kommunal",
                Website = "http://www.vaxjo.se/fagrabackskolan",
                Latitude = "56.881238",
                Longitude = "14.830092",
                Other = "Grundskola",
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
            c1.OrganisationalUnits.Add(ou4);
            c1.OrganisationalUnits.Add(ou5);
            context.Categories.Add(c1);

            Category c2 = new Category()
            {
                Name = "Förskola"
            };
            context.Categories.Add(c2);

            Category c4 = new Category()
            {
                Name = "Gymnasieskola"
            };
            context.Categories.Add(c4);

            //group categories
            GroupCategory gc1 = new GroupCategory()
            {
                Name = "Skola"
            };
            gc1.Categories.Add(c1);
            gc1.Categories.Add(c2);
            gc1.Categories.Add(c4);
            context.GroupCategories.Add(gc1);

            Category c3 = new Category()
            {
                Name = "Sjukhus"
            };
            context.Categories.Add(c3);

            Category c5 = new Category()
            {
                Name = "Vårdcentral"
            };
            context.Categories.Add(c5);

            GroupCategory gc2 = new GroupCategory()
            {
                Name = "Sjukvård & hälsa"
            };
            gc2.Categories.Add(c3);
            gc2.Categories.Add(c5);
            context.GroupCategories.Add(gc2);


            #endregion
        }
    }
}
