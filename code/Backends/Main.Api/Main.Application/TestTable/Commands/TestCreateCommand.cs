using AutoMapper;
using Main.Application.Interfaces;
using Main.Application.TestTable.DTO;
using Main.Domian.Entities;
using MediatR;
using SharedKernel.Application.Commands;

namespace Main.Application.TestTable.Commands;

public record TestCreateCommand : CreateCommand<TestTableDto>, IRequest<TestTableDto>
{
}

public class TestCreateCommandHandler : CreateCommandHanlder<IMainDbContext, test_table>, IRequestHandler<TestCreateCommand, TestTableDto>
{
    public TestCreateCommandHandler(IMainDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public Task<TestTableDto> Handle(TestCreateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    protected override test_table MapToEntity<TDto>(TDto data)
    {
        return base.MapToEntity(data);
    }
}