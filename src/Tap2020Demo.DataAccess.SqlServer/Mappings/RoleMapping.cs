using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uaic.Tap2020Demo.Core.Identity;

namespace Uaic.Tap2020Demo.DataAccess.SqlServer.Mappings
{
    class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles")
                .HasKey(r => r.Id);
        }
    }
}
