using BusinessLayer.IRepo;
using DataAccessLayer.DBContext;
using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repo
{
    public class UsersRepo : Repository<Users>, IUsersRepo
    {
        readonly ECommerceContext eCommerceContext;
        public UsersRepo(ECommerceContext DbContext) : base(DbContext)
        {
            eCommerceContext= DbContext;
        }
        public Users GetUserByName(string userName)
        {
            return eCommerceContext.Users.FirstOrDefault(s => s.UserName == userName);
        }
    }
}
