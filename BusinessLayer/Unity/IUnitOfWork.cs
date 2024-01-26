using BusinessLayer.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Unity
{
    public interface IUnitOfWork : IDisposable
    {
        IBrandRepo brandRepo {  get; }
        ICategoriesRepo categoriesRepo { get; }
        IProductsRepo productsRepo { get; }
        IRoleRepo roleRepo { get; }
        IUsersRepo usersRepo { get; }
        IUsersRoleRepo usersRoleRepo { get; }
        void Complete();

    }
}
