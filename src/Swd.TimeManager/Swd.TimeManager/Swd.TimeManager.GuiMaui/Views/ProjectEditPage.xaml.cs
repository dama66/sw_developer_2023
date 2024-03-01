using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class ProjectEditPage : ContentPage
{
	public ProjectEditPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadProjectAsync();
    }

    private async Task LoadProjectAsync()
    {
        var viewModel = (ProjectEditPageViewModel)BindingContext;
        await viewModel.LoadProjectAsync();
        // Falls nicht gleich angezeigt wird
        //await MainThread.InvokeOnMainThreadAsync(() => this.editGrid.BindingContext = viewModel.Project);

    }
}