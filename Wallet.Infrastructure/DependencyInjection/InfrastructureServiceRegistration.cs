using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Application.Interfaces;
using Wallet.Infrastructure.Persistence;
using Wallet.Infrastructure.Repositories;

namespace Wallet.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WalletDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // services
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IMovementRepository, MovementRepository>();

            return services;
        }
    }
}
