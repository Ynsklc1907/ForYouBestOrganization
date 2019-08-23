using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrganizationUserRepository:GenericRepository<OrganizationUser>
    {
        public OrganizationUserRepository(foryoubestDb db):base(db)
        {

        }
    }
}
