using Repositories;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Repositories.Contracts;
using Services.Contracts;
using Services;
using Entities.Models;
using StoreApp.Models;
namespace StoreApp.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options => //İhtiyaç olması durumunda Db kullanacağımızı belirtmiş olduk.
            {
                options.UseSqlite(configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("StoreApp"));//Migration hedefi belirttik.
            });
        }
        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();/*Configurasyon ifadeleri tanimladik*/
            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);/*10 dakika sonra oturumu dusur.*/
            });/*2.adim Middleware insasi buradan devam eder.*/
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            /*Her user bu nesneyi ayri ayri uretmesine gerek yok, bir defa uretildikten sonra herkes bu nesneyi kullanabilir. O yuzden Singleton kullandik.*/
            services.AddScoped<Cart>(c => SessionCart.GetCart(c));
        }
        public static void ConfigureRepositoryRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
        public static void ConfigureServicesRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IOrderService, OrderManager>();
        }
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options=>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false; /*Bu komut sona bir slash ekleyip eklememe ile ilgili bir komuttur.*/
            });
        }
    }
}