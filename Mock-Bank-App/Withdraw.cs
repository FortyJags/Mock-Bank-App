using Mock_Bank_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mock_Bank_App
{
    internal class Withdraw
    {

        private float userWithdrawAmount;
        private bool userEnteredValidWithdrawlAmount = false;
        private TransactionHistory _history;
        
        public Withdraw(TransactionHistory history)
        {
            _history = history;
        }
        //Allows the user to withdraw funds from their account. This calls upon a CheckAmountAgainstBalance method to make sure the transaction is valid
        public float Transaction(float currentAmount)
        {
            ColoredConsole.WriteLineColored("Current balance: £" + currentAmount, ConsoleColor.Yellow);
            ColoredConsole.WriteLineColored("How much would you like to withdraw?", ConsoleColor.Blue);
            userWithdrawAmount = Convert.ToSingle(Console.ReadLine());
            while (userEnteredValidWithdrawlAmount == false)
            {
                currentAmount = CheckAmountAgainstBalance(currentAmount);
            }
            Console.Clear();
            Console.WriteLine("£" + currentAmount);
            return currentAmount;

        }

        //This checks the amount being withdrawn and ensures the user does not drop below 0. If the amount withdrawn - the current balance = 0 then the user is informed they cannot do that
        private float CheckAmountAgainstBalance(float currentAmount)
        {
            if (currentAmount - userWithdrawAmount < 0) { ColoredConsole.WriteLineColored("You cannot withdraw that much. Please enter a different number.", ConsoleColor.Red); userWithdrawAmount = Convert.ToSingle(Console.ReadLine()); }
            else { currentAmount -= userWithdrawAmount; ColoredConsole.WriteLineColored("New balance: £" + currentAmount, ConsoleColor.Yellow); userEnteredValidWithdrawlAmount = true; _history.AddToTransactionList(userWithdrawAmount, currentAmount, "withdraw"); }

            return currentAmount;
        }
    }
}
