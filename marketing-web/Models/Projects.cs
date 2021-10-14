using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace marketing_web.Models
{
    public partial class Projects
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string CoverPhoto { get; set; }
        public string ClientName { get; set; }
        public string ClientLogo { get; set; }
        public string Address { get; set; }
        public DateTime InsertedDate { get; set; }
        public string InsertedFrom { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedFrom { get; set; }
    }
}
