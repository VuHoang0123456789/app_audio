using AutoMapper;
using File.Application.Interfaces;
using File.Application.TestTable.Dto;
using File.Domain.Entities;
using MediatR;
using SharedKernel.Application.Commands;

namespace File.Application.TestTable.Commands;

public record TestTableCreateCommand : CreateCommand<TestTableDto>, IRequest<TestTableDto> 
{
}

public class TestTableCreateCommandHanlder : CreateCommandHanlder<IFileDbContext, test_table>, IRequestHandler<TestTableCreateCommand, TestTableDto>
{
    public TestTableCreateCommandHanlder(IFileDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public Task<TestTableDto> Handle(TestTableCreateCommand request, CancellationToken cancellationToken)
    {
        return this.Handle<TestTableDto>(request, cancellationToken);
    }

    protected override test_table MapToEntity<TDto>(TDto data)
    {
        return base.MapToEntity(data);
    }
}
