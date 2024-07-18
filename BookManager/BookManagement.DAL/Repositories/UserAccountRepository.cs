using BookManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DAL.Repositories
{
    public class UserAccountRepository
    {
        // GUI goi server -> repo -> DbContext -> table

        private BookManagementDbContext _context;
        // ham nao xai ham do phai new

        // bai nay minh ko get all account vi chua co nhu cau quan li toan bo account
        // bai nay chi can select 1 dong account where email = ? & pass = ? dau vao !!!
        // ham select ko tra ve toan bo account ma chi tra ve 1 account phu  hop user va pass dua vao
       public UserAccount GetOne(string email, string pass)
        {// hoac tra ve null do sai email , hoac sai pass, hoac ca hai
            // nguoc lai tra ve dung account dang login 
            // bai nay sai bieu thuc lambda (delegates) =>
            _context = new();
            //return _context.UserAccounts.FirstOrDefault(where).ToList();
            // menh de where tra ve true
            return _context.UserAccounts.FirstOrDefault(x => x.Email == email && x.Password == pass);
               // bool check(useraccount x)
        }
    }
}
