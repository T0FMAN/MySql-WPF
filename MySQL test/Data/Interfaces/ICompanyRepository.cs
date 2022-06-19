using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySQL_test.Models;

namespace MySQL_test.Data.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<BindingList<Company>> GetAllAsBindingList();
    }
}
