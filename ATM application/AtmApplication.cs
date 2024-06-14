using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace ATM_application
{





    public class AtmApplication
    {
        private Bank bank;

        public AtmApplication()
        {
            bank = new Bank();
        }

        public void execute()
        {
            bool exit = false;
            while (!exit)
            {
                DisplayMainMenu();
                int choice = int.Parse(Console.ReadLine());

                if (choice == 3)
                {
                    Console.WriteLine("Do you want to exit [y/n].");
                    var ch = Console.ReadLine();
                    if (ch == "y")
                        return;
                }


                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        SelectAccount();
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void DisplayMainMenu()
        {
            Console.WriteLine("=============Wrlcome to the ATM Application=============");
            Console.WriteLine("ATM Main Menu:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Select Account");
            Console.WriteLine("3. Exit");
        }

        private void CreateAccount()
        {
            Console.WriteLine("\n=============Welcome Create Account Menu=============\n\n");

            Console.WriteLine("Enter Account Holder's Name:");
            string accountHolderName = Console.ReadLine();

            Console.WriteLine("Enter Account Number(must be between 111 and 1000):");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Initial Balance:");
            double initialBalance = double.Parse(Console.ReadLine());

            double interestRate;
            do
            {
                Console.WriteLine("Enter Interest Rate (Must be 3% or less):");
                interestRate = double.Parse(Console.ReadLine());

                if (interestRate <= 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a value 3 or less.");
                }
            } while (true);

            Console.WriteLine("You entered a valid interest rate: " + interestRate);



            Account account = new Account(accountNumber, initialBalance, interestRate, accountHolderName);
            bank.AddAccount(account);
            Console.WriteLine("Account created successfully.");
        }

        private void SelectAccount()
        {
            Console.WriteLine("Enter Account Number:");
            int accountNumber = int.Parse(Console.ReadLine());

            Account account = bank.RetrieveAccount(accountNumber);
            Console.WriteLine($"\n\nWelcome  {account.AccountHolderName}\n\n");
            if (account != null)
            {
                bool exitAccountMenu = false;
                while (!exitAccountMenu)
                {
                    DisplayAccountMenu();
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"\nBalance: ${account.Balance}\n");
                            break;
                        case 2:
                            Console.WriteLine("Enter deposit amount:");
                            double depositAmount = double.Parse(Console.ReadLine());
                            account.Deposit(depositAmount);
                            break;
                        case 3:
                            Console.WriteLine("Enter withdrawal amount:");
                            double withdrawAmount = double.Parse(Console.ReadLine());
                            account.Withdraw(withdrawAmount);
                            break;
                        case 4:
                            account.DisplayTransactions();
                            break;
                        case 5:
                            exitAccountMenu = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        private void DisplayAccountMenu()
        {
            Console.WriteLine("Account Menu:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Display Transactions");
            Console.WriteLine("5. Exit Account");
        }
    }


}
