using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Model
{
    public class Person : ModelBase
    {
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateOnly EntryDate { get; set; }
        public DateOnly? ExitDate { get; set; }

    }
}
