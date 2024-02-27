using Swd.TimeManager.GuiMaui.Model;

namespace Swd.TimeManager.GuiMaui;

public partial class ProjectPage : ContentPage
{
	TimeManagerDatabase _database;

	public ProjectPage()
	{
		InitializeComponent();
		_database = new TimeManagerDatabase();
	}

}