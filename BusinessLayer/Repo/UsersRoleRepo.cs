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
    public class UsersRoleRepo : Repository<UsersRole>, IUsersRoleRepo
    {
        readonly ECommerceContext _dbContext;
        public UsersRoleRepo(ECommerceContext DbContext) : base(DbContext)
        {
            _dbContext = DbContext;
        }
        public List<UsersRole> GetRolesByUserId(long userId)
        {
            return _dbContext.UsersRole.Include(s => s.Role).Where(s => s.UserId == userId).ToList();

        }
    }
}
