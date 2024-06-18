using SpaCRM.Interfaces;

namespace SpaCRM.Data.Entities;

public class UserEntity : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime ModificationDate { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string Image { get; set; }

    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public Guid RoleId { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }
    
    public RoleEntity RoleEntity { get; set; }
    
    public virtual List<BookingEntity> Bookings { get; set; }
}