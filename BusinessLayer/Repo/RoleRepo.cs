using BusinessLayer.IRepo;
using DataAccessLayer.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
    public class RoleRepo : Repository<DataAccessLayer.Entity.Role>, IRoleRepo
    {
        public RoleRepo(ECommerceContext dbContext)
            : base(dbContext)
        {

        }

    }
}
