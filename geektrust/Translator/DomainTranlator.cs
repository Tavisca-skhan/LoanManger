using Geektrust.Command;
using Geektrust.Model;

namespace Geektrust
{
    public static class DomainTranlator
    {
        public static Loan ToLoan(this LoanCommand command)
        {
            return new Loan(command.GetBankName(), command.GetBorrowerName(), command.Principal, command.NoOfYears, command.RateOfInterest);
        }
        public static Payment ToPayment(this PayMentCommand command)
        {
            return new Payment(command.GetBankName(), command.GetBorrowerName(), command.Amount, command.EmiNumber);
        }
        public static BalanceReq ToBalanceReq(this BalanceCommand command)
        {
            return new BalanceReq(command.GetBankName(), command.GetBorrowerName(), command.EmiNumber);
        }

    }

}
