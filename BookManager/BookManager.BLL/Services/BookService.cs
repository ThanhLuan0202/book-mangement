using BookManager.DAL.Models;
using BookManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BLL.Services
{
    public class BookService
    {
        private BookRepository _repo;

        public List<Book> GetAll()
        {
            _repo = new();
            return _repo.GetAll();
        }
        public void DeleteBook(Book book)
        {
            _repo = new();
            _repo.DeleteBook(book);
        }
    }
}
