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
    public class LichSuDangNhapConfigurations : IEntityTypeConfiguration<lich_su_dang_nhap>
    {
        public void Configure(EntityTypeBuilder<lich_su_dang_nhap> builder)
        {
            builder.ToTable("lich_su_dang_nhap", "admin");
            builder.Property(p => p.trang_thai)
                .HasMaxLength(32);
            builder.Property(p => p.ip_address)
                .HasMaxLength(32);
            builder.Property(p => p.user_agent)
                .HasMaxLength(1024);
        }
    }
    public class LichSuThayDoiMatKhauConfigurations : IEntityTypeConfiguration<lich_su_thay_doi_mat_khau>
    {
        public void Configure(EntityTypeBuilder<lich_su_thay_doi_mat_khau> builder)
        {
            builder.ToTable("lich_su_thay_doi_mat_khau", "admin");
            builder.Property(p => p.mat_khau_cu)
                .HasMaxLength(255);
            builder.Property(p => p.nguoi_tao)
                .HasMaxLength(255);
        }
    }
    public class AuditLogsConfigurations : IEntityTypeConfiguration<audit_logs>
    {
        public void Configure(EntityTypeBuilder<audit_logs> builder)
        {
            builder.ToTable("audit_logs", "admin");
            builder.Property(p => p.hanh_dong)
                .HasMaxLength(255);
            builder.Property(p => p.nguoi_tao)
                .HasMaxLength(255);
        }
    }
}
