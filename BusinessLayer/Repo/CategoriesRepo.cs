using BusinessLayer.IRepo;
using DataAccessLayer.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
    public class CategoriesRepo : Repository<DataAccessLayer.Entity.Categories>, ICategoriesRepo
    {
        public CategoriesRepo(ECommerceContext dbContext)
            : base(dbContext)
        {

        }

    }
}
