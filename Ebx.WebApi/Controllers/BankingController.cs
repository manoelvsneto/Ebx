using Ebx.Models;
using Ebx.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ebx.WebApi.Controllers
{
    [ApiController]
    [Route("event")]
    public class BankingController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;

        [HttpPost]
        public IActionResult Post([FromBody] Event.Request request)
        {
            int amount = (int)request.Amount;

            switch (request.Type.ToString().ToLower())
            {
                case "deposit":
                    _accountService.Deposit(request.Destination, request.Amount);
                    return Created("", new
                    {
                        destination = new
                        {
                            id = request.Destination,
                            balance = _accountService.GetBalance(request.Destination).Balance
                        }
                    });
                case "withdraw":
                    bool res = _accountService.Withdraw( request.Origin, request.Amount);
                    if (res)
                    {
                        return Created("", new
                        {
                            origin = new
                            {
                                id = request.Origin,
                                balance = _accountService.GetBalance(request.Origin).Balance
                            }
                        });
                    }
                    else
                    {
                        return NotFound((int)0);
                    }
                case "transfer":
                    bool resTransfer = _accountService.Transfer(request.Origin, request.Destination, amount);
                    if (resTransfer)
                    {
                        return Created("", new
                        {
                            origin = new { id = request.Origin, balance = _accountService.GetBalance(request.Origin).Balance },
                            destination = new { id = request.Destination, balance = _accountService.GetBalance(request.Destination).Balance }
                        });
                    }
                    else
                    {
                        return NotFound((int)0);
                    }
            }
            return NotFound(0);
        }
    }
}