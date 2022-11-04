using cloud_databases_cvgen.DAL.EntityTypeConfigurations;
using cloud_databases_cvgen.Models;
using Microsoft.EntityFrameworkCore;


namespace cloud_databases_cvgen.DAL.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly FunctionConfiguration _config;

        public DbSet<User> Users { get; set; }

        public DatabaseContext(FunctionConfiguration config)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                accountEndpoint: _config.CosmosAccountEndpoint,
                accountKey: _config.CosmosAccountKey,
                databaseName: _config.CosmosDatabaseName
            );
        }
    }
}
