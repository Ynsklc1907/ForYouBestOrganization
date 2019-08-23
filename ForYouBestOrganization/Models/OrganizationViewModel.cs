using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForYouBestOrganization.Models
{
    public class OrganizationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime OrgDate { get; set; }
        public virtual int Organizer_Id { get; set; }
        public string Place { get; set; }
        public string ImageUrl { get; set; }
    }
}