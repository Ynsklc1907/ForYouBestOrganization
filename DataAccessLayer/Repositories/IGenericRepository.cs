using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> Listele();
        void Delete(int id);
        TEntity Find(int id);


    }
}
