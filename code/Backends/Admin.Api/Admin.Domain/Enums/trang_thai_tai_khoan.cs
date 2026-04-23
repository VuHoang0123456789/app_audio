using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.Enums;

public enum trang_thai_tai_khoan
{
    Active = 1,       // dùng bình thường
    Locked = 2,       // bị khóa (vd: sai pass nhiều lần)
    Disabled = 3      // admin tắt riêng account này
}
