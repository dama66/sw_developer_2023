namespace Swd.TimeManager.GuiMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           // MainPage = new AppShell();
           MainPage = new LoginPage();
        }
    }
}
