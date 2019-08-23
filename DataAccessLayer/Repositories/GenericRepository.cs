using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    

     public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity: class
    {
        foryoubestDb db;

        public GenericRepository(foryoubestDb _db)
        {
            db = _db;
        }

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entity = Find(id);
            db.Set<TEntity>().Remove(entity);
            db.SaveChanges();
        }

        public TEntity Find(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public List<TEntity> Listele()
        {
            return db.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }



    }
}
