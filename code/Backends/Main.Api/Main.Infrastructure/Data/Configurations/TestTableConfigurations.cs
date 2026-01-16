using Main.Domian.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Main.Infrastructure.Data.Configurations;

internal class TestTableConfigurations : IEntityTypeConfiguration<test_table>
{
    public void Configure(EntityTypeBuilder<test_table> builder)
    {
        builder.Property(p => p.ma)
            .HasMaxLength(32)
            .IsRequired();
        builder.Property(p => p.ten)
            .HasMaxLength(255)
            .IsRequired();
    }
}
