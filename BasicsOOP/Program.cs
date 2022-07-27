using BasicsOOP;
using Figures;

static void Move(IMove2D obj)
{
    Console.WriteLine(obj.Move(5, 5));
}

var figure = new Figure();
Console.WriteLine(figure);
Move(figure);
Console.WriteLine(figure);

Console.WriteLine();

var circle = new Circle();

Console.WriteLine(circle);
Move(circle);
Console.WriteLine(circle);
