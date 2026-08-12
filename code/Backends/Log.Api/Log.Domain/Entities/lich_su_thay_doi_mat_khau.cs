using SharedKernel.Domain.Entities;

namespace Admin.Domain.Entities;

public class lich_su_thay_doi_mat_khau
{
    public Guid id { get; set; }
    public Guid? tai_khoan_id {  get; set; }
    public string? mat_khau_cu {  get; set; }
    public DateTime? ngay_tao { get; set; }
    public string? nguoi_tao { get; set; }
    public virtual tai_khoan tai_khoan { get; set; }
}
