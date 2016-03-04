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

        //private static string PhysicalUploadedImagesPath= System.Web.HttpContext.Current.Server.MapPath(".") + @"\Content\pictures\";

        private static string path = System.AppDomain.CurrentDomain.BaseDirectory + @"\Content\pictures\";

        public int Id { get; set; }

        [Required]
        public string OrganisationalUnitId { get; set; }

        [Required(ErrorMessage = "Namnet måste fyllas i.")]
        [MaxLength(100, ErrorMessage = "Namnet kan inte vara längre än {1} tecken.")]
        [MinLength(3, ErrorMessage = "Namnet måste vara minst {1} tecken.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Korta beskrivningen måste fyllas i.")]
        [MaxLength(500, ErrorMessage = "Korta beskrivningen kan inte vara längre än {1} tecken.")]
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string ImagePath { get; set; }

        [MaxLength(255, ErrorMessage = "Adressen kan inte vara längre än {1} tecken.")]
        public string Address { get; set; }

        [MaxLength(50, ErrorMessage = "Telefon kan inte vara längre än {1} tecken.")]
        public string Telephone { get; set; }

        [MaxLength(100, ErrorMessage = "Kontakt kan inte vara längre än {1} tecken.")]
        public string Contact { get; set; }

        [MaxLength(100, ErrorMessage = "E-post kan inte vara längre än {1} tecken.")]
        [EmailAddress(ErrorMessage = "E-post är inte i korrekt format")]
        public string Email { get; set; }

        [MaxLength(50, ErrorMessage = "Organisations-form kan inte vara längre än {1} tecken.")]
        public string OrganisationalForm { get; set; } // Private, Public or some other form

        [MaxLength(100, ErrorMessage = "Webbsida kan inte vara längre än {1} tecken.")]
        public string Website { get; set; }
        
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        [MaxLength(50, ErrorMessage = "Övrigt kan inte vara längre än {1} tecken.")]
        public string Other { get; set; }
        

        public OrganisationalUnitInfoViewModel()
        {
            //Empty
        }
        public OrganisationalUnitInfoViewModel(OrganisationalUnitInfo entity)
        {
            Id = entity.Id;
            OrganisationalUnitId = entity.OrganisationalUnitId;
            Name = entity.Name;
            ShortDescription = entity.ShortDescription;
            LongDescription = entity.LongDescription;
            if(entity.ImagePath != "")
            {
                ImagePath = entity.ImagePath;
            }
            else
            {
                ImagePath = "default.jpg";
            }
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

        public void TransferToEntity(OrganisationalUnitInfo entity)
        {
            entity.Name = Name;
            entity.ShortDescription = ShortDescription;
            entity.LongDescription = LongDescription;
            entity.ImagePath = ImagePath;
            entity.Address = Address;
            entity.Telephone = Telephone;
            entity.Contact = Contact;
            entity.Email = Email;
            entity.OrganisationalForm = OrganisationalForm;
            entity.Website = Website;
            entity.Latitude = Latitude;
            entity.Longitude = Longitude;
            entity.Other = Other;
        }
    }
}