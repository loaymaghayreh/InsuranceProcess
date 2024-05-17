using Insurance.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Interface
{
    public  interface ICustomerApplicationRepository
    {
        Task<CustomerApplication> GetByIdAsync(int id);
        Task AddAsync(CustomerApplication customerApplication);
        Task UpdateAsync(CustomerApplication customerApplication);
        Task DeleteAsync(int id);
        Task<List<CustomerApplication>> GetAllAsync();
    }
}
