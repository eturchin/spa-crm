using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpaCRM.Data;
using SpaCRM.ViewModels;

namespace SpaCRM.Commands.Specialist.GetList;

public class GetSpecialistsHandler(AppDbContext context, IMapperBase mapper) : IRequestHandler<GetSpecialistsQuery, GetSpecialistsResponse>
{
    public async Task<GetSpecialistsResponse> Handle(GetSpecialistsQuery request, CancellationToken cancellationToken)
    {
        var specialistEntities = await context.Specialists
            .AsNoTracking()
            .Where(x => x.Services.Any(serviceEntity => serviceEntity.Id == request.ServiceId))
            .OrderBy(x => x.LastName)
            .ToListAsync(cancellationToken);
        
        var model = mapper.Map<List<SpecialistViewModel>>(specialistEntities);

        return new GetSpecialistsResponse
        {
            Message = "Services have been successfully received",
            StatusCode = StatusCodes.Status200OK,
            Elements = model
        };
    }
}