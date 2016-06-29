using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            SweetShop onlineShop = new OnlineSweetShop();
            SweetShop victoriaShop = new ViktoriaSweetShop();

            Set set1 = onlineShop.OrderSet("big birthday set");
            Console.WriteLine(set1.ToString());
            Set set2 = victoriaShop.OrderSet("small tea set");
            Console.WriteLine(set2.ToString());

        }
    }
}
