using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swd.TimeManager.GuiMaui.Model;
using System.Windows.Input;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    [QueryProperty(nameof(TaskId), "taskId")]
    public class TaskDeletePageViewModel : BaseViewModel
    {
        //Fields
        private Swd.TimeManager.GuiMaui.Model.Task _task;
        private int _taskId;
        private TimeManagerDatabase _database;


        //Properties
        public Swd.TimeManager.GuiMaui.Model.Task Task
        {
            get { return _task; }
            set
            {
                _task = value;
                OnPropertyChanged();
            }
        }

        //Properties
        public int TaskId
        {
            get { return _taskId; }
            set
            {
                _taskId = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public TaskDeletePageViewModel()
        {
            _database = new TimeManagerDatabase();

            DeleteCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Delete(),
                //Can Execute: Methode die true/false zurücklieft
                () => IsActionPossible()
                );
            CancelCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Cancel(),
                //Can Execute: Methode die true/false zurücklieft
                () => IsActionPossible()
                );

        }

        public async System.Threading.Tasks.Task Delete()
        {
            TimeManagerDatabase database = new TimeManagerDatabase();
            await database.DeleteTaskAsync(this.Task);
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task LoadTaskAsync()
        {
            Task = await _database.GetTaskByIdAsync(TaskId);
        }


        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }

    }
}
