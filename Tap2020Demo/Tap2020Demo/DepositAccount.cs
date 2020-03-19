using System;

namespace Tap2020Demo
{
    class DepositAccount : Account
    {
        protected override decimal WithdrawInternal(decimal amount)
        {
            throw new InvalidOperationException("Cannot withdraw from Deposit account.");
        }
    }
}
