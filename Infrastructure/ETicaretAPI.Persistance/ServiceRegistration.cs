using ETicaretAPI.Application.Repositories.CustomerRepository;
using ETicaretAPI.Application.Repositories.OrderRepository;
using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Persistance.Contexts;
using ETicaretAPI.Persistance.Repositories.CustomerRepository;
using ETicaretAPI.Persistance.Repositories.OrderRepository;
using ETicaretAPI.Persistance.Repositories.ProductRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices( this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
