using System;

namespace FinalTask_7_7
{
    public class GetFreeCourier
    {
        private readonly string[] CourierDatabase = new string[]
        {
        "Иванов Иван Иванович",
        "Петров Петр Петрович",
        "Сидоров Сидор Сидорович",
        "Козлов Козьма Козьмич",
        "Николаев Николай Николаевич",
        "Александров Александр Александрович",
        "Михайлов Михаил Михайлович",
        "Андреев Андрей Андреевич",
        "Сергеев Сергей Сергеевич",
        "Васильев Василий Васильевич"
        };

        public string CourierName { get; }
        public string CostOfDelivery { get; }

        public GetFreeCourier()
        {
            Random random = new Random();
            int index = random.Next(0, CourierDatabase.Length);
            CourierName = CourierDatabase[index];
            CostOfDelivery = $"{new Random().Next(50, 101) * 10:000.00}";
        }
    }
}
