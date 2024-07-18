using BookManagement.DAL.Models;
using BookManagement.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.BLL.Services
{
    public class UserAccountService
    {
        //GUI Service Repo DbContext table
        // Service can goi Repo, khai bao bien Repo
        private UserAccountRepository _repo = new();
        public UserAccount? Authenticate(string email, string pass)
        {
            return _repo.GetOne(email, pass);
        }
    }
}
