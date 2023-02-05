namespace Command
{
    public class Invoker
    {
        private ICommand? _onCommand;

        public void SetCommand(ICommand command)
        {
            _onCommand = command;
        }

        public void Start()
        {
            if (_onCommand is ICommand)
                _onCommand.Execute();
        }
    }
}