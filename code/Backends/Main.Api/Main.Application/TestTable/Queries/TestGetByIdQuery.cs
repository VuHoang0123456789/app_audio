using AutoMapper;
using Main.Application.Interfaces;
using Main.Application.TestTable.DTO;
using Main.Domian.Entities;
using MediatR;
using SharedKernel.Application.Queries;

namespace Main.Application.TestTable.Queries;

public record TestGetByIdQuery : GetByIdQuery, IRequest<TestTableDto>
{
}

public class TestGetByIdQueryHandler : GetByIdQueryHanlder<IMainDbContext, test_table>, IRequestHandler<TestGetByIdQuery, TestTableDto>
{
    public TestGetByIdQueryHandler(IMainDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public Task<TestTableDto> Handle(TestGetByIdQuery request, CancellationToken cancellationToken)
    {
        return this.Handle<TestTableDto>(request, cancellationToken);
    }
}
