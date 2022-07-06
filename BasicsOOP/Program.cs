using BasicsOOP;

Console.WriteLine("Введите строку, которую необходимо перевернуть");
Console.WriteLine(ProcessingString.Reverse(Console.ReadLine()));
Console.Write("пёс: ");
Console.WriteLine(ProcessingString.Reverse("пёс"));
Console.Write("tacocat: ");
Console.WriteLine(ProcessingString.Reverse("tacocat"));
Console.Write("1234321: ");
Console.WriteLine(ProcessingString.Reverse("1234321"));
Console.Write("3432112: ");
Console.WriteLine(ProcessingString.Reverse("3432112"));

/*
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
*/