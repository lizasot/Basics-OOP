using BasicsOOP;
using Figures;

var p = new Point();
Console.WriteLine(p);
Console.WriteLine();

p.Move(5, 4);
Console.WriteLine(p);
Console.WriteLine();

var circle = new Circle();
Console.WriteLine(circle);
Console.WriteLine("Area: " + circle.CalcArea());
Console.WriteLine();

var rec = new Rectangle();
Console.WriteLine(rec);
Console.WriteLine("Area: " + rec.CalcArea());
Console.WriteLine();

rec.SetColor(ConsoleColor.Red);
rec.ChangeVisibility();
rec.Move(-5, 8);
Console.WriteLine(rec);