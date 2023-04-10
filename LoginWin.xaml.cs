using Arenda_2._0.Infrastructure;
using Arenda_2._0.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Arenda_2._0
{
    /// <summary>
    /// Логика взаимодействия для LoginWin.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        bool verify = true;
        int verifyCheck = 0;
        public LoginWin()
        {
            InitializeComponent();
        }
        async void disableButton()
        {
            loginButton.IsEnabled = false;
            await Task.Delay(TimeSpan.FromSeconds(10));
            loginButton.IsEnabled = true;
        }
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            using (RentOfTorgPlacesContext db = new RentOfTorgPlacesContext())
            {
                User user = db.Users.Where(u => u.Login == loginBox.Text && u.Password == passwordBox.Password).Include(r => r.RoleNavigation).FirstOrDefault() as User;

                // admin
                if (user != null)
                {
                    new MainWindow(user).Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неуспешная авторизация");
                    verifyCheck += 1;

                    // captcha view
                    captchaBox.Visibility = Visibility.Visible;
                    captchaBlock.Visibility = Visibility.Visible;
                    captchaBlock.Text = CaptchaBuilder.Refresh();
                    verify = false;

                    if (verifyCheck > 1)
                    {
                        disableButton();
                        captchaBlock.Text = CaptchaBuilder.Refresh();
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
