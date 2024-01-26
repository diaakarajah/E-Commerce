using BusinessLayer.IRepo;
using DataAccessLayer.DBContext;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public ECommerceContext _DbContext { get; set; }


        public Repository(ECommerceContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _DbContext.Set<T>();
        }

        public T GetByID(long Id)
        {


            return _DbContext.Set<T>().FirstOrDefault(e => e.Id == Id);
        }
        public T Create(T entity)
        {
            return _DbContext.Set<T>().Add(entity).Entity;
        }

        public T Update(T entity)
        {
            return _DbContext.Set<T>().Update(entity).Entity;
        }

        public bool Delete(T Entity)
        {
            _DbContext.Set<T>().Remove(Entity);
            return true;
        }
      
       
    }

}
