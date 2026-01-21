using File.Application.TestTable.Commands;
using File.Application.TestTable.Queries;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Api;

namespace File.Api.Controllers;

[Route("api/test")]
[ApiController]
public class TestController : BaseCrudApiController<
    TestTableGetAllQuery,
    TestTableGetByIdQuery,
    TestTableCreateCommand,
    TestTableUpdateCommand,
    TestTableDeleteCommand
    >
{
}
