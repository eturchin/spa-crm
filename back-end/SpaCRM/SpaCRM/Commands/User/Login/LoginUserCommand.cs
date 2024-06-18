using MediatR;

namespace SpaCRM.Commands.User.Login;

public class LoginUserCommand : IRequest<LoginUserResponse>
{
    public string PhoneNumber { get; init; }
    
    public string Password { get; init; }
}