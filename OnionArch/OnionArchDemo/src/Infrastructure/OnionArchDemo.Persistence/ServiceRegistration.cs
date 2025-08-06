using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionArchDemo.Application.Interfaces.Repositories;
using OnionArchDemo.Persistence.Context;
using OnionArchDemo.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchDemo.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("memoryDb"));

            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
