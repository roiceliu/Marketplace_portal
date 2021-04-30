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

        //Get table record/Entity by PrimaryKey 
        TEntity Get(object obj);

        void Insert(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        IEnumerable<TEntity> GetAll();

        

    }

    public class GenericRepository<TEntity>: IRepository<TEntity> where TEntity : class
    {
        internal JooleEntities context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(JooleEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();

        }

        
        public void Insert(TEntity entity) {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public TEntity GetByID(int id)
        {

            return dbSet.Find(id);

        }

        
        public TEntity Get(object obj)
        {
            return dbSet.Find(obj);
        }

        public void Update(TEntity entity)
        {

            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll() {

            return dbSet.AsEnumerable<TEntity>();
        }

    }
}
