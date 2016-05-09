using System;
using System.Linq;

namespace CommandPattern
{
    class MainClass
    {
        static void Main(string[] args)
        {
            ChooseCommand commandChoose = new ChooseCommand();
            commandChoose.Choose();

            // Wait for user
            Console.ReadKey();
        }
    }
}
        

        
