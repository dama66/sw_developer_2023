using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class TaskEditPage : ContentPage
{
	public TaskEditPage()
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
        var viewModel = (TaskEditPageViewModel)BindingContext;
        await viewModel.LoadTaskAsync();
        // Falls nicht gleich angezeigt wird
        //await MainThread.InvokeOnMainThreadAsync(() => this.editGrid.BindingContext = viewModel.Project);

    }
}