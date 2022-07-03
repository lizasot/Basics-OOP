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
    private int BankNumber;
    private decimal Balance;
    private BankAccountType TypeAccount;


    public void SetBankNumber(int bankNumber)
    {
        BankNumber = bankNumber;
    }
    public int GetBankNumber()
    {
        return BankNumber;
    }
    public void SetBalance(decimal balance)
    {
        Balance = balance;
    }
    public decimal GetBalance()
    {
        return Balance;
    }
    public void SetTypeAccount(BankAccountType typeAccount)
    {
        TypeAccount = typeAccount;
    }
    public BankAccountType GetTypeAccount()
    {
        return TypeAccount;
    }
}
