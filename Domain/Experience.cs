using System;
using System.Collections.Generic;

#nullable disable

namespace AshrafFirstWebsite.Models
{
    public partial class Experience
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string Place { get; set; }
    }
}
