using BookManager.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace BookManager.DAL.Repositories
{
    public class BookRepository
    {
        private BookManagementDbContext _context;

        public List<Book> GetAll()
        {
            _context = new();
            return _context.Books.Include("BookCategory").ToList();
        }
        public void AddBook(Book book)
        {
            _context= new();
            _context.Books.Add(book);
            _context.SaveChanges();

        }
        public void UpdateBook(Book book)
        {
            _context= new();
            _context.Books.Update(book);
            _context.SaveChanges();
        }
        public void DeleteBook(Book book) 
        {
            _context = new();
            _context.Books.Remove(book);
            _context.SaveChanges();

        }
    }
}
