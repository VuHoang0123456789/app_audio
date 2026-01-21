using AutoMapper;
using File.Application.Interfaces;
using File.Domain.Entities;
using MediatR;
using SharedKernel.Application.Commands;

namespace File.Application.TestTable.Commands;

public record TestTableDeleteCommand : DeleteCommand, IRequest<int>
{
}

public class TestTableDeleteCommandHanlder : DeleteCommandHanlder<IFileDbContext, test_table>, IRequestHandler<TestTableDeleteCommand, int>
{
    public TestTableDeleteCommandHanlder(IFileDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public Task<int> Handle(TestTableDeleteCommand request, CancellationToken cancellationToken)
    {
        return this.Handle((DeleteCommand)request, cancellationToken);
    }
}
