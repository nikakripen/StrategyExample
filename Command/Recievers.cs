using System;

namespace Command
{
    class TV
    {
        public void On()
        {
            Console.WriteLine("Телевизор включен!");
        }

        public void Off()
        {
            Console.WriteLine("Телевизор выключен...");
        }
    }

    class Microwave
    {
        public void StartCooking(int time)
        {
            Console.WriteLine("Подогреваем еду");
        }

        public void StopCooking()
        {
            Console.WriteLine("Еда подогрета!");
        }
    }
}