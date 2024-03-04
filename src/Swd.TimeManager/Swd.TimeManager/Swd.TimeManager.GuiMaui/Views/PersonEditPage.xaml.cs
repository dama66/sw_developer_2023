using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class PersonEditPage : ContentPage
{
	public PersonEditPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadPersonAsync();
    }

    private async Task LoadPersonAsync()
    {
        var viewModel = (PersonEditPageViewModel)BindingContext;
        await viewModel.LoadPersonAsync();
        // Falls nicht gleich angezeigt wird
        //await MainThread.InvokeOnMainThreadAsync(() => this.editGrid.BindingContext = viewModel.Project);

    }
}