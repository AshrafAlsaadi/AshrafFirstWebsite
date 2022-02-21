using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace AshrafFirstWebsite.Models
{
    public class ViewModel
    {
        public IEnumerable<About> AboutInfo { get; set; }
        public IEnumerable<Skill> skillinfo { get; set; }
        public IEnumerable<Service> serviceinfo { get; set; }
        public IEnumerable<Education> educationinfo { get; set;}
        public IEnumerable<Latest> Latestinfo { get; set; }
        public IEnumerable<Contact> contactinfo { get; set; }
    }
}
