using BasicsOOP;

Console.WriteLine("Введите строку, в которой необходимо найти Email");
string str = Console.ReadLine();
if (str != null)
{
    Console.WriteLine(ProcessingString.SearchMail(ref str));
}