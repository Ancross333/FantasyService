using FantasyService.Api.Commands.Requests;
using FantasyService.Api.Commands.UserAuthentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FantasyServic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserAuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CreateUserAsync(CreateUserRequest request)
        {
            var cmd = new CreateUserCommand(
                request.Email,
                request.Username,
                request.FirstName,
                request.LastName,
                request.Password
            );

            var data = await _mediator.Send(cmd);
            return Ok(data);
        }
    }
}