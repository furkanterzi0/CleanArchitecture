using MyDDDApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDDDApp.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> getAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task AddAsync(Product product);
        Task DeleteAsync(Guid id);
    }
}
