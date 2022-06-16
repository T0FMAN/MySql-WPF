using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Dem.ekz_test___EF_MySQL.Data.Interfaces
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        Task<IEnumerable<T>> GetAll();
        bool Add(T item);
        bool Delete(T item);
        bool Update(T item);
        bool Save();
    }
}
