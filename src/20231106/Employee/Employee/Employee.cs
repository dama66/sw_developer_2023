using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager
{
    public class Employee
    {
        private String _name;
        private Guid _id;
        private DateTime _birthDate;


        public Employee(string name, DateTime birthDate)
        {
            _name = name;

            _id = Guid.NewGuid();
            _birthDate = birthDate;
        }

        public string Name 
        {  
            get { return _name; } 
        }

        public Guid Id
        {
            get { return _id; }
        }

        public int BirthYear 
        {
            get { return _birthDate.Year; }

        } 

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {_name}");
            Console.WriteLine($"Id: {_id}");
            Console.WriteLine($"BirthYear: {_birthDate}");

            Console.ReadLine();
        }
    }
}
