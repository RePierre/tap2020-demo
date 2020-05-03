using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Uaic.Tap2020Demo.Core;
using Uaic.Tap2020Demo.Core.Accounts;
using Uaic.Tap2020Demo.DataAccess;
using Uaic.Tap2020Demo.DataAccess.Repositories;

namespace Tap2020Demo.Examples
{
    class DependencyInjectionExample
    {
        private readonly IDataRepository dataRepository;
        private readonly IUnitOfWork unitOfWork;

        public DependencyInjectionExample(IDataRepository dataRepository, IUnitOfWork unitOfWork)
        {
            this.dataRepository = dataRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Show()
        {
            var accountHolder = new Customer
            {
                FirstName = "Ileana",
                LastName = "Scândură",
                IdNo = "091203923018",
                Id = Guid.NewGuid()
            };

            var debitAccount = new DebitAccount
            {
                AccountHolderId = accountHolder.Id,
                Iban = "RO29RZBR2617696727494944"
            };

            var savingsAccount = new SavingsAccount
            {
                AccountHolderId = accountHolder.Id,
                Iban = "RO29RZBR2617696727494946"
            };

            accountHolder.DebitAccounts.Add(debitAccount);
            accountHolder.SavingsAccounts.Add(savingsAccount);

            dataRepository.Insert(accountHolder);

            debitAccount.Deposit(100);
            unitOfWork.Commit();

            System.Console.WriteLine("Debit accounts of {0}:", accountHolder.FullName);
            foreach (var da in accountHolder.DebitAccounts)
            {
                System.Console.WriteLine("IBAN: {0}, Amount: {1}", da.Iban, da.Amount);
            }
        }
    }
}
