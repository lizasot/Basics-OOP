using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOOP;
/// <summary>
/// Типы банковских счетов
/// </summary>
public enum BankAccountType
{
    Payment,
    Current,
    Deposit,
    Currency,
    Special,
    Budget,
}
/// <summary>
/// Класс банковского счёта
/// </summary>
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

    private static int GenerateBankNumber()
    {
        return ++TotalBankNumber;
    }
    /// <summary>
    /// Вывод информации о банковском счёте
    /// </summary>
    public void PrintInfo()
    {
        Console.WriteLine($"Баланс банковского счёта #{_BankNumber} типа {_TypeAccount}: {_Balance};");
    }
    /// <summary>
    /// Снятие суммы с баланса банковского счёта
    /// </summary>
    /// <param name="amount">Сумма, которую необходимо снять</param>
    /// <returns>Возвращает, удачно ли прошёл перевод</returns>
    public bool BalanceWithdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        return false;
    }
    /// <summary>
    /// Начисление суммы на баланс
    /// </summary>
    /// <param name="amount">Сумма, которую необходимо начислить</param>
    public void BalancePut(decimal amount)
    {
        Balance += amount;
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
