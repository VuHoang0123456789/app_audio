using AutoMapper;
using File.Application.Interfaces;
using File.Application.TestTable.Dto;
using File.Domain.Entities;
using MediatR;
using SharedKernel.Application.Commands;

namespace File.Application.TestTable.Commands;

public record TestTableUpdateCommand : UpdateCommand<TestTableDto>, IRequest<TestTableDto> 
{
}

public class TestTableUpdateCommandHanlder : UpdateCommandHanlder<IFileDbContext, test_table>, IRequestHandler<TestTableUpdateCommand, TestTableDto>
{
    public TestTableUpdateCommandHanlder(IFileDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public Task<TestTableDto> Handle(TestTableUpdateCommand request, CancellationToken cancellationToken)
    {
        return this.Handle<TestTableDto>(request, cancellationToken);
    }

    protected override void MapToEntity<TDto>(TDto data, test_table entity)
    {
        base.MapToEntity(data, entity);
    }
}
