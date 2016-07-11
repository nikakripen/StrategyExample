using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class TVOnCommand : ICommand
    {
        private TV _tv;

        public TVOnCommand(TV tvSet)
        {
            _tv = tvSet;
        }
        public void Execute()
        {
            _tv.On();
        }
        public void Undo()
        {
            _tv.Off();
        }
    }

    class MicrowaveCommand : ICommand
    {
        private Microwave _microwave;
        private int _time;
        public MicrowaveCommand(Microwave m, int t)
        {
            _microwave = m;
            _time = t;
        }
        public void Execute()
        {
            _microwave.StartCooking(_time);
            _microwave.StopCooking();
        }

        public void Undo()
        {
            _microwave.StopCooking();
        }
    }

    class NoCommand : ICommand
    {
        public void Execute()
        {
        }
        public void Undo()
        {
        }
    }

    class MacroCommand : ICommand
    {
        private List<ICommand> _commands;
        public MacroCommand(List<ICommand> coms)
        {
            _commands = coms;
        }
        public void Execute()
        {
            foreach (ICommand c in _commands)
                c.Execute();
        }

        public void Undo()
        {
            foreach (ICommand c in _commands)
                c.Undo();
        }
    }
}
