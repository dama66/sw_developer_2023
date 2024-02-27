using Swd.TimeManager.GuiMaui.Model;

namespace Swd.TimeManager.GuiMaui;

public partial class AddProjectPage : ContentPage
{
	TimeManagerDatabase _database;

	public AddProjectPage()
	{
		InitializeComponent();
		_database = new TimeManagerDatabase();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		Project p = new Project();
		p.Name = "Test project";
		p.Created = DateTime.Now;
		p.CreatedBy = "David.Maier";

		await _database.SaveProjectAsync(p);
    }
}