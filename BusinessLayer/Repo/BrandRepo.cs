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
    public class BrandRepo : Repository<DataAccessLayer.Entity.Brands>, IBrandRepo
    {
        public BrandRepo(ECommerceContext dbContext)
            : base(dbContext)
        {

        }


    }
}
