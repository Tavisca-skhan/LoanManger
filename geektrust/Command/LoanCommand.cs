using System;

namespace Geektrust.Command
{
    public class LoanCommand :ICommand
    {
        private readonly string BankName;
        private readonly string BorrowerName;
        public Int32 Principal { get; }
        public int NoOfYears { get; }
        public decimal RateOfInterest { get; }
        
        public LoanCommand(string[] inputs)
        {
                BankName = inputs[1];
                BorrowerName = inputs[2];
                Principal = Convert.ToInt32(inputs[3]);
                NoOfYears = Convert.ToInt32(inputs[4]);
                RateOfInterest = Convert.ToDecimal(inputs[5]);
        }

        public string GetBankName() =>  BankName;
        public string GetBorrowerName() => BorrowerName;


    }
}
