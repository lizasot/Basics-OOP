using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOOP
{
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
            string result = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                result += str[i];
            }
            return result;
        }
    }
}
