using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class TimeRecordDeletePage : ContentPage
{
    public TimeRecordDeletePage()
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
        var viewModel = (TimeRecordDeletePageViewModel)BindingContext;
        
        await viewModel.LoadProjectsAsync();
        await viewModel.LoadPersonsAsync();
        await viewModel.LoadTasksAsync();
        await viewModel.LoadTimeRecordAsync();

        
        // Falls nicht gleich angezeigt wird
        //await MainThread.InvokeOnMainThreadAsync(() =>
        //{
        //    this.BindingContext = null;
        //    this.BindingContext = viewModel;
        //}
        //);
    }
}