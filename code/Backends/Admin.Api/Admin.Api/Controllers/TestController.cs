using Admin.Application.TestTable.Commands;
using Admin.Application.TestTable.Queries;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Api;

namespace Admin.Api.Controllers;

[Route("api/test")]
[ApiController]
public class TestController : BaseCrudApiController<
    TestTableGetAllQuery,
    TestTableGetByIdQuery,
    TestCreateCommand,
    TestUpdateCommand,
    TestDeleteCommand
    >
{
}
