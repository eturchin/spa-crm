using SpaCRM.Interfaces;

namespace SpaCRM.Data.Entities;

public sealed class RoleEntity : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime ModificationDate { get; set; }

    public string Name { get; set; }

    public List<UserEntity> Users { get; set; }
}