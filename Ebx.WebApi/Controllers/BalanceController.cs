using Ebx.Models;
using Ebx.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ebx.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BalanceController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public BalanceController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        ///  teste
        /// </summary>
        /// <param name="account_id"></param>
        /// <returns></returns>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetBalance([FromQuery] string account_id)
        {
            Account account = _accountService.GetBalance(account_id);
            if (account != null)
            {
                return Ok(account.Balance);
            }
            return NotFound(0);
        }
    }
}
