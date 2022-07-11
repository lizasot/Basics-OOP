using BasicsOOP;
using BasicsOOP.Builds;

var b = new Build(188, 5, 160, 4);
var b2 = new Build(188, 5, 160, 4);
Console.WriteLine(b.ID);
Console.WriteLine(b2.ID);
Console.WriteLine(b.ApartmentsPerFloor());
Console.WriteLine(b.FloorHeight());