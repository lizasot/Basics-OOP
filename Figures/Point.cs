namespace Figures;
public class Point : Figure, IGetArea
{
    public override string GetName()
    {
        return "Point";
    }
    public double CalcArea()
    {
        return 0;
    }
}