using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uaic.Tap2020Demo.Core;

namespace Uaic.Tap2020Demo.DataAccess.SqlServer.Mappings
{
    class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers")
                .HasKey(_ => _.Id);

            builder.Property(_ => _.FullName).HasColumnName("FullName").ValueGeneratedOnAddOrUpdate();

            builder.HasMany(_ => _.DebitAccounts)
                .WithOne(_ => _.AccountHolder);
        }
    }
}
