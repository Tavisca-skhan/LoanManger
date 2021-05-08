using Geektrust.Model;
using System;
using System.Collections.Generic;

namespace Geektrust.Command
{
    public static class Ensure
    {
        internal static void ShouldBeValidRequest(this string[] values)
        {
            if (values.Length < 4 || values.Length > 6)
                throw new Exception("Invalid input provided");

        }

        internal static void ShouldBeValidCommand(string input)
        {
            if (Enum.TryParse(input, true, out CommandType commandType) == false)
                throw new ArgumentException($"{input} is invalid");
        }
        internal static void CanAddLoan(this List<Loan> loans, Loan loan)
        {
            if(loans.Contains(loan))
                  throw new Exception($"loan with bankname:{loan.BankName} and borrowername{loan.BorrowerName} allready exist");

        }
        internal static void ShouldBeValidLoanCount(this List<Loan> loans)
        {
            if(loans.Count == 0) throw new Exception($"No loan exist");
        }

    }
}
