using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrganizationRepository:GenericRepository<Organization>
    {
        public OrganizationRepository(foryoubestDb db):base(db)
        {

        }
        
    }
}
