using BookManager.DAL.Models;
using BookManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BLL.Services
{
    public class BookCategoryService
    {
        private BookCategoryRepository _repo;

        public List<BookCategory> GetAll()
        {
            _repo = new();
            return _repo.GetAll();
        }
    }
}
