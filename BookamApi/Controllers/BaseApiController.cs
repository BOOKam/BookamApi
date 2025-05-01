using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookamApi.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult Success(object data, string message = "Operation successful")
        {
            return Ok(new {
                success = true,
                data,
                message
            });
        }

        protected IActionResult Error(string? errorMessage, Exception? e, string? code = "ERROR")
        {
            return BadRequest(new {
                success = false,
                error = new {
                    code,
                    message = errorMessage,
                    inner = e?.InnerException?.Message,
                    stackTrace = e?.StackTrace
                }
            });
        }
    }
}