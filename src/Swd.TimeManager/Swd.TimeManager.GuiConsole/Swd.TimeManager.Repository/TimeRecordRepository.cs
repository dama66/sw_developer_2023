using Microsoft.EntityFrameworkCore;
using Swd.TimeManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Repository
{
    public class TimeRecordRepository : GenericRepository<TimeRecord, TimeManagerContext>, ITimeRecordRepository
    {
        //um andere Objekte bei Read hinzuzufügen
        public TimeRecord ReadByKeyInclusive (object Key)
        {
            TimeManagerContext context = new TimeManagerContext ();
            var timeRecord = context.TimeRecord
                .Include(rec => rec.Person)
                .Include(rec => rec.Project)
                .Include(rec => rec.Task)
                .Where(w => w.Id == Convert.ToInt64(Key))
                .FirstOrDefault();

            return timeRecord;
        }

    }
}
