using DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DBContext
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext()
        {
        }
        public ECommerceContext(DbContextOptions dbContextOptions)
     : base(dbContextOptions)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UsersRole> UsersRole { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Product { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.;database=ECommerceDB;Integrated Security=True ;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Users>().HasData(new Users
            //{
            //    Id = 1,
            //    UserName = "diaa",
            //    Password = "diaa@123"
            //});
            //modelBuilder.Entity<Role>().HasData(new Role
            //{
            //    Id = 1,
            //    RoleNameAr = "مسؤول",
            //    RoleNameEn = "Admin"
            //},
            //new Role
            //{
            //    Id = 2,
            //    RoleNameAr = "مستخدم",
            //    RoleNameEn = "User"
            //}
            //);
            //modelBuilder.Entity<UsersRole>().HasData(new UsersRole
            //{
            //    Id = 1,
            //    UserId = 1,
            //    RoleId = 1
            //});
            //modelBuilder.Entity<Products>().Property(o => o.Price).HasPrecision(18, 2);

        }
    }
}
