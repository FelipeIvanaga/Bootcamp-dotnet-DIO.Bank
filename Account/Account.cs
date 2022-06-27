namespace DIO.Bank
{
  public class Account
  {
    private AccountType AccountType { get; set; }
    private double Balance { get; set; }
    private double Credit { get; set; }
    private string Name { get; set; }

    public Account(AccountType accountType, double balance, double credit, string name)
    {
      this.AccountType = accountType;
      this.Balance = balance;
      this.Credit = credit;
      this.Name = name;
    }

    public bool Withdraw(double amount)
    {
      if (this.Balance - amount < (this.Credit * -1))
      {
        Console.WriteLine("Insufficient funds");
        return false;
      }

      this.Balance -= amount;
      Console.WriteLine("Balance of {0} account is {1}", this.Name, this.Balance);
      return true;
    }

    public void Deposit(double amount)
    {
      this.Balance += amount;
      Console.WriteLine("Balance of {0} account is {1}", this.Name, this.Balance);
    }

    public void Tranfer(double amount, Account destinationAccount)
    {
      if (this.Withdraw(amount))
      {
        destinationAccount.Deposit(amount);
      }
    }

    public override string ToString()
    {
      string response = "";
      response += "AccountType " + this.AccountType + " | ";
      response += "Name " + this.Name + " | ";
      response += "Balance " + this.Balance + " | ";
      response += "Credit " + this.Credit + " | ";
      return response;
    }
  }
}