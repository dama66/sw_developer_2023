﻿using Swd.TimeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.Repository
{
    public class TaskRepository : GenericRepository<Model.Task, TimeManagerContext>, ITaskRepository
    {


    }
}
