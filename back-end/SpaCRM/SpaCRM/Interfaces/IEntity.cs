namespace SpaCRM.Interfaces;

public interface IEntity
{
    Guid Id { get; set; }

    DateTime CreatedDate { get; set; }

    DateTime ModificationDate { get; set; }
}