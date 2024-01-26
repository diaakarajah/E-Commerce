using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepo
{
    public interface IProductsRepo : IRepository<Products>
    {
        List<Products> GetProductsList();
    }
}
