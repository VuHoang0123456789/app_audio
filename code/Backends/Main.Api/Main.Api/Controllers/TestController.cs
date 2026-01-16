using Main.Application.TestTable.Commands;
using Main.Application.TestTable.Queries;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Api;

namespace Main.Api.Controllers;

[Route("api/test")]
[ApiController]
public class TestController : BaseCrudApiController<
    TestGetAllQuery,
    TestGetByIdQuery,
    TestCreateCommand,
    TestUpdateCommand,
    TestDeleteCommand
    >
{
}
