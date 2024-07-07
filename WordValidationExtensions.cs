using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask_7
{
            public static class StringExtensions
        {
            private static readonly char[] Alphabet = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

            public static string WordValidate(this string str, out string errorMessage)
            {
                errorMessage = null;

                // Проверка на пустое поле
                if (string.IsNullOrEmpty(str))
                {
                    errorMessage = "Введенное поле не может быть пустым";
                    return null;
                }

                // Проверяем, что введенные данные содержат только русские буквы
                foreach (char c in str)
                {
                    if (!Alphabet.Contains(c))
                    {
                        errorMessage = "Допускается ввод только русских букв";
                        return null;
                    }
                }

                // Проверяем, что первая буква должна быть заглавная
                if (!Alphabet.Take(32).Contains(str[0]))
                {
                    errorMessage = "Первая буква должна быть заглавная";
                    return null;
                }

                // Проверяем, что все буквы кроме первой строчные
                for (int i = 1; i < str.Length; i++)
                {
                    if (!Alphabet.Skip(32).Contains(str[i]))
                    {
                        errorMessage = "Заглавная буква может быть только в начале";
                        return null;
                    }
                }

                // Проверяем, что больше 2х букв
                if (str.Length < 2)
                {
                    errorMessage = "Должно быть более 1й буквы";
                    return null;
                }

                return str;
            }
        }
    
}
