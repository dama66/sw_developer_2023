using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class TimeRecordEditPage : ContentPage
{
    public TimeRecordEditPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var viewModel = (TimeRecordEditPageViewModel)BindingContext;
        await viewModel.LoadProjectsAsync();
        await viewModel.LoadPersonsAsync();
        await viewModel.LoadTasksAsync();
        await viewModel.LoadTimeRecordAsync();
        // Falls nicht gleich angezeigt wird
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            this.BindingContext = null;
            this.BindingContext = viewModel;
        }
        );

    }
}