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
            //creating an instance of a confectionery shop     
            var confectionery = new CityCenterConfectionery();

            //order sweets from the city center confectionery shop
            Console.WriteLine(confectionery.MakeCake().Name);
            confectionery.MakeMuffins(7).ForEach((m) => Console.WriteLine(m.Name));
            confectionery.MakeProfiteroles(5).ForEach((p) => Console.WriteLine(p.Name));

        }
    }
}
