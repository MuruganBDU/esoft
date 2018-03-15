using SoftCollection.Service.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCollection.Repository.Repository
{
    public class BaseConnection<TEntity> where TEntity : class
    {
        protected readonly PrimaryContext dbcontext;
        protected readonly DbSet<TEntity> dbset;
        
        public BaseConnection()
        {
            dbcontext = new PrimaryContext();
            dbset = dbcontext.Set<TEntity>();
            
        }

        public IList<TEntity> Read()
        {
            return dbset.ToList();
        }
            
        public TEntity Create(TEntity item)
        {
            try
            {
                dbcontext.Entry(item).State = EntityState.Added;
                dbcontext.SaveChanges();
            }
            catch (DbEntityValidationException dx)
            {

                throw dx;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public bool Update(TEntity item)
        {
            try
            {
                dbcontext.Entry(item).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException dx)
            {

                throw dx;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
