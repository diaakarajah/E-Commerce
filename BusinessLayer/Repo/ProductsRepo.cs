using BusinessLayer.IRepo;
using DataAccessLayer.DBContext;
using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
    public class ProductsRepo : Repository<DataAccessLayer.Entity.Products>, IProductsRepo
    {
        readonly ECommerceContext eCommerceContext;

        public ProductsRepo(ECommerceContext dbContext)
            : base(dbContext)
        {
            eCommerceContext=dbContext;
        }
       public  List<Products> GetProductsList()
        {
            return eCommerceContext.Product.Include(s=>s.Brand).Include(s=>s.Category).ToList() ;
        }
    }
}
