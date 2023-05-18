using Mock_Bank_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mock_Bank_App
{


    internal class Deposit
    {
        private decimal depositAmount;
        private string? depositText;
        private TransactionHistory _history;


        public Deposit(TransactionHistory history)
        {
            _history = history;
        }

        //Asks the user for an amount they want to deposit. This calls FloatTypeCheck to make sure their input is a number. If the number is valid, it adds to the current amount and also supplies data to the transaction log. If the number is not valid, it asks for a different number.
        public decimal Transaction(decimal currentAmount)
        {
            Console.WriteLine("Please enter the amount you wish to deposit.");
            while (depositText != "quit")
            {
                depositText = Console.ReadLine();
                if (DecimalTypeCheck(depositText) == true)
                {
                    Console.WriteLine("Previous balance £" + currentAmount); currentAmount += depositAmount; Console.WriteLine("New balance: £" + currentAmount);
                    _history.AddToTransactionList(currentAmount, depositAmount, "deposit"); return currentAmount;
                }
                else if (DecimalTypeCheck(depositText) == false) { ColoredConsole.WriteLineColored("Please enter a number or enter quit to return to menu", ConsoleColor.Blue); }

            }

            return currentAmount;
        }

        public void ReturnToMenu() => Console.Clear();

        //Checks a given string and returns true or false depending on if the string can be converted to a float
        private bool DecimalTypeCheck(string userInput) => decimal.TryParse(userInput, out depositAmount);



    }
}

