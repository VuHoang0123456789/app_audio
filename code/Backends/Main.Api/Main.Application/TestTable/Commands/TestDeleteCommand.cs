using AutoMapper;
using Main.Application.Interfaces;
using Main.Domian.Entities;
using MediatR;
using SharedKernel.Application.Commands;

namespace Main.Application.TestTable.Commands;

public record TestDeleteCommand : DeleteCommand, IRequest<int>
{
}

public class TestDeleteCommandHandler : DeleteCommandHanlder<IMainDbContext, test_table>, IRequestHandler<TestDeleteCommand, int>
{
    public TestDeleteCommandHandler(IMainDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public Task<int> Handle(TestDeleteCommand request, CancellationToken cancellationToken)
    {
        return this.Handle((DeleteCommand)request, cancellationToken);
    }
}