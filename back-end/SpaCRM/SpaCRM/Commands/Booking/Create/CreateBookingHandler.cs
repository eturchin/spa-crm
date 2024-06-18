using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpaCRM.Data;
using SpaCRM.Data.Entities;
using SpaCRM.ViewModels;

namespace SpaCRM.Commands.Booking.Create;

public class CreateBookingHandler(AppDbContext context, IMapperBase mapper) : IRequestHandler<CreateBookingCommand, CreateBookingResponse>
{
    public async Task<CreateBookingResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var existingBooking = await context.Bookings
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
                x.ServiceId == request.ServiceId &&
                x.SpecialistId == request.SpecialistId &&
                x.Date == request.Date, cancellationToken);

        if (existingBooking != null)
        {
            throw new ValidationException("This time is already busy");
        }
        
        var userEntity = await context.Users
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken) ??
                         throw new NotImplementedException("User not found");
            
        var bookingEntity = mapper.Map<BookingEntity>(request);

        if (string.IsNullOrEmpty(request.ClientName))
        {
            bookingEntity.ClientName = $"{userEntity.LastName} {userEntity.FirstName}";
        }

        if (string.IsNullOrEmpty(request.PhoneNumber))
        {
            bookingEntity.PhoneNumber = userEntity.PhoneNumber;
        }

        await context.AddAsync(bookingEntity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        
        var model = mapper.Map<BookingViewModel>(bookingEntity);

        return new CreateBookingResponse
        {
            Message = "Booking successfully created.",
            StatusCode = StatusCodes.Status201Created,
            Item = model
        };
    }
}