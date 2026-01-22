using File.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace File.Infrastructure.Data.Configurations;

public class TestTableConfiguration : IEntityTypeConfiguration<test_table>
{
    public void Configure(EntityTypeBuilder<test_table> builder)
    {
        builder.ToTable("test_table", "file");

        builder.Property(p => p.ma)
            .HasMaxLength(32)
            .IsRequired();

        builder.Property(p => p.ten)
            .HasMaxLength (255)
            .IsRequired();
    }
}
