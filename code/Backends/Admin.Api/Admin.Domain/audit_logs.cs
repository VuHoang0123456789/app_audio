using SharedKernel.Domain.Entities;

namespace Admin.Domain;

public class audit_logs
{
    public Guid id { get; set; }
    public Guid? nguoi_dung_id { get; set; }
    public string? hanh_dong { get; set; }
    public string? du_lieu_truoc { get; set; }
    public string? du_lieu_sau { get; set; }
    public DateTime? ngay_tao { get; set; }
    public string? nguoi_tao { get; set; }
    public virtual nguoi_dung nguoi_dung { get; set; }
}
