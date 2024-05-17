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
    public class CustomerApplicationRepository : ICustomerApplicationRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CustomerApplicationRepository> _logger;

        public CustomerApplicationRepository(AppDbContext context, ILogger<CustomerApplicationRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<CustomerApplication> GetByIdAsync(int id)
        {
            return await _context.CustomerApplications.FindAsync(id);
        }

        public async Task AddAsync(CustomerApplication customerApplication)
        {
            try
            {
                _context.CustomerApplications.AddAsync(customerApplication);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error adding customer application: {ex.Message}", ex);
                throw;  // Rethrow the exception to ensure it's still caught by higher-level error handling
            }
        }

        public async Task UpdateAsync(CustomerApplication customerApplication)
        {
            _context.CustomerApplications.Update(customerApplication);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customerApplication = await _context.CustomerApplications.FindAsync(id);
            if (customerApplication != null)
            {
                _context.CustomerApplications.Remove(customerApplication);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CustomerApplication>> GetAllAsync()
        {
            return await _context.CustomerApplications.ToListAsync();
        }
    }
}
