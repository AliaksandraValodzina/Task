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
                decimal x = 10000.0m;
                decimal sum = 0.0m;

                var customer =
                from p in dataSource.Customers
                select p;


                foreach (var p in customer)
                {
                    sum += p.Orders[2].Total;
                    if (sum >= x)
                    {
                        ObjectDumper.Write(sum);
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        public void Linq0002()
        {
            try
            {
                var customer =
                from c in dataSource.Customers
                select c;

                var supplies =
                from s in dataSource.Suppliers
                select s;


                foreach (var c in customer)
                {
                    string output = $"Customer: {c.CustomerID} from {c.Country} {c.City}";
                    ObjectDumper.Write(output);
                    foreach (var s in supplies)
                    {
                        if (c.Country == s.Country && c.City == s.City)
                        {
                            output = $"Supplies: {s.SupplierName} from {s.Country} {s.City}";
                            ObjectDumper.Write(output);
                        }
                    }
                    ObjectDumper.Write("\r\n");
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        public void Linq0003()
        {
            try
            {
                decimal x = 1000.0m;

                var customer =
                from p in dataSource.Customers
                select p;


                foreach (var p in customer)
                {
                    decimal order = p.Orders[2].Total;
                    if (order >= x)
                    {
                        string output = $"Customer: {p.CustomerID} has order {order}";
                        ObjectDumper.Write(output);
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        public void Linq0004()
        {
            try
            {
                var clientsId =
                from p in dataSource.Customers
                select p.CustomerID;

                DateTime firstData = DateTime.Now;
                foreach (var p in dataSource.Customers)
                {
                    DateTime data = p.Orders[1].OrderDate;
                    if (data < firstData)
                    {
                        firstData = data;
                    }

                }

                /*var clients =
                from p in dataSource.Customers
                where p.Orders[1].OrderDate = firstData
                select p;*/

                foreach (var p in clientsId)
                {
                    ObjectDumper.Write(p);
                }
            }
            catch (Exception)
            {

            }
        }

    }
}
