using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Uaic.Tap2020Demo.Core.Accounts;
using Uaic.Tap2020Demo.Core.Accounts.Base;

namespace Uaic.Tap2020Demo.DataAccess.SqlServer.Mappings
{

    class AccountMapping : IEntityTypeConfiguration<DepositAccountBase>
    {
        public void Configure(EntityTypeBuilder<DepositAccountBase> builder)
        {
            builder.ToTable("Accounts")
                            .HasKey(_ => _.Id);

            builder.Property(_ => _.Id).IsRequired();

            builder.Property(_ => _.Amount).HasColumnName("Amount");
            builder.Property(_ => _.Iban).HasColumnName("Iban").HasMaxLength(34);
            builder.Property(_ => _.AccountHolderId).HasColumnName("CustomerId");

            builder.HasOne(_ => _.AccountHolder)
                .WithMany();

            builder.HasDiscriminator<int>("AccountTypeId")
                .HasValue<CreditAccount>(1)
                .HasValue<DebitAccount>(2)
                .HasValue<DepositAccount>(3)
                .HasValue<SavingsAccount>(4);
        }
    }
}
