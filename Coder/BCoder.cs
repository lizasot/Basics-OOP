using System.Text;

namespace Coder;
//англ:
//a: 97
//z: 122
//A: 65
//Z: 90

//ру:
//а: 1072
//я: 1103
//А: 1040
//Я: 1071
public class BCoder : ICoder
{
    private int _Pos = 1;
    public int Pos
    {
        get { return _Pos; }
        set
        {
            if (value > 0)
            {
                _Pos = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("value");
            }
        }
    }

    public string Encode(string? str)
    {
        if (str == null)
        {
            return "";
        }
        var newStr = new StringBuilder(str.Length);
        for (int i = 0; i < str.Length; i++)
        {
            int charCode = (int)str[i];
            int newCharCode = charCode + Pos;
            if (charCode >= 1072 && charCode <= 1103) //а-я
            {
                newCharCode -= ((newCharCode - 1072) / 32) * 32; //32 буквы русского алфавита без ё
                newStr.Append((char)newCharCode);
                continue;
            }
            else if (charCode >= 1040 && charCode <= 1071) //А-Я
            {
                newCharCode -= ((newCharCode - 1040) / 32) * 32; //32 буквы русского алфавита без ё
                newStr.Append((char)newCharCode);
                continue;
            }
            else if (charCode >= 97 && charCode <= 122) //a-z
            {
                newCharCode -= ((newCharCode - 97) / 26) * 26; //26 букв английского алфавита
                newStr.Append((char)newCharCode);
                continue;
            }
            else if (charCode >= 65 && charCode <= 90) //A-Z
            {
                newCharCode -= ((newCharCode - 65) / 26) * 26; //26 букв английского алфавита
                newStr.Append((char)newCharCode);
                continue;
            }

            newStr.Append((char)charCode);
        }
        return newStr.ToString();
    }
    public string Decode(string? str)
    {
        if (str == null)
        {
            return "";
        }
        var newStr = new StringBuilder(str.Length);
        for (int i = 0; i < str.Length; i++)
        {
            int charCode = (int)str[i];
            int newCharCode = charCode - Pos;
            if (charCode >= 1072 && charCode <= 1103) //а-я
            {
                newCharCode += ((1103 - newCharCode) / 32) * 32; //32 буквы русского алфавита без ё
                newStr.Append((char)newCharCode);
                continue;
            }
            else if (charCode >= 1040 && charCode <= 1071) //А-Я
            {
                newCharCode += ((1071 - newCharCode) / 32) * 32; //32 буквы русского алфавита без ё
                newStr.Append((char)newCharCode);
                continue;
            }
            else if (charCode >= 97 && charCode <= 122) //a-z
            {
                newCharCode += ((122 - newCharCode) / 26) * 26; //26 букв английского алфавита
                newStr.Append((char)newCharCode);
                continue;
            }
            else if (charCode >= 65 && charCode <= 90) //A-Z
            {
                newCharCode += ((90 - newCharCode) / 26) * 26; //26 букв английского алфавита
                newStr.Append((char)newCharCode);
                continue;
            }

            newStr.Append((char)charCode);
        }
        return newStr.ToString();
    }

    public BCoder()
    {
        Pos = 1;
    }
    public BCoder(int pos)
    {
        Pos = pos;
    }
}
