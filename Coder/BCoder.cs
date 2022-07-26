using System.Text;

namespace Coder;

public class BCoder : ICoder
{

    /// <summary>
    /// Шифрование строки
    /// </summary>
    /// <param name="str">Строка, которую необходимо зашифровать</param>
    /// <returns>Возвращает строку в зашифрованном виде</returns>
    public string Encode(string? str)
    {
        if (str == null)
        {
            return "";
        }
        var newStr = new StringBuilder(str.Length);
        for (int i = 0; i < str.Length; i++)
        {
            if (Enum.IsDefined(typeof(UpperAlphabet), str[i].ToString())) //А-Я
            {
                int newPos = 33 - ((int)Enum.Parse(typeof(UpperAlphabet), str[i].ToString()) - 1);
                newStr.Append(Enum.GetName(typeof(UpperAlphabet), newPos));
                continue;
            }
            else if (Enum.IsDefined(typeof(LowAlphabet), str[i].ToString())) //а-я
            {
                int newPos = 33 - ((int)Enum.Parse(typeof(UpperAlphabet), str[i].ToString()) - 1);
                newStr.Append(Enum.GetName(typeof(UpperAlphabet), newPos));
                continue;
            }
            newStr.Append(str[i]);
        }
        return newStr.ToString();
    }

    /// <summary>
    /// Расшифрование зашифрованной строки
    /// </summary>
    /// <param name="str">Строка, которую необходимо расшифровать</param>
    /// <returns>Возвращает строку в расшифрованном виде</returns>
    public string Decode(string? str)
    {
        if (str == null)
        {
            return "";
        }
        return Encode(str);
    }
}
