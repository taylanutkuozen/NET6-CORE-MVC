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
                new Product() {ProductID=1,CategoryID=2,ImageUrl="/images/1.jpg", ProductName="Computer", ProductPrice=17_000},
                new Product() {ProductID=2,CategoryID=2,ImageUrl="/images/2.jpg", ProductName="Keyboard", ProductPrice=1_000},
                new Product() {ProductID=3,CategoryID=2,ImageUrl="/images/3.jpg", ProductName="Mouse", ProductPrice=500},
                new Product() {ProductID=4,CategoryID=2,ImageUrl="/images/4.jpg", ProductName="Monitor", ProductPrice=7_000},
                new Product() {ProductID=5,CategoryID=2,ImageUrl="/images/5.jpg", ProductName="Deck", ProductPrice=1_500},
                new Product() {ProductID=6,CategoryID=1,ImageUrl="/images/6.jpg", ProductName="History",ProductPrice=25},
                new Product() {ProductID=7,CategoryID=1,ImageUrl="/images/7.jpg", ProductName="Hamlet",ProductPrice=45}
            );
        }
    }
}