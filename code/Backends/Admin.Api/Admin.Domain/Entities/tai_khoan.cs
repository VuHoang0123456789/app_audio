using Admin.Domain.Enums;
using SharedKernel.Domain.Entities;

namespace Admin.Domain.Entities;

public class tai_khoan : BaseEntity
{
    public Guid nguoi_dung_id { get; set; }

    public string? ten_dang_nhap {  get; set; }
    public string? mat_khau { get; set; }
    public DateTime? last_login_at { get; set; }
    public int? so_lan_dang_nhap_that_bai { get; set; }
    public DateTime? thoi_diem_khoa_tai_khoan { get; set; }
    public trang_thai_tai_khoan trang_thai { get; set; } = trang_thai_tai_khoan.Active;

    public string? provider { get; set; } //Loại đăng nhập: local, google....
    public string? provider_user_id { get; set; } //id bên thứ 3 ví dụ: với local là null, google là sub...
    public virtual nguoi_dung nguoi_dung { get; set; }
    public virtual ICollection<lich_su_thay_doi_mat_khau> ds_lich_su_thay_doi_mat_khau { get; set; }
    public virtual ICollection<lich_su_dang_nhap> ds_lich_su_dang_nhap { get; set; }
}
