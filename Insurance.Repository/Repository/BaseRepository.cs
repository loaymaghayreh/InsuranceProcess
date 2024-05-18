using Insurance.Domain.Interface;
using Insurance.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Repository.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context, ILogger<T> logger)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T t)
        {
            _context.Set<T>().AddAsync(t);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(T t)
        {
            _context.Set<T>().Update(t);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllForReadingAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
    }
}
