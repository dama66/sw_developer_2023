using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class OverviewPage : ContentPage
{
    public OverviewPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadOverviewDataAsync();
    }

    private async Task LoadOverviewDataAsync()
    {
        var viewModel = (OverviewViewModel)BindingContext;
        await viewModel.LoadOverviewDataAsync();
        // Falls nicht gleich angezeigt wird
        //await MainThread.InvokeOnMainThreadAsync(() => ((ListView)Content).ItemsSource = viewModel.ProjectList);

    }
}