using System.Runtime.Serialization;
using MediatR;

namespace FantasyService.Api.Commands.UserAuthentication
{
    public class CreateUserCommand : IRequest<CreateUserDto>
    {
        [DataMember]
        public string Email {get; init;}
        [DataMember]
        public string Username {get; init;}
        [DataMember]
        public string FirstName {get; init;}
        [DataMember]
        public string LastName {get; init;}
        [DataMember]
        public string Password {get; init;}

        public CreateUserCommand(string email, string username, string firstName, string lastName, string password)
        {
            Email = email;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }

    public record CreateUserDto
    {
        public int UserId {get; init;}
    }
}