using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using Swd.TimeManager.GuiMaui.Model;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    public class PersonAddPageViewModel : ObservableValidator
    {
        //Fields
        private Person _person;



        //Properties
        public Person Person
        {
            get { return _person; }
            set
            {
              SetProperty(ref  _person , value);
            }
        }

        //Commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        public PersonAddPageViewModel()
        {
            Person = new Person { EntryDate = DateTime.Today};

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
