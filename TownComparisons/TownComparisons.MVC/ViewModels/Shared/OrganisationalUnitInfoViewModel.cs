using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TownComparisons.Domain.Entities;

namespace TownComparisons.MVC.ViewModels.Shared
{
    public class OrganisationalUnitInfoViewModel
    {
        public int Id { get; set; }

        public string OrganisationalUnitId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string ImagePath { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string Telephone { get; set; }

        [MaxLength(100)]
        public string Contact { get; set; }

        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(50)]
        public string OrganisationalForm { get; set; } // Private, Public or some other form

        [MaxLength(100)]
        public string Website { get; set; }
        
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        [MaxLength(50)]
        public string Other { get; set; }




        public OrganisationalUnitInfoViewModel()
        {
            //Empty
        }
        public OrganisationalUnitInfoViewModel(Domain.Entities.OrganisationalUnitInfo entity)
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
            OrganisationalForm = entity.OrganisationalForm;
            Website = entity.Website;
            Latitude = entity.Latitude;
            Longitude = entity.Longitude;
            Other = entity.Other;
        }
    }
}