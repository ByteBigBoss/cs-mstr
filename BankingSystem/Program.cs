using System;

namespace BankingSystem
{
    //BASE ACCOUNT CLASS
    public class Account
    {
        public string AccountHolder {get; set;}
        protected decimal Balance;

        public Account(string accountHolder, decimal initialBalance)
        {
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"{amount:C} deposited. New Balance: {Balance:C}");
        }

        public virtual void Withdraw(decimal amount)
        {
            if(amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"{amount:C} withdrawn. New Balance: {Balance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient funds}");
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Account Holder: {AccountHolder}, Balance: {Balance:C}");
        }
    }

    // SAVINGs ACCOUNT CLASS INHERITING FROM ACCOUNT
    public class SavingsAccount: Account
    {
        public decimal InterestRate {get; set;}

        public SavingsAccount(string accountHolder, decimal initialBalance, decimal interestRate)
        : base(accountHolder, initialBalance)
        {
            InterestRate = interestRate;
        }

        // OVERRIDING METHOD
        public override void Deposit(decimal amount)
        {
            base.Deposit(amount);
            ApplyInterest();
        }

        private void ApplyInterest()
        {
            decimal interest = Balance * InterestRate / 100;
            Balance += interest;
            Console.WriteLine($"Interest of {interest:C} applied. New Balance: {Balance:C}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount myAccount = new SavingsAccount("John Doe", 1000.00m, 3.5m);

            myAccount.Deposit(500);
            myAccount.Withdraw(200);
            myAccount.ShowBalance();
        }
    }
}