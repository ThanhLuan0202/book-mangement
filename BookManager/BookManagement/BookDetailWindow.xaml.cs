using BookManagement.BLL.Services;
using BookManagement.DAL.Models;
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

namespace BookManagement_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for BookDetailWindow.xaml
    /// </summary>
    public partial class BookDetailWindow : Window
    {
        // tui can 2 cai service
        private BookService _service = new(); // luu sach
        private CategoryService _cateService = new(); // danh sach cate

        // ta bo sung them 1 prop viet theo style full cx dc, style
        // auto-generate cx dc
        public Book EditedBook { get; set; } = null;
                                             // mon moi ~ _edited = null
        //int yob;
        // yob = 2004; -> set() ten bien kem dau = thi la set
        // cw(yob)  sout(yob) ten bien minh en thi la Get()
        public BookDetailWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // do vao comboBox 5 dong Category
            // chon Self Help nhung can con so 5 Pk
            BookCategoryIdComboBox.ItemsSource = _cateService.GetAllCategories();

            BookCategoryIdComboBox.DisplayMemberPath = "BookGenreType";

            BookCategoryIdComboBox.SelectedValuePath = "BookCategoryId";

            // select default category 1 trong new mode 
            BookCategoryIdComboBox.SelectedValue = 1;
            // kiem tra xem man hinh nay o mode nao: new/create hay edit/update 
            // bien/ prop EditedBook chinh la flag co dung check status/ mode cua man hinh nay . Neu co == null -> tao moi sach
            // Neu co != null -> ai do ben ngoai day cho no cuon sach (ben kia main day) thi la -> edit mode
            BookModeLabel.Content = "Tao moi cuon sach";

            if (EditedBook != null)
            {
                BookModeLabel.Content = "Chinh sua thong tin sach";
                // do data vao cac o text, lich, dropdown
                // luu y: disable o book id, ko cho edit pk - toang het tat ca fk neu co - hoac choi tro cascadde
                BookIdTextBox.Text = EditedBook.BookId.ToString();

                BookIdTextBox.IsEnabled = false; // cam edit Id cuon sach

                BookNameTextBox.Text = EditedBook.BookName;
                DescriptionTextBox.Text = EditedBook.Description;
                PublicationDateDatePicker.Text = EditedBook.PublicationDate.ToString();
                QuantityTextBox.Text = EditedBook.Quantity.ToString();
                PriceTextBox.Text = EditedBook.Price.ToString();
                AuthorTextBox.Text = EditedBook.Author;

                // jump den dung cate cuon sach dang co
                BookCategoryIdComboBox.SelectedValue = EditedBook.BookCategoryId;
                // thuc ra cai combobox nay da do san 5 loai sach doan code trc if()
                // chi can cho ai do select, ta chu dong select ung voi cate cua cuon sach dang edit 
            }
            
               
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            // chui trc khi save 
            // co the tach rieng ham validate()
            // if(validdate()) thi goi code duoi
            // MessageBox.Show(BookCategoryIdComboBox.SelectedValue.ToString());

            int quantity = int.Parse(QuantityTextBox.Text);
            if (quantity <= 0 || quantity > 10_000_000)
            {
                MessageBox.Show("The quantity must be between 1...10,000,000");
                return;
            }

            Book x = new Book() { };
            x.BookId = int.Parse(BookIdTextBox.Text);
            x.BookName = BookNameTextBox.Text;
            x.Description = DescriptionTextBox.Text;
            x.PublicationDate = DateTime.Now;
            x.Quantity = int.Parse(QuantityTextBox.Text);
            x.Price = double.Parse(PriceTextBox.Text);
            x.Author = AuthorTextBox.Text;
            x.BookCategoryId = int.Parse(BookCategoryIdComboBox.SelectedValue.ToString());

            
            // ve man hinh chinh F5 grid 
            if (EditedBook == null)
            {
                _service.CreateBook(x);
            }
            else
                _service.UpdateBook(x);
            this.Close(); // nhan nut save, save xong, phai tat cua so
            // thua ke ham close() cua class cha windows
            
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close(); // goi ham cua cha window
        }
    }
}
