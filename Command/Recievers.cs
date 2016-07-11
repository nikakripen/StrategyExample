using System;

namespace Command
{
    class TV
    {
        public void On()
        {
            Console.WriteLine("��������� �������!");
        }

        public void Off()
        {
            Console.WriteLine("��������� ��������...");
        }
    }

    class Microwave
    {
        public void StartCooking(int time)
        {
            Console.WriteLine("����������� ���");
        }

        public void StopCooking()
        {
            Console.WriteLine("��� ���������!");
        }
    }
}