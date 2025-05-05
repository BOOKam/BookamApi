using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookamApi.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult Success(object data, string message)
        {
            return Ok(new {
                success = true,
                data,
                message
            });
        }

        protected IActionResult CreatedSuccess(string actionName, object routeValues, object data, string message)
        {
            return CreatedAtAction(actionName, routeValues, new
            {
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
                    // stackTrace = e?.StackTrace
                }
            });
        }
        protected IActionResult ErrorFromIdentityResult(IdentityResult result, string code = "IDENTITY_ERROR", string message = "Identity operation failed")
        {
            var details = result.Errors
                .GroupBy(e => e.Code)
                .Select(g => new
                {
                    field = g.Key,
                    errors = g.Select(e => e.Description).ToArray()
                }).ToArray();

            return BadRequest(new
            {
                success = false,
                error = new
                {
                    code,
                    message,
                    details
                }
            });
        }

        protected IActionResult ErrorFromModelState(ModelStateDictionary modelState, string code = "VALIDATION_ERROR")
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var errors = modelState
                .Where(x => x.Value?.Errors.Count > 0)
                .Select(x => new
                {
                    field = x.Key,
                    errors = x.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                }).ToArray();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            return BadRequest(new
            {
                success = false,
                error = new
                {
                    code,
                    message = "Validation failed",
                    details = errors
                }
            });
        }
    }
}