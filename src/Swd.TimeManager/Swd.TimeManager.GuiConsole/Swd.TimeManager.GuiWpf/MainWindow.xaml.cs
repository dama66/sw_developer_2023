﻿using Swd.TimeManager.Business;
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

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            ProjectService projectService = new ProjectService();
            this.lstData.ItemsSource = projectService.ReadAll().ToList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            fEdit f = new fEdit(this);
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.Show();
            this.Hide();
        }

        private void btnEditTimeRecord_Click(object sender, RoutedEventArgs e)
        {
            fEditTimeRecord f = new fEditTimeRecord(this);
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.Show();
            this.Hide();
        }
    }
}