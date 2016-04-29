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
        public List<DateTime> Linq0004()
        {

            /*var query = dataSource.Customers
                    .Select(grp => new
                    {
                        ID = grp.CustomerID,
                        MinDate = grp.Orders.Min(t => t.OrderDate)
                    });*/

            /*let dataStr = c.Element("orders").Elements("order").Elements("total").Min()
                     let data = Convert.ToDateTime(dataStr)
                     group c by (string)c.Element("id") into g
                     */


            /*var customers = (from c in Doc.Element("customers").Elements("customer")
                             group (string)c.Element("id").Value by Convert.ToDateTime(c.Element("orderdate").Value)
                             ).ToDictionary(o => o.Key, o => o.ToList());*/

            var customers = (from c in Doc.Element("customers").Elements("customer").Elements("orders").Elements("order")
                             select Convert.ToDateTime(c.Elements("orderdate").Min())).ToList();



            return customers;
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
    }

    //????
    /*public void Linq0003()
    {
        try
        {
            decimal x = 0.0m;

            var orders = from o in dataSource.Customers
                         select o.Orders.Where(p => p.Total > x);


            var customer =
            from c in dataSource.Customers
            where c.Orders.Contains(x => orders.Contains(x))
            select c.CustomerID;

            foreach (var c in customer)
            {
                ObjectDumper.Write(c);
            }
        }
        catch (IndexOutOfRangeException)
        {

        }
    }*/

    /*public void Linq0004()
    {

        DateTime data = DateTime.Now;
        try
        {

            var query = dataSource.Customers
                .Select(grp => new
                {
                    ID = grp.CustomerID,
                    MinDate = grp.Orders.Min(t => t.OrderDate)
                });

            foreach (var c in query)
            {
                ObjectDumper.Write(c);
            }

        }
        catch (Exception)
        {

        }
    }

    public void Linq0005()
    {

        DateTime data = DateTime.Now;
        try
        {


            var latest = (from d in dataSource.Customers
                          select new
                          {
                              d.CustomerID,
                              d.Orders,
                              d.Orders
                          }).First();

            /*var query = dataSource.Customers
                .Select(grp => new
                {
                    ID = grp.CustomerID,
                    Date = grp.Orders.GetValue
                    // Date = grp.Orders.GetValue(x => x.OrderDate)
                    //.GroupBy(t => t.OrderDate.Year)
                });

            foreach (var c in query)
            {
                ObjectDumper.Write(c);
            }

        }
        catch (Exception)
        {

        }
    }

}*/

    /*public IDictionary<string, double> Linq_8()
        {
            XDocument doc = XDocument.Load($@"{Environment.CurrentDirectory}\Data\Customers.xml");

            // Вывод суммы!!! 

            var rez = (from c in doc.Descendants("customer")
                       group c by (string)c.Element("city") into g
                       select new
                       {
                           city = g.Key,
                           total = g.Elements("total").Sum(el => (double)el)
                       }).ToDictionary(o => o.city, o => o.total);

            return rez;
        }*/
}
