using SpaCRM.Interfaces;

namespace SpaCRM.Data.Entities;

public class BookingEntity : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime ModificationDate { get; set; }
    
    public DateTime Date { get; set; }
    
    public Guid ServiceId { get; set; }

    public Guid? UserId { get; set; }
    
    public Guid? SpecialistId { get; set; }
    
    public string ClientName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public virtual UserEntity User { get; set; }  
    
    public virtual ServiceEntity Service { get; set; }  
    
    public virtual SpecialistEntity? Specialist { get; set; }  
}