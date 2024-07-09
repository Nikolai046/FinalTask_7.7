using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask_7_7
{
    public class GetDeliveryTime
    {
        public DateTime Result { get; private set; }

        public GetDeliveryTime()
        {
            SelectDeliveryTime();
        }

        private void SelectDeliveryTime()
        {
            DateTime currentDate = DateTime.Now;
            DateTime maxDate = currentDate.AddMonths(1);

            int year = SelectValue("год", currentDate.Year, maxDate.Year);
            int month = SelectValue("месяц",
                year == currentDate.Year ? currentDate.Month : 1,
                year == maxDate.Year ? maxDate.Month : 12);
            int day = SelectValue("день",
                (year == currentDate.Year && month == currentDate.Month) ? currentDate.Day : 1,
                DateTime.DaysInMonth(year, month));

            int hour = SelectValue("час", 0, 23);
            int minute = SelectValue("минуту", 0, 50, 10); // шаг в 10 минут

            Result = new DateTime(year, month, day, hour, minute, 0);
           
            Console.Clear();
            Console.WriteLine($"Выбранное время доставки: {Result}");
            Console.ReadLine();
        }

        private int SelectValue(string valueName, int min, int max, int step = 1)
        {
            int currentValue = min;
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                Console.WriteLine($"Выберите {valueName} (используйте стрелки вверх/вниз, Enter для подтверждения):");
                Console.WriteLine(currentValue);

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    currentValue = (currentValue + step <= max) ? currentValue + step : min;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    currentValue = (currentValue - step >= min) ? currentValue - step : max;
                }

            } while (keyInfo.Key != ConsoleKey.Enter);

            return currentValue;
        }
    }
}
