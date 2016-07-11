using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Starbuzz_Decorator
{
    public abstract class Tea
    {
        public string Sort;
        public string Brand;
        public int Quality;
        public override string ToString()
        {
            return Brand + " " + Sort + " " + (Quality > 10 ? "hight" : Quality > 5 ? "medium" : "low") + " quality";
        }
    }

    public class EarlGreyTea : Tea
    {
        public EarlGreyTea()
        {
            Brand = "Lipton";
            Sort = "Earl Grey";
            Quality = 6;
        }
    }

    public class TeaAdapter : Beverage
    {
        private Tea _tea;
        public TeaAdapter(Tea tea)
        {
            _tea = tea;
            Description = _tea.ToString();
        }

        public override double cost()
        {
            return _tea.Quality > 10 ? 0.9 : _tea.Quality < 5 ? 0.7 : 0.5;
        }
    }
}
