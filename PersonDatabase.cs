using System;
using System.Collections.Generic;

namespace FinalTask_7_7
{
    public class PersonDatabase
    {
        private static List<(int Index, string Name, string SecondName, string PhoneNumber)> people
            = new List<(int Index, string Name, string SecondName, string PhoneNumber)>();
        private static int currentIndex = 0;
        public string[][] SelectedUserData { get; private set; }

        public PersonDatabase()
        {
            ManageUsers();
        }

        public PersonDatabase(int index)
        {
            SelectUserByIndex(index);
        }

        private void ManageUsers()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Менеджер пользователей");
                Console.WriteLine("1. Добавить нового пользователя");
                Console.WriteLine("2. Выбрать уже существующего пользователя по индексу");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddNewUser();
                    break;
                }
                else if (choice == "2")
                {
                    if (SelectExistingUser())
                    {
                        break;
                    }
                }
            }
        }

        private void AddNewUser()
        {
            PersonDataCollect personData = new PersonDataCollect();
            string[][] userData = personData.PersonData;
            people.Add((currentIndex, userData[0][1], userData[1][1], userData[2][1]));
            SelectUserByIndex(currentIndex);
            currentIndex++;
        }

        private bool SelectExistingUser()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Введите индекс пользователя или 'q' для возврата в основное меню:");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    return false;
                }

                if (int.TryParse(input, out int index) && index >= 0 && index < people.Count)
                {

                    SelectUserByIndex(index);
                    return true;
                }

                Console.WriteLine("Неверный индекс. Нажмите любую клавишу, чтобы повторить.");
                Console.ReadKey();
            }
        }

        private void SelectUserByIndex(int index)
        {
            (int Index, string Name, string SecondName, string PhoneNumber) user = default;
            foreach (var person in people)
            {
                if (person.Index == index)
                {
                    user = person;
                    break;
                }
            }
            if (user != default)
            {
                SelectedUserData = new string[][]
                {
                    new string[] { "PersonIndex", user.Index.ToString() },
                    new string[] { "PersonName", user.Name },
                    new string[] { "PresonSecondName", user.SecondName },
                    new string[] { "PersonPhoneNumber", user.PhoneNumber }

                };


            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Пользователь с индексом {index} не найден.");
                Console.ReadLine();
                SelectedUserData = null;
            }
        }
    }
}
