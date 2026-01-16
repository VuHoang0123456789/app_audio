using AutoMapper;
using Main.Application.Interfaces;
using Main.Application.TestTable.DTO;
using Main.Domian.Entities;
using MediatR;
using SharedKernel.Application.Commands;

namespace Main.Application.TestTable.Commands;

public record TestUpdateCommand : UpdateCommand<TestTableDto>, IRequest<TestTableDto>
{
}

public class TestUpdateCommandHandler : UpdateCommandHanlder<IMainDbContext, test_table>, IRequestHandler<TestUpdateCommand, TestTableDto>
{
    public TestUpdateCommandHandler(IMainDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public Task<TestTableDto> Handle(TestUpdateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
