using BookManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DAL.Repositories
{
    public class CategoryRepository
    {
        // calss nay chinh la Cabinet chi choi voi Category
        // no can nho den DbContext
        // GUI -> SERVICE -> REPO (HERE !) -> DBCONTEXT -> TABLE
        // Nho new repo moi lan dung
        private BookManagementDbContext _context;

        public List<BookCategory> GetAll()
        {
            _context = new();
            return _context.BookCategories.ToList(); // ta ko join vi chi can 
            // trong noi bo table Category (3 cot id, genre, desc)
        }
    }
}
