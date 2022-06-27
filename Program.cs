namespace DIO.Bank

{
  class Program
  {
    static List<Account> accountsList = new List<Account> { };
    static void Main(string[] args)
    {
      string userOption = GetUserOption();

      while (userOption != "X")
      {
        switch (userOption)
        {
          case "1":
            ListAccounts();
            break;
          case "2":
            InsertAccount();
            break;
          case "3":
            Transfer();
            break;
          case "4":
            Withdraw();
            break;
          case "5":
            Deposit();
            break;
          case "C":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        userOption = GetUserOption();
      }

      Console.WriteLine("Thank you for using ours services.");
      Console.ReadLine();
    }

    private static void Deposit()
    {
      Console.WriteLine("Deposit");

      Console.WriteLine("Insert Account number: ");
      int accountNumber = int.Parse(Console.ReadLine());

      Console.WriteLine("Insert Amount to depositv: ");
      double amountToDeposit = double.Parse(Console.ReadLine());

      accountsList[accountNumber].Deposit(amountToDeposit);
    }

    private static void Withdraw()
    {
      Console.WriteLine("Withdraw");

      Console.WriteLine("Insert Account number: ");
      int accountNumber = int.Parse(Console.ReadLine());

      Console.WriteLine("Insert Amount to withdraw: ");
      double amountToWithdraw = double.Parse(Console.ReadLine());

      accountsList[accountNumber].Withdraw(amountToWithdraw);
    }

    private static void Transfer()
    {
      Console.WriteLine("Tranfer");

      Console.WriteLine("Insert origin Account number: ");
      int originAccount = int.Parse(Console.ReadLine());

      Console.WriteLine("Insert destination Account number: ");
      int destinationAccount = int.Parse(Console.ReadLine());

      Console.WriteLine("Insert Amount to tranfer: ");
      double amount = double.Parse(Console.ReadLine());

      accountsList[originAccount].Tranfer(amount, accountsList[destinationAccount]);

    }

    private static void ListAccounts()
    {
      Console.WriteLine("List accounts");

      if (accountsList.Count == 0)
      {
        Console.WriteLine("No account registered.");
        return;
      }

      for (int i = 0; i < accountsList.Count; i++)
      {
        Account account = accountsList[i];
        Console.Write("{0} ", i);
        Console.WriteLine(account);
      }
    }

    private static void InsertAccount()
    {
      Console.WriteLine("Insert a new Account");

      Console.WriteLine("Insert 1 for Personal account or 2 for Legal Entity: ");
      int accountTypeEntry = int.Parse(Console.ReadLine());

      Console.WriteLine("Insert Client Name: ");
      string nameEntry = Console.ReadLine();

      Console.WriteLine("Insert initial Balance: ");
      double balanceEntry = double.Parse(Console.ReadLine());

      Console.WriteLine("Insert Account Credit: ");
      double creditEntry = double.Parse(Console.ReadLine());

      Account newAccount = new Account(accountType: (AccountType)accountTypeEntry,
                                      balance: balanceEntry,
                                      credit: creditEntry,
                                      name: nameEntry);

      accountsList.Add(newAccount);
    }

    private static string GetUserOption()
    {
      Console.WriteLine();
      Console.WriteLine("Console Bank!");
      Console.WriteLine("Choose your desired operation");

      Console.WriteLine("1 - List Accounts");
      Console.WriteLine("2 - Add new Account");
      Console.WriteLine("3 - Tranfer");
      Console.WriteLine("4 - Withdraw");
      Console.WriteLine("5 - Deposit");
      Console.WriteLine("C - Clear console");
      Console.WriteLine("X - Exit");
      Console.WriteLine();

      string userOption = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return userOption;
    }
  }
}