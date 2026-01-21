using AutoMapper;
using File.Application.Interfaces;
using File.Application.TestTable.Dto;
using File.Domain.Entities;
using MediatR;
using SharedKernel.Application.Queries;

namespace File.Application.TestTable.Queries;

public record TestTableGetAllQuery : GetAllQuery, IRequest<ResponeListDto<TestTableDto>>
{
}

public class TestTableGetAllQueryHanlder : GetAllQueryHanlder<IFileDbContext, test_table>, IRequestHandler<TestTableGetAllQuery, ResponeListDto<TestTableDto>>
{
    public TestTableGetAllQueryHanlder(IFileDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public Task<ResponeListDto<TestTableDto>> Handle(TestTableGetAllQuery request, CancellationToken cancellationToken)
    {
        return this.Handle<TestTableDto>(request, cancellationToken);
    }

    protected override IQueryable<test_table> QueryBuilder(IQueryable<test_table> query, dynamic filter, string search, GetAllQuery request)
    {
        return query;
    }
}
