using Geektrust.Command;
using Geektrust.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geektrust.Services
{
    public class BankingService 
    {
        private readonly List<Loan> Loans = new List<Loan>();

        public void AddLoan(Loan loan )
        {
            Loans.CanAddLoan(loan);
            Loans.Add(loan);
        }
        public void AddPayMentToLoan(Payment payMent)
        {
            Loans.ShouldBeValidLoanCount();
            var loan = Loans.Find(x => x.BankName == payMent.BankName && x.BorrowerName == payMent.BorrowerName);
            if(loan!=null)
            loan.DownPayments.Add(payMent);
            else throw new Exception($"loand does not exist with bankname : {payMent.BankName} and borrowerName {payMent.BorrowerName} ");
        }
        private int CalculateEmiToPay( int emiAmount, int emiStart, int emiEnd)
        {
            return (emiEnd - emiStart) * emiAmount;
        }


        public Balance GetBalance(BalanceReq req)
        {
            Loans.ShouldBeValidLoanCount();
            var loan = Getloan(req);
            if(loan == null)  throw new Exception($"loand does not exist with bankname : {req.BankName} and borrowerName {req.BorrowerName} ");
            var emiAmount = loan.EmiAmount;
            var downPayments = loan.DownPayments.OrderBy(x => x.EmiNumber).ToList();
            decimal balanceLeft = loan.TotalAmountToPay;
            int emiNumberPaid = 0;
            foreach(var payment in loan.DownPayments)
            {
                if (payment.EmiNumber <= req.EmiNumber)
                {
                    balanceLeft -= CalculateEmiToPay(emiAmount, emiNumberPaid, req.EmiNumber);
                    balanceLeft -= payment.Amount;
                    emiNumberPaid = req.EmiNumber;
                }

            }
            if (emiNumberPaid < req.EmiNumber)
            {
                balanceLeft = balanceLeft - CalculateEmiToPay(emiAmount, emiNumberPaid, req.EmiNumber);
            }
            decimal totalLoanPaid = loan.TotalAmountToPay- balanceLeft;
            int emiLeft = (int)Math.Ceiling(balanceLeft / loan.EmiAmount);
            return new Balance(loan.BankName,loan.BorrowerName, totalLoanPaid, emiLeft);
        }

        private Loan Getloan(BalanceReq req)
        {
            return Loans.Find(x => x.BankName.Equals(req.BankName, StringComparison.CurrentCultureIgnoreCase) 
              && x.BorrowerName.Equals(req.BorrowerName,StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
