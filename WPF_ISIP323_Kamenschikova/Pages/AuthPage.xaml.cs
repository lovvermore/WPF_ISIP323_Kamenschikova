using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_ISIP323_Kamenschikova.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();

        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("заполни поле ублюдок");
                return;
            }

            User user = Core.Context.Users.FirstOrDefault(l => l.Login == LoginTextBox.Text && l.Password == PasswordBox.Password);
            if (user == null)
            {
                MessageBox.Show("Ты больной ублюдок, напиши не говно");
            }
            else 
            {
                Core.UserEblan = user;
                MessageBox.Show("Еблан успешно вошел");
                NavigationService.Navigate(new AccountPage());
            }
            NavigationService.Navigate(new AccountPage());
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }
    }
}
