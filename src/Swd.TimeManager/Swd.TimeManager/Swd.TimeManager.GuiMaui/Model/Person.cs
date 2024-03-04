using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.GuiMaui.Model
{
    public class Person : ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DisplayName { get; }
        public string Email { get; set; }
        public string EntryDate { get; set; }
        public string? ExitDate { get; set; }

        public Person()
        { 
        
        }

    }
}
