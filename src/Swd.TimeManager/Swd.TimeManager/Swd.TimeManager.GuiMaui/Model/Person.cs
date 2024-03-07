using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Swd.TimeManager.GuiMaui.Model
{
    public class Person : ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DisplayName { get => string.Format("{0} {1}", LastName, FirstName); }
        public string Email { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }

        public Person()
        { 

        }

    }
}
