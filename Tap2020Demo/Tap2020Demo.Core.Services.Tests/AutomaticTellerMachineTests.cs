using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Uaic.Tap2020Demo.Core.Accounts.Base;
using Uaic.Tap2020Demo.Core.Services;

namespace Tap2020Demo.Core.Services.Tests
{
    public class AutomaticTellerMachineTests
    {
        public AutomaticTellerMachine Atm { get; protected set; }

        public Mock<IWithdrawalAndDepositAccount> From { get; set; }

        public Mock<IDepositAccount> To { get; set; }

        protected void Initialize()
        {
            Atm = new AutomaticTellerMachine();
            From = new Mock<IWithdrawalAndDepositAccount>();
            To = new Mock<IDepositAccount>();
        }


        [TestClass]
        public class WhenNotEnoughFundsInSource : AutomaticTellerMachineTests
        {

            [TestInitialize]
            public void TestInitialize()
            {
                Initialize();
            }

            [TestMethod]
            public void TransferShouldThrow()
            {
                // Arrange
                bool exceptionThrown = true;

                // Act
                try
                {
                    Atm.Transfer(From.Object, To.Object, 100m);
                }
                catch (InvalidOperationException)
                {
                    exceptionThrown = true;
                }

                // Assert
                Assert.IsTrue(exceptionThrown);
            }
        }

        [TestClass]
        public class WhenSourceHasEnoughFunds : AutomaticTellerMachineTests
        {
            [TestInitialize]
            public void TestInitialize()
            {
                Initialize();

                From.SetupGet(_ => _.Amount)
                    .Returns(200m);
            }

            [TestMethod]
            public void TransferShouldCallWithdraw()
            {
                // Arrange
                // Act
                Atm.Transfer(From.Object, To.Object, 100m);

                // Assert
                From.Verify(_ => _.Withdraw(It.IsAny<decimal>()));
            }

            [TestMethod]
            public void TransferShouldCallDeposit()
            {
                // Arrange
                // Act
                Atm.Transfer(From.Object, To.Object, 100m);

                // Assert
                To.Verify(_ => _.Deposit(It.IsAny<decimal>()));
            }
        }
    }
}
