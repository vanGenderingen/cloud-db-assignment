using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using cloud_databases_cvgen.Models;

namespace cloud_databases_cvgen.DAL.EntityTypeConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToContainer("Users")
                .HasNoDiscriminator()
                .HasPartitionKey(u => u.Id);
        }
    }
}
