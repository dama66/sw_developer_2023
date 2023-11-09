using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AbstrakteDatentypen
{
    internal class Developer : Employee
    {
        private readonly decimal _baseSallery;
        private string _name;
        private Guid _id;
        private DateTime _birthDate;

        public Developer(string name, DateTime birthDate, decimal baseSallery)
        {
            _name = name;
            _birthDate = birthDate;
            _id = Guid.NewGuid();
            _baseSallery = baseSallery;
        }

        public override string Name { get { return _name; } }

        public override Guid Id { get { return _id; } }

        public override int BirthYear { get { return _birthDate.Year; } }

        public override decimal CalculateSallery()
        {
            var age = DateTime.Now.Year - BirthYear;
            var factor = age / 5;

            return _baseSallery * (1.00m + factor /100.0m);
        }

        public override void ShowInfo()
        {
            
                Console.WriteLine($"Name: {_name}");
                Console.WriteLine($"Id: {_id}");
                Console.WriteLine($"BirthYear: {_birthDate}");
            
        }
    }
}
