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
    public class TimeRecordListPageViewModel : ObservableValidator
    {
        //Fields
        private TimeManagerDatabase _database;
        private ObservableCollection<TimeRecord> _timerecordlist;

        //Properties
        public ObservableCollection<TimeRecord> TimeRecordList
        {
            get { return _timerecordlist; }
            set
            {
                SetProperty(ref _timerecordlist, value);
            }
        }

        //Commands
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public TimeRecordListPageViewModel()
        {
            _database = new TimeManagerDatabase();
            _timerecordlist = new ObservableCollection<TimeRecord>();

            AddCommand = new Command(
                () => Add(),
               () => IsActionPossible()
                );
            EditCommand = new Command(
                (object timerecordId) => Edit(timerecordId),
                (object timerecordId) => IsActionPossible()
                );
            DeleteCommand = new Command(
                (object timerecordId) => Delete(timerecordId),
                (object timerecordId) => IsActionPossible()
                );
        }

        public async System.Threading.Tasks.Task LoadTimeRecordsAsync()
        {
            TimeRecordList = new ObservableCollection<TimeRecord>(await _database.GetTimeRecordsAsync());
        }

        public async System.Threading.Tasks.Task Add()
        {
            await Shell.Current.GoToAsync("timerecordadd");
        }

        public async System.Threading.Tasks.Task Edit(object projectId)
        {
            if (int.TryParse(projectId.ToString(), out int id))
            {
                var navigationParameter = new Dictionary<string, object>
                {
                    {"timerecordId", id }
                };
                await Shell.Current.GoToAsync("timerecordedit", navigationParameter);
            }
        }

        public async System.Threading.Tasks.Task Delete(object timerecordId)
        {
            if (int.TryParse(timerecordId.ToString(), out int id))
            {

                var navigationParameter = new Dictionary<string, object>
                {
                    {"timerecordId", id }
                };
                await Shell.Current.GoToAsync("timerecorddelete", navigationParameter);
            }
        }

        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }

    }



}
