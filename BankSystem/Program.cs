using Microsoft.VisualBasic;

namespace BankSystem
{
    //enum Type
    //{
    //    Withdraw,
    //    Deposite,
    //}

    //class Transaction
    //{
    //    public double Amount { get; set; }
    //    public DateTime DateTime { get; set; }
    //    public Type Type { get; set; }
    //}

    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public int WithdrawCounter { get; set; }
        public string Type { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime Date { get; set; }
        public double Max {  get; set; }


        public Account(string Name = "Unnamed Account", double Balance = 0.0, string type = "null")
        {
            this.Name = Name;
            this.Balance = Balance;
            this.Type = type;
            this.DateTime = DateTime.Now;
            this.Date = DateTime.Date;
            Max = this.Balance / 5;

        }

        public virtual bool Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                return true;
            }
            return false;
        }

        public virtual bool Withdraw(double amount, DateTime oprationDate)
        {
            //if(this.Type == "TrustAccount")
            //{
            //    this.WithdrawCounter++;
            //    if (this.WithdrawCounter < 4)
            //    {
            //        if(amount < this.Max)
            //        {
            //            if (Balance - amount >= 0)
            //            {
            //                Balance -= amount;
            //                return true;
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("The withdraw opration must less then 20% of your balance");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("You are can't make more then 3 withdraw oprations in same year");
            //    }
            //}
            //else
            //{
                if (Balance - amount >= 0)
                {
                    Balance -= amount;
                    return true;
                }
            //}
            
            return false;
        }

        public static Account operator +(Account obj1, Account obj2)
        {
            Account NewAccount = new Account()
            {
                Balance = obj1.Balance + obj2.Balance,
            };
            return NewAccount;
        }

        public override string ToString()
        {
            return $"Name is: {Name}, Balance is: {Balance}";
        }
    }

    public static class AccountUtil
    {
        // Utility helper functions for Account class
        public static void Display(List<Account> accounts)
        {
            Console.WriteLine("\n=== Accounts ==========================================");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }
        }

        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount, DateTime dateTime)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount, dateTime))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }
    }

    public class SavingAccount : Account
    {
        public SavingAccount(string Name = "Unnamed Account", double Balance = 0.0, double rate = 0.2) : base(Name, Balance)
        {
            Rate = rate;
        }

        double Rate { get; set; }

        public override bool Deposit(double amount)
        {
            return base.Deposit(amount + Rate);
        }
    }
    
    public class CheckingAccount : Account
    {
        public CheckingAccount(string name = "Unnamed Account", double balance = 0.0, double fee = 1.5) : base(name, balance) 
        {
            Fee = fee;
        }

        double Fee { get; set; }


        public override bool Withdraw(double amount, DateTime oprationDate)
        {
            double total = amount + this.Fee;
            return base.Withdraw(total, oprationDate);
        }
    }



    class TrustAccount : Account
    {
        public TrustAccount(string Name = "Unnamed Account", double Balance = 0.0, double rate = 0.2, double largerAmount = 5000, int bouns = 50, int withdrawCounter = 0, string type = "TrustAccount") : base(Name, Balance, type)
        {
            Rate = rate;
            LargerAmount = largerAmount;
            Bouns = bouns;
            CreatedDate = DateTime.Now;
            Max = this.Balance / 5;
            WithdrawelCounter = 0;
        }

        public double Rate { get; set; }
        public double LargerAmount { get; set; }
        public int Bouns { get; set; }
        public DateTime CreatedDate { get; set; }
        public double Max { get; set; }
        public int WithdrawelCounter {  get; set; }
        public override bool Deposit(double amount)
        {
            return base.Deposit(amount >= this.LargerAmount ? amount += this.LargerAmount : amount);
        }

        public override bool Withdraw(double amount, DateTime oprationDate)
        {
            WithdrawelCounter++;
            if(this.WithdrawelCounter <= 3)
            {
                oprationDate.AddYears(1);
                if (oprationDate < this.CreatedDate)
                {
                    if(amount < this.Max)
                    {
                        if (Balance - amount >= 0)
                        {
                            this.Balance =- amount;
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    return true;
                }
                return true;
            }
            return false;
        }
    }


    class Program
    {
        static void Main()
        {
            // Accounts
            //var accounts = new List<Account>();
            //accounts.Add(new Account());
            //accounts.Add(new Account("Larry"));
            //accounts.Add(new Account("Moe", 2000));
            //accounts.Add(new Account("Curly", 5000));

            //Console.WriteLine(accounts[2] + accounts[3]);

            //AccountUtil.Display(accounts);
            //AccountUtil.Deposit(accounts, 1000);
            //AccountUtil.Withdraw(accounts, 2000, DateTime.Now);

            // Savings
            //var savAccounts = new List<Account>();
            //savAccounts.Add(new SavingAccount());
            //savAccounts.Add(new SavingAccount("Superman"));
            //savAccounts.Add(new SavingAccount("Batman", 2000));
            //savAccounts.Add(new SavingAccount("Wonderwoman", 5000, 5.0));

            //AccountUtil.Display(savAccounts);
            //AccountUtil.Deposit(savAccounts, 1000);
            //AccountUtil.Withdraw(savAccounts, 2000);

            // Checking
            //var checAccounts = new List<Account>();
            //checAccounts.Add(new CheckingAccount());
            //checAccounts.Add(new CheckingAccount("Larry2"));
            //checAccounts.Add(new CheckingAccount("Moe2", 2000));
            //checAccounts.Add(new CheckingAccount("Curly2", 5000));

            //AccountUtil.Display(checAccounts);
            //AccountUtil.Deposit(checAccounts, 1000);
            //AccountUtil.Withdraw(checAccounts, 2000);
            //AccountUtil.Withdraw(checAccounts, 2000);

            // Trust
            var trustAccounts = new List<Account>();
            //trustAccounts.Add(new TrustAccount());
            //trustAccounts.Add(new TrustAccount("Superman2"));
            //trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 10000, 5.0));

            AccountUtil.Display(trustAccounts);
            //AccountUtil.Deposit(trustAccounts, 1000);
            //AccountUtil.Deposit(trustAccounts, 6000);
            AccountUtil.Withdraw(trustAccounts, 1500, DateTime.Now);
            AccountUtil.Withdraw(trustAccounts, 3000, DateTime.Now);
            AccountUtil.Withdraw(trustAccounts, 500, DateTime.Now);
            AccountUtil.Withdraw(trustAccounts, 500, DateTime.Now);

            Console.WriteLine();
        }
    }
}
