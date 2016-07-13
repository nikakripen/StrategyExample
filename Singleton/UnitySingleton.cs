using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Singleton
{
    class NewSingleton
    {
        [Dependency]
        public Random Random { get; set; }
    }
}
