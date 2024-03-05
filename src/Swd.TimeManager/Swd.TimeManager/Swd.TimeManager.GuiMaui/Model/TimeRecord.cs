using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.GuiMaui.Model
{
    public class TimeRecord : ModelBase
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Duration { get; set; }

        public long PersonId { get; set; }
        public long ProjectId { get; set; }
        public long TaskId { get; set; }

    }
}
