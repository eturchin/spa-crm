using MediatR;

namespace SpaCRM.Commands.Specialist.GetList;

public class GetSpecialistsQuery : IRequest<GetSpecialistsResponse>
{
    public Guid ServiceId { get; init; }
}