using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Дан текстовый файл, содержащий ФИО и e-mail адрес. 
//Разделителем между ФИО и адресом электронной почты является символ &: 
//Кучма Андрей Витальевич & Kuchma@mail.ru Мизинцев Павел Николаевич & Pasha@mail.ru
//Сформировать новый файл, содержащий список адресов электронной почты

namespace BasicsOOP;
/// <summary>
/// Класс, работающий со строками
/// </summary>
public class ProcessingString
{
    /// <summary>
    /// Переворачивание строки
    /// </summary>
    /// <param name="str">Строка, которую необходимо перевернуть</param>
    /// <returns>Перевёрнутая строка</returns>
    public static string Reverse(string str)
    {
        var result = new StringBuilder(str.Length);
        for (int i = str.Length - 1; i >= 0; i--)
        {
            result.Append(str[i]);
        }
        return result.ToString();
    }
    /// <summary>
    /// Возвращает первый Email в строке 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string SearchMail(ref string str)
    {
        //[ ][n символов]@[n символов].[n символов][ ]
        int index = str.IndexOf('@');
        var indexStart = index;
        try
        {
            if (index != -1)
            {
                //находит первый символ, с которого начинается адрес почты
                do
                {
                    indexStart--;
                } while (str[indexStart] != ' ' && indexStart != 0);
                if (str[indexStart] == ' ')
                {
                    indexStart++;
                }

                //проверяет наличие точки в адресе почты
                do
                {
                    index++;
                } while (str[index] != '.' && str[index] != ' ' && index != str.Length - 1);
                if (str[index] == ' ' || index == str.Length - 1)
                {
                    str = "";
                    return ""; //возвращает пустую строку, если точка не найдена
                }
                //находит последний символ адреса почты
                do
                {
                    index++;
                } while (str[index] != ' ' && index != str.Length - 1);
                if (str[index] == ' ')
                {
                    index--;
                }
            }
            else
            {
                str = "";
                return "";
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            str = "";
            return "";
        }
        var result = str.Substring(indexStart, index);
        str = "";
        return result;
    }
    /// <summary>
    /// Читает указанный файл, разделяя прочитанные данные на строки по символу &. В каждой строке производится поиск Email и записывается в файл test.txt
    /// </summary>
    /// <param name="file">Полный путь файла</param>
    public static void ReadFile(string file)
    {
        try
        {
            using (StreamReader fs = File.OpenText(@file))
            {
                using (StreamWriter fw = new StreamWriter("test.txt", false))
                {
                    string str = "";
                    string email = "";
                    while (fs.Peek() != -1)
                    {
                        char c = (char)fs.Read();
                        if (c != '&')
                        {
                            str = str + c;
                        }
                        else
                        {
                            email = SearchMail(ref str);
                            if (email != "")
                            {
                                fw.WriteLine(email);
                            }
                        }
                    }
                    email = SearchMail(ref str);
                    if (email != "")
                    {
                        fw.WriteLine(email);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}