using System;
using Geektrust.Command;
using Geektrust.Services;

namespace Geektrust
{

    public class BankingManager
        {
            private readonly BankingService _bankingservice;
           
            public BankingManager(BankingService bankingService)
            {
                _bankingservice = bankingService;
                
            }
            public void Executes(string[] inputs)
            {
              foreach(var input in inputs)
              {
                    var command = CommandBuilderFactory.GetCommand(input);
                    if (command is LoanCommand) Processloan(command);
                    else if (command is PayMentCommand) ProccesPayment(command);
                    else ProcessBalance(command);
              }

            }

            private void ProcessBalance(ICommand command)
            {
                var balanceCommand = command as BalanceCommand;
                var balanceReq = balanceCommand.ToBalanceReq();
                var balance= _bankingservice.GetBalance(balanceReq);
                Console.WriteLine(balance.ToString());
            }

            private void ProccesPayment(ICommand command)
            {
                var payMentCommand = command as PayMentCommand;   
                var payment = payMentCommand.ToPayment();
                _bankingservice.AddPayMentToLoan(payment);
            }

            private void Processloan(ICommand command)
            {
                var loanCommand = command as LoanCommand;
                var loan = loanCommand.ToLoan();
                _bankingservice.AddLoan(loan);
                
            }
        }

}
