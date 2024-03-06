using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Swd.TimeManager.GuiMaui.Model;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    [QueryProperty(nameof(TimeRecordId), "timerecordId")]
    public class TimeRecordEditPageViewModel : BaseViewModel
    {
        //Fields
        private TimeManagerDatabase _database;

        private TimeRecord _timerecord;
        private int _timerecordId;
        private Project _selectedproject;
        private Person _selectedperson;
        private Model.Task _selectedtask;

        private ObservableCollection<Project> _projectlist;
        private ObservableCollection<Person> _personlist;
        private ObservableCollection<Model.Task> _tasklist;

        //Properties
        public TimeRecord TimeRecord
        {
            get { return _timerecord; }
            set
            {
                _timerecord = value;
                OnPropertyChanged();
            }
        }

        public int TimeRecordId
        {
            get { return _timerecordId; }
            set
            {
                _timerecordId = value;
                OnPropertyChanged();
            }
        }

        public Project SelectedProject
        {
            get { return _selectedproject; }
            set
            {
                _selectedproject = value;
                OnPropertyChanged();
            }
        }

        public Person SelectedPerson
        {
            get { return _selectedperson; }
            set
            {
                _selectedperson = value;
                OnPropertyChanged();
            }
        }

        public Model.Task SelectedTask
        {
            get { return _selectedtask; }
            set
            {
                _selectedtask = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Project> ProjectList
        {
            get { return _projectlist; }
            set
            {
                _projectlist = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Person> PersonList
        {
            get { return _personlist; }
            set
            {
                _personlist = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Model.Task> TaskList
        {
            get { return _tasklist; }
            set
            {
                _tasklist = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        public TimeRecordEditPageViewModel()
        {
            _database = new TimeManagerDatabase();

            SaveCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Save(),
                 //Can Execute: Methode die true/false zurücklieft
                 IsFormValid
                );

            CancelCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Cancel(),
                //Can Execute: Methode die true/false zurücklieft
                IsFormValid
                );
        }

        private async void Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task Save()
        {
            this.TimeRecord.ProjectId = this.SelectedProject.Id;
            this.TimeRecord.PersonId = this.SelectedPerson.Id;
            this.TimeRecord.TaskId = this.SelectedTask.Id;

            await _database.SaveTimeRecordAsync(this.TimeRecord);
            await Shell.Current.GoToAsync("..");
            TimeRecord = new TimeRecord();
        }

        public async System.Threading.Tasks.Task LoadProjectsAsync()
        {
            ProjectList = new ObservableCollection<Project>(await _database.GetProjectsAsync());
        }

        public async System.Threading.Tasks.Task LoadPersonsAsync()
        {
            PersonList = new ObservableCollection<Person>(await _database.GetPersonsAsync());
        }

        public async System.Threading.Tasks.Task LoadTasksAsync()
        {
            TaskList = new ObservableCollection<Model.Task>(await _database.GetTasksAsync());
        }


        public async System.Threading.Tasks.Task LoadTimeRecordAsync()
        {
            TimeRecord = await _database.GetTimeRecordByIdAsync(TimeRecordId);

            foreach (var Project in ProjectList)
            {
                if (Project.Id == TimeRecord.ProjectId)
                {
                    SelectedProject = Project;
                }
            }

            foreach (var Person in PersonList)
            {
                if (Person.Id == TimeRecord.PersonId)
                {
                    SelectedPerson = Person;
                }
            }

            foreach (var Task in TaskList)
            {
                if (Task.Id == TimeRecord.TaskId)
                {
                    SelectedTask = Task;
                }
            }

        }

        private bool IsFormValid()
        {
            bool isFormValid;

            isFormValid = true;

            return isFormValid;
        }


    }
}
