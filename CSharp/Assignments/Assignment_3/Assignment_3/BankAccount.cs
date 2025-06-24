using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class BankAccount
    {
        static void Main(string[] args)
        {
            Accounts accounts = new Accounts(105678934567, "Thamaraii", "Savings");
            accounts.GetData();
            accounts.UpdateBalance();
            Console.WriteLine("******* Bank Details ******");
            Console.WriteLine(accounts.ShowData());

            Console.Read();
        }
    }

    /*
   Inheritance:

    1. Create a class called Accounts which has data members/fields like Account no, Customer name, Account type, Transaction type (d/w), amount, balance
    D->Deposit
    W->Withdrawal

    -write a function that updates the balance depending upon the transaction type

        -If transaction type is deposit call the function credit by passing the amount to be deposited and update the balance

      function  Credit(int amount) 

        -If transaction type is withdraw call the function debit by passing the amount to be withdrawn and update the balance

      Debit(int amt) function 

    -Pass the other information like Account no, customer name, acc type through constructor

    -write and call the show data method to display the values.

 */

    class Accounts
    {
        long AccountNo;
        string CustomerName;
        string AccountType;
        string TransactionType;
        int Amount;
        int Balance;

        public Accounts(long AccNo,string CusName,string AccType)
        {
            this.AccountNo = AccNo;
            this.CustomerName = CusName;
            this.AccountType = AccType;
            this.Balance = 0;
        }

        public void GetData()
        {
            Console.WriteLine("Enter The Transaction Type: Either Deposit/ Withdraw");
            TransactionType = Console.ReadLine();
            Console.WriteLine("Input Amt: ");
            Amount = Convert.ToInt32(Console.ReadLine());
        }

        public void UpdateBalance() {
            if (TransactionType.ToLower() == "deposit")
                CreditFun(Amount);
            else if (TransactionType.ToLower() == "withdraw")
                DebitFun(Amount);
            else
                Console.WriteLine("Invalid Transaction Type");
        }

        public void CreditFun(int amt)
        {
            Balance = Balance + Amount; 
        }

        public void DebitFun(int amt)
        {
            if(amt <= Balance)
                Balance = Balance - Amount;
            else
                Console.WriteLine("Insufficient Balance");
        }

        public string ShowData()
        {
            return ($"Account Number: {AccountNo } , Customer Name: {CustomerName} , Account Type: {AccountType} , " +
                $"Transaction Type: {TransactionType}  , Amount: {Amount}  , Balance: {Balance}");
        }
    }

}
