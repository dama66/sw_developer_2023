using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrakteDatentypen
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var employeeList = new Employee[]
            {
                new Developer("Max Mustermann", new DateTime(1980, 5, 10), 1800.00m),
                new Developer("Hans Worst", new DateTime(2003, 5, 10), 1800.00m),
            };

            startCalculation(employeeList);


        }

        private static void startCalculation(Employee[] employeeList)
        {
            foreach (var ma in employeeList)
            {
                ma.ShowInfo();
                Console.WriteLine($"Gehalt: EUR {ma.CalculateSallery():#,000.00}\n");
            }
        }
    }
}
