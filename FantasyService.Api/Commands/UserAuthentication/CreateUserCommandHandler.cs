using MediatR;

namespace FantasyService.Api.Commands.UserAuthentication
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserDto>
    {
        public Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return HandleInternalAsync(request);
        }

        private async Task<CreateUserDto> HandleInternalAsync(CreateUserCommand request)
        {
            await Task.CompletedTask;
            return new CreateUserDto
            {
                UserId = 0
            };
        }
    }
}