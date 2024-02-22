namespace Swd.TimeManager.GuiMaui;

public partial class IntroPage : ContentPage
{
	public IntroPage()
	{
		InitializeComponent();
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		if(await isAutenticated())
		{
			await Shell.Current.GoToAsync("///main");
		}
		else
		{
            await Shell.Current.GoToAsync("///login");
        }
		base.OnNavigatedTo(args);
	}

	private async Task<Boolean> isAutenticated()
	{
		await Task.Delay(1000);
		var hasAutenticated = await SecureStorage.GetAsync("hasAuthKey");
		return !(hasAutenticated == null);
	}

}