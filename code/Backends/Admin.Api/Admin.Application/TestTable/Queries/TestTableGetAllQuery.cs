using Admin.Application.TestTable.Dto;
using Admin.Domain;
using Admin.Domain.Interfaces;
using AutoMapper;
using MediatR;
using SharedKernel.Application.Queries;

namespace Admin.Application.TestTable.Queries;

public record TestTableGetAllQuery : GetAllQuery, IRequest<ResponeListDto<TestTableDto>>
{
}

public class TestTableGetAllQueryHanlder : GetAllQueryHanlder<IAdminContext, test_table>, IRequestHandler<TestTableGetAllQuery, ResponeListDto<TestTableDto>>
{
    public TestTableGetAllQueryHanlder(IAdminContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
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
