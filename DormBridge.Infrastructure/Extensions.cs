using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormBridge.Domain.Repositories;
using DormBridge.Infrastructure.DAL;
using DormBridge.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DormBridge.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DormBridgeDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
