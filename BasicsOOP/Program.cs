using BasicsOOP;

BankAccount test1 = new BankAccount();
BankAccount test2 = new BankAccount(413);
BankAccount test3 = new BankAccount(BankAccountType.Budget);
BankAccount test4 = new BankAccount(612,BankAccountType.Deposit);

test1.PrintInfo();
Console.WriteLine("Введите сумму, которую хотите положить на счёт #1");
test1.BalancePut(Convert.ToDecimal(Console.ReadLine()));
test1.PrintInfo();
Console.WriteLine("Введите сумму, которую хотите снять со счёта #1");
if (test1.BalanceWithdraw(Convert.ToDecimal(Console.ReadLine())))
{
    Console.WriteLine("Снятие прошло успешло.");
}
else
{
    Console.WriteLine("Не хватает средств для снятия.");
}
test1.PrintInfo();

test2.PrintInfo();
test3.PrintInfo();
test4.PrintInfo();