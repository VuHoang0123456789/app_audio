using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Domain.Enums;

public enum trang_thai_nguoi_dung
{
    Pending = 0,      // mới tạo, chưa hoàn tất (chưa verify email…)
    Active = 1,       // hoạt động bình thường
    Locked = 2,       // bị khóa (admin / vi phạm)
    Suspended = 3,    // tạm ngưng (có thể mở lại)
    Deleted = 4       // xóa mềm
}
