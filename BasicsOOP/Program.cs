using BasicsOOP;
using Coder;
//англ:
//a: 97
//z: 122
//A: 65
//Z: 90

//ру:
//а: 1072
//я: 1103
//А: 1040
//Я: 1071


var codeA = new ACoder();
int pos = 0;
do {
    Console.Write("Введите число, на которое необходимо сдвинуть буквы послания: ");
} while (!int.TryParse(Console.ReadLine(), out pos));
var codeB = new BCoder(pos);


//переделать задачу с BCoder

Console.WriteLine("Введите строку для зашифровки: ");
string? str = Console.ReadLine();
Console.Write("Зашифровка ACoder (сдвиг на 1 букву): ");
string tmpStr = codeA.Encode(str);
Console.WriteLine(tmpStr);
Console.Write("Расшифровка ACoder: ");
tmpStr = codeA.Decode(tmpStr);
Console.WriteLine(tmpStr);
Console.Write("Расшифровка ACoder ещё раз: ");
tmpStr = codeA.Decode(tmpStr);
Console.WriteLine(tmpStr);

Console.WriteLine();

Console.Write($"Работа BCoder (сдвиг на {pos} букв(ы)): ");
tmpStr = codeB.Encode(str);
Console.WriteLine(tmpStr);
Console.Write("Расшифровка BCoder: ");
tmpStr = codeB.Decode(tmpStr);
Console.WriteLine(tmpStr);
Console.Write("Расшифровка BCoder ещё раз: ");
tmpStr = codeB.Decode(tmpStr);
Console.WriteLine(tmpStr);