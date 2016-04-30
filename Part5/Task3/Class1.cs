using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task3
{
    public class Customers
    {

        //private string path = $@"{Environment.CurrentDirectory}\Data\Customers.xml";
        XDocument Doc;

        public Customers() {
            Doc = XDocument.Load($@"{Environment.CurrentDirectory}\Data\Customers.xml");
        }

        // 1.
        public List<string> Linq0001(double x)
        {
            var customers = (from c in Doc.Descendants("customer")
                            group c by (string)c.Element("customer") into g
                            from s in g
                            let sum = (double)s.Elements("orders").Elements("order").Elements("total").Sum(n => double.Parse(n.Value))
                            where sum > x
                            select (string)s.Element("id")).ToList();

            /*var sum = (from c in doc.Descendants("customer")
                       group c by (string)c.Element("customer") into g
                       from s in g
                       let tSum = (double)s.Elements("orders").Elements("order").Elements("total").Sum(n => double.Parse(n.Value))
                       where tSum > x
                       select tSum).ToList();*/

            return customers;
        }

        // 2.
        public IDictionary<string, List<string>> Linq0002()
        {
            var customers = (from c in Doc.Element("customers").Elements("customer")
                             group c.Element("id").Value by c.Element("country").Value
                             ).ToDictionary(o => o.Key, o => o.ToList());

            return customers;
        }

        // 3.
        public List<string> Linq0003(double x)
        {
            var orders = (from o in Doc.Element("customers").Elements("customer")
                          let total = o.Element("orders").Elements("order").Elements("total").ToList()
                          from t in total
                          where  Double.Parse((string)t) > x
                          select (string)o.Element("id")).Distinct().ToList();

            return orders;
        }

        // 4.
        public IDictionary<string, DateTime> Linq0004()
        {
            var customers = (from c in Doc.Descendants("customer")
                             let elements = c.Element("orders").Elements("order").ToList()
                             where elements.Count > 0
                             let data = elements.Min(order => DateTime.Parse(order.Element("orderdate").Value))
                             select new
                             {
                                 Name = c.Element("name").Value,
                                 Value = data
                             }).ToDictionary(o => o.Name, o => o.Value);

            return customers;
        }

        // 5.
        public Dictionary<string, DateTime> Linq0005()
        {

            var customers = (from c in Doc.Descendants("customer")
                             let elements = c.Element("orders").Elements("order").ToList()
                             where elements.Count > 0
                             let data = elements.Min(order => DateTime.Parse(order.Element("orderdate").Value))
                             let sum = elements.Sum(order => double.Parse(order.Element("total").Value))
                             orderby data, sum, c.Element("name")
                             select new
                             {
                                 Name = c.Element("name").Value,
                                 Value = data
                             }).ToDictionary(o => o.Name, o => o.Value);

            return customers;
        }

        // 6.
        public List<string> Linq0006()
        {
            int i;

            var customers = (from c in Doc.Descendants("customer")
                             let region = (string)c.Element("region") ?? String.Empty
                             where String.IsNullOrEmpty(region)
                    || !c.Element("phone").Value.Contains('(')
                    || !c.Element("phone").Value.Contains(')')
                    || Int32.TryParse(c.Element("postalcode").Value, out i)
                             select c.Element("name").Value).ToList();

            return customers;
        }

        public IDictionary<string, List<double>> Linq0007()
        {

            var rez = (from c in Doc.Element("customers").Elements("customer")
                       //let total = c.Elements("total").ToList()
                       //let sum = total.Sum(e => Double.Parse((string)e))
                       group c.Elements("total").Sum(e => Double.Parse((string)e)) by c.Element("city").Value
                       //).ToDictionary(o => o.Key, o => o.ToList().Sum(e => Double.Parse((string)e)));
                       ).ToDictionary(o => o.Key, o => o.ToList());

            return rez;
        }
    }

    [TestClass]
public class Test
{
    [TestMethod]
    public void Test_1()
    {
        Customers customer = new Customers();
        List<string> customerList = customer.Linq0001(1000.0);
        string customerZero = customerList.ElementAt(0);
        Assert.AreEqual(customerZero.Equals("ALFKI"), true);
    }

        [TestMethod]
        public void Test_2()
        {
            Customers customer = new Customers();
            IDictionary<string, List<string>> customerList = customer.Linq0002();
            List<string> germanyCustomers = customerList["Germany"];
            Assert.IsTrue(germanyCustomers.Contains("ALFKI"));
        }

        [TestMethod]
        public void Test_3()
        {
            Customers customer = new Customers();
            List<string> customerList = customer.Linq0003(5000.0);
            Assert.IsTrue(customerList.Contains("BLONP"));
        }

        [TestMethod]
        public void Test_4()
        {
            Customers customer = new Customers();
            var customerList = customer.Linq0004();
            DateTime data = new DateTime(1997, 8, 25, 0, 0, 0);
            Assert.IsTrue(customerList["Alfreds Futterkiste"].Equals(data));
        }

        [TestMethod]
        public void Test_5()
        {
            Customers customer = new Customers();
            var customerList = customer.Linq0005();
            DateTime data = new DateTime(1996, 7, 4, 0, 0, 0);
            Assert.IsTrue(customerList["Wilman Kala"].Equals(data));
        }

        [TestMethod]
        public void Test_6()
        {
            Customers customer = new Customers();
            var customerList = customer.Linq0006();
            Assert.IsTrue(customerList.Contains("Alfreds Futterkiste"));
        }
    }
}
