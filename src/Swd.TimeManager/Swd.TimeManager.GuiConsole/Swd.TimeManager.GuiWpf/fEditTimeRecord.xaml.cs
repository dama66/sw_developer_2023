using Swd.TimeManager.Business;
using Swd.TimeManager.GuiWpf.ViewModels;
using Swd.TimeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Swd.TimeManager.GuiWpf
{
    /// <summary>
    /// Interaction logic for fEdit.xaml
    /// </summary>
    public partial class fEditTimeRecord : Window
    {
        private Window _callerWindow;
        private Person _person;
        public fEditTimeRecord()
        {
            InitializeComponent();
        }

        public fEditTimeRecord(Window callerWindow):this() 
        {
            _callerWindow = callerWindow;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _callerWindow.Show();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new TimeRecordViewModel();
        }
    }
}
