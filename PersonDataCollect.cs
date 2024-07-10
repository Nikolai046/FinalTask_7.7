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
    public class PersonDatabase
    {
        private List<(int Index, string[] PersonData)> people;
        private int currentIndex;
        public string[] SelectedUserData { get; private set; }

        public PersonDatabase()
        {
            people = new List<(int Index, string[] PersonData)>();
            currentIndex = 0;
        }

        public PersonDatabase(int index)
        {
            people = new List<(int Index, string[] PersonData)>();
            currentIndex = 0;
            ManageUsers();
            SelectUserByIndex(index);
        }

        public int ManageUsers()
        {
            //while (true)
            //{
                Console.Clear();
                Console.WriteLine("Менеджер пользователей");
                Console.WriteLine("1. Добавить нового пользователя");
                Console.WriteLine("2. Выбрать уже существующего пользователя по индексу");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddNewUser();
                }
                else if (choice == "2")
                {
                    int selectedIndex = SelectExistingUser();
                    if (selectedIndex != -1)
                    {
                        SelectUserByIndex(selectedIndex);
                        return selectedIndex;
                    }
                   
                }
            return -1;
            //}
        }

        private void AddNewUser()
        {
            PersonDataCollect personData = new PersonDataCollect();
            people.Add((currentIndex, personData.PersonData));
            Console.WriteLine($"Пользователь добавлен с индексом {currentIndex}");
            currentIndex++;
            Console.ReadKey();
        }

        private int SelectExistingUser()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите индекс пользователя или 'q' для возврата в основное меню:");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    return -1;
                }

                if (int.TryParse(input, out int index) && index >= 0 && index < people.Count)
                {
                    return index;
                }

                Console.WriteLine("Неверный индекс. Нажмите любую клавишу, чтобы повторить.");
                Console.ReadKey();
            }
        }

        private void SelectUserByIndex(int index)
        {
            var user = people.Find(p => p.Index == index);
            if (user != default)
            {
                SelectedUserData = user.PersonData;
            }
            else
            {
                Console.WriteLine($"Пользователь с индексом {index} не найден.");
                SelectedUserData = null;
            }
        }
    }
}
