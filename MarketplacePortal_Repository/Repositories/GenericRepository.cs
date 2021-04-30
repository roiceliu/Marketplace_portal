using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketplacePortal_DAL;


namespace MarketplacePortal_Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);

        void Insert(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        List<TEntity> GetAll();

        

    }

    public class GenericRepository<TEntity>: IRepository<TEntity> where TEntity : class
    {
        protected JooleEntities context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(JooleEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();


        }
        public void Insert(TEntity entity) {

            dbSet.Add(entity);

        }

        public void Delete(TEntity entity)
        {

            dbSet.Remove(entity);

        }

        public TEntity GetByID(int id)
        {

            return dbSet.Find(id);

        }

        public void Update(TEntity entity)
        {

            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public List<TEntity> GetAll() {

            return dbSet.ToList<TEntity>();
        }

    }
}
