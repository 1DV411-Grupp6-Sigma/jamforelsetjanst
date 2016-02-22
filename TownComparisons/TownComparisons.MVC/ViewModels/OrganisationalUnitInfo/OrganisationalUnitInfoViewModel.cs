using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TownComparisons.MVC.ViewModels.OrganisationalUnitInfo
{
    public class OrganisationalUnitInfoViewModel
    {
        public int Id { get; set; }

        public string OrganisationalUnitId { get; set; }  // this is the external ID from the web service (like Kolada)

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string ImagePath { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public string OrganisationalForm { get; set; } // Private, Public or some other form

        public string Website { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Other { get; set; }

        public OrganisationalUnitInfoViewModel()
        {
            //Empty
        }
        public OrganisationalUnitInfoViewModel(TownComparisons.Domain.Entities.OrganisationalUnitInfo entity)
        {
            Id = entity.Id;
            OrganisationalUnitId = entity.OrganisationalUnitId;
            Name = entity.Name;
            ShortDescription = entity.ShortDescription;
            LongDescription = entity.LongDescription;
            ImagePath = entity.ImagePath;
            Address = entity.Address;
            Telephone = entity.Telephone;
            Contact = entity.Contact;
            Email = entity.Email;
            Website = entity.Website;
            Latitude = entity.Latitude;
            Longitude = entity.Longitude;
            Other = entity.Other;
        }
    }
}