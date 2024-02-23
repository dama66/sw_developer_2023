using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    public class LoginPageViewModel : BasicViewModel
    {
        //Fields
        private string _username;
        private string _password;

        //Properties
        public string Username
		{
			get { return _username; }
			set 
            { 
                _username = value;
                OnPropertyChanged();
            }
		}

        public string Password
        {
            get { return _password; }
            set 
            {
                _password = value; 
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand LoginCommand { get; set; }

        public LoginPageViewModel()
        {
            Username = "david.maier";
            Password = "welcome";

            LoginCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Login(),
                //Can Execute: methode die true/false zurückliefert
                () => IsLoginDataComplete()
                );
        }

        public async Task Login()
        {
            await Shell.Current.GoToAsync("main");
        }

        private bool IsLoginDataComplete()
        {
            bool isLoginDataComplete = true;

            return isLoginDataComplete;
        }

    }
}
