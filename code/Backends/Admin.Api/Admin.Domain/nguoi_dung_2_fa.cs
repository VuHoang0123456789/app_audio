using Admin.Domain.Enums;
using SharedKernel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain;

public class nguoi_dung_2_fa : BaseEntity
{
    public Guid nguoi_dung_id { get; set; }
    public string? totp_secret { get; set; } // dùng cho totp
    public string? target {  get; set; } //dành cho case gửi qua email || sms giá trị là số điện thoại hoặc email
    public string? code { get; set; }// mã otp 
    public DateTime? expires_at { get; set; } // hạn sử dụng
    public DateTime? used_at { get; set; } // thời điểm sử dụng
    public int? attempt_count { get; set; } // số lần nhập sai
    public int? max_attempts { get; set; } = 5; // giới hạn nhập sai otp
    public int? resend_count { get; set; } // số lần gửi otp
    public DateTime? last_sent_at { get; set; }// thời điểm gửi gần nhất
    public loai_otp? two_factor_method { get; set; } = loai_otp.Totp;
    public virtual nguoi_dung nguoi_dung { get; set; }
}
