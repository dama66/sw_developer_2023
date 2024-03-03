﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Swd.TimeManager.GuiMaui.Model;

namespace Swd.TimeManager.GuiMaui.ViewModel
{
    public class TaskAddPageViewModel : BaseViewModel
    {
        //Fields
        private TimeManager.GuiMaui.Model.Task _task;

        //Properties
        public TimeManager.GuiMaui.Model.Task Task
        {
            get { return _task; }
            set
            {
                _task = value;
                OnPropertyChanged();
            }
        }

        //Commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }


        public TaskAddPageViewModel()
        {
            Task = new TimeManager.GuiMaui.Model.Task();

            SaveCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Save(),
                 //Can Execute: Methode die true/false zurücklieft
                 () => IsFormValid()
                );

            CancelCommand = new Command(
    //Execute: Methode die aufgerufen wird
    () => Cancle(),
     //Can Execute: Methode die true/false zurücklieft
     IsFormValid
    );
        }

        private async void Cancle()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task Save()
        {
            TimeManagerDatabase database = new TimeManagerDatabase();
            await database.SaveTaskAsync(this.Task);
            await Shell.Current.GoToAsync("..");
            Task = new TimeManager.GuiMaui.Model.Task();
        }

        public async System.Threading.Tasks.Task SetTaskToEdit()
        {
            TimeManagerDatabase database = new TimeManagerDatabase();
            // Project = await database.GetProjectByIdAsync(SelectedProjectId);
        }

        private bool IsFormValid()
        {
            bool isFormValid;

            isFormValid = true;

            return isFormValid;
        }


    }
}