using System;
using System.Collections.Generic;
using System.Text;

namespace Geektrust.Model
{
    public class Balance
    {
        public string BankName { get; private set; }
        public string BorrowerName { get; private set; }
        public decimal AmountPaid { get; private set; }
        public int NoOfEmiLeft { get; private set; }

        public Balance(string bankName, string borrowerName, decimal amountPaid, int noOfEmiLeft)
        {
            BankName = bankName;
            BorrowerName = borrowerName;
            AmountPaid = amountPaid;
            NoOfEmiLeft = noOfEmiLeft;
        }

        public override string ToString()
        {
            return string.Concat(BankName, " ", BorrowerName, " ", AmountPaid.ToString(), " ", NoOfEmiLeft);
        }
    }
}
