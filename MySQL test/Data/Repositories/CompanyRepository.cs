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
        readonly AppDbContext _context;

        public CompanyRepository()
        {
            _context = new AppDbContext();
        }

        public async Task<BindingList<Company>> GetAllAsBindingList()
        {
            var companies = await _context.Companies.Include(n => n.Location)
                                                    .Include(n => n.Employees)
                                                    .ToListAsync();

            var bindingList = new BindingList<Company>(companies);

            return bindingList;
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
            _context.Update(item);
            return Save();
        }

        bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
