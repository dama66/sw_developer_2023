﻿using CommunityToolkit.Mvvm.ComponentModel;
using Swd.TimeManager.GuiMaui.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swd.TimeManager.GuiMaui.ViewModel
{

    [QueryProperty(nameof(ProjectId), "projectId")]
    public class ProjectEditPageViewModel : ObservableValidator
    {
        //Fields
        private Project _project;
        private int _projectId;
        private TimeManagerDatabase _database;


        //Properties
        public Project Project
        {
            get { return _project; }
            set
            {
                SetProperty(ref _project, value);
            }
        }

        //Properties
        public int ProjectId
        {
            get { return _projectId; }
            set
            {
                SetProperty(ref _projectId, value);
            }
        }

        //Commands
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public ProjectEditPageViewModel()
        {
            _database = new TimeManagerDatabase();

            SaveCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Save(),
                //Can Execute: Methode die true/false zurücklieft
                () => IsActionPossible()
                );
            CancelCommand = new Command(
                //Execute: Methode die aufgerufen wird
                () => Cancel(),
                //Can Execute: Methode die true/false zurücklieft
                () => IsActionPossible()
                );

        }

        public async System.Threading.Tasks.Task Save()
        {
            TimeManagerDatabase database = new TimeManagerDatabase();
            await database.SaveProjectAsync(this.Project);
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async System.Threading.Tasks.Task LoadProjectAsync()
        {
            Project = await _database.GetProjectByIdAsync(ProjectId);
        }


        private bool IsActionPossible()
        {
            bool isActionPossible = true;

            return isActionPossible;
        }
    }
}