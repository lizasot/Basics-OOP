using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOOP;
public class ComplexNumber
{
    private float _Real;
    private float _Imaginary;

    public float Real
    {
        get { return _Real; }
        set { _Real = value; }
    }
    public float Imaginary
    {
        get { return _Imaginary; }
        set { _Imaginary = value; }
    }

    public static bool operator ==(ComplexNumber numb1, ComplexNumber numb2)
    {
        return numb1._Real == numb2._Real && numb1._Imaginary == numb2._Imaginary;
    }
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
        string str = "";
        if (_Real != 0)
        {
            str = _Real.ToString();
        }
        if (_Imaginary != 0)
        {
            if (_Imaginary > 0)
            {
                str += " + ";
            }
            else
            {
                str += " - ";
                _Imaginary *= -1;
            }
            str += _Imaginary != 1 ? _Imaginary.ToString() : "" + "i";
        }
        return str;
    }

    public ComplexNumber()
    {
        Real = 0;
        Imaginary = 0;
    }
    public ComplexNumber(float real, float imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }
}
