using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Swd.TimeManager.Model
{
    public class Person : ModelBase
    {
        public long Id { get; set; }

        [Required]
        //CustomValidation --> Kann ganze Methode angehängt werden
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string DisplayName { get; }

        [StringLength(100)] //Für Validierung im Code
        [EmailAddress]
        public string Email { get; set; }
        public DateOnly EntryDate { get; set; }
        public DateOnly? ExitDate { get; set; }

    }
}
