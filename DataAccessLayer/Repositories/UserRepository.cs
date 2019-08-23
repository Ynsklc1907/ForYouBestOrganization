using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository:GenericRepository<User>
    {
        public UserRepository(foryoubestDb db):base(db)
        {

        }


    }
}
