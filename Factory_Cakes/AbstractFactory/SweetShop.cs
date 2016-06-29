using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    abstract class SweetShop
    {
        public Set OrderSet(string type)
        {
            var set = CreateSet(type);

            set.Prepare();

            return set;
        }

        protected abstract Set CreateSet(string type);
    }

    class OnlineSweetShop : SweetShop
    {
        protected override Set CreateSet(string type)
        {
            IConfectionery confectionery = new CityCenterConfectionery();

            switch (type)
            {
                case "small tea set":
                    return new SmallTeaSet(confectionery) {Name = "Small Tea Set From City Center Bakery"};
                case "big birthday set":
                    return new BigBirhtdaySet(confectionery) {Name = "Big Birthday Set City Center Bakery" };
                default:
                    return null;
            }
        }
    }

    class ViktoriaSweetShop : SweetShop
    {
        protected override Set CreateSet(string type)
        {
            IConfectionery confectionery = new CityCenterConfectionery();

            switch (type)
            {
                case "small tea set":
                    return new SmallTeaSet(confectionery) { Name = "Small Tea Set From New Bakery" };
                case "big dbirthday set":
                    return new BigBirhtdaySet(confectionery) { Name = "Big Birthday Set New Bakery" };
                default:
                    return null;
            }
        }
    }

    abstract class Set
    {
        protected IConfectionery Confectionery;
        public string Name { get; set; }
        protected List<Muffin> Muffins { get;  set; }
        protected List<Profiterole> Profiteroles { get; set; }
        protected Cake Cake { get; set; }

        protected Set(IConfectionery confectionery)
        {
            Confectionery = confectionery;
        }

        public abstract void Prepare();

        public override string ToString()
        {
            return $"\n------ {Name} ------\nwhith {Cake?.GetType().Name} \n{Muffins?.Count} {Muffins?[0]?.GetType().Name}\n{Profiteroles?.Count} {Profiteroles?[0]?.GetType().Name}";
        }
    }

    class SmallTeaSet : Set
    {
        public SmallTeaSet(IConfectionery confectionery) : base(confectionery)
        {
            
        }
        
        public override void Prepare()
        {
            Console.WriteLine("Preparing " + Name);
            Muffins = Confectionery.MakeMuffins(5);
            Profiteroles = Confectionery.MakeProfiteroles(5);
        }

    }
    class BigBirhtdaySet : Set
    {
        public BigBirhtdaySet(IConfectionery confectionery) : base(confectionery)
        {

        }

        public override void Prepare()
        {
            Console.WriteLine("Preparing " + Name);
            Muffins = Confectionery.MakeMuffins(10);
            Profiteroles = Confectionery.MakeProfiteroles(10);
            Cake = Confectionery.MakeCake();
        }

    }

}
