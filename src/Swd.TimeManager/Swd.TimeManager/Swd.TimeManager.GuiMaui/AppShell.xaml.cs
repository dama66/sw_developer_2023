﻿using Swd.TimeManager.GuiMaui.Views;

namespace Swd.TimeManager.GuiMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("intro", typeof(IntroPage));
            Routing.RegisterRoute("login", typeof(LoginPage));
            Routing.RegisterRoute("overview", typeof(OverviewPage));
            Routing.RegisterRoute("add", typeof(AddPage));
            Routing.RegisterRoute("list", typeof(ListPage));
            Routing.RegisterRoute("settings", typeof(SettingsPage));
            Routing.RegisterRoute("project", typeof(ProjectPage));

            Routing.RegisterRoute("projectlist", typeof(ProjectListPage));
            Routing.RegisterRoute("projectadd", typeof(ProjectAddPage));
            Routing.RegisterRoute("projectedit", typeof(ProjectEditPage));
            Routing.RegisterRoute("projectdelete", typeof(ProjectDeletePage));
        }

    }
}
