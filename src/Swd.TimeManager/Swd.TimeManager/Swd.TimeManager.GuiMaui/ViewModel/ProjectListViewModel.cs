using Microsoft.Maui.Controls.Handlers.Compatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swd.TimeManager.GuiMaui.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    public class ProjectListViewModel : BasicViewModel
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
                _projectlist = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ProjectListViewModel()
        {
            _database = new TimeManagerDatabase();
            _projectlist = new ObservableCollection<Project>();

            AddCommand = new Command(() => Add(),() => IsActionPossible());
            EditCommand = new Command(() => Edit(),() => IsActionPossible());
            DeleteCommand = new Command(() => Delete(),() => IsActionPossible());
        }

        public async Task LoadProjectsAsync()
        {
            ProjectList = new ObservableCollection<Project> (await _database.GetProjectsAsync());
        }

        public async Task Add()
        {
            await Shell.Current.GoToAsync("projectadd");
        }

        public async Task Edit()
        {
            await Shell.Current.GoToAsync("projectedit");
        }

        public async Task Delete()
        {
            await Shell.Current.GoToAsync("projectdelete");
        }

        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }

    }



}
