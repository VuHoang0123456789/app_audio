using AutoMapper;
using Main.Application.Interfaces;
using Main.Application.TestTable.DTO;
using Main.Domian.Entities;
using MediatR;
using SharedKernel.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Application.TestTable.Queries;

public record TestGetAllQuery : GetAllQuery, IRequest<ResponeListDto<TestTableDto>>
{
}

public class TestGetAllQueryHandler : GetAllQueryHanlder<IMainDbContext, test_table>, IRequestHandler<TestGetAllQuery, ResponeListDto<TestTableDto>>
{
    public TestGetAllQueryHandler(IMainDbContext context, IMapper mapper, IMediator mediator) : base(context, mapper, mediator)
    {
    }

    public Task<ResponeListDto<TestTableDto>> Handle(TestGetAllQuery request, CancellationToken cancellationToken)
    {
        return this.Handle<TestTableDto>(request, cancellationToken);
    }
}
