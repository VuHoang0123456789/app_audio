using Admin.Application.TestTable.Dto;
using Admin.Domain;
using Admin.Domain.Interfaces;
using AutoMapper;
using MediatR;
using SharedKernel.Application.Commands;

namespace Admin.Application.TestTable.Commands;

public record TestCreateCommand : CreateCommand<TestTableDto>, IRequest<TestTableDto>
{
}

public class TestCreateCommandHanlder : CreateCommandHanlder<IAdminContext, test_table>, IRequestHandler<TestCreateCommand, TestTableDto>
{
    public TestCreateCommandHanlder(IAdminContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
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
