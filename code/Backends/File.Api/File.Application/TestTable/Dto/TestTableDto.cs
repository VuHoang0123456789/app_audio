using AutoMapper;
using File.Domain.Entities;
using SharedKernel.Application.DTO;

namespace File.Application.TestTable.Dto;

public class TestTableDto : BaseAuditableDto
{
    public string? ma {  get; set; }
    public string? ten { get; set; }
}

public class TestTableDtoProfile : Profile
{
    public TestTableDtoProfile()
    {
        CreateMap<test_table, TestTableDto>();
        CreateMap<TestTableDto, test_table>();
    }
}
