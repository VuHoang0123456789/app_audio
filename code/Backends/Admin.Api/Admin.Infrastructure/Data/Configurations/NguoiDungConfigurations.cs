using Admin.Domain;
using Admin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Admin.Infrastructure.Data.Configurations
{
    public class NguoiDungConfigurations : IEntityTypeConfiguration<nguoi_dung>
    {
        public void Configure(EntityTypeBuilder<nguoi_dung> builder)
        {
            builder.ToTable("nguoi_dung", "admin");

            builder.Property(p => p.ten)
                .HasMaxLength(255);

            builder.Property(p => p.so_dien_thoai)
                .HasMaxLength(11);

            builder.Property(p => p.email)
                .HasMaxLength(255);

            builder.Property(p => p.gioi_tinh)
                .HasMaxLength(32)
                .HasComment("1: nam, 2: nu, 3: khac");

            builder.Property(p => p.trang_thai)
                .HasMaxLength(32);

            builder.Property(p => p.two_factor_enabled)
                .HasDefaultValue(false);

            builder.HasMany(p => p.ds_tai_khoan)
                .WithOne(o => o.nguoi_dung)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.ds_nguoi_dung_2_fa)
                .WithOne(x => x.nguoi_dung)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.ds_lich_su_dang_nhap)
                .WithOne(x => x.nguoi_dung)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.ds_audit_logs)
                .WithOne(x => x.nguoi_dung)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class NguoiDung2FAConfigurations : IEntityTypeConfiguration<nguoi_dung_2_fa>
    {
        public void Configure(EntityTypeBuilder<nguoi_dung_2_fa> builder)
        {
            builder.ToTable("nguoi_dung_2_fa", "admin");

            builder.Property(p => p.totp_secret)
                .HasMaxLength(255);

            builder.Property(p => p.target)
                .HasMaxLength(11);

            builder.Property(p => p.code)
                .HasMaxLength(6);

            builder.Property(p => p.attempt_count)
                .HasMaxLength(32);

            builder.Property(p => p.max_attempts)
                .HasMaxLength(32);

            builder.Property(p => p.resend_count)
               .HasMaxLength(32);

            builder.Property(p => p.two_factor_method)
                 .HasMaxLength(32);
        }
    }
}
