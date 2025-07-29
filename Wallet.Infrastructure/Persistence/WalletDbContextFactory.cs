using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace Wallet.Infrastructure.Persistence
{
    public class WalletDbContextFactory : IDesignTimeDbContextFactory<WalletDbContext>
    {
        public WalletDbContext CreateDbContext(string[] args)
        {
            // Cargar configuración desde appsettings.json del proyecto Wallet.Api
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Wallet.Api"))
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<WalletDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new WalletDbContext(builder.Options);
        }
    }
}
