using Microsoft.Maui.Controls.Handlers.Compatibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swd.TimeManager.GuiMaui.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Buffers;
using CommunityToolkit.Mvvm.ComponentModel;


namespace Swd.TimeManager.GuiMaui.ViewModel
{
    public class SearchListPageViewModel : ObservableValidator
    {
        //Fields
        private TimeManagerDatabase _database;
        private ObservableCollection<SearchResult> _resultlist;
        private string _searchValue;
        private decimal _resultSum;

        //Properties
        public ObservableCollection<SearchResult> ResultList
        {
            get { return _resultlist; }
            set
            {
                SetProperty(ref _resultlist, value);
            }
        }

        public string SearchValue
        {
            get { return _searchValue; }
            set
            {
                SetProperty(ref _searchValue, value);
            }
        }

        public decimal ResultSum
        {
            get { return _resultSum; }
            set
            {
                SetProperty(ref _resultSum, value);
            }
        }

        //Commands
        public ICommand SearchCommand { get; set; }


        public SearchListPageViewModel()
        {
            _database = new TimeManagerDatabase();
            _resultlist = new ObservableCollection<SearchResult>();

            SearchCommand = new Command(
                (object searchValue) => Search(searchValue),
                (object searchValue) => IsActionPossible()
                );

        }

        public async System.Threading.Tasks.Task Search(object searchValue)
        {
            SearchValue = searchValue.ToString();
            ObservableCollection<SearchResult> resultList = 
                new ObservableCollection<SearchResult>(await _database.GetSearchResultAsync(SearchValue));
            ResultList = resultList;
            ResultSum = ResultList.Sum(r => r.Duration);

        }

        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }

    }



}
