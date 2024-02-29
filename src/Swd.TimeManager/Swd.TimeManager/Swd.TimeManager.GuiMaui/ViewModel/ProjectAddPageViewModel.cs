using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Swd.TimeManager.GuiMaui.Model;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    public class ProjectAddPageViewModel : BasicViewModel
    {
        //Fields
        private Project _project;

        //Properties
        public Project Project
        {
            get { return _project; }
            set
            {
                _project = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        public ProjectAddPageViewModel()
        {
            Project = new Project();

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

        public async Task Save()
        {
            TimeManagerDatabase database = new TimeManagerDatabase();
            await database.SaveProjectAsync(this.Project);
            await Shell.Current.GoToAsync("..");
            Project = new Project();
        }


        public async Task SetProjectToEdit()
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
