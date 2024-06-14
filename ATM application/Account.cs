using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections.Generic;

namespace ATM_application
{
    public class Account
    {
        public int AccountNumber { get; private set; }
        public double Balance { get; private set; }
        public double InterestRate { get; private set; }
        public string AccountHolderName { get; private set; }
        private List<string> transactions;

        public Account(int accountNumber, double initialBalance, double interestRate, string accountHolderName)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
            InterestRate = interestRate;
            AccountHolderName = accountHolderName;
            transactions = new List<string>();
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                transactions.Add($"Deposited: ${amount}");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                transactions.Add($"Withdrew: ${amount}");
            }
        }

        public void DisplayTransactions()
        {
            Console.WriteLine("=======Transactions=======");
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Account Holder : {AccountHolderName}");
            Console.WriteLine($"Interest rare : {InterestRate}");
            Console.WriteLine($"Balance : {Balance}");
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

        public void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Holder: {AccountHolderName}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: ${Balance}");
            Console.WriteLine($"Interest Rate: {InterestRate}%");
        }
    }
}
