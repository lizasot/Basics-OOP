namespace Figures;
public class Rectangle : Point
{
    private double _Width;
    private double _Height;

    public double Width { get { return _Width; } set { _Width = value; } }
    public double Height { get { return _Height; } set { _Height = value; } }

    public override string GetName()
    {
        return "Rectangle";
    }
    public double CalcArea()
    {
        return _Width * _Height;
    }
}