using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Xml.Linq;

namespace Task3
{
    public class Customers
    {

        public List<string> Linq_9()
        {
            string message = Environment.CurrentDirectory;
            Console.Write(message);

            XDocument doc = XDocument.Load($@"{Environment.CurrentDirectory}\Data\Customers.xml");

            var customers = doc.Elements("customers").Elements("customer")
                           .Select(element => element.Value)
                           .ToList();


            return customers;
    }
    }
}
