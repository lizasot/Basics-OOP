using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOOP;
public class RationalNumber
{
    private int _Numerator;
    private int _Denominator;

    public int Numerator
    {
        get { return _Numerator; }
        set { _Numerator = value; }
    }
    public int Denominator
    {
        get { return _Denominator; }
        set
        {
            if (value == 0)
            {
                throw new ArgumentOutOfRangeException("value");
            }
            if (value < 0)
            {
                _Numerator *= -1;
                _Denominator = value * (-1);
            }
            _Denominator = value;
        }
    }

    public static int NOD(int numb1, int numb2)
    {
        int tmp = 0;
        if (numb1 == 0)
        {
            throw new ArgumentOutOfRangeException("numb1");
        }
        if (numb2 == 0)
        {
            throw new ArgumentOutOfRangeException("numb2");
        }
        if (numb1 < 0)
        {
            numb1 *= -1;
        }
        if (numb2 < 0)
        {
            numb1 *= -1;
        }
        if (numb2 > numb1)
        {
            tmp = numb1;
            numb1 = numb2;
            numb2 = tmp;
        }
        tmp = 0;
        int result = numb1;
        int remainder = numb2;
        do
        {
            tmp = result;
            result = remainder;
            remainder = tmp - (result * (tmp / result));
        } while (remainder != 0);
        return result;
    }
    public static int NOK(int numb1, int numb2)
    {
        return (numb1 * numb2) / NOD(numb1, numb2);
    }

    public static bool operator ==(RationalNumber numb1, RationalNumber numb2)
    {
        return ((numb1._Numerator == numb2._Numerator) && (numb1._Denominator == numb2._Denominator));
    }
    public static bool operator !=(RationalNumber numb1, RationalNumber numb2) => !(numb1 == numb2);
    public static bool operator >(RationalNumber numb1, RationalNumber numb2)
    {
        if (numb1._Denominator == numb2._Denominator)
        {
            return numb1._Numerator > numb2._Numerator;
        }
        if (numb1._Numerator == numb2._Numerator)
        {
            return !(numb1._Denominator > numb2._Denominator);
        }

        int nok = NOK(numb1._Denominator, numb2._Denominator);
        if (numb1._Denominator * (nok / numb1._Denominator) == numb2._Denominator * (nok / numb2._Denominator)) //знаменатели приведённых дробей должны быть равны
        {
            return (numb1._Numerator * (nok / numb1._Denominator)) > (numb2._Numerator * (nok / numb2._Denominator));
        }
        else
        {
            throw new Exception("Возник непредвиденный случай.");
        }
    }
    public static bool operator <(RationalNumber numb1, RationalNumber numb2)
    {
        if (numb1 == numb2)
        {
            return false;
        }
        else
        {
            return !(numb1 > numb2);
        }
    }
    public static bool operator >=(RationalNumber numb1, RationalNumber numb2)
    {
        if (numb1 == numb2)
        {
            return true;
        }
        else
        {
            return numb1 > numb2;
        }
    }
    public static bool operator <=(RationalNumber numb1, RationalNumber numb2)
    {
        if (numb1 == numb2)
        {
            return true;
        }
        else
        {
            return numb1 < numb2;
        }
    }
    public static RationalNumber operator +(RationalNumber numb1, RationalNumber numb2)
    {
        int nok = NOK(numb1._Denominator, numb2._Denominator);
        return new RationalNumber((numb1._Numerator * (nok / numb1._Denominator)) + (numb2._Numerator * (nok / numb2._Denominator)), nok);
    }
    public static RationalNumber operator -(RationalNumber numb1, RationalNumber numb2)
    {
        int nok = NOK(numb1._Denominator, numb2._Denominator);
        return new RationalNumber((numb1._Numerator * (nok / numb1._Denominator)) - (numb2._Numerator * (nok / numb2._Denominator)), nok);
    }
    public static RationalNumber operator ++(RationalNumber numb)
    {
        numb._Numerator += numb._Denominator;
        return numb;
    }
    public static RationalNumber operator --(RationalNumber numb)
    {
        numb._Numerator -= numb._Denominator;
        return numb;
    }
    public static RationalNumber operator *(RationalNumber numb1, RationalNumber numb2)
    {
        return new RationalNumber(numb1._Numerator * numb2._Numerator, numb1._Denominator * numb2._Denominator);
    }
    public static RationalNumber operator /(RationalNumber numb1, RationalNumber numb2)
    {
        return new RationalNumber(numb1._Numerator * numb2._Denominator, numb1._Denominator * numb2._Numerator);
    }
    public static RationalNumber operator %(RationalNumber numb1, RationalNumber numb2)
    {
        var numb = (numb1 / numb2);
        numb.Numerator -= (numb.Numerator / numb.Denominator)* numb.Denominator;
        return numb;
    }

    public override string ToString()
    {
        return _Numerator.ToString() + "/" + _Denominator.ToString();
    }
    public static explicit operator float(RationalNumber numb)
    {
        return (float)numb._Numerator / (float)numb._Denominator;
    }
    public static explicit operator int(RationalNumber numb)
    {
        return numb._Numerator / numb._Denominator;
    }

    public RationalNumber()
    {
        Numerator = 1;
        Denominator = 1;
    }
    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }
}