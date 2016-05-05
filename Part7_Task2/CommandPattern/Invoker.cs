namespace CommandPattern
{
    public class Invoker
    {
        Command command;

        public void SetCommand(Command command) 
        {
            this.command = command;
        }

        public void Run()
        {
            command.Execute();
        }
    }
}
