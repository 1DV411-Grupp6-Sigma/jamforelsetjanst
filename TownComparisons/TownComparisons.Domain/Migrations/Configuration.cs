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

            //first delete any previous categories (including it's associations to property queries and organisational units)
            foreach(var groupCategory in context.GroupCategories)
            {
                context.GroupCategories.Remove(groupCategory);
            }


            // Some queries for category
            PropertyQueryInfo query1 = new PropertyQueryInfo()
            {
                WebServiceName = koladaWebServiceName,
                QueryId = "N15030",
                OriginalTitle = "Lärare med pedagogisk högskoleexamen i grundskola, lägeskommun, (%)",
                Title = "Lärare med pedagogisk högskoleexamen i grundskola, lägeskommun, (%)"
            };
            PropertyQueryInfo query2 = new PropertyQueryInfo()
            {
                WebServiceName = koladaWebServiceName,
                QueryId = "N15033",
                OriginalTitle = "Elever/lärare (årsarbetare) i grundskola, lägeskommun, antal",
                Title = "Elever/lärare (årsarbetare) i grundskola, lägeskommun, antal"
            };
            PropertyQueryInfo query3 = new PropertyQueryInfo()
            {
                WebServiceName = koladaWebServiceName,
                QueryId = "N15406",
                OriginalTitle = "Elever i åk. 9 som minst uppnått kunskapskraven för Godkänd i ämnesprovet i matematik, kommunala skolor, andel (%)",
                Title = "Elever i åk. 9 som minst uppnått kunskapskraven för Godkänd i ämnesprovet i matematik, kommunala skolor, andel (%)"
            };
            PropertyQueryInfo query4 = new PropertyQueryInfo()
            {
                WebServiceName = koladaWebServiceName,
                QueryId = "N15807",
                OriginalTitle = "Elever i grundskola belägen i kommunen, antal",
                Title = "Elever i grundskola belägen i kommunen, antal"
            };
            PropertyQueryInfo query5 = new PropertyQueryInfo()
            {
                WebServiceName = koladaWebServiceName,
                QueryId = "N15403",
                OriginalTitle = "Elever i åk. 9, meritvärde kommunala skolor, genomsnitt (16 ämnen)",
                Title = "Elever i åk. 9, meritvärde kommunala skolor, genomsnitt (16 ämnen)"
            };
            PropertyQueryInfo query6 = new PropertyQueryInfo()
            {
                WebServiceName = koladaWebServiceName,
                QueryId = "N15422",
                OriginalTitle = "Elever i åk. 9 som är behöriga till ekonomi-, humanistiska och samhällsvetenskapsprogrammet, lägeskommun, andel (%)",
                Title = "Elever i åk. 9 som är behöriga till ekonomi-, humanistiska och samhällsvetenskapsprogrammet, lägeskommun, andel (%)"
            };
            //and some Organisational units for category
            OrganisationalUnitInfo ou1 = new OrganisationalUnitInfo()
            {
                OrganisationalUnitId = "V15E129000301",
                Name = "Slättängsskolan LM",
                ShortDescription = "Slättängsskolan 7-9 är en högstadieskola med tre till fyra klasser i varje årskurs. Vi har i dagsläget ca 240 elever.",
                LongDescription = "Slättängsskolan 7-9 är en högstadieskola med tre till fyra klasser i varje årskurs. Vi har i dagsläget ca 240 elever. Skolan tillhör Kristianstads västra skolområde. Våra elever kommer från olika delar av skolområdet: Köpinge skola, Helgedalskola och Slättängskolan F-6.",
                ImagePath = "",
                Address = "Slättängsvägen 96, 291 62, Kristianstad",
                Telephone = "044-13 60 44",
                Contact = "Sven-Erik Nilsson, rektor",
                Email = "sven-erik.nilsson@utb.kristianstad.se",
                OrganisationalForm = "Kommunal",
                Website = "www.kristianstad.se/Skolportaler/Slattangsskolan7-9/",
                Latitude = 56.019305,
                Longitude = 14.125117,
                Other = "Grundskola",
            };
            OrganisationalUnitInfo ou2 = new OrganisationalUnitInfo()
            {
                OrganisationalUnitId = "V15E129000401",
                Name = "Nosabyskolan",
                ShortDescription = "Nosabyskolan hör till Skolområde Östra i Kristianstad. Upptagningsområdet består av blandad bebyggelse med höghus och villaområden i kommundelarna Hammar, Kulltorp och Österäng.",
                LongDescription = "Nosabyskolan hör till Skolområde Östra i Kristianstad. Upptagningsområdet består av blandad bebyggelse med höghus och villaområden i kommundelarna Hammar, Kulltorp och Österäng. Våra lokaler är moderna och väl anpassade dagens undervisning.De togs i bruk i januari 2013.",
                ImagePath = "https://www.kristianstad.se/ImageVaultFiles/id_7933/cf_2/223x937.jpg",
                Address = "Balsbyvägen 6, 29147, Kristianstad",
                Telephone = "044-136021",
                Contact = "Per Gustafsson, rektor",
                Email = "per.gustafsson@kristianstad.se",
                OrganisationalForm = "Kommunal",
                Website = "https://www.kristianstad.se/sv/Skolportaler/nosabyskolan/",
                Latitude = 56.052475,
                Longitude = 14.196342,
                Other = "Grundskola",
            };
            OrganisationalUnitInfo ou3 = new OrganisationalUnitInfo()
            {
                OrganisationalUnitId = "V15E129000701",
                Name = "Öllsjöskolan LM",
                ShortDescription = "Skolan bedriver undervisning i F-9 och skolbarnomsorg för barn i åk F-6. Vi arbetar i två spår. I varje spår finns tre arbetslag indelade i F-3, 4-6 och 7-9. I arbetslagen F-6 ingår även verksamhet för barn i fritidshem och för elever i 7-9 finns verksamhet i elevcaféet.",
                LongDescription = "Skolan bedriver undervisning i F-9 och skolbarnomsorg för barn i åk F-6. Vi arbetar i två spår. I varje spår finns tre arbetslag indelade i F-3, 4-6 och 7-9. I arbetslagen F-6 ingår även verksamhet för barn i fritidshem och för elever i 7-9 finns verksamhet i elevcaféet. Det finns även ett arbetslag som arbetar för elevhälsan. På skolan finns engagerad personal med ett positivt och inkluderande förhållningssätt som vill ge eleverna en bra skola.Pedagogernas erfarenhet och kompetens tas tillvara för att nå en helhetssyn och hög kvalité.",
                ImagePath = "http://www.kristianstad.se/ImageVaultFiles/id_3650/cf_689/st_edited/B51DBx0ZxARwTj5f-xSo.jpg",
                Address = "Blåtands väg 20, 291 66, Kristianstad",
                Telephone = "044-134150",
                Contact = "Linus Pålsson, rektor",
                Email = "linus.palsson@kristianstad.se",
                OrganisationalForm = "Kommunal",
                Website = "http://www.kristianstad.se/sv/Skolportaler/ollsjoskolan/",
                Latitude = 56.011727,
                Longitude = 14.098495,
                Other = "Grundskola",
            };
            OrganisationalUnitInfo ou4 = new OrganisationalUnitInfo()
            {
                OrganisationalUnitId = "V15E129002002",
                Name = "Sånnaskolan LM",
                ShortDescription = "Sånnaskolan är F-9-skolan med varm och vänlig atmosfär där elever och personal trivs och elevernas måluppfyllelse är hög.",
                LongDescription = "Sånnaskolan är F-9-skolan med varm och vänlig atmosfär där elever och personal trivs och elevernas måluppfyllelse är hög. Våra klasser är små för de yngre barnen och större för de äldre eftersom vi då tar emot elever från Villaskolan och Yngsjö skola.",
                ImagePath = "",
                Address = "Sandvaktaregatan 1, 29635, Åhus",
                Telephone = "0733-134651",
                Contact = "Marcus Svensson, rektor 7-9",
                Email = "marcus.svensson@utb.kristianstad.se",
                OrganisationalForm = "Kommunal",
                Website = "https://www.kristianstad.se/sv/Skolportaler/sannaskolan/",
                Latitude = 55.9257,
                Longitude = 14.286111,
                Other = "Grundskola",
            };
            OrganisationalUnitInfo ou5 = new OrganisationalUnitInfo()
            {
                OrganisationalUnitId = "V15E129002401",
                Name = "Tollarps skola L",
                ShortDescription = "Tollarps skola präglas av en god kollegial stämning, där det finns en öppenhet till nytänkande och utrymme för kreativitet. Vi har ett gott samarbete i personalgruppen och arbetar lösningsfokuserat tillsammans för att nå en hög måluppfyllelse.",
                LongDescription = "Tollarps skola präglas av en god kollegial stämning, där det finns en öppenhet till nytänkande och utrymme för kreativitet. Vi har ett gott samarbete i personalgruppen och arbetar lösningsfokuserat tillsammans för att nå en hög måluppfyllelse. Skolan är en F - 9 skola i kommunal regi som även bedriver fritidsverksamhet för årskurs F - 6.På skolan finns 415 elever i åldershomogena klasser.Dessa klasser är indelade i två spår, A och B.Kopplat till verksamheten finns tre arbetslag indelade i F - 3, 4 - 6 och 7 - 9.Det finns även ett arbetslag som arbetar för elevhälsan, EHT.I det sistnämnda arbetslaget finns speciallärare, specialpedagoger, skolsköterska, kurator och studie - och yrkesvägledare inklusive rektorerna.",
                ImagePath = "https://www.kristianstad.se/PageFiles/88603/d-huset3.jpg",
                Address = "Borgargatan 13, 298 33 Tollarp",
                Telephone = "044-134503",
                Contact = "Eva Axelsson, rektor 4-9",
                Email = "eva.axelsson@utb.kristianstad.se",
                OrganisationalForm = "Kommunal",
                Website = "https://www.kristianstad.se/sv/Skolportaler/tollarpsskola/",
                Latitude = 55.931406,
                Longitude = 13.966987,
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
            c1.Queries.Add(query4);
            c1.Queries.Add(query5);
            c1.Queries.Add(query6);
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
