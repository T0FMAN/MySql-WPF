using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySQL_test.Data.Interfaces;
using MySQL_test.Models;
using System.ComponentModel;

namespace MySQL_test.Data.Repositories
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
            _context.Add(item);
            return Save();
        }

        public bool Delete(Company item)
        {
            _context.Remove(item);
            return Save();
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
