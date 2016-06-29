using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    abstract class Muffin
    {
        public string Name { get; protected set; }
    }

    abstract class Cake
    {
        public string Name { get; protected set; }
    }

    abstract class Profiterole
    {
        public string Name { get; protected set; }
    }

    class PragueCake : Cake
    {
        public PragueCake(string name)
        {
            Name = name;
        }
    }
    class Cheesecake : Cake
    {
        public Cheesecake(string name)
        {
            Name = name;
        }
    }
    class ChocolateProfiterole : Profiterole
    {
        public ChocolateProfiterole(string name)
        {
            Name = name;
        }
    }
    class RaspberryProfiterole : Profiterole
    {
        public RaspberryProfiterole(string name)
        {
            Name = name;
        }
    }
    class FrenchMuffin : Muffin
    {
        public FrenchMuffin(string name)
        {
            Name = name;
        }
    }
    class StrawberryMuffin : Muffin
    {
        public StrawberryMuffin(string name)
        {
            Name = name;
        }
    }

}
