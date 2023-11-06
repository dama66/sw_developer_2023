using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee("Max Mustermann", new DateTime(1985, 2, 28));

            employee1.ShowInfo();
        }
    }
}
