using BookManager.BLL.Services;
using BookManager.DAL.Models;
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

namespace BookManager.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookService _bookServices;
        public MainWindow()
        {
            InitializeComponent();
        }

       

        

        private void UpdateCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BookDataGrid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            BookDetail bookDetail = new();
            bookDetail.Show();
            this.Hide();
        }

        private void DeleteCreate_Click(object sender, RoutedEventArgs e)
        {
            Book selected = BookDataGrid.SelectedItem as Book;
            if (selected == null)
            {
                MessageBox.Show("chon di roi moi xoa duoc!","choose one", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBoxResult answer = MessageBox.Show("Do you really want to delete the selected book?", "Delete confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
                return;

            _bookServices = new();
            _bookServices.DeleteBook(selected);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _bookServices = new();
            BookDataGrid.ItemsSource = _bookServices.GetAll().ToList();
        }
    }
}