using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Swd.TimeManager.GuiMaui.Model;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    public class PersonAddPageViewModel : BaseViewModel
    {
        //Fields
        private Person _person;
        private DateTime _entryDateRaw = DateTime.Now;



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

        public DateTime EntryDateRaw
        {
            get { return _entryDateRaw; }
            set
            {
                _entryDateRaw = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        public PersonAddPageViewModel()
        {
            Person = new Person();

            SaveCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Save(),
                //Can Execute: Methode die true/false zurücklieft
                 IsFormValid
                );

            CancelCommand = new Command(
    //Execute: Methode die aufgerufen wird
    () => Cancle(),
     //Can Execute: Methode die true/false zurücklieft
     IsFormValid
    );
        }

        private async void Cancle()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task Save()
        {
            _person.EntryDate = _entryDateRaw.ToString("dd.MM.yyyy");
            TimeManagerDatabase database = new TimeManagerDatabase();
            await database.SavePersonAsync(this.Person);
            await Shell.Current.GoToAsync("..");
            Person = new Person();
        }


        public async System.Threading.Tasks.Task SetPersonToEdit()
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
