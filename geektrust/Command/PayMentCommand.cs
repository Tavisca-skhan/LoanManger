using System;

namespace Geektrust.Command
{
    public class PayMentCommand :ICommand
    {
        
        public string BankName { get; }
        public string BorrowerName { get; }
        public decimal Amount { get; }
        public int EmiNumber { get; }
        
        public PayMentCommand(string[] inputs)
        {
            BankName = inputs[1];
            BorrowerName = inputs[2];
            Amount = Convert.ToInt64(inputs[3]);
            EmiNumber = Convert.ToInt32(inputs[4]);
            
        }

        public string GetBankName() => BankName;
        public string GetBorrowerName() => BorrowerName;

    }
}
