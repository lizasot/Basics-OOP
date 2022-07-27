using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers;
/// <summary>
/// Класс комплексных чисел
/// </summary>
public readonly struct ComplexNumber
{
    private readonly float _Real = 0;
    private readonly float _Imaginary = 0;

    public float Real { get { return _Real; } }
    public float Imaginary { get { return _Imaginary; } }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is not ComplexNumber)
        {
            return false;
        }

        ComplexNumber other = (ComplexNumber)obj;
        return Real == other.Real
            && Imaginary == other.Imaginary;
    }
    public static bool operator ==(ComplexNumber numb1, ComplexNumber numb2) => Equals(numb1, numb2);
    public static bool operator !=(ComplexNumber numb1, ComplexNumber numb2) => !(numb1 == numb2);
    public static ComplexNumber operator +(ComplexNumber numb1, ComplexNumber numb2)
    {
        return new ComplexNumber(numb1._Real + numb2._Real, numb1._Imaginary + numb2._Imaginary);
    }
    public static ComplexNumber operator *(ComplexNumber numb1, ComplexNumber numb2)
    {
        return new ComplexNumber((numb1._Real * numb2._Real) - (numb1._Imaginary * numb2._Imaginary), (numb1._Real * numb2._Imaginary) + (numb1._Imaginary * numb2._Real));
    }
    public static ComplexNumber operator -(ComplexNumber numb1, ComplexNumber numb2)
    {
        return new ComplexNumber(numb1._Real - numb2._Real, numb1._Imaginary - numb2._Imaginary);
    }
    public override string ToString()
    {
        var str = new StringBuilder();
        if (_Real != 0)
        {
            str.Append(_Real);
        }
        if (_Imaginary != 0)
        {
            if (_Imaginary > 0)
            {
                str.Append(" + ");
                str.Append(_Imaginary != 1 ? _Imaginary : "");
            }
            else
            {
                str.Append(" - ");
                str.Append(_Imaginary != -1 ? -_Imaginary : "");
            }
            str.Append("i");
        }
        return str.ToString();
    }

    public ComplexNumber(float real, float imaginary)
    {
        _Real = real;
        _Imaginary = imaginary;
    }
}
