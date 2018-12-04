using CookBook.Infrastructure.Commands.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected readonly ICommandDispatcher CommandDispatcher;

        public BaseController(ICommandDispatcher commandDispatcher)
        {
            CommandDispatcher = commandDispatcher;
        }
    }
}
