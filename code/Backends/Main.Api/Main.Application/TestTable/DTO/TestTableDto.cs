using AutoMapper;
using Main.Domian.Entities;
using SharedKernel.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.TestTable.DTO;

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