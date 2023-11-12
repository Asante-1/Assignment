using Hubtel.Vault.Api.Data.Configuration;
using Hubtel.Vault.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using Npgsql;

namespace Hubtel.Vault.Api.Data
{
    public class AppDbContext : IdentityDbContext<WalletUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Wallet> Wallet { get; set; }

        public class DapperContext
        {
            private readonly IConfiguration _configuration;
            public DapperContext(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public IDbConnection CreateConnection()
                => new NpgsqlConnection(_configuration.GetConnectionString("HubtelVault"));
        }
    }
}
 