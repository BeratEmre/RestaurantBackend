using Entity.Entities;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Core.Entities.concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class Contexts: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Restaurant;Trusted_Connection=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Sweet> Sweets { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<OperationClaim> OperationClaims{ get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        //public DbSet<Table> Tables { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
