using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class TaskListPage : ContentPage
{
    public TaskListPage()
    {
        InitializeComponent();
        LoadProjectsAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadProjectsAsync();
    }

    private async System.Threading.Tasks.Task LoadProjectsAsync()
    {
        var viewModel = (TaskListPageViewModel)BindingContext;
        await viewModel.LoadProjectsAsync();
        // Falls nicht gleich angezeigt wird
        //await MainThread.InvokeOnMainThreadAsync(() => ((ListView)Content).ItemsSource = viewModel.ProjectList);

    }
}


