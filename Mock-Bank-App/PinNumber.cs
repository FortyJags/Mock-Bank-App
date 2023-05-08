using Mock_Bank_App;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace Mock_Bank_App
{
    internal class PinNumber
    {

        private string? validPinNumber;
        private string? userPinAttempt;
        private int pinAttempts = 0;

        private string? username;

        public string? Username { get; set; }

        public string? ValidPinNumber { get { return validPinNumber; } set { validPinNumber = value; } }
        

        //Asks user for a pin number, then calls the PinChecker method 
        public void PinEntry()
        {
       
        if (validPinNumber.Contains("locked")) { Console.Write("Account is locked"); System.Environment.Exit(0); }
            while (userPinAttempt != validPinNumber)
            {
                Console.Clear();

                ColoredConsole.WriteLineColored("Please enter your PIN", ConsoleColor.Blue);
                ColoredConsole.ChangeTypingColor(ConsoleColor.White); Console.WriteLine(pinAttempts);
                userPinAttempt = Console.ReadLine();
                PinChecker();
            }
            ColoredConsole.WriteLineColored("Welcome", ConsoleColor.Blue);
        }

        //Checks 2 things. First it checks if the user has attempted to enter a pin number unsuccesfully 3 times, if true then it locks the account and calls LockOutAccount. It also checks to see if the users input equals the valid pin assigned to their account, if they enter the wrong pin it adds 1 to the pin attempts and calls PinEntry.
        public void PinChecker()
        {
            if (pinAttempts == 3) { validPinNumber = "locked"; ColoredConsole.WriteLineColored("Your account has been locked, please type a message for the admin to review.", ConsoleColor.Red); LockOutAccount(); pinAttempts = 0; }
            if (userPinAttempt != validPinNumber) { ColoredConsole.WriteLineColored("Incorrect PIN", ConsoleColor.Red); pinAttempts++; PinEntry(); }
        }


        //Allows the user to change their pin number when called. Also saves the new pin number in the customers pin number file. 

        public void UserChangesPIN(string userName)
        {

            userPinAttempt = "1"; pinAttempts = -1;
            ColoredConsole.WriteLineColored("Please enter your old PIN", ConsoleColor.Blue);
            PinChecker();
            ColoredConsole.WriteLineColored("Please enter you new PIN", ConsoleColor.Blue);
            ColoredConsole.ChangeTypingColor(ConsoleColor.White); validPinNumber = Console.ReadLine();
            ColoredConsole.WriteLineColored("Please enter you new PIN again", ConsoleColor.Blue);
            pinAttempts = 0;
            PinChecker();
            File.WriteAllText($"{userName}BankPinCode.txt", validPinNumber);


        }


        //This is called when the user is locked out of their account. It asks the user to contact the admin and provide a brief message explaining their issue. This then adds the username and message to a ticket which can be accessed in a different application. 
        private void LockOutAccount()
        {

            string message = Console.ReadLine();

            List<TicketData> ticketData = new List<TicketData>() { new TicketData(Username, message) };
            List<string> raiseTicket = new List<string>();


            foreach (TicketData data in ticketData)
            {
                raiseTicket.Add($"{Username}, {message}");
            }

            File.WriteAllLines(@"D:\LearnToCode\Admin\Admin\bin\Debug\net6.0\Tickets.csv", raiseTicket);
            File.WriteAllText($"{username}BankPinCode.txt", validPinNumber);
            Environment.Exit(0);
        }

        public void LoadPin() { 
            if (File.Exists($"{username}BankPinCode.txt")) { validPinNumber = File.ReadAllText($"{validPinNumber}BankPinCode.txt"); }
            else { validPinNumber = "0000"; }
            }



}

    public record TicketData(string username, string message);
}

