using BookManagement.DAL.Models;
using BookManagement.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BLL.Services
{
    public class CategoryService
    {
        // thang nay goi Repo de lo table
        // chinh no lai bi GUI goi
        // GUI -> SERVICE - here - Repo ->...

        private CategoryRepository _repo = new(); // new luon ko so trong

        public List<BookCategory> GetAllCategories()
        {
            return _repo.GetAll();
        } // co the dung Expression Bodied
        
        // nho la do Category vao GUI 
    }
}
