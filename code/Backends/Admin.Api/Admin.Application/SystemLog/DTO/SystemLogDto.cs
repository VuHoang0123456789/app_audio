using Admin.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Application.SystemLog.DTO;

public class SystemLogDto
{
    public Guid id { get; set; }
    public Guid nguoi_dung_id { get; set; }
    public string? ip_thiet_bi { get; set; }
    public string hanh_dong { get; set; }
    public string chuc_nang { get; set; }
    public string du_lieu_truoc { get; set; }
    public string du_lieu_sau { get; set; }
    public DateTime? ngay_tao { get; set; }
    public string? nguoi_tao { get; set; }
}

public class SystemLogDtoProfile : Profile
{
    public SystemLogDtoProfile()
    {
        CreateMap<audit_logs, SystemLogDto>();
        CreateMap<SystemLogDto, audit_logs>();
    }
}
