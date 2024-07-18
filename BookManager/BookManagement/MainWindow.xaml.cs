using BookManagement.BLL.Services;
using BookManagement.DAL.Models;
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

namespace BookManagement_HoangNgocTrinh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookService _bookService = new();
        public  UserAccount User { get; set; }



        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void BookMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // day la cai ham se tu dc goi khi cua so mo len - EVENT xuat hien thi goij ham gi - lap trinh su kien - onclick() trong xu li nut bam ben trong HTML
            // ta se fill vao data grid. Tuy nhien ta se tach cau lenh fill vao grid thanh 1 ham rieng cho code de doc 
            // vi viec fill vao grid sex xuat hien nhieu lan
            //1. Mo man hinh len, fill drid trc tien
            //2 . Nhan nut tao moi cuon sach, mo man hinh tao moi, tao moi xong tro lai ma hinh ta phai F5 lai Grid 
            //3. Sua lai cuon sach, F5 lai grid
            //4. Xoa cuon sach , F5 lai grid
            // ham nay dc dung o nhieu noi , goi la helper, private la du
            LoadDataToGrid();

            HelloMsgLabel.Content = "Hello" + User.FullName;
            // cam nut bam neu laf staff
            if (User.Role == 2)
            {
                CreateButton.IsEnabled = false;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false; 
            }
        }
        // ham helper
        private void LoadDataToGrid()
        {
            BookListDataGrid.ItemsSource = null; // xoa luoi vi de phong co data
            BookListDataGrid.ItemsSource = _bookService.GetAllBooks();// tai lai data
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            BookDetailWindow detail = new();
            detail.ShowDialog();
            LoadDataToGrid();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // lay cuon sach user chon tu luoi de day sang man hinh Detail
            // ko lay tu table, phi, do toan bo sach da bo vao ram dang nam trong Grid
            //Book selected =(Book)BookListDataGrid.SelectedItem;
            // bi exception neu ep ko dc, vi du ko chon 1 dong nao thi lam sao ma ep kieu
            // bat exception hoac dung chieu khac 
            Book selected = BookListDataGrid.SelectedItem as Book;
                                                          // as la toan toan tu moi 
                                                          // ep thu ve trai thanh ve phai rang ep selected item thanh book
                                                          // neu ep ko thanh cong thi gan null thay vi tung Exception

            if (selected == null)
            {
                // chui neu muon edit ma ko chon sach de edit 
                MessageBox.Show("Please select a book before editing","Choose one", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            // xu li update 
            //MessageBox.Show(selected.BookName);
            // tim cach day, chuyen selected sang ben man hinh detail
            // 2 chang 1 nang ko di xuong data lay lai, co trong ram roi thi cung tro

            BookDetailWindow detail = new();
            // chot quan trong khac phan Create, ta phai day cuon sach selected sang ben kia 

            detail.EditedBook = selected;
            detail.ShowDialog(); // render show len
            LoadDataToGrid();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); // remove app khoi ram 
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Book selected = BookListDataGrid.SelectedItem as Book;
            
            if (selected == null)
            {
                
                MessageBox.Show("Please select a book before deleteting", "Choose one", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult answer = MessageBox.Show("Do you really want to delete the selected book?","Delete confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
                return;

            _bookService.DeleteBook(selected);
            LoadDataToGrid();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string name = BookNameTextBox.Text;
            string desc= DescriptionTextBox.Text;

            List<Book> result = _bookService.GetBooksByNameAndDesc(name, desc);

            BookListDataGrid.ItemsSource = null; // xoa luoi vi de phong co data
            BookListDataGrid.ItemsSource = result;// tai lai data
        }
    }
}