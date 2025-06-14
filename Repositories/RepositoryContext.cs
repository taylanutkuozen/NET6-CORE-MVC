﻿using System.Reflection;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace Repositories
{
    public class RepositoryContext:IdentityDbContext<IdentityUser>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options):base(options) //DbContextOptions gelmeyen bir talep, bir newleme isteği geçersizdir.
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //Modeller oluşturulur iken araya girebilmek ve bir işlem gerçekleşmesi için kullanırız.
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            /*modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());*/
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}