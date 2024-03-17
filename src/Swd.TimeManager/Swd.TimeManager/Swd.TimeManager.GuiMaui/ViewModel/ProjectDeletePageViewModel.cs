using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swd.TimeManager.GuiMaui.Model;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    [QueryProperty(nameof(ProjectId), "projectId")]
    public class ProjectDeletePageViewModel : ObservableValidator
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
                SetProperty(ref _project, value);
            }
        }

        //Properties
        public int ProjectId
        {
            get { return _projectId; }
            set
            {
                SetProperty(ref _projectId, value);
            }
        }

        //Commands
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public ProjectDeletePageViewModel()
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
            await database.DeleteProjectAsync(this.Project);
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task LoadProjectAsync()
        {
            Project = await _database.GetProjectByIdAsync(ProjectId);
        }


        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }

    }
}
