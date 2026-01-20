using Admin.Application.TestTable.Dto;
using Admin.Domain;
using Admin.Domain.Interfaces;
using AutoMapper;
using MediatR;
using SharedKernel.Application.Queries;

namespace Admin.Application.TestTable.Queries;

public record TestTableGetByIdQuery : GetByIdQuery, IRequest<TestTableDto> 
{
}

public class TestTableGetByIdQueryHanlder : GetByIdQueryHanlder<IAdminContext, test_table>, IRequestHandler<TestTableGetByIdQuery, TestTableDto>
{
    public TestTableGetByIdQueryHanlder(IAdminContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public Task<TestTableDto> Handle(TestTableGetByIdQuery request, CancellationToken cancellationToken)
    {
        return this.Handle<TestTableDto>(request, cancellationToken);
    }
}
