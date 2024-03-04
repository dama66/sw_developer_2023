using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class TaskDeletePage : ContentPage
{
	public TaskDeletePage()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadTaskAsync();
    }

    private async Task LoadTaskAsync()
    {
        var viewModel = (TaskDeletePageViewModel)BindingContext;
        await viewModel.LoadTaskAsync();
        // Falls nicht gleich angezeigt wird
       // await MainThread.InvokeOnMainThreadAsync(() => this.editGrid.BindingContext = viewModel.Project);

    }
}