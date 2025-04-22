using Microsoft.EntityFrameworkCore;
using Repositories;
using Entities.Models;
using Repositories.Contracts;
using System.Net;
using Services.Contracts;
using Services;
using AutoMapper;
using System.Reflection;
using StoreApp.Models;
var builder = WebApplication.CreateBuilder(args);//Uygulama başlayacağı ifade edilmiş. Servis yok. hiçbir şey yok
builder.Services.AddControllersWithViews();//Controller kullanacagim ve View nesnelerinden istifade edecegim.
builder.Services.AddRazorPages();//Razor Page kullanabilmek için Controller kullanmaya gerek olmayacaktir.
builder.Services.AddDbContext<RepositoryContext>(options=> //İhtiyaç olması durumunda Db kullanacağımızı belirtmiş olduk.
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),b=>b.MigrationsAssembly("StoreApp"));//Migration hedefi belirttik.
});
builder.Services.AddDistributedMemoryCache();/*Session Middleware insasi icin kullanilacaktir.On bellek sagliyor. Server tarafinda bilgileri tutuyor.*/
builder.Services.AddSession(options=>
{
    /*Configurasyon ifadeleri tanimladik*/
    options.Cookie.Name="StoreApp.Session";
    options.IdleTimeout=TimeSpan.FromMinutes(10); /*10 dakika sonra oturumu dusur.*/
}
);/*2.adim Middleware insasi buradan devam eder.*/
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();/*
Her user bu nesneyi ayri ayri uretmesine gerek yok, bir defa uretildikten sonra herkes bu nesneyi kullanabilir. O yuzden Singleton kullandik.*/
builder.Services.AddScoped<IRepositoryManager,RepositoryManager>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IOrderRepository,OrderRepository>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();
builder.Services.AddScoped<IOrderService,OrderManager>();
builder.Services.AddScoped<Cart>(c=> SessionCart.GetCart(c));
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var app = builder.Build();  //Uygulamanın inşası var denilmiş.
app.UseStaticFiles();//wwwroot klasörü kullanılabilir olacak.
app.UseSession();/*Session-3.adim=Sessionlari etkinlestirdik.*/
/*app.MapGet("/", () => "Hello World!");
app.MapGet("/btk",()=>"BTK Akademi");*/
//Tek tek endpointleri bu şekilde tanımlamak yerine bir routing mekanizması kuruyoruz.
app.UseHttpsRedirection();
app.UseRouting();//Routing mekanizmasını dikkate almasını sağlamak için
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name:"Admin",
        areaName:"Admin",
        pattern:"Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(    
        "default",
        "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();//Razor Pages endpoint icerisinde yapilandirdik.
});
app.Run();