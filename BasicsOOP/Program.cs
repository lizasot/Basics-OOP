using BasicsOOP;
using Builds;

var b = Creator.CreateBuild(188, 5, 160, 4);
var b2 = Creator.CreateBuild(188, 5, 160, 4);
Creator.CreateBuild(150);
Creator.CreateBuild(10);
Creator.CreateBuild(80);

Console.WriteLine(b.ID);
Console.WriteLine(b2.ID);
Console.WriteLine(b.ApartmentsPerFloor());
Console.WriteLine(b.FloorHeight());

Console.WriteLine();
Console.WriteLine("Total builds: " + Creator.TotalBuild);
Console.WriteLine("ID and Height of each building:");
foreach (var build in Creator.BuildList)
{
    Console.WriteLine(build.Key + " " + build.Value.Height);
}

Console.WriteLine();
Console.Write("Введите айди здания, которое хотите удалить: ");
if (!Creator.RemoveBuild(int.Parse(Console.ReadLine())))
{
    Console.WriteLine("Нет такого айди.");
}


Console.WriteLine();
Console.WriteLine("ID and Height of each building:");
foreach (var build in Creator.BuildList)
{
    Console.WriteLine(build.Key + " " + build.Value.Height);
}