using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.GuiMaui.Model
{
    public class OverviewData
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public decimal Duration { get; set; }
        public List<TaskInfo> Tasks { get; set; }

    }
}
