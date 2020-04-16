using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uaic.Tap2020Demo.Core;

namespace Uaic.Tap2020Demo.DataAccess.SqlServer.Mappings
{
    class AccountHolderMapping : IEntityTypeConfiguration<AccountHolder>
    {
        public void Configure(EntityTypeBuilder<AccountHolder> builder)
        {
            builder.ToTable("AccountHolders")
                .HasKey(_ => _.Id);

            builder.Property(_ => _.Id).UseIdentityColumn();

            builder.Property(_ => _.FullName).HasColumnName("Name").HasMaxLength(150);

            builder.HasMany(_ => _.DebitAccounts)
                .WithOne(_ => _.AccountHolder);
        }
    }
}
