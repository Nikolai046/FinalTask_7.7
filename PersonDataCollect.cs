using FinalTask_7_77;
using System;

namespace FinalTask_7_7
{
    public class PersonDataCollect
    {
        public string[][] PersonData { get; private set; }
        private string[] personName;

        public PersonDataCollect()
        {
            personName = GetPersonName();
            PersonData = new string[3][];
            PersonData[0] = new string[] { "PersonName", personName[0] };
            PersonData[1] = new string[] { "PresonSecondName", personName[1] };
            PersonData[2] = new string[] { "PersonPhoneNumber", GetPhoneNumber() };
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
                    Console.WriteLine($"Введите {nameTypes[i]}: ");
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