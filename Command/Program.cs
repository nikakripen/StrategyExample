using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Pult pult = new Pult();
            TV tv = new TV();
            pult.SetCommand(new TVOnCommand(tv));
            pult.PressButton();
            pult.PressUndo();

            Microwave microwave = new Microwave();
            pult.SetCommand(new MicrowaveCommand(microwave, 5000));
            pult.PressButton();

            MacroCommand macro = new MacroCommand(new List<ICommand>() { new TVOnCommand(tv), new MicrowaveCommand(microwave, 5000) });
            pult.SetCommand(macro);
            pult.PressButton();
        }
    }
}
