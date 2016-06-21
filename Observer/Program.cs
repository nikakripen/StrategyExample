using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject subject = new ConcreteSubject();

            Chart chart = new Chart(subject);
            Notification notification = new Notification(subject);
            subject.SetMeasurements(31.4f);
            subject.SetMeasurements(30);
            subject.SetMeasurements(31.2f);
        }
    }
}
