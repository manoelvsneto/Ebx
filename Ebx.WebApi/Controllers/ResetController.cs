using Ebx.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ebx.WebApi.Controllers
{
    [ApiController]
    [Route("reset")]
    public class ResetController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;

        [HttpPost]
        public IActionResult ResetAll()
        {
            _accountService.Reset();
            return new ContentResult
            {
                Content = "OK",
                ContentType = "text/plain",
                StatusCode = 200
            };
        }
    }
}
