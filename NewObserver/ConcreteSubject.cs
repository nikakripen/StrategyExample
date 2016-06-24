using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewObserver
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
            {
                _observers.Add(observer);
            }
            return new Unsubscriber(this, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<float>> _observers;
            private IObserver<float> _observer;

            public Unsubscriber(ConcreteSubject subjest, IObserver<float> observer)
            {
                this._observers = subjest._observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        //public void RemoveObserver(IObserver<float> observer)
        //{
        //    int i = _observers.IndexOf(observer);
        //    if (i >= 0)
        //    {
        //        _observers.Remove(observer);
        //    }
        //}

        public void NotifyObservers()
        {
            foreach (IObserver<float> observer in _observers)
            {
                if (_data < 0)
                    observer.OnError(new Exception("Temperature sensor crashed! Temperature is " + _data));
                else
                    observer.OnNext(_data);
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
