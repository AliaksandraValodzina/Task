using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Task3
{
    public class Customers
    {

        public IDictionary<string, double> Linq_9()
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
    }

        public void Linq0001()
        {
            XDocument doc = XDocument.Load($@"{Environment.CurrentDirectory}\Data\Customers.xml");

            try
            {
                decimal x = 1000000.0m;

                var customer = (from c in doc.Descendants("customer")
                                let sum = (decimal)c.Elements("total").Sum(o => (decimal)o)
                                where sum > x
                                select c).ToList();


                foreach (var p in customer)
                {
                    string output = $"Customer: {p.CustomerID} orders summ {p}";
                    ObjectDumper.Write(output);
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        /*public void Linq0002()
        {
            try
            {
                var customerAndSupplies =
                from c in dataSource.Customers
                from s in dataSource.Suppliers
                where c.Country == s.Country
                where c.City == s.City
                group s.SupplierName by c.CustomerID;

                foreach (var p in customerAndSupplies)
                {
                    string output = $"p.Key";
                    ObjectDumper.Write(output);

                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }*/

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
}
}
