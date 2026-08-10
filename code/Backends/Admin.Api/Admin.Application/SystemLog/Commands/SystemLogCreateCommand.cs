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

public record SystemLogCreateCommand : CreateCommand<SystemLogDto>, IRequest<SystemLogDto>
{
}

public class SystemLogCreateCommandHandler : CreateCommandHanlder<IAdminContext, audit_logs>, IRequestHandler<SystemLogCreateCommand, SystemLogDto>
{
    public SystemLogCreateCommandHandler(IAdminContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public  async Task<SystemLogDto> Handle(SystemLogCreateCommand request, CancellationToken cancellationToken)
    {
        return await Handle<SystemLogDto>(request, cancellationToken);
    }

    protected override audit_logs MapToEntity<Dto>(Dto dto)
    {
        var entity = base.MapToEntity(dto);
        entity.id = Guid.NewGuid();
        return entity;
    }
}