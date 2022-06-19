using MySQL_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQL_test.Data.Interfaces
{
    public interface ILoginRepository
    {
        Task<User> CheckUserLogin(string login, string password);
    }
}
