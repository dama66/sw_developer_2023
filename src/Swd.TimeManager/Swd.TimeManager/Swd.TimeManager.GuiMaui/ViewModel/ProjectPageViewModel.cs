using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Swd.TimeManager.GuiMaui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    [QueryProperty(nameof(SelectedProjectId), "Id")]
    class ProjectPageViewModel : BasicViewModel
    {
        //Fields
        private Project _project;
        private int _selectedProjectid;

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
        public int SelectedProjectId
        {
            get { return _selectedProjectid; }
            set
            {
                _selectedProjectid = value;
                OnPropertyChanged();
                SetProjectToEdit();
            }
        }

        //Commands
        public ICommand SaveCommand { get; set; }



        public ProjectPageViewModel()
        {
            Project = new Project();

            SaveCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Save(),
                //Can Execute: Methode die true/false zurücklieft
                () => IsFormValid()
                );
        }

        public async Task Save()
        {
            TimeManagerDatabase database = new TimeManagerDatabase();
            await database.SaveProjectAsync(this.Project);
            await Shell.Current.GoToAsync("..");
        }


        public async Task SetProjectToEdit()
        {
            TimeManagerDatabase database = new TimeManagerDatabase();
            Project = await database.GetProjectByIdAsync(SelectedProjectId);
        }

        private bool IsFormValid()
        {
            bool isFormValid = true;

            return isFormValid;
        }


    }
}
