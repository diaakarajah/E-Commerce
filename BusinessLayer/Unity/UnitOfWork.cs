using BusinessLayer.IRepo;
using BusinessLayer.Repo;
using DataAccessLayer.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Unity
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ECommerceContext _dbContext;

        public IBrandRepo brandRepo { get; private set; }

        public ICategoriesRepo categoriesRepo { get; private set; }

        public IProductsRepo productsRepo { get; private set; }

        public IRoleRepo roleRepo { get; private set; }

        public IUsersRepo usersRepo { get; private set; }

        public IUsersRoleRepo usersRoleRepo { get; private set; }
        public UnitOfWork(ECommerceContext dbContext)
        {
            _dbContext = dbContext;
            brandRepo = new BrandRepo(_dbContext);
            categoriesRepo= new CategoriesRepo(_dbContext);
            productsRepo= new ProductsRepo(_dbContext);
            roleRepo= new RoleRepo(_dbContext);
            usersRepo= new UsersRepo(_dbContext);
            usersRoleRepo= new UsersRoleRepo(_dbContext);
        }

        public void Complete()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
