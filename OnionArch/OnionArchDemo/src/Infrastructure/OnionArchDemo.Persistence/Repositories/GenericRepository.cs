using Microsoft.EntityFrameworkCore;
using OnionArchDemo.Application.Interfaces.Repositories;
using OnionArchDemo.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchDemo.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }
    }
}
