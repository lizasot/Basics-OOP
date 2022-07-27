namespace Figures;
public class Circle : Point
{
    private double _R = 0;
    public double R { get { return _R; } set { _R = value; } }
    public override string GetName()
    {
        return "Circle";
    }
    public double CalcArea()
    {
        return Math.PI * R * R;
    }
}