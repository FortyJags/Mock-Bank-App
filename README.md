# Mock-Bank-App

This app was created to mimic the typical banking application that most people use in their daily lives. 

I have added the basics for this: the option to add or withdraw funds, the option to view transaction hsitroy, the option to change pin number, the option to view current balance.

There is a save feature as well, which saves into 3 files. First, it saves the current amount of money. Secondly, it saves the transaction history into a .csv. Finally, it saves the pin number.
-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

This app first checks for any of the three files to see if they exist.
If they do, it loads the information and assigns it to its relevant types 
(current amount assigned to int currentAmount, pin number assigned to string validPinNumber, transaction history assigned to List<string> _transactions).

It then runs through the PIN authentication. This simply asks the user for their pin number and checks it against what is assigned to validPinNumber.
On each incorrect attempt, a counter called pinAttempts is incremented by 1.
If pin attempts is equal to 3, the account becomes locked. 

The locked account process has 2 main steps.
First, the pin number gets changed to "locked", also is the user is prompted to write a message to the admin explaining their issue(a seperate application is being produced to handle issues such as pin number changes).

The pin number is changed to "locked" as the program performs a check before any pin entry is attempted to see if the pin is equal to locked. 
If it is "locked", then the program informs the user their account is locked and closes down.
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Should the user pass the pin validation, they are presented with a menu. They can choose to add, withdraw, view balance, view transaction history, change pin or quit.

Adding funds allows the user to add to their current ba;ance. This performs a FloatTypeCheck on the user input to ensure it is of type float, if it is then it is added to their current balance.
If not, the user is informed that the number is invalid.

Withdrawing allows the user to withdraw from their current amount. It performs a check to make sure the user does not go below 0, if the user does then they are informed they cannot withdraw that much. 
The withdrawl amount comes out of their current balance.

For both of these, after a successful interaction some information is saved. The date and time of transaction, the type of transaction and the amount they withdrew/deposited are combined to make a string and then added to
the lsit of transactions. 

When the users whishes to view their transactions, they are show each transaction in full. 
