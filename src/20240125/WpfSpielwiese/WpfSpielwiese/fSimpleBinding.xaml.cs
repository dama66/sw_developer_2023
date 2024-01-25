using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfSpielwiese
{
    /// <summary>
    /// Interaction logic for fSimpleBinding.xaml
    /// </summary>
    public partial class fSimpleBinding : Window
    {
        private Window _callerWindow;

        public fSimpleBinding()
        {
            InitializeComponent();
        }

        public fSimpleBinding(Window callerWindow):this()
        {
            _callerWindow = callerWindow;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _callerWindow.Show();
        }
    }
}
