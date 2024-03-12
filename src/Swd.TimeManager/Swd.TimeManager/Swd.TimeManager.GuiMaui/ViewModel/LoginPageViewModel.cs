using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Swd.TimeManager.GuiMaui.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swd.TimeManager.GuiMaui.ViewModel
{

    //=> Partial notwendig da Codegeneratur aus MVVM Toolkit eine Klasse mit dem selben Namen
    public partial class LoginPageViewModel : ObservableValidator
    {
        //Fields
        private string _username;
        private string _password;
        private ValidationResult _validationResult;

        //Events -> Nur bei manueller Implementierung von INotifyPropertyChanged notwendig
        //public event PropertyChangedEventHandler PropertyChanged;


        //Properties
        [Required(ErrorMessage = "Username is a required field!")]
        public string Username
        {
            get { return _username; }
            set
            {
                SetProperty(ref _username, value, true);
                LoginCommand.NotifyCanExecuteChanged();
                //OnPropertyChanged("Username");
            }
        }

        [Required(ErrorMessage = "Password is a required field!")]
        [MinLength(8, ErrorMessage = "Minimum length is 5 characters!")]
      //  [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8}$", ErrorMessage = "Password is not complex enough!")]
        [IsEmailPasswordEqual(nameof(Username))]
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value, true);
                LoginCommand.NotifyCanExecuteChanged();
                //OnPropertyChanged();
            }
        }

        public ValidationResult ValidationResult
        {
            get { return _validationResult; }
            set
            {
                SetProperty(ref _validationResult, value, true);
            }
        }



        //Commands
        //=> Nicht mehr notwendig wenn MVVM Toolkit verwendet wird 
        //public ICommand LoginCommand { get; set; }



        public LoginPageViewModel()
        {
            Username = "marcel.butterweck";
            Password = "12345";


            //=> Nicht mehr notwendig wenn MVVM Toolkit verwendet wird 
            //LoginCommand = new Command(
            //    //Execute: Methode die aufgerufen wird
            //    () => Login(),
            //    //Can Execute: Methode die true/false zurücklieft
            //    () => IsLoginDataComplete()
            //);

        }


        //-> Nur bei manueller Implementierung von INotifyPropertyChanged notwendig
        //public void OnPropertyChanged([CallerMemberName] string name = "" ) =>
        //    PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( name ) );


        [RelayCommand(CanExecute = nameof(IsLoginDataComplete))]
        public async System.Threading.Tasks.Task Login()
        {
            //await Shell.Current.GoToAsync("main");
            Application.Current.MainPage = new AppShell();
        }


        private bool IsLoginDataComplete()
        {
            Validate();
            bool isLoginDataComplete = true;
            if (ValidationResult != null)
            {
                if (ValidationResult.ErrorMessage != null)
                {
                    isLoginDataComplete = false;
                }
            }
            return isLoginDataComplete;
        }


        private void Validate()
        {
            ValidateAllProperties();
            if (HasErrors)
            {
                ValidationResult = new ValidationResult(string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage)));
            }
            else
            {
                ValidationResult = null;
            }
        }


    }
}
