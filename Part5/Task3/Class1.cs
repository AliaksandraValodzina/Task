using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace Task3
{
    public class Customers
    {

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
                          where Double.Parse((string)t) > x
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

        // 7. Average Turnover In Towns
        public IDictionary<string, double> Linq0007_2()
        {

            var rez = Doc.Element("customers").Elements("customer")
                       .GroupBy(x => x.Element("city").Value)
                       .Select(l => new
                       {
                           Name = l.Key,
                           Value = l.Average(c => c.Element("orders").Elements("order").Count())
                       }).ToDictionary(o => o.Name, o => Math.Round(o.Value, 2));

            return rez;
        }

        // 7. Average orders count
        public IDictionary<string, double> Linq0007_1()
        {

            var rez = (from f in Doc.Element("customers").Elements("customer")
                       from k in f.Elements("orders").Elements("order")
                       group k.Element("total").Value by f.Element("city").Value into g
                       select new
                       {
                           Name = g.Key,
                           Value = g.ToList().Average(x => double.Parse(x))
                       }).ToDictionary(o => o.Name, o => Math.Round(o.Value, 2));

            return rez;
            }

        // 8. Month
        public IDictionary<int, double> Linq0008_Month()
        {

            var rez = (from f in Doc.Element("customers").Elements("customer")
                       from k in f.Elements("orders").Elements("order")
                       let month = DateTime.ParseExact((string)k.Element("orderdate").Value, "yyyy-M-dTH:mm:ss", CultureInfo.InvariantCulture).Month
                       orderby month
                       group k.Element("total").Value by month into g
                       select new
                       {
                           Name = g.Key,
                           Value = g.Sum(x => double.Parse(x))
        }).ToDictionary(o => o.Name, o => Math.Round(o.Value, 2));

            return rez;
        }

        // 8. Year
        public IDictionary<int, double> Linq0008_Year()
        {

            var rez = (from f in Doc.Element("customers").Elements("customer")
                       from k in f.Elements("orders").Elements("order")
                       let year = DateTime.ParseExact((string)k.Element("orderdate").Value, "yyyy-M-dTH:mm:ss", CultureInfo.InvariantCulture).Year
                       orderby year
                       group k.Element("total").Value by year into g
                       select new
                       {
                           Name = g.Key,
                           Value = g.Sum(x => double.Parse(x))
                       }).ToDictionary(o => o.Name, o => Math.Round(o.Value, 2));

            return rez;
        }

        // 8. Year, month
        public IDictionary<string, double> Linq0008_YearMonth()
        {

            var rez = (from f in Doc.Element("customers").Elements("customer")
                       from k in f.Elements("orders").Elements("order")
                       let year = DateTime.ParseExact((string)k.Element("orderdate").Value, "yyyy-M-dTH:mm:ss", CultureInfo.InvariantCulture).Year
                       let month = DateTime.ParseExact((string)k.Element("orderdate").Value, "yyyy-M-dTH:mm:ss", CultureInfo.InvariantCulture).Month
                       let monthYear = year.ToString() + "-" + month.ToString()
                       orderby year
                       group k.Element("total").Value by monthYear into g
                       select new
                       {
                           Name = g.Key,
                           Value = g.Sum(x => double.Parse(x))
                       }).ToDictionary(o => o.Name, o => Math.Round(o.Value, 2));

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

        [TestMethod]
        public void Test_7_1()
        {
            Customers customer = new Customers();
            var customerList = customer.Linq0007_1();
            Assert.IsTrue(customerList["London"].Equals(1148.37));
        }

        [TestMethod]
        public void Test_7_2()
        {
            Customers customer = new Customers();
            var customerList = customer.Linq0007_2();
            Assert.IsTrue(customerList["London"].Equals(7.67));
        }

        [TestMethod]
        public void Test_8_1()
        {
            Customers customer = new Customers();
            var customerList = customer.Linq0008_Month();
            Assert.IsTrue(customerList[1].Equals(155480.19));
        }

        [TestMethod]
        public void Test_8_2()
        {
            Customers customer = new Customers();
            var customerList = customer.Linq0008_Year();
            Assert.IsTrue(customerList[1996].Equals(208083.97));
        }

        [TestMethod]
        public void Test_8_3()
        {
            Customers customer = new Customers();
            var customerList = customer.Linq0008_YearMonth();
            Assert.IsTrue(customerList["1996-9"].Equals(26381.4));
        }
    }
}
