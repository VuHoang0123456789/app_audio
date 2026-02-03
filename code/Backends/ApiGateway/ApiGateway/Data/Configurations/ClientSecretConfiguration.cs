using ApiGateway.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiGateway.Data.Configurations;

public class ClientSecretConfiguration : IEntityTypeConfiguration<ClientSecret>
{
    public void Configure(EntityTypeBuilder<ClientSecret> builder)
    {
        builder.ToTable("ClientSecrets", "identity", tb => tb.ExcludeFromMigrations());
        builder.HasKey(t => t.Id);
        builder.HasOne(t => t.Client)
           .WithMany(t => t.ClientSecrets)
           .HasForeignKey(t => t.ClientId);
    }
}
