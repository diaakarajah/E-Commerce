using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IRepo
{
    public  interface IUsersRoleRepo:IRepository<UsersRole>
    {
        List<UsersRole> GetRolesByUserId(long userId);
    }
}
