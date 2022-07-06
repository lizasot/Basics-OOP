using BasicsOOP;

BankAccount test1 = new BankAccount();
BankAccount test2 = new BankAccount(413);

test1.PrintInfo();
Console.WriteLine("Введите сумму, которую хотите положить на счёт #1");
test1.BalancePut(Convert.ToDecimal(Console.ReadLine()));
test1.PrintInfo();
test2.PrintInfo();
Console.WriteLine("Введите сумму, которую хотите перевести со счёта #1 на счёт #2");
if (test2.TransferMoney(test1, Convert.ToDecimal(Console.ReadLine())))
{
    Console.WriteLine("Перевод прошёл успешло.");
}
else
{
    Console.WriteLine("Не хватает средств для перевода.");
}
test1.PrintInfo();
test2.PrintInfo();