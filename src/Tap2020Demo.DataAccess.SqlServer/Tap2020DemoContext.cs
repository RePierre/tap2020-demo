using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Uaic.Tap2020Demo.Core.Accounts;

namespace Uaic.Tap2020Demo.DataAccess.SqlServer
{
    public class Tap2020DemoContext : DbContext
    {
        public Tap2020DemoContext()
        {
        }

        public DbSet<DebitAccount> DebitAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Tap2020"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
