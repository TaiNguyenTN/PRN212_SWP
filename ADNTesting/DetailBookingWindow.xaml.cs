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
using System.Xaml;
using DAL.Entities;
using DAL.Repositories;

namespace ADNTesting
{
    /// <summary>
    /// Interaction logic for DetailBookingWindow.xaml
    /// </summary>
    public partial class DetailBookingWindow : Window
    {
        private ServiceRepository serviceRepository = new ServiceRepository();
        public Service serviceCurrent { get; set; }
        public User userCurrent { get; set; }

        private List<Service> allServices;
        public DetailBookingWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            allServices = serviceRepository.GetAll();

            // Bind ComboBox to Service objects
            cbxServiceType.ItemsSource = allServices;
            cbxServiceType.DisplayMemberPath = "ServiceName";
            cbxServiceType.SelectedValuePath = "ServiceId";

            // Select current service if available
            if (serviceCurrent != null)
            {
                cbxServiceType.SelectedItem = allServices.FirstOrDefault(s => s.ServiceId == serviceCurrent.ServiceId);
            }

            FillElements();
            FillComboBoxTestPurpose();
        }

        public void FillElements()
        {
            if (userCurrent != null)
            {
                txtFullName.Text = userCurrent.FullName;
                dpDob.SelectedDate = userCurrent.DateOfBirth?.ToDateTime(TimeOnly.MinValue);
                txtPhone.Text = userCurrent.Phone;
                txtEmail.Text = userCurrent.Email;
                cbxDistrict.Text = userCurrent.Address?.ToString();
            }

            if (serviceCurrent != null)
            {
                cbxServiceType.SelectedItem = allServices.FirstOrDefault(s => s.ServiceId == serviceCurrent.ServiceId);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBooking_Click(object sender, RoutedEventArgs e)
        {
            Appointment x = new();
            x.FullName = txtFullName.Text;
            x.Dob = DateOnly.FromDateTime(dpDob.SelectedDate ?? DateTime.Now);
            x.Phone = txtPhone.Text;
            x.Email = txtEmail.Text;
            x.Province = cbxProvince.Text;
        }

        public void FillComboBoxTestPurpose()
        {
            var selectedService = cbxServiceType.SelectedItem as Service;

            if (selectedService?.ServiceTestPurposes != null)
            {
                var testPurposeNames = selectedService.ServiceTestPurposes
                    .Where(stp => stp.IsActive == true && stp.TestPurpose != null && stp.TestPurpose.IsActive == true)
                    .Select(stp => stp.TestPurpose.TestPurposeName)
                    .ToList();

                cbxTestPurpose.ItemsSource = testPurposeNames;
            }
            else
            {
                cbxTestPurpose.ItemsSource = null;
            }
        }

        private void cbxServiceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillComboBoxTestPurpose();
        }
    }
}
