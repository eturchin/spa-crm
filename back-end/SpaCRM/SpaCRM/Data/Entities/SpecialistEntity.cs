using SpaCRM.Interfaces;

namespace SpaCRM.Data.Entities;

public class SpecialistEntity : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime ModificationDate { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public virtual List<ServiceEntity> Services { get; set; }
    
    public virtual List<BookingEntity> Bookings { get; set; }
}