using Arenda_2._0.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Arenda_2._0
{
    public partial class MainWindow : Window
    {
        public MainWindow(User user)
        {
            InitializeComponent();

            statusUser.Text = user.RoleNavigation.Name;
            List<string> sortList = new List<string>() { "free", "nfree" };

            using (RentOfTorgPlacesContext db = new RentOfTorgPlacesContext())
            {
                if (user != null)
                {
                    statusUser.Text = user.RoleNavigation.Name;
                    MessageBox.Show($"{user.RoleNavigation.Name}: {user.Surname} {user.Name}. \r\t");
                }
                else
                {
                    statusUser.Text = "Гость";
                    MessageBox.Show("Гость");
                }
                productlistView.ItemsSource = db.Places.ToList();
            }
        }
        private void UpdatePlace()
        {

        }

        private void sortPlaceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (RentOfTorgPlacesContext db = new RentOfTorgPlacesContext())
            {
                if (sortPlacesComboBox.SelectedValue == "free")
                {
                    productlistView.ItemsSource = db.Places.OrderByDescending(u => u.PlaceNum).ToList();
                }

                if (sortPlacesComboBox.SelectedValue == "nfree")
                {
                    productlistView.ItemsSource = db.Places.OrderBy(u => u.PlaceNum).ToList();
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new LoginWin().Show();
            this.Close();
        }
        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (RentOfTorgPlacesContext db = new RentOfTorgPlacesContext())
            {
                if (searchBox.Text.Length > 0)
                {
                    productlistView.ItemsSource = db.Places.Where(db => db.PlaceNum.ToString().Contains(searchBox.Text)).ToList();
                }
            }
        }
    }
}
