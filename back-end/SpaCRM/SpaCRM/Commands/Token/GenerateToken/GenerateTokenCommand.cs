using MediatR;

namespace SpaCRM.Commands.Token.GenerateToken;

public class GenerateTokenCommand: IRequest<GenerateTokenResponse>
{
    public Guid Id { get; init; }
    
    public Guid RoleId { get; init; }
    
    public string PhoneNumber { get; init; }
}