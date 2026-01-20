using Admin.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Infrastructure.Data.Configurations;

public class TestTableConfigurations : IEntityTypeConfiguration<test_table>
{
    public void Configure(EntityTypeBuilder<test_table> builder)
    {
        builder.ToTable("test_table", "admin");

        builder.Property(p => p.ma)
            .HasMaxLength(32)
            .IsRequired();

        builder.Property(p => p.ten)
            .HasMaxLength(255)
            .IsRequired();
    }
}
