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
    private int _BankNumber;
    private decimal _Balance;
    private BankAccountType _TypeAccount;

    public int BankNumber
    {
        get { return _BankNumber; }
    }
    public decimal Balance
    {
        get { return _Balance; }
        set { _Balance = value; }
    }
    public BankAccountType TypeAccount
    {
        get { return _TypeAccount; }
        set { _TypeAccount = value; }
    }

    public static int GenerateBankNumber()
    {
        return ++TotalBankNumber;
    }
    public void PrintInfo()
    {
        Console.WriteLine($"Баланс банковского счёта #{_BankNumber} типа {_TypeAccount}: {_Balance};");
    }

    public BankAccount()
    {
        _BankNumber = GenerateBankNumber();
        _Balance = 0;
        _TypeAccount = BankAccountType.Current;
    }
    public BankAccount(decimal balance)
    {
        _BankNumber = GenerateBankNumber();
        _Balance = balance;
        _TypeAccount = BankAccountType.Current;
    }
    public BankAccount(BankAccountType typeAccount)
    {
        _BankNumber = GenerateBankNumber();
        _Balance = 0;
        _TypeAccount = typeAccount;
    }
    public BankAccount(decimal balance, BankAccountType typeAccount)
    {
        _BankNumber = GenerateBankNumber();
        _Balance = balance;
        _TypeAccount = typeAccount;
    }
}
