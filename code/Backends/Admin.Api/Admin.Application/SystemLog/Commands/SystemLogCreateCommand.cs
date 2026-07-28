using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SharedKernel.Application.Commands;
using Admin.Application.SystemLog.DTO;
using Admin.Domain.Interfaces;
using Admin.Domain.Entities;
using AutoMapper;


namespace Admin.Application.SystemLog.Commands;

public record SystemLogCreateCommand : CreateCommand<SystemLogDto>, IRequest<bool>
{
}

public class SystemLogCreateCommandHandler : CreateCommandHanlder<IAdminContext, audit_logs>, IRequestHandler<SystemLogCreateCommand, bool>
{
    public SystemLogCreateCommandHandler(IAdminContext context, IMapper mapper, IMediator mediator)
        : base(context, mapper, mediator)
    {
    }

    public async Task<bool> Handle(SystemLogCreateCommand request, CancellationToken cancellationToken)
    {
        // call the generic create handler on the base class and return a bool result
        var dto = await base.Handle<SystemLogDto>(request, cancellationToken);
        return dto != null;
    }
}