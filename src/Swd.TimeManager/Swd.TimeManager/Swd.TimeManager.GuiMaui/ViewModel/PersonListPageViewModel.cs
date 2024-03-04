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
    public class PersonListPageViewModel : BaseViewModel
    {
        //Fields
        private TimeManagerDatabase _database;
        private ObservableCollection<Person> _personlist;

        //Properties
        public ObservableCollection<Person> PersonList
        {
            get { return _personlist; }
            set
            {
                _personlist = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public PersonListPageViewModel()
        {
            _database = new TimeManagerDatabase();
            _personlist = new ObservableCollection<Person>();

            AddCommand = new Command(
                () => Add(),
               ()=> IsActionPossible()
                );
            EditCommand = new Command(
                (object personId) => Edit(personId),
                (object personId) => IsActionPossible()
                );
            DeleteCommand = new Command(
                (object personId) => Delete(personId),
                (object personId) => IsActionPossible()
                );
        }

        public async System.Threading.Tasks.Task LoadPersonsAsync()
        {
            PersonList = new ObservableCollection<Person> (await _database.GetPersonsAsync());
        }

        public async System.Threading.Tasks.Task Add()
        {
            await Shell.Current.GoToAsync("personadd");
        }

        public async System.Threading.Tasks.Task Edit(object personId)
        {
            if (int.TryParse(personId.ToString(), out int id))
            {

                var navigationParameter = new Dictionary<string, object>
                {
                    {"personId", id }
                };
                await Shell.Current.GoToAsync("personedit", navigationParameter);
            }

        }

            public async System.Threading.Tasks.Task Delete(object personId)
        {
            if (int.TryParse(personId.ToString(), out int id))
            {

                var navigationParameter = new Dictionary<string, object>
                {
                    {"personId", id }
                };
                await Shell.Current.GoToAsync("persondelete", navigationParameter);
            }
        }

        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }

    }



}
