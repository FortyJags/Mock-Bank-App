using Mock_Bank_App;



PinNumber number = new PinNumber();
TransactionHistory transactionHistory = new TransactionHistory(number);
Withdraw withdraw = new Withdraw(transactionHistory);
Deposit deposit = new Deposit(transactionHistory);




decimal startingAmount = 1000;
decimal currentAmount;

int userMenuChoice = 0;



ColoredConsole.WriteLineColored("Please enter your username", ConsoleColor.Blue);
ColoredConsole.ChangeTypingColor(ConsoleColor.White); number.Username = Console.ReadLine();


if (File.Exists($"{number.Username}BankCurrentAmount.txt")) { currentAmount = Convert.ToDecimal(File.ReadAllText($"{number.Username}BankCurrentAmount.txt")); } else { currentAmount = startingAmount; }
if (File.Exists($"{number.Username}TransactionHistory.csv")) { transactionHistory.LoadHistory(); }
number.LoadPin();


number.PinEntry();
PickingMenuOptions();


void MenuDisplay()
{
    ColoredConsole.WriteLineColored("Please select what you would like to do:\n1 - Withdraw\n2 - Deposit\n3 - Change PIN\n4 - Check Balance\n5 - Transaction History\n6 - Exit", ConsoleColor.Green);

    try { ColoredConsole.ChangeTypingColor(ConsoleColor.White); userMenuChoice = Convert.ToInt32(Console.ReadLine()); } catch (FormatException) { ColoredConsole.WriteLineColored("That was not a number, please pick a number.", ConsoleColor.Red); }


}



void PickingMenuOptions()
{
    while (userMenuChoice != 6)
    {
        MenuDisplay();
        switch (userMenuChoice)
        {
            case 1:
                currentAmount = withdraw.Transaction(currentAmount);
                break;
            case 2:
                currentAmount = deposit.Transaction(currentAmount);
                deposit.ReturnToMenu();
                break;
            case 3:
                number.UserChangesPIN(number.Username);
                deposit.ReturnToMenu();
                break;
            case 4:
                Console.Clear();
                Console.WriteLine("Current balance is: £" + currentAmount.ToString());
                break;
            case 5:
                transactionHistory.ShowTransactionHistory();
                break;
            case 6:
                File.WriteAllText($"{number.Username}BankCurrentAmount.txt", Convert.ToString(currentAmount));
                transactionHistory.SaveHistory();
                break;

        }
    }

}

