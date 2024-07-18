using BookManager.BLL.Services;
using BookManager.DAL.Models;
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

namespace BookManager.UI
{
    /// <summary>
    /// Interaction logic for BookDetail.xaml
    /// </summary>
    public partial class BookDetail : Window
    {
        private BookCategoryService _cateService;
        public Book EditedBook { get; set; } = null;

        public BookDetail()
        {
            InitializeComponent();
        }

        private void BookCategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BookManagementDbContext _context = new();
            BookCategoryComboBox.ItemsSource = _context.BookCategories.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _cateService = new();
            BookCategoryComboBox.ItemsSource = _cateService.GetAll();
            BookCategoryComboBox.DisplayMemberPath = "BookGenreType";
            BookCategoryComboBox.SelectedValuePath = "BookCategoryId";
            BookCategoryComboBox.SelectedValue = 1;

            if (EditedBook != null)
            {

            }

        }
    }
}
