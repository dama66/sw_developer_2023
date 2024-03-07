using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.GuiMaui.Model
{
    public class SearchResult
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public decimal Duration { get; set; }

    }
}
