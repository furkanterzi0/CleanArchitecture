using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchDemo.Application.Interfaces.Repositories
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
    }
}
