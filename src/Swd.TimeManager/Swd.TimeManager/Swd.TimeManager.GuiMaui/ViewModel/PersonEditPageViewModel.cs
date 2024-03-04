using Swd.TimeManager.GuiMaui.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swd.TimeManager.GuiMaui.ViewModel
{

    [QueryProperty(nameof(PersonId), "personId")]
    public class PersonEditPageViewModel : BaseViewModel
    {
        //Fields
        private Person _person;
        private int _personId;
        private DateTime _entryDateRaw;
        private DateTime _exitDateRaw;
        private TimeManagerDatabase _database;


        //Properties
        public Person Person
        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public int PersonId
        {
            get { return _personId; }
            set
            {
                _personId = value;
                OnPropertyChanged();
            }
        }

        public DateTime EntryDateRaw
        {
            get { return _entryDateRaw; }
            set
            {
                _entryDateRaw = value;
                OnPropertyChanged();
            }
        }

        public DateTime ExitDateRaw
        {
            get { return _exitDateRaw; }
            set
            {
                _exitDateRaw = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public PersonEditPageViewModel()
        {
            _database = new TimeManagerDatabase();

            SaveCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Save(),
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

        public async System.Threading.Tasks.Task Save()
        {
            _person.EntryDate = _entryDateRaw.ToString("dd.MM.yyyy");
            _person.ExitDate = _exitDateRaw.ToString("dd.MM.yyyy");
            TimeManagerDatabase database = new TimeManagerDatabase();
            await database.SavePersonAsync(this.Person);
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task LoadPersonAsync()
        {
            Person = await _database.GetPersonByIdAsync(PersonId);

            EntryDateRaw = DateTime.Parse(Person.EntryDate);
            ExitDateRaw = DateTime.Parse(Person.ExitDate);
        }


        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }
    }
}