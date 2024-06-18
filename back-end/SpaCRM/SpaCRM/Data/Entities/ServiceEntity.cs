using SpaCRM.Interfaces;

namespace SpaCRM.Data.Entities;

public class ServiceEntity : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime ModificationDate { get; set; }
    
    public string Title { get; set; }
    
    public double Price { get; set; }
    
    public virtual List<SpecialistEntity> Specialists { get; set; }
    
    public virtual List<BookingEntity> Bookings { get; set; }
}