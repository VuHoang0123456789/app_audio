using Admin.Domain;
using Admin.Domain.Interfaces;
using AutoMapper;
using MediatR;
using SharedKernel.Application.Commands;

namespace Admin.Application.TestTable.Commands;

public record TestDeleteCommand : DeleteCommand, IRequest<int>
{
}

public class TestDeleteCommandHanlder : DeleteCommandHanlder<IAdminContext, test_table>, IRequestHandler<TestDeleteCommand, int>
{
    public TestDeleteCommandHanlder(IAdminContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public Task<int> Handle(TestDeleteCommand request, CancellationToken cancellationToken)
    {
        return this.Handle((DeleteCommand)request, cancellationToken);
    }
}
