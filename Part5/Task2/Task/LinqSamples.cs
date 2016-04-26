// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using SampleSupport;
using Task.Data;

// Version Mad01

namespace SampleQueries
{
	[Title("LINQ Module")]
	[Prefix("Linq")]
	public class LinqSamples : SampleHarness
	{

		private DataSource dataSource = new DataSource();

		[Category("Restriction Operators")]
		[Title("Where - Task 1")]
		[Description("This sample uses the where clause to find all elements of an array with a value less than 5.")]
		public void Linq1()
		{
			int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

			var lowNums =
				from num in numbers
				where num < 5
				select num;

			Console.WriteLine("Numbers < 5:");
			foreach (var x in lowNums)
			{
				Console.WriteLine(x);
			}
		}

		[Category("Restriction Operators")]
		[Title("Where - Task 2")]
		[Description("This sample return return all presented in market products")]

		public void Linq2()
		{
			var products =
				from p in dataSource.Products
				where p.UnitsInStock > 0
				select p;

			foreach (var p in products)
			{
				ObjectDumper.Write(p);
			}
		}

        public void Linq0001()
        {
            try
            {
                decimal x = 1000000.0m;

                var customer =
                dataSource.Customers.
                Where(c => c.Orders.Sum(o => o.Total) > x)
                .ToList();


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

        /*public void Linq0001_DELETE()
        {
            try
            {
                decimal x = 1000000.0m;
                decimal sum = 0.0m;

                var customer =
                from p in dataSource.Customers
                select p;


                foreach (var p in customer)
                {
                    for (int i = 0; i < p.Orders.Length; i++)
                    {
                        sum += p.Orders[i].Total;
                    }
                    if (sum >= x)
                    {
                        string output = $"Customer: {p.CustomerID} orders summ {sum}";
                        ObjectDumper.Write(output);
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }*/

        public void Linq0002()
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

        public void Linq0004()
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
                    });*/

                foreach (var c in query)
                {
                    ObjectDumper.Write(c);
                }

            }
            catch (Exception)
            {

            }
        }

    }
}
