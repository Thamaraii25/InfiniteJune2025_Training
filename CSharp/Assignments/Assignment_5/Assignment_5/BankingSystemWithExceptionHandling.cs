using System;

namespace Assignment_5
{
    class BankingSystemWithExceptionHandling
    {
        static void Main(string[] args)
        {
            BankingSystem bankSys = new BankingSystem();

            while (true)
            {
                try
                {
                    bankSys.GetData();
                }
                catch (InvalidTransactionType ex)
                {
                    Console.WriteLine("Invalid Transaction: " + ex.Message);
                }
                catch (InSufficientBalanceException ex)
                {
                    Console.WriteLine("Transaction Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected Error: " + ex.Message);
                }

                Console.WriteLine("Do U want to Continue this Transaction (Yes/ No)");
                string choice = Console.ReadLine().ToLower();
               
                if(choice != "yes" && choice != "y")
                {
                    Console.WriteLine("Thankyou for the using our service!!!");
                    break;
                }

            }
           

            Console.Read();
        }

        class BankingSystem
        {
            public long AccountNumber;
            public string TypeOfTransaction;
            public int AccountBalance;
            public int Amount;

            public BankingSystem()
            {
                Console.WriteLine("Input Account No:");
                AccountNumber = long.Parse(Console.ReadLine());
                this.AccountBalance = 0;
            }

            public void GetData()
            {

                Console.WriteLine("Input Transaction Type (Deposit / Withdraw):");
                TypeOfTransaction = Console.ReadLine().ToLower();

                Console.WriteLine("Input Amount:");
                Amount = Convert.ToInt32(Console.ReadLine());

                if (TypeOfTransaction == "deposit")
                {
                    DepositAmount(Amount);
                }
                else if (TypeOfTransaction == "withdraw")
                {
                    WithdrawAmount(Amount);
                }
                else
                {
                    throw new InvalidTransactionType("Invalid transaction type. Use 'Deposit' / 'Withdraw'.");
                }
            }

            public void WithdrawAmount(int amount)
            {
                if (AccountBalance < amount)
                {
                    throw new InSufficientBalanceException("Insufficient balance to complete withdrawal.");
                }

                AccountBalance -= amount;
                Console.WriteLine("Withdrawal successful. Current Balance: {0}", AccountBalance);
            }

            public void DepositAmount(int amount)
            {
                AccountBalance += amount;
                Console.WriteLine("Deposit successful. Current Balance: {0}", AccountBalance);
            }
        }

        class InSufficientBalanceException : ApplicationException
        {
            public InSufficientBalanceException(string message) : base(message) { }
        }
        class InvalidTransactionType : ApplicationException
        {
            public InvalidTransactionType(string message) : base(message) { }
        }
    }
}
