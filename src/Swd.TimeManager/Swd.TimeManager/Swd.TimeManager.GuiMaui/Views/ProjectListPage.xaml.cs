using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class ProjectListPage : ContentPage
{
	public ProjectListPage()
	{
		InitializeComponent();
		LoadProjectsAsync();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		LoadProjectsAsync();
    }

    private async Task LoadProjectsAsync()
	{
		var viewModel = (ProjectListPageViewModel)BindingContext;
		await viewModel.LoadProjectsAsync();
		// Falls nicht gleich angezeigt wird
		//await MainThread.InvokeOnMainThreadAsync(() => ((ListView)Content).ItemsSource = viewModel.ProjectList);
		
	}
}