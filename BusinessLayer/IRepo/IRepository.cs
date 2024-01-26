using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepo
{
    public  interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetByID(long id);
        T Create(T entity); 
        T Update(T entity);
        bool Delete(T entity);
    }
}
