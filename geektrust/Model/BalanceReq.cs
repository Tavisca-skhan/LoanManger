using System;
using System.Collections.Generic;
using System.Text;

namespace Geektrust.Model
{
   public class BalanceReq
    {
        
        public  string BankName { get; }
        public  int EmiNumber { get; }
        public  string BorrowerName { get; }

        public BalanceReq(string bankName, string borrowerName, int emiNumber)
        {
            BorrowerName = borrowerName;
            BankName = bankName;
            EmiNumber = emiNumber;
        }

    }
}
