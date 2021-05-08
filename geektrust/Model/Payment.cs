using System;
using System.Collections.Generic;
using System.Text;

namespace Geektrust.Model
{
    public  class Payment
    {
        public decimal Amount { get; }
        public int EmiNumber { get; }
        public string BorrowerName { get; }
        public string BankName { get; }

        public Payment(string bankName, string borrowerName, decimal amount, int emiNumber)
        {
            BankName=bankName;
            BorrowerName = borrowerName;
            Amount = amount;
            EmiNumber = emiNumber;

        }
    }
}
