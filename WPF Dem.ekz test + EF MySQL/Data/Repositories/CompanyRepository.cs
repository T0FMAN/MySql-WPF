using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Dem.ekz_test___EF_MySQL.Data.Interfaces;
using WPF_Dem.ekz_test___EF_MySQL.Models;

namespace WPF_Dem.ekz_test___EF_MySQL.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository()
        {
            _context = new AppDbContext();
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _context.Companies.ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();

            return saved > 0;
        }

        public bool Update(object data)
        {
            throw new NotImplementedException();
        }

        public bool Add(Company item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Company item)
        {
            throw new NotImplementedException();
        }

        public bool Update(Company item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
