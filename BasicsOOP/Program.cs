using BasicsOOP;

BankAccount bankAccount1 = new BankAccount();
BankAccount bankAccount2 = new BankAccount();
BankAccount bankAccount3 = bankAccount1;

Console.WriteLine(Equals(bankAccount1,bankAccount2));
Console.WriteLine(Equals(bankAccount1, bankAccount3));

Console.WriteLine(bankAccount1 == bankAccount2);
Console.WriteLine(bankAccount1 == bankAccount3);

Console.WriteLine(!(bankAccount1 != bankAccount2));
Console.WriteLine(!(bankAccount1 != bankAccount3));

Console.WriteLine("bankAccount1 " + bankAccount1.GetHashCode());
Console.WriteLine("bankAccount2 " + bankAccount2.GetHashCode());
Console.WriteLine("bankAccount3 " + bankAccount3.GetHashCode());

Console.WriteLine(bankAccount1);
Console.WriteLine(bankAccount2);
Console.WriteLine(bankAccount3);