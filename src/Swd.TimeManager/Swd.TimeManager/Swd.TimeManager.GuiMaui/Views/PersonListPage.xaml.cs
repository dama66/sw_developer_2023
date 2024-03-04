using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class PersonListPage : ContentPage
{
	public PersonListPage()
	{
		InitializeComponent();
		LoadPersonsAsync();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		LoadPersonsAsync();
    }

    private async Task LoadPersonsAsync()
	{
		var viewModel = (PersonListPageViewModel)BindingContext;
		await viewModel.LoadPersonsAsync();
		// Falls nicht gleich angezeigt wird
		//await MainThread.InvokeOnMainThreadAsync(() => ((ListView)Content).ItemsSource = viewModel.ProjectList);
		
	}
}