using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpaCRM.Data;
using SpaCRM.ViewModels;

namespace SpaCRM.Commands.Service.GetList;

public class GetServicesHandler(AppDbContext context, IMapperBase mapper) : IRequestHandler<GetServicesQuery, GetServicesResponse>
{
    public async Task<GetServicesResponse> Handle(GetServicesQuery request, CancellationToken cancellationToken)
    {
        var serviceEntities = await context.Services
            .AsNoTracking()
            .OrderBy(x => x.Title)
            .ToListAsync(cancellationToken);
        
        var model = mapper.Map<List<ServiceViewModel>>(serviceEntities);

        return new GetServicesResponse
        {
            Message = "Services have been successfully received",
            StatusCode = StatusCodes.Status200OK,
            Elements = model
        };
    }
}