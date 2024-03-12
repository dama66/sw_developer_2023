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
    public class OverviewViewModel : ObservableValidator
    {
        //Fields
        private TimeManagerDatabase _database;
        private ObservableCollection<OverviewData> _overviewList;

        //Properties
        public ObservableCollection<OverviewData> OverviewList
        {
            get { return _overviewList; }
            set
            {
                SetProperty(ref _overviewList, value);
            }
        }

        //Commands

        public OverviewViewModel()
        {
            _database = new TimeManagerDatabase();
            _overviewList = new ObservableCollection<OverviewData>();

        }

        public async System.Threading.Tasks.Task LoadOverviewDataAsync()
        {
            OverviewList = new ObservableCollection<OverviewData> (await _database.GetOverviewDataAsync());
        }



        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }

    }



}
