using Order.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        public Task<int> SaveChangesAsync()
        {
            return Task.FromResult(1);
        }
    }
}
