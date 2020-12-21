using System;

namespace CSharpPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            String sTest = Console.ReadLine();
            Console.WriteLine($"Echo: {sTest}");
            Console.ReadLine();

            BankAccount act = new BankAccount();
        }
    }

    public class BankAccount
    {
        public BankAccount()
        {
            balance = 10;
        }

        private double balance;
        public double Balance
        {
            get
            {
                return balance;
            }

            protected set
            {
               balance = value;
            }
        }

        public virtual void AddToBalance(double dAdd)
        {
            Balance += dAdd;
        }
    }

    public class ChildBankAccount : BankAccount
    {
        public ChildBankAccount()
        {
            Balance = 5;
        }

        public override void AddToBalance(double dAdd)
        {
            if (dAdd > 1000)
                dAdd = 1000;

            base.AddToBalance(dAdd);
        }
    }
}
