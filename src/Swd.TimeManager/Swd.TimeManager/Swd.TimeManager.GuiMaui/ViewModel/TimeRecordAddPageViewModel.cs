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
    public class TimeRecordAddPageViewModel : BaseViewModel
    {
        //Fields
        private TimeManagerDatabase _database;

        private TimeRecord _timerecord;
        private ObservableCollection<Project> _projectlist;
        private ObservableCollection<Person> _personlist;

        private Project _selectedproject;
        private Person _selectedperson;
        // private ObservableCollection<Task> _tasklist;


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

        //public ObservableCollection<Task> TaskList
        //{
        //    get { return _tasklist; }
        //    set
        //    {
        //        _tasklist = value;
        //        OnPropertyChanged();
        //    }
        //}

        //Commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        public TimeRecordAddPageViewModel()
        {
            _database = new TimeManagerDatabase();

            TimeRecord = new TimeRecord { Date = DateTime.Today, Duration = 0.25M };

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


        public async System.Threading.Tasks.Task SetTimeRecordToEdit()
        {
            TimeManagerDatabase database = new TimeManagerDatabase();
           // Project = await database.GetProjectByIdAsync(SelectedProjectId);
        }

        private bool IsFormValid()
        {
            bool isFormValid;

                isFormValid = true;
   
            return isFormValid;
        }


    }
}
