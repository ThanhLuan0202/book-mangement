using BookManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.DAL.Repositories
{
    //class này đóng vai BookCabinet đã học 
    //nó sẽ có các hàm CRUD table book 
    //nhưng mình ko cần viết câu SQL, mà chỉ đi gọi đại sứ DB chính từ object từ class DBContext 
    //BDContext cx là 1 dạng cabinet nhưng chơi thẳng với database do bên trong nó có chuỗi kết nối CSDL 
    //class BookRepo chính là Cabinet nhưng chỉ chơi 1 table Book
    //cài cho nguyên lí S trong SOLID 
    //class này phải khai báo biến DBContext 
    //và có các hàm CRUD table Book 
    //vì chơi trực tiếp table -> thuộc level layer DAL Data Access Layer 
    public class BookRepository
    {
        private BookManagementDbContext _context;//ko new, lúc nào thao tác table mới new 
        // List<Book> _arr = new();
        //            _arr.Add(new Book());
        
        public List<Book> GetAll()
        {
            _context = new BookManagementDbContext();
            //Book là DBSet to hơn List, convert về list 
            //select * from book - lazy loading nghia la
            // select tu cuon sach trong table, new book() va add vao List<Book> books
            // nhung luoi ko join, ko co new category ben trong cuon sach, de dam bao performance
            // neu ta muon lay luon trong info cate phai chu dong bao join

            return _context.Books.Include("BookCategory").ToList();
            // da join xong table BookCategory qua bien BookCategory {get; set;}
        }
        public void Create(Book x)
        {
            // new DbContext() roi moi dung 
            _context = new();
            _context.Books.Add(x);
            _context.SaveChanges();
        }// da xong insert xuon sach, new Book tu GUI dua xuong, vi tu GUI ta co man hinh nhap moi cuon sach, pass tu Service 
        // Tuong tu ta co ham update(book), Delete(Book x), Delete(int BookId)
        //remove 1 object tu List, hoac remove theo Pk where Id 

        public void Update(Book x)
        {
            _context = new();
            _context.Books.Update(x);
            _context.SaveChanges();
        }
        public void Delete(Book x)
        {
            _context = new();
            _context.Books.Remove(x);
            _context.SaveChanges();
        }
    }
}


//Mô hình sử dụng class 
//Gui WPF --> Service (BLL) --> REPO(DAL) --> DBContect --> Table
//GUi WPF <-- Service (BLL) <-- REPO(DAL) <-- DBContect <-- Table