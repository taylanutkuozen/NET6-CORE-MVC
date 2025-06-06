using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repositories.Config
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    /*Identity Type config ifadesi olmasi icin IEntityTypeConfiguration tarafindan implement edilmesi gerekiyor.*/
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder) //Assembly uzerinden alacak, RepositoryContext uzerinde mevcut
        {
            builder.HasData(
               new IdentityRole() { Name = "User", NormalizedName = "USER" },
               new IdentityRole() { Name = "Editor", NormalizedName = "EDITOR" },
               new IdentityRole() {Name="Admin", NormalizedName="ADMIN"}
           );
        }
    }
}