using Swd.TimeManager.GuiMaui.Views;

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

            Routing.RegisterRoute("tasklist", typeof(TaskListPage));
            Routing.RegisterRoute("taskadd", typeof(TaskAddPage));
            Routing.RegisterRoute("taskedit", typeof(TaskEditPage));
            Routing.RegisterRoute("taskdelete", typeof(TaskDeletePage));

            Routing.RegisterRoute("personlist", typeof(PersonListPage));
            Routing.RegisterRoute("personadd", typeof(PersonAddPage));
            Routing.RegisterRoute("personedit", typeof(PersonEditPage));
            Routing.RegisterRoute("persondelete", typeof(PersonDeletePage));

            Routing.RegisterRoute("timerecordlist", typeof(TimeRecordListPage));
            Routing.RegisterRoute("timerecordadd", typeof(TimeRecordAddPage));
            Routing.RegisterRoute("timerecordedit", typeof(TimeRecordEditPage));
            Routing.RegisterRoute("timerecorddelete", typeof(TimeRecordDeletePage));
        }

    }
}
