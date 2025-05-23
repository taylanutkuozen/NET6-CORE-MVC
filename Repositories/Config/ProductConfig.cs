using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p=>p.ProductID);
            builder.Property(p=>p.ProductName).IsRequired();
            builder.Property(p=>p.ProductPrice).IsRequired();
            builder.HasData(
                new Product() {ProductID=1,CategoryID=2,ImageUrl="/images/a.jpg", ProductName="Computer", ProductPrice=17_000,ShowCase=false},
                new Product() {ProductID=2,CategoryID=2,ImageUrl="/images/a.jpg", ProductName="Keyboard", ProductPrice=1_000,ShowCase=false},
                new Product() {ProductID=3,CategoryID=2,ImageUrl="/images/a.jpg", ProductName="Mouse", ProductPrice=500,ShowCase=false},
                new Product() {ProductID=4,CategoryID=2,ImageUrl="/images/a.jpg", ProductName="Monitor", ProductPrice=7_000,ShowCase=false},
                new Product() {ProductID=5,CategoryID=2,ImageUrl="/images/a.jpg", ProductName="Deck", ProductPrice=1_500,ShowCase=false},
                new Product() {ProductID=6,CategoryID=1,ImageUrl="/images/a.jpg", ProductName="History",ProductPrice=25,ShowCase=false},
                new Product() {ProductID=7,CategoryID=1,ImageUrl="/images/a.jpg", ProductName="Hamlet",ProductPrice=45,ShowCase=false},
                new Product() {ProductID=8,CategoryID=2,ImageUrl="/images/a.jpg", ProductName="Xp-Pen", ProductPrice=100,ShowCase=true},
                new Product() {ProductID=9,CategoryID=1,ImageUrl="/images/a.jpg", ProductName="Mobile Phone",ProductPrice=15_000,ShowCase=true},
                new Product() {ProductID=10,CategoryID=2,ImageUrl="/images/a.jpg", ProductName="Tablet",ProductPrice=5_000,ShowCase=true}
            );
        }
    }
}