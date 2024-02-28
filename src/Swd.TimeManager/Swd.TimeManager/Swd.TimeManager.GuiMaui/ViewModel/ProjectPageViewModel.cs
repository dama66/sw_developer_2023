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
    class ProjectPageViewModel : BasicViewModel
    {
        TimeManagerDatabase _database;

        private Project _project;
        public Project Project
        {
            get { return _project; }
            set
            {
                _project = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }

        public ProjectPageViewModel()
        {
            Project = new Project();
            SaveCommand = new Command(async () => await Save());
        }

        public async Task Save()
        {
            _database = new TimeManagerDatabase();

            await _database.SaveProjectAsync(Project);
        }

    }
}
