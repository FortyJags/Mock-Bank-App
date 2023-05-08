using Mock_Bank_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock_Bank_App
{
    internal class TransactionHistory
    {
        private List<string?> _transactions = new List<string?>();
        private string[] _loadedHistory;
        private PinNumber _customerName;
        private int index = 0;

        public TransactionHistory(PinNumber customerName)
        {
            _customerName = customerName;
        }

        //When called, displays each transaction in the _transactions list
        public void ShowTransactionHistory()
        {
            foreach (var transaction in _transactions)
            {
               ColoredConsole.WriteLineColored(transaction, ConsoleColor.Yellow);
            }

            Console.WriteLine();
        }


        //When called, this takes the Date and Time at that moment, creates a string showing DateTime, transaction type and transactiona mounts. This string is then added to the _transactions list
        public void AddToTransactionList(float amountAddedOrWithdrawn, float amountAfterTransaction, string transactionType)
        {
            DateTime timeOfTransaction = DateTime.Now;
            string transactionString = $"At {timeOfTransaction}:{transactionType} of £{amountAddedOrWithdrawn} totaling to £{amountAfterTransaction},";
            _transactions.Add(transactionString);

        }


        //Saves all data in _transactions tothe customers transaction file
        public void SaveHistory() => File.WriteAllLines($"{_customerName.Username}TransactionHistory.csv", _transactions);


        //When called, takes the string from the customers transaction file, splits it and adds each string to the _transaction list
        public void LoadHistory()
        {
            _loadedHistory = File.ReadAllLines($"{_customerName.Username}TransactionHistory.csv");

            foreach (string transaction in _loadedHistory)
            {

                string[] tokens = transaction.Split(",");
                _transactions.Add(tokens[index]);

            }
        }



    }
}
