using BasicsOOP;

BankAccount test = new BankAccount();

test.SetBankNumber(1);
test.SetBalance(100);
test.SetTypeAccount(BankAccountType.Payment);

Console.WriteLine($"Баланс банковского счёта #{test.GetBankNumber()} типа {test.GetTypeAccount()}: {test.GetBalance()};");