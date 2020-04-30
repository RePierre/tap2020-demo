using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Uaic.Tap2020Demo.Core.Accounts;
using Uaic.Tap2020Demo.Core.Accounts.Base;

namespace Uaic.Tap2020Demo.DataAccess.SqlServer.Mappings
{

    class DebitAccountMapping : IEntityTypeConfiguration<DebitAccount>
    {
        public void Configure(EntityTypeBuilder<DebitAccount> builder)
        {
            builder.ToTable("Accounts")
                            .HasKey(_ => _.Id);

            builder.Property(_ => _.Id).IsRequired();

            builder.Property(_ => _.Amount).HasColumnName("Amount");
            builder.Property(_ => _.Iban).HasColumnName("Iban").HasMaxLength(34);
        }
    }
}
