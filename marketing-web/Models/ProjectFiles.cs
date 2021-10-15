using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace marketing_web.Models
{
    public partial class ProjectFiles
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string FilePath { get; set; }
        public DateTime InsertedDate { get; set; }
        public string InsertedFrom { get; set; }

        public virtual Projects Project { get; set; }
    }
}
