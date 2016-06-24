using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbuzz_Decorator
{
    public abstract class Beverage
    {
        private string _description = "Unknown Beverage";

        public virtual string Description
        {
            get
            {
                return _description;
            }
            protected set
            {
                _description = value;
            }
        }

        public abstract double cost();
    }

    public abstract class CondimentDecorator : Beverage
    {
        protected Beverage Beverage;
        //public string Description { get; }
    }
}
