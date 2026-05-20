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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            List<Film> films = Core.Context.Films.ToList();
            InfoList.ItemsSource = films;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SortSearch();
        }

        private void SortSearch() 
        {
            // 1 - получить полные данные из БД
            List<Film> films = Core.Context.Films.ToList();
            // 2 - Отсортировать по названи или рейтингу
            // проверка выбрал ли пользователь сортировку
            switch (SortComboBox?.SelectedIndex)
            { 
                case 1:
                     films = films.OrderBy(f => f.Name).ToList();
                    break;
                case 2:
                    films = films.OrderBy(f => f.Rating).ToList();
                    break;
            }
            // 3 - Отфильтровать по названию
            // проврка, ввёл ли пользователь что-то
            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text) && SearchTextBox.Text != "Поиск...")
            { 
                films = films.Where(f => f.Name.ToLower().Contains(SearchTextBox.Text.ToLower())).ToList();
            }

            // 4 - зашрузить итоговый списко в listbox
            InfoList.ItemsSource = films;
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortSearch();
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {

            if (Core.UserEblan == null)
            {
                NavigationService.Navigate(new AuthPage());
            }
            else
            {
                NavigationService.Navigate(new AccountPage());
            }
        }

        private void ChooseFilm_Click(object sender, RoutedEventArgs e)
        {
            Film film = (sender as Button).DataContext as Film;
            if (film != null)
                NavigationService.Navigate(new FilmPage(film));
        }
    }
}
