using Microsoft.Maui.Controls.Handlers.Compatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swd.TimeManager.GuiMaui.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Swd.TimeManager.Model;


namespace Swd.TimeManager.GuiMaui.ViewModel
{
    public class TaskListPageViewModel : BaseViewModel
    {
        //Fields
        private TimeManagerDatabase _database;
        private ObservableCollection<TimeManager.GuiMaui.Model.Task> _tasklist;

        //Properties
        public ObservableCollection<TimeManager.GuiMaui.Model.Task> TaskList
        {
            get { return _tasklist; }
            set
            {
                _tasklist = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public TaskListPageViewModel()
        {
            _database = new TimeManagerDatabase();
            _tasklist = new ObservableCollection<TimeManager.GuiMaui.Model.Task>();

            AddCommand = new Command(
                () => Add(),
               ()=> IsActionPossible()
                );
            EditCommand = new Command(
                (object taskId) => Edit(taskId),
                (object taskId) => IsActionPossible()
                );
            DeleteCommand = new Command(
                (object taskId) => Delete(taskId),
                (object taskId) => IsActionPossible()
                );
        }

        public async System.Threading.Tasks.Task LoadProjectsAsync()
        {
            TaskList = new ObservableCollection<Swd.TimeManager.GuiMaui.Model.Task> (await _database.GetTasksAsync());
        }

        public async System.Threading.Tasks.Task Add()
        {
            await Shell.Current.GoToAsync("taskadd");
        }

        public async System.Threading.Tasks.Task Edit(object taskId)
        {
            if (int.TryParse(taskId.ToString(), out int id))
            {

                var navigationParameter = new Dictionary<string, object>
                {
                    {"taskId", id }
                };
                await Shell.Current.GoToAsync("taskedit", navigationParameter);
            }

        }

            public async System.Threading.Tasks.Task Delete(object taskId)
        {
            if (int.TryParse(taskId.ToString(), out int id))
            {

                var navigationParameter = new Dictionary<string, object>
                {
                    {"taskId", id }
                };
                await Shell.Current.GoToAsync("taskdelete", navigationParameter);
            }
        }

        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }

    }



}
