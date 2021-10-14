using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace marketing_web.ViewModels
{
    public class ProjectUpdateViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public IFormFile CoverPhoto { get; set; }
        public string CoverPhotoPath { get; set; }
        [Required]
        public string ClientName { get; set; }
        public IFormFile ClientLogo { get; set; }
        public string ClientLogoPath { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
