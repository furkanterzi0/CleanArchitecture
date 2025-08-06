using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchDemo.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistiration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();


            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assm));
        }

    }
}
