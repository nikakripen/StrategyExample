using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Chart : IObserver<float>
    {
        private float _data;
        public ConcreteSubject Subject;

        public Chart(ConcreteSubject subject)
        {
            Subject = subject;
            Subject.RegisterObserver(this);
        }

        public void Update(float data)
        {
            _data = data;
            
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Display chart! Last Temperature: {0}", _data);
        }
    }

    class Store : IObserver<float>
    {
        private float _data;
        public ConcreteSubject Subject;

        public Store(ConcreteSubject subject)
        {
            Subject = subject;
            Subject.RegisterObserver(this);
        }

        public void Update(float data)
        {
            _data = data;
            SaveData();
        }

        public void SaveData()
        {
            Console.WriteLine("Save Temperature {0}", _data);
        }

        public List<float> GetDataList()
        {
            return new List<float>();
        } 
    }

    class Notification : IObserver<float>
    {
        private float _data;

        public ConcreteSubject Subject;

        public List<string> Emails { get; set; }

        public Notification(ConcreteSubject subject)
        {
            Subject = subject;
            Subject.RegisterObserver(this);
        }

        public void Update(float data)
        {
            _data = data;
            Notify();
        }

        public void Notify()
        {
            Console.WriteLine("Current conditions: Temperature = {0}", _data);
        }
    }
}

