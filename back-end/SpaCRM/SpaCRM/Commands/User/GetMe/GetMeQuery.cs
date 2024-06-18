using MediatR;

namespace SpaCRM.Commands.User.GetMe;

public class GetMeQuery(Guid id) : IRequest<GetMeResponse>
{
    public Guid Id { get; } = id;
}