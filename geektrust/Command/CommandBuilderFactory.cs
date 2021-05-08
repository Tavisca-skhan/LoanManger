using System;
using System.Collections.Generic;
using System.Text;

namespace Geektrust.Command
{
    public static class CommandBuilderFactory
    {

        public static ICommand GetCommand(String command)
        {
            var input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Ensure.ShouldBeValidRequest(input);
            Ensure.ShouldBeValidCommand(input[0]);
            Enum.TryParse(input[0], true, out CommandType commandType);
            switch (commandType)
            {
                case CommandType.LOAN:
                    return new LoanCommand(input);
                case CommandType.PAYMENT:
                    return new PayMentCommand(input);
                case CommandType.BALANCE:
                    return new BalanceCommand(input);
                default: throw new InvalidOperationException($"no implementaion found for {input[0]}");

            }




        }
    }

    public enum CommandType
    {
        LOAN,
        PAYMENT,
        BALANCE
    }
}
