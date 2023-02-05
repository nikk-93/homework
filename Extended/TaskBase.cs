namespace Command
{
    public abstract class TaskBase : ICommand
    {
        public abstract void Execute();

        public abstract string GetName();
    }
}