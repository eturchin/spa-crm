using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpaCRM.Data;
using SpaCRM.ViewModels;

namespace SpaCRM.Commands.Booking.GetMy;

public class GetMyAppointmentsHandler(AppDbContext context, IMapperBase mapper) : IRequestHandler<GetMyAppointmentsQuery, GetMyAppointmentsResponse>
{
    public async Task<GetMyAppointmentsResponse> Handle(GetMyAppointmentsQuery request, CancellationToken cancellationToken)
    {
        _ = await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken) ??
            throw new NotImplementedException("User not found");

        var bookingEntities = await context.Bookings
            .AsNoTracking()
            .Where(x => x.UserId == request.UserId)
            .OrderByDescending(x => x.Date)
            .ToListAsync(cancellationToken);

        var models = new List<BookingViewModel>();
        
        foreach (var bookingEntity in bookingEntities)
        {
            var specialist = await context.Specialists
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == bookingEntity.SpecialistId, cancellationToken);
            
            var service = await context.Services
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == bookingEntity.ServiceId, cancellationToken);

            var model = mapper.Map<BookingViewModel>(bookingEntity);

            model.Specialist = mapper.Map<SpecialistViewModel>(specialist);
            model.Service = mapper.Map<ServiceViewModel>(service);
            
            models.Add(model);
        }
        
        return new GetMyAppointmentsResponse
        {
            Message = "Appointments have been successfully received",
            StatusCode = StatusCodes.Status200OK,
            Elements = models,
            Count = models.Count
        };
    }
}