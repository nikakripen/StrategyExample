using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class ConcreteSubject : ISubject<float>
    {
        private List<IObserver<float>> _observers;
        float _data;

        public ConcreteSubject()
        {
            _observers = new List<IObserver<float>>();
        }

        public void RegisterObserver(IObserver<float> observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver<float> observer)
        {
            int i = _observers.IndexOf(observer);
            if (i >= 0)
            {
                _observers.Remove(observer);
            }
        }

        public void NotifyObservers()
        {
            foreach (IObserver<float> observer in _observers)
            {
                observer.Update(_data);
            }
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements(float data)
        {
            this._data = data;
            MeasurementsChanged();
        }
    }
}
