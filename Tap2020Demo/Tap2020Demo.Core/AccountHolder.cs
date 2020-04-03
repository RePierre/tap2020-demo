using System;
using System.Collections.Generic;
using System.Text;
using Uaic.Tap2020Demo.Core.Accounts;

namespace Uaic.Tap2020Demo.Core
{
    public class AccountHolder : IEntityBase
    {
        public AccountHolder()
        {
            DebitAccounts = new List<DebitAccount>();
        }
        public int Id { get; set; }

        public string FullName { get; set; }

        public virtual IList<DebitAccount> DebitAccounts { get; set; }
    }
}
