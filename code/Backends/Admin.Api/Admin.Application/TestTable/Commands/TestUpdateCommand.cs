using Admin.Application.TestTable.Dto;
using Admin.Domain;
using Admin.Domain.Interfaces;
using AutoMapper;
using MediatR;
using SharedKernel.Application.Commands;

namespace Admin.Application.TestTable.Commands;

public record TestUpdateCommand : UpdateCommand<TestTableDto>, IRequest<TestTableDto>
{
}

public class TestUpdateCommandHanlder : UpdateCommandHanlder<IAdminContext, test_table>, IRequestHandler<TestUpdateCommand, TestTableDto>
{
    public TestUpdateCommandHanlder(IAdminContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public Task<TestTableDto> Handle(TestUpdateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    protected override void MapToEntity<TDto>(TDto data, test_table entity)
    {
        base.MapToEntity(data, entity);
    }
}
