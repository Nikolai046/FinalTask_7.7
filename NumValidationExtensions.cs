using System;
using System.Linq;


namespace FinalTask_7_7
{
    public static class NumValidationExtensions
    {
        public static string NumValidate(this string str, out string errorMessage, int nmin, int nmax)
        {
            errorMessage = null;
            char[] numarray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (str.Length == 0)
            {
                errorMessage = "Введенное поле не может быть пустым";
                return null;
            }
            foreach (var ch in str)
            {
                if (!numarray.Contains(Convert.ToChar(ch)))
                {
                    errorMessage = "Допускается ввод только цифр";
                    return null;
                }
            }
            if (Convert.ToInt32(str) < nmin || Convert.ToInt32(str) > nmax)
            {
                errorMessage = $"Вводимое значение дольно быть от {nmin} до {nmax}";
                return null;
            }
            return str;
        }
    }
}
