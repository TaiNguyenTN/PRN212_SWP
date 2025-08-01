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
using BLL.Services;
using DAL.Entities;

namespace ADNTesting
{
    /// <summary>
    /// Interaction logic for AppointmentBookedWindow.xaml
    /// </summary>
    public partial class AppointmentBookedWindow : Window
    {
        private AppointmentService _appointmentService = new();
        public User userCurrent { get; set; }
        public AppointmentBookedWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGird();
            FillComboBox();
        }

        public void FillComboBox()
        {
            cbxStatus.ItemsSource = null;
            cbxStatus.ItemsSource = new List<string> { "PENDING", "CONFIRMED", "COLLECTING_SAMPLE", "RECEIVED", "TESTING", "COMPLETED", "ALL" };
        }

        public void FillDataGird()
        {
            if (userCurrent != null)
            {
                dgv.ItemsSource = null;
                dgv.ItemsSource = _appointmentService.GetAllAppointments()
                    .Where(x => x.UserId == userCurrent.UserId)
                    .OrderByDescending(x => x.AppointmentId)
                    .ToList();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgv.ItemsSource = null;
            dgv.ItemsSource = _appointmentService.GetAppointmentsBySearch(txtSearch.Text)
                .Where(x => x.UserId == userCurrent.UserId)
                .OrderByDescending(x => x.AppointmentId)
                .ToList();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnViewDetail_Click(object sender, RoutedEventArgs e)
        {
            ViewAppointmentDetail view = new();
            Appointment? selected = dgv.SelectedItem as Appointment;
            if(selected == null)
            {
                MessageBox.Show("Hãy chọn một cuộc hẹn để xem chi tiết!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            view.selected = selected;
            view.ShowDialog();
        }

        private void cbxStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userCurrent == null)
                return;

            string? status = cbxStatus.SelectedItem?.ToString();
            var allAppointments = _appointmentService.GetAllAppointments()
                                                      .Where(x => x.UserId == userCurrent.UserId);

            if (!string.IsNullOrEmpty(status) && status != "ALL")
            {
                allAppointments = allAppointments.Where(x => x.Status == status);
            }

            dgv.ItemsSource = null;
            dgv.ItemsSource = allAppointments.OrderByDescending(x => x.AppointmentId).ToList();
            
        }
    }
}
