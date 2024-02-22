using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Model
{
    public class TimeRecord : ModelBase
    {
        public long Id { get; set; }
        public DateOnly Date {  get; set; }
        public decimal Duration { get; set; }

        //Fremdschlüssel zusätzlich als property, damit es möglich ist, bestehende Person, Project, Task zu einem neuen TimeRecord hinzugefügt werden können.
        public long PersonId { get; set; }
        public long ProjectId { get; set; }
        public long TaskId { get; set; }

        public Person Person { get; set; }
        public Project Project { get; set; }
        public Task Task { get; set; }
    }
}
