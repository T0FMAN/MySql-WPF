using Microsoft.EntityFrameworkCore;
using MySQL_test.Data.Interfaces;
using MySQL_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_test.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;

        public LoginRepository()
        {
            _context = new AppDbContext();
        }

        public async Task<User> CheckUserLogin(string login, string password)
        {
            return await _context.Users.AsNoTracking()
                                       .Include(n => n.Post)
                                       .FirstOrDefaultAsync(n => n.Login == login && n.Password == password);
        }
    }
}
