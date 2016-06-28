using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbuzz_Decorator
{
    public class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage) : base(beverage)
        {
            
        }
        
        public override string Description
        {
            get
            {
                return Beverage.Description + ", Mocha";
            }
        }

        public override double cost()
        {
            return 0.20 + Beverage.cost();
        }
    }

    public class Soy : CondimentDecorator
    {
        public Soy(Beverage beverage) : base(beverage)
        {
            
        }

        public override string Description
        {
            get
            {
                return Beverage.Description + ", Soy";
            }
        }

        public override double cost()
        {
            return 0.15 + Beverage.cost();
        }
    }

    public class Whip : CondimentDecorator
    {
        public Whip(Beverage beverage) :  base(beverage)
        {
            
        }

        public override string Description
        {
            get
            {
                return Beverage.Description + ", Whip";
            }
        }

        public override double cost()
        {
            return 0.10 + Beverage.cost();
        }
    }
}
