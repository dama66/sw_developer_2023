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
    [QueryProperty(nameof(ProjectId), "projectId")]
    public class ProjectEditPageViewModel : BasicViewModel
    {
        //Fields
        private Project _project;
        private int _projectId;
        private TimeManagerDatabase _database;





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
        public int ProjectId
        {
            get { return _projectId; }
            set
            {
                _projectId = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public ProjectEditPageViewModel()
        {
            Project = new Project();

            SaveCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Save(),
                 //Can Execute: Methode die true/false zurücklieft
                 IsActionPossible
                );

            CancelCommand = new Command(
    //Execute: Methode die aufgerufen wird
    () => Cancle(),
     //Can Execute: Methode die true/false zurücklieft
     IsActionPossible
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

        public async Task LoadProjectAsync()
        {
            Project = await _database.GetProjectByIdAsync(ProjectId);
        }

        private bool IsActionPossible()
        {
            bool isFormValid;

            isFormValid = true;

            return isFormValid;
        }

    }
}
