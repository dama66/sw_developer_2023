using Swd.TimeManager.Business;
using Swd.TimeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swd.TimeManager.GuiWpf.ViewModels
{
    public class TimeRecordViewModel
    {
        public TimeRecord TimeRecord { get; set; }
        public List<Project> Projects { get; set; }
        public List<Person> Persons { get; set; }
        public List<Model.Task> Tasks { get; set; }

        public TimeRecordViewModel()
        {
            TimeRecordService timeRecordService = new TimeRecordService();
            TimeRecord = timeRecordService.ReadAll().FirstOrDefault();

            ProjectService projectService = new ProjectService();
            Projects = projectService.ReadAll().ToList();

            PersonService personService = new PersonService();
            Persons = personService.ReadAll().ToList();

            TaskService tasksService = new TaskService();
            Tasks = tasksService.ReadAll().ToList();

        }

    }
}
