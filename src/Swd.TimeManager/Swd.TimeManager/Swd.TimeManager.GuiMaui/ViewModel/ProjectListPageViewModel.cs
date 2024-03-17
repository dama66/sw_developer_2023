using Microsoft.Maui.Controls.Handlers.Compatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swd.TimeManager.GuiMaui.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;


namespace Swd.TimeManager.GuiMaui.ViewModel
{
    public class ProjectListPageViewModel : ObservableValidator
    {
        //Fields
        private TimeManagerDatabase _database;
        private ObservableCollection<Project> _projectlist;

        //Properties
        public ObservableCollection<Project> ProjectList
        {
            get { return _projectlist; }
            set
            {
                SetProperty(ref _projectlist, value);
            }
        }

        //Commands
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ProjectListPageViewModel()
        {
            _database = new TimeManagerDatabase();
            _projectlist = new ObservableCollection<Project>();

            AddCommand = new Command(
                () => Add(),
               ()=> IsActionPossible()
                );
            EditCommand = new Command(
                (object projectId) => Edit(projectId),
                (object projectId) => IsActionPossible()
                );
            DeleteCommand = new Command(
                (object projectId) => Delete(projectId),
                (object projectId) => IsActionPossible()
                );
        }

        public async System.Threading.Tasks.Task LoadProjectsAsync()
        {
            ProjectList = new ObservableCollection<Project> (await _database.GetProjectsAsync());
        }

        public async System.Threading.Tasks.Task Add()
        {
            await Shell.Current.GoToAsync("projectadd");
        }

        public async System.Threading.Tasks.Task Edit(object projectId)
        {
            if (int.TryParse(projectId.ToString(), out int id))
            {

                var navigationParameter = new Dictionary<string, object>
                {
                    {"projectId", id }
                };
                await Shell.Current.GoToAsync("projectedit", navigationParameter);
            }

        }

            public async System.Threading.Tasks.Task Delete(object projectId)
        {
            if (int.TryParse(projectId.ToString(), out int id))
            {

                var navigationParameter = new Dictionary<string, object>
                {
                    {"projectId", id }
                };
                await Shell.Current.GoToAsync("projectdelete", navigationParameter);
            }
        }

        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }

    }



}
