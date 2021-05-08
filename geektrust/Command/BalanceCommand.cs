using System;

namespace Geektrust.Command
{
    public class BalanceCommand :ICommand
    {
       
        private string BankName { get; }
        private string BorrowerName { get; }
        public int EmiNumber { get; }
        
        public BalanceCommand(string[] inputs)
        {
            BankName = inputs[1];
            BorrowerName = inputs[2];
            EmiNumber = Convert.ToInt32(inputs[3]);
           
        }

        public string GetBankName() => BankName;
        public string GetBorrowerName() => BorrowerName;

    }
}
