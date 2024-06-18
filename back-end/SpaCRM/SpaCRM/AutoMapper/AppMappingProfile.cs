using AutoMapper;
using SpaCRM.Commands.Booking.Create;
using SpaCRM.Commands.User.Register;
using SpaCRM.Data.Entities;
using SpaCRM.ViewModels;

namespace SpaCRM.AutoMapper;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        // Booking
        CreateMap<CreateBookingCommand, BookingEntity>();
        CreateMap<BookingEntity, BookingViewModel>();

        // Service
        CreateMap<ServiceEntity, ServiceViewModel>();
        
        // Specialist
        CreateMap<SpecialistEntity, SpecialistViewModel>();
        
        // User
        CreateMap<RegisterUserCommand, UserEntity>();
        CreateMap<UserEntity, UserViewModel>();
    }
}