using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOOP;

public enum BankAccountType
{
    Payment,
    Current,
    Deposit,
    Currency,
    Special,
    Budget,
}

public class BankAccount
{
    static private int TotalBankNumber = 0;
    private int BankNumber;
    private decimal Balance;
    private BankAccountType TypeAccount;

    public int GetBankNumber()
    {
        return BankNumber;
    }
    public decimal GetBalance()
    {
        return Balance;
    }
    public BankAccountType GetTypeAccount()
    {
        return TypeAccount;
    }
    public static int GenerateBankNumber()
    {
        return ++TotalBankNumber;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Баланс банковского счёта #{BankNumber} типа {TypeAccount}: {Balance};");
    }

    public BankAccount()
    {
        BankNumber = GenerateBankNumber();
        Balance = 0;
        TypeAccount = BankAccountType.Current;
    }
    public BankAccount(decimal balance)
    {
        BankNumber = GenerateBankNumber();
        Balance = balance;
        TypeAccount = BankAccountType.Current;
    }
    public BankAccount(BankAccountType typeAccount)
    {
        BankNumber = GenerateBankNumber();
        Balance = 0;
        TypeAccount = typeAccount;
    }
    public BankAccount(decimal balance, BankAccountType typeAccount)
    {
        BankNumber = GenerateBankNumber();
        Balance = balance;
        TypeAccount = typeAccount;
    }
}
