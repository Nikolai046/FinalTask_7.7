using FinalTask_7_77;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask_7_7
{
    public class PersonDataCollect
    {
        public string[] PersonData { get; private set; }

        public PersonDataCollect()
        {
            PersonData = new string[3];
            string[] names = GetPersonName();
            PersonData[0] = names[0];
            PersonData[1] = names[1];
            PersonData[2] = GetPhoneNumber();
        }

        private string[] GetPersonName()
        {
            string[] nameTypes = { "имя", "фамилию" };
            string[] names = new string[2];

            for (int i = 0; i < 2; i++)
            {
                string input;
                string errorMessage;

                do
                {
                    Console.Clear();
                    Console.WriteLine($"Введите ваше {nameTypes[i]}: ");
                    input = Console.ReadLine();

                    names[i] = input.WordValidate(out errorMessage);

                    if (errorMessage != null)
                    {
                        Console.WriteLine(errorMessage);
                        Console.ReadKey();
                    }
                } while (errorMessage != null);
            }

            return names;
        }

        private string GetPhoneNumber()
        {
            string phonenumber;
            string errorMessage;

            do
            {
                Console.Clear();
                Console.WriteLine("Укажите свой номер мобильного телефона: ");
                Console.Write("+79");
                phonenumber = Console.ReadLine();

                errorMessage = null;
                phonenumber = phonenumber.ValidatePhoneNumber(out errorMessage);

                if (errorMessage != null)
                {
                    Console.WriteLine(errorMessage);
                    Console.ReadKey();
                }
            } while (errorMessage != null);

            return $"+79{phonenumber}";
        }
    }
}
