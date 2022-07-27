using System.Text;

namespace Figures;
public class Figure
{
    private ConsoleColor _Color = ConsoleColor.White;
    private bool _Visible = true;
    private double _X = 0;
    private double _Y = 0;

    public double X { get { return _X; } set { _X = value; } }
    public double Y { get { return _Y; } set { _Y = value; } }
    public bool Visible { get { return _Visible; } set { _Visible = value; } }
    public ConsoleColor Color { get { return _Color; } set { _Color = value; } }

    public virtual string GetName()
    {
        return "Figure";
    }
    public bool Move(int x, int y)
    {
        X += x;
        Y += y;
        return true;
    }
    public bool Move(int x)
    {
        X += x;
        return true;
    }
    public bool SetColor(ConsoleColor color)
    {
        Color = color;
        return true;
    }
    public void ChangeVisibility()
    {
        Visible = !Visible;
    }
    public override string ToString()
    {
        return new StringBuilder()
            .Append("Figure: ").AppendLine(GetName())
            .Append("Color: ").AppendLine(_Color.ToString())
            .Append("Visible: ").AppendLine(_Visible.ToString())
            .AppendFormat($"[X, Y]: [{_X}, {_Y}]")
            .ToString();
    }
}