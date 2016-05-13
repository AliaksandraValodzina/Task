using System;
using System.Linq;

namespace CommandPattern
{
    class MainClass
    {
        static void Main(string[] args)
        {
            CommandController commandChoose = new CommandController();
            commandChoose.Choose();

            // Wait for user
            Console.ReadKey();
        }
    }
}
        

        
