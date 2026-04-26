using Admin.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Infrastructure.Data.Configurations
{
    public class TaiKhoanConfigurarations : IEntityTypeConfiguration<tai_khoan>
    {
        public void Configure(EntityTypeBuilder<tai_khoan> builder)
        {
            builder.ToTable("tai_khoan", "admin");

            builder.Property(p => p.ten_dang_nhap)
                .HasMaxLength(255);
            builder.Property(p => p.mat_khau)
                .HasMaxLength(255);
            builder.Property(p => p.so_lan_dang_nhap_that_bai)
                .HasMaxLength(32);
            builder.Property(p => p.trang_thai)
                .HasMaxLength(32);
            builder.Property(p => p.provider)
                .HasMaxLength(255);
            builder.Property(p => p.provider_user_id)
                .HasMaxLength(255);
            builder.HasOne(d => d.nguoi_dung)
                .WithMany(d => d.ds_tai_khoan)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(d => d.ds_lich_su_dang_nhap)
                .WithOne(d => d.tai_khoan)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(d => d.ds_lich_su_thay_doi_mat_khau)
                .WithOne(d => d.tai_khoan)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
