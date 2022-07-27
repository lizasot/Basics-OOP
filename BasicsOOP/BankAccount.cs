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
    private static int TotalBankNumber = 0;
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
    /// <summary>
    /// Зачисление суммы с другого счёта
    /// </summary>
    /// <param name="source">Банковский счёт, откуда снимаются деньги для перевода</param>
    /// <param name="amount">Сумма, которую необходимо перевести</param>
    /// <returns>Возвращает, удачно ли прошёл перевод</returns>
    public bool TransferMoney(BankAccount source, decimal amount)
    {
        if (source.BalanceWithdraw(amount))
        {
            BalancePut(amount);
            return true;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(BankNumber, Balance, TypeAccount);
    }
    public override bool Equals(object? obj)
    {
        if (obj is not BankAccount other)
            return false;

        return BankNumber == other.BankNumber 
            && Balance == other.Balance 
            && TypeAccount == other.TypeAccount;
    }
    public static bool operator ==(BankAccount account1, BankAccount account2) => Equals(account1, account2);
    public static bool operator !=(BankAccount account1, BankAccount account2) => !(account1 == account2);
    public override string ToString()
    {
        return $"Баланс банковского счёта #{_BankNumber} типа {_TypeAccount}: {_Balance};";
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
