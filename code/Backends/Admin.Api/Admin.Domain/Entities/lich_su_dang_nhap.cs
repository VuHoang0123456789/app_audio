using SharedKernel.Domain.Entities;
using System.Net;

namespace Admin.Domain.Entities;

public class lich_su_dang_nhap
{
    public Guid id { get; set; }
    public Guid tai_khoan_id { get; set; }
    public Guid nguoi_dung_id { get; set; }
    public DateTime? thoi_gian_dang_nhap { get; set; }
    public string? trang_thai { get; set; }
    public string? ip_address { get; set; }
    public string? user_agent { get; set; }
    public virtual tai_khoan tai_khoan { get; set; }
    public virtual nguoi_dung nguoi_dung { get; set; }
}
