using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class TimeRecordListPage : ContentPage
{
	public TimeRecordListPage()
	{
        InitializeComponent();
        LoadTimeRecordsAsync();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadTimeRecordsAsync();
    }

    private async Task LoadTimeRecordsAsync()
	{
		var viewModel = (TimeRecordListPageViewModel)BindingContext;
		await viewModel.LoadTimeRecordsAsync();
		// Falls nicht gleich angezeigt wird
		//await MainThread.InvokeOnMainThreadAsync(() => ((ListView)Content).ItemsSource = viewModel.ProjectList);
		
	}
}