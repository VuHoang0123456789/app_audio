using Admin.Domain.Enums;
using SharedKernel.Domain.Entities;

namespace Admin.Domain;

public class nguoi_dung : BaseEntity
{
    //thông tin người dùng
    public string? ten {  get; set; }
    public string? email { get; set; }
    public string? so_dien_thoai { get; set; }
    public int? gioi_tinh { get; set; } //1: nam, 2: nu, 3: khac
    public string? dia_chi { get; set; }
    public DateTime? ngay_sinh { get; set; }
    public Guid? anh_dai_dien_id { get; set; }

    //thời gian 
    public DateTime? last_login_at { get; set; }

    //trạng thái
    public trang_thai_nguoi_dung? trang_thai { get; set; } = trang_thai_nguoi_dung.Active;

    //otp
    public bool? two_factor_enabled { get; set; }

    public virtual ICollection<nguoi_dung_2_fa> ds_nguoi_dung_2_fa { get; set; }
    public virtual ICollection<tai_khoan> ds_tai_khoan { get; set; }
    public virtual ICollection<audit_logs> ds_audit_logs { get; set; }
    public virtual ICollection<lich_su_dang_nhap> ds_lich_su_dang_nhap { get; set; }
}
