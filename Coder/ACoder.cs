using System.Text;

namespace Coder;
/// <summary>
/// Русский алфавит в верхнем регистре. Значения в диапазоне от 1 до 33
/// </summary>
public enum UpperAlphabet
{
    А = 1,
    Б,
    В,
    Г,
    Д,
    Е,
    Ё,
    Ж,
    З,
    И,
    Й,
    К,
    Л,
    М,
    Н,
    О,
    П,
    Р,
    С,
    Т,
    У,
    Ф,
    Х,
    Ц,
    Ч,
    Ш,
    Щ,
    Ъ,
    Ы,
    Ь,
    Э,
    Ю,
    Я //33
}

/// <summary>
/// Русский алфавит в нижнем регистре. Значения в диапазоне от 1 до 33
/// </summary>
public enum LowAlphabet
{
    а = 1,
    б,
    в,
    г,
    д,
    е,
    ё,
    ж,
    з,
    и,
    й,
    к,
    л,
    м,
    н,
    о,
    п,
    р,
    с,
    т,
    у,
    ф,
    х,
    ц,
    ч,
    ш,
    щ,
    ъ,
    ы,
    ь,
    э,
    ю,
    я //33
}

/// <summary>
/// Класс, поддерживающий шифрование и дешифрование в виде сдвига буквы на Pos позиций по русскому алфавиту.
/// </summary>
public class ACoder : ICoder
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
                int offset = Pos + (int)Enum.Parse(typeof(UpperAlphabet), str[i].ToString());
                offset -= (offset / 33) * 33;
                newStr.Append(Enum.GetName(typeof(UpperAlphabet), offset));
                continue;
            }
            else if (Enum.IsDefined(typeof(LowAlphabet), str[i].ToString())) //а-я
            {
                int offset = Pos + (int)Enum.Parse(typeof(LowAlphabet), str[i].ToString());
                offset -= (offset / 33) * 33;
                newStr.Append(Enum.GetName(typeof(LowAlphabet), offset));
                continue;
            }
            newStr.Append(str[i]);
        }
        return newStr.ToString();
    }

    /// <summary>
    /// Расшифрование единожды зашифрованной строки
    /// </summary>
    /// <param name="str">Строка, которую необходимо расшифровать</param>
    /// <returns>Возвращает строку в расшифрованном виде</returns>
    public string Decode(string? str)
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
                int offset = (int)Enum.Parse(typeof(UpperAlphabet), str[i].ToString()) - Pos;
                offset += ((33 - offset) / 33) * 33;
                newStr.Append(Enum.GetName(typeof(UpperAlphabet), offset));
                continue;
            }
            else if (Enum.IsDefined(typeof(LowAlphabet), str[i].ToString())) //а-я
            {
                int offset = (int)Enum.Parse(typeof(LowAlphabet), str[i].ToString()) - Pos;
                offset += ((33 - offset) / 33) * 33;
                newStr.Append(Enum.GetName(typeof(LowAlphabet), offset));
                continue;
            }
            newStr.Append(str[i]);
        }
        return newStr.ToString();
    }

    public ACoder()
    {
        Pos = 1;
    }
    public ACoder(int pos)
    {
        Pos = pos;
    }
}