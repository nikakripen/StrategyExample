using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewObserver
{
    class Chart : IObserver<float>
    {
        private float _data;
        private IDisposable _unsubscriber;

        public virtual void OnCompleted()
        {
            Console.WriteLine("The Temperature Tracker has completed transmitting data");
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        public virtual void OnNext(float value)
        {
            _data = value;
            Display();
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }

        public Chart(IObservable<float> subject)
        {
            if (subject != null)
                _unsubscriber = subject.Subscribe(this);
        }

        public void Display()
        {
            Console.WriteLine("Display chart! Last Temperature: {0}", _data);
        }
    }

    class Store : IObserver<float>
    {
        private float _data;
        private IDisposable _unsubscriber;

        public virtual void OnCompleted()
        {
            Console.WriteLine("The Temperature Tracker has completed transmitting data");
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        public virtual void OnNext(float value)
        {
            _data = value;
            SaveData();
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }

        public Store(ConcreteSubject subject)
        {
            if (subject != null)
                _unsubscriber = subject.Subscribe(this);
        }

        public void SaveData()
        {
            Console.WriteLine("Save Temperature {0}", _data);
        }
    }

    class Notification : IObserver<float>
    {
        private float _data;
        private IDisposable _unsubscriber;

        public virtual void OnCompleted()
        {
            Console.WriteLine("The Temperature Tracker has completed transmitting data");
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        public virtual void OnNext(float value)
        {
            _data = value;
            Notify();
        }

        public virtual void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }

        public Notification(ConcreteSubject subject)
        {
            if (subject != null)
                _unsubscriber = subject.Subscribe(this);
        }

        public void Notify()
        {
            Console.WriteLine("Current conditions: Temperature = {0}", _data);
        }
    }
}

