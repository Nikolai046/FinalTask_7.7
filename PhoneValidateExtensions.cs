using System.Linq;

namespace FinalTask_7_77
{
    public static class PhoneValidateExtensions
    {
        public static string ValidatePhoneNumber(this string phoneNumber, out string errorMessage)
        {
            errorMessage = null;

            // Проверка на пустое поле
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                errorMessage = "Введенное поле не может быть пустым";
                return null;
            }

            // Удаление всех нецифровых символов
            string result = new string(phoneNumber.Where(char.IsDigit).ToArray());

            // Проверка, состоит ли номер только из цифр
            if (result.Length != phoneNumber.Length)
            {
                errorMessage = "Номер телефона должен состоять только из цифр";
                return null;
            }

            // Проверка длины номера
            if (result.Length != 9)
            {
                errorMessage = "Номер телефона должен состоять из 11 цифр";
                return null;
            }

            return result;
        }
    }
}
