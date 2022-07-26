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
public class ACoder : ICoder
{
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
            if (charCode >= 1072 && charCode <= 1103)
            {
                if (charCode == 1103)
                {
                    newStr.Append('а');
                }
                else
                {
                    newStr.Append((char)(str[i] + 1));
                }
            }
            else if (charCode >= 1040 && charCode <= 1071)
            {
                if (charCode == 1071)
                {
                    newStr.Append('А');
                }
                else
                {
                    newStr.Append((char)(str[i] + 1));
                }
            }
            else if (charCode >= 97 && charCode <= 122)
            {
                if (charCode == 122)
                {
                    newStr.Append('a');
                }
                else
                {
                    newStr.Append((char)(str[i] + 1));
                }
            }
            else if (charCode >= 65 && charCode <= 90)
            {
                if (charCode == 90)
                {
                    newStr.Append('A');
                }
                else
                {
                    newStr.Append((char)(str[i] + 1));
                }
            }
            else
            {
                newStr.Append(str[i]);
            }
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
            if (charCode >= 1072 && charCode <= 1103)
            {
                if (charCode == 1072)
                {
                    newStr.Append('я');
                }
                else
                {
                    newStr.Append((char)(str[i] - 1));
                }
            }
            else if (charCode >= 1040 && charCode <= 1071)
            {
                if (charCode == 1040)
                {
                    newStr.Append('Я');
                }
                else
                {
                    newStr.Append((char)(str[i] - 1));
                }
            }
            else if (charCode >= 97 && charCode <= 122)
            {
                if (charCode == 97)
                {
                    newStr.Append('z');
                }
                else
                {
                    newStr.Append((char)(str[i] - 1));
                }
            }
            else if (charCode >= 65 && charCode <= 90)
            {
                if (charCode == 65)
                {
                    newStr.Append('Z');
                }
                else
                {
                    newStr.Append((char)(str[i] - 1));
                }
            }
            else
            {
                newStr.Append(str[i]);
            }
        }
        return newStr.ToString();
    }
}