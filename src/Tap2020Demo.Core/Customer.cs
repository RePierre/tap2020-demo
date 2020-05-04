using System;
using System.Collections.Generic;
using System.Text;
using Uaic.Tap2020Demo.Core.Accounts;

namespace Uaic.Tap2020Demo.Core
{
    public class Customer : IEntityBase
    {
        public Customer()
        {
            DebitAccounts = new List<DebitAccount>();
            SavingsAccounts = new List<SavingsAccount>();
        }

        public Guid Id { get; set; }

        public string IdNo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        public virtual IList<DebitAccount> DebitAccounts { get; set; }

        public virtual IList<SavingsAccount> SavingsAccounts { get; set; }
    }
}
