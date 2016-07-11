namespace Command
{
    // Invoker - инициатор
    class Pult
    {
        private ICommand _command;

        public Pult()
        {
            _command = new NoCommand();
        }

        public void SetCommand(ICommand com)
        {
            _command = com;
        }

        public void PressButton()
        {
            _command.Execute();
        }
        public void PressUndo()
        {
            _command.Undo();
        }
    }
}