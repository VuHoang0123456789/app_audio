using AutoMapper;
using File.Application.Interfaces;
using File.Application.TestTable.Dto;
using File.Domain.Entities;
using MediatR;
using SharedKernel.Application.Queries;

namespace File.Application.TestTable.Queries;

public record TestTableGetByIdQuery : GetByIdQuery, IRequest<TestTableDto>
{
}

public class TestTableGetByIdQueryHanlder : GetByIdQueryHanlder<IFileDbContext, test_table>, IRequestHandler<TestTableGetByIdQuery, TestTableDto>
{
    public TestTableGetByIdQueryHanlder(IFileDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public Task<TestTableDto> Handle(TestTableGetByIdQuery request, CancellationToken cancellationToken)
    {
        return this.Handle<TestTableDto>(request, cancellationToken);
    }
}
