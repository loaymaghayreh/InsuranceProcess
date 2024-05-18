using Insurance.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T t);
        Task UpdateAsync(T t);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllForReadingAsync();
    }
}
