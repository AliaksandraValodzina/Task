using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            ItemChooser item = new ItemChooser();

            //Choose a pizza
            item.ChoosePizza();

            //Choose a components
            //item.ChooseComponent();

            // One more components
            //item.NextComponent();

            // One more pizza
            ///item.NextPizza();

            // Check a sale
            item.CheckPrise();

            // Print and wait for user
            Console.WriteLine($"Sum = {item.Sum}");
            Console.ReadKey();
        }
    }
}
