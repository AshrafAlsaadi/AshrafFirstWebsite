using System;
using System.Collections.Generic;

#nullable disable

namespace AshrafFirstWebsite.Models
{
    public partial class Education
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public string Section { get; set; }
        public string Courses { get; set; }
    }
}
