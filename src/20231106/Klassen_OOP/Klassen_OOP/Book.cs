using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Klassen_OOP
{
    internal class Book
    {
        
        private int _pageCount;
        private string _title;
        private string _author;
        private string _isbn;
        private decimal _price;
        
        private Guid _id;
        private bool _isAvailable;
        private DateTime _startBorrowingDate;
        private DateTime _stopBorrowingDate;
        private bool _returnDateOverdrawn;

        //user specific Konstructor
        public Book(int pageCount, string title, string author, string isbn, decimal price)
        {
            InitBorrowStateInfo();

            _pageCount = pageCount;
            _title = title;
            _author = author;
            _isbn = isbn;
            _price = price;
        }

        public string Title 
        {
            get
            { 
                return _title; 
            } 
        
            //set 
            //{
            //    _title = value; 
            //}
        
        }  

        private void InitBorrowStateInfo()
        {
            _id = Guid.NewGuid();
            _isAvailable = true;
            _startBorrowingDate = DateTime.MinValue;
            _stopBorrowingDate = DateTime.MinValue;
            _returnDateOverdrawn = false;
        }

        public void StartBorrowing(TimeSpan duration)
        {
            _startBorrowingDate = DateTime.Now;
            _stopBorrowingDate = _startBorrowingDate.Add(duration);
            _isAvailable = false;
            _returnDateOverdrawn = _stopBorrowingDate < DateTime.Now;
        }

        public void EndBorrowing()
        {
            _isAvailable = true;
            _returnDateOverdrawn = false;
        }

        public void DisplayInfo()
        {
           // ReturnDateOverdrawn = StopBorrowingDate < DateTime.Now;

            Console.WriteLine($"ID: {_id}");
            Console.WriteLine($"Titel: {_title} [{_author}]");
            Console.WriteLine($"Available: {_isAvailable}");
            Console.WriteLine($"Overdrawn: {_returnDateOverdrawn}");

            if (!_isAvailable)
            {
                Console.WriteLine($"Start: {_startBorrowingDate.ToShortDateString()}");
                Console.WriteLine($"until: {_stopBorrowingDate.ToShortDateString()}");
            }
        }
    }
}
