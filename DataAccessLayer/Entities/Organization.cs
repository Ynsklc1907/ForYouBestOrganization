using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime OrgDate { get; set; }
        public virtual User Organizer { get; set; }
        public string Place { get; set; }
        public string ImageUrl { get; set; }
        public List<OrganizationUser> Organizations { get; set; }


    }
}
