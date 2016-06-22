using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class ConcreteSubject : IObservable<float>
    {
        private List<IObserver<float>> _observers;
        float _data;

        public ConcreteSubject()
        {
            _observers = new List<IObserver<float>>();
        }

        public IDisposable Subscribe(IObserver<float> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<float>> _observers;
            private IObserver<float> _observer;

            public Unsubscriber(List<IObserver<float>> observers, IObserver<float> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
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
