using Swd.TimeManager.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Swd.TimeManager.GuiWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person.Id = 1;
            person.FirstName = "David";
            person.LastName = "Maier";

            Project project = new Project();
            project.Id = 1;
            project.Name = "TestProject";

            Model.Task task = new Model.Task();
            task.Id = 1;
            task.Name = "TestTask";

            TimeRecord record = new TimeRecord();
            record.Id = 1;
            record.Date = DateOnly.FromDateTime(DateTime.Now);
            record.Duration = 10;
            record.Person = person;
            record.Project = project;
            record.Task = task;



        }
    }
}