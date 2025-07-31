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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserService _userService = new();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            User x = new();
            x.FullName = txtFullName.Text;
            x.Gender = cbxGender.SelectedItem as string;
            x.DateOfBirth = dpDateOfBirth.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDateOfBirth.SelectedDate.Value) : null;
            x.Email = txtEmail.Text;
            x.Phone = txtPhone.Text;
            x.Address = txtAddress.Text;
            x.Username = txtUsername.Text;
            x.Password = txtPassword.Text;
            
            _userService.AddUser(x);
            this.Close();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void FillComboBox()
        {
            cbxGender.ItemsSource = new List<String> { "Nam", "Nữ", "Khác" };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
        }
    }
}
