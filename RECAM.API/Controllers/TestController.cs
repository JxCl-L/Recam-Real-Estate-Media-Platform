using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RECAM.Common.Exceptions;
using RECAM.Common.Responses;

namespace RECAM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("ok")]
        public IActionResult TestOk() => Ok(ApiResponse<string>.Ok("haha"));

        [HttpGet("notfound")]
        public IActionResult TestNotFound() => throw new NotFoundException("找不到哇");


    }
}
