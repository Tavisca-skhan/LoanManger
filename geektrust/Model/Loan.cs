using System;
using System.Collections.Generic;
using System.Text;

namespace Geektrust.Model
{
    public class Loan
    {
        public string BorrowerName { get; }
        public string  BankName { get; }
        public int Principal { get; }
        public int NoOfYears { get; }
        public decimal InterestRate { get; }

        public List<Payment> DownPayments = new List<Payment>();

        public Loan(string bankName, string borrowerName, int principal, int noOfYears, decimal interestRate)
        {
            BorrowerName = borrowerName;
            BankName = bankName;
            Principal = principal;
            NoOfYears = noOfYears;
            InterestRate = interestRate;
        }

        public int EmiAmount => (int)Math.Ceiling(TotalAmountToPay/ (12 * NoOfYears));
        public decimal TotalAmountToPay => Principal + TotalIntrest;
        private decimal TotalIntrest => Math.Ceiling((Principal * NoOfYears * InterestRate) / 100);
        public override bool Equals(object obj)
        {
            var loan = obj as Loan;
            return loan != null &&
                   BorrowerName == loan.BorrowerName &&
                   BankName == loan.BankName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BorrowerName, BankName);
        }
    }
}
