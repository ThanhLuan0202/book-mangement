using BookManagement.DAL.Models;
using BookManagement.DAL.Repositories;
using System.Linq;

namespace BookManagement.BLL.Services
{
    //Gui WPF --> Service (BLL) --> REPO(DAL) --> DBContect --> Table
    //class này cx là 1 dạng cabinet, nhưng chỉ chơi với table
    //Book, chơi trong Ram, tính toán gì đó đưa trở lại GUI, hoặc lấy từ GUI đem xuống Repo -> từ đó xuống DBContext rồi xuống table 
    //nó sẽ bị gọi bởi GUI 
    //nhưng nó lại gọi Repo , cần khai báo biến Repo 
    public class BookService
    {
        private BookRepository _repo=new();

        
        public List<Book> GetAllBooks()
        {
            _repo = new BookRepository();
            return _repo.GetAll(); //phân trang, sort trước khi trả về.....
        }
        public void CreateBook(Book x)
        {
            _repo.Create(x);
        }
        public void UpdateBook(Book x)
        {
            _repo.Update(x);
        }

        public void DeleteBook(Book x)
        {
            _repo.Delete(x);
        }
        // ham search o service, select * from book where BookName like book_name vao "tu khoa"
        // and or desciption like _tu_khoa_dua_vao
        // ==
        // like contains(co chua tu khoa)
        // ten sach trong ram. Contains(tu khoa)
        // khong care hoa thuong moi ra nhieu ket qua 
        // ta phai doi tat ca ve lower case hoac upper case
        // databas - ram va keyword deu cung hoa, cung thuong

        public List<Book> GetBooksByNameAndDesc(string name, string desc)
        {
            name = name.ToLower();
            desc = desc.ToLower();
            // return _repo.GetAll().Where();
            //return _repo.GetAll().Where(x => x.BookName == ??? && x.Description == ??? );
            return _repo.GetAll().Where(x => x.BookName.ToLower().Contains(name) && x.Description.ToLower().Contains(desc)  ).ToList();
        }
    }
}
