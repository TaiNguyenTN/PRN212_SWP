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
using DAL.Entities;

namespace ADNTesting
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public User userCurrent { get; set; }
        public ManagerWindow()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnAppointment_Click(object sender, RoutedEventArgs e)
        {
            ManageAppointment manageAppointment = new ManageAppointment();
            manageAppointment.userCurrent = userCurrent;
            manageAppointment.ShowDialog();
        }

        private void btnService_Click(object sender, RoutedEventArgs e)
        {
            ManageServiceWindow manageService = new ManageServiceWindow();
            manageService.userCurrent = userCurrent;
            manageService.ShowDialog();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            ManageReportWindow manageReportWindow = new ManageReportWindow();
            manageReportWindow.userCurrent = userCurrent;
            manageReportWindow.ShowDialog();
        }
    }
}
