using Microsoft.EntityFrameworkCore;
using System.Net;
using AutoMapper;
using System.Reflection;
using StoreApp.Infrastructure.Extensions;
var builder = WebApplication.CreateBuilder(args);//Uygulama başlayacağı ifade edilmiş. Servis yok. hiçbir şey yok
builder.Services.AddControllersWithViews();//Controller kullanacagim ve View nesnelerinden istifade edecegim.
builder.Services.AddRazorPages();//Razor Page kullanabilmek için Controller kullanmaya gerek olmayacaktir.
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServicesRegistration();
builder.Services.ConfigureRouting();
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var app = builder.Build();  //Uygulamanın insası var denilmiş.
app.UseStaticFiles();//wwwroot klasörü kullanılabilir olacak.
app.UseSession();/*Session-3.adim=Sessionlari etkinlestirdik.*/
/*app.MapGet("/", () => "Hello World!");
app.MapGet("/btk",()=>"BTK Akademi");*/
//Tek tek endpointleri bu şekilde tanımlamak yerine bir routing mekanizması kuruyoruz.
app.UseHttpsRedirection();
app.UseRouting();//Routing mekanizmasını dikkate almasını sağlamak için
app.UseAuthentication();//Once Authentication
app.UseAuthorization();//Sonra Authorization
/*Kisi yetkili mi degil mi oturum acti mi acmadi mi bu bilgileri kaydedebiliriz.
Authentication ve Authorization Routing ile Endpoints arasinda olmalidir.*/
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        "default",
        "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();//Razor Pages endpoint icerisinde yapilandirdik.
});
app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureDefaultAdminUser();
app.Run();