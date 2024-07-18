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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UserAccountService _service = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // chan Login, phu hop voi new main
            string email = EmailTextBox.Text; //lay email da go
            string password = PasswordTextBox.Text;
            

            UserAccount user = _service.Authenticate(email, password);
            if (user == null)
            {
                MessageBox.Show("Invalid email or password.", "Wrong credentials",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            //kiem tra co la member ko, chui ko co quyen
            if(user.Role == 3)
            {
                MessageBox.Show("You have no permission to access this function! ", "Wrong permission", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }



            //mở màn hình MainWindow 
            //khai báo biến tạo object và render
            MainWindow mainWindow = new MainWindow();

            mainWindow.User = user;// trc khi render phai gan user da login thanh cong sang Main de disable nut nhan


            mainWindow.Show(); //Render
            //ẩn đi Login 
            this.Hide(); //vì class login kế thừa từ class cha window của OS, có sẵn hàm của Cha Hide() ẩn chính mình đi, ko cần render nữa 
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();//
        }
    }
}
