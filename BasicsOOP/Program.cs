using BasicsOOP;

BankAccount test1 = new BankAccount();
BankAccount test2 = new BankAccount(413);
BankAccount test3 = new BankAccount(BankAccountType.Budget);
BankAccount test4 = new BankAccount(612,BankAccountType.Deposit);

test1.PrintInfo();
test2.PrintInfo();
test3.PrintInfo();
test4.PrintInfo();