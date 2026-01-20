using Admin.Domain;
using AutoMapper;
using SharedKernel.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Application.TestTable.Dto;

public class TestTableDto : BaseAuditableDto
{
    public string ma { get; set; }
    public string ten { get; set; }
}

public class TestTableDtoProfile : Profile
{
    public TestTableDtoProfile()
    {
        CreateMap<test_table, TestTableDto>();
        CreateMap<TestTableDto, test_table>();
    }
}