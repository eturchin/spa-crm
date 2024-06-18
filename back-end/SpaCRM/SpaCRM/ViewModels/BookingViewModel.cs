namespace SpaCRM.ViewModels;

public class BookingViewModel
{
    public Guid Id { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public DateTime Date { get; set; }
    
    public Guid UserId { get; set; }
    
    public ServiceViewModel? Service { get; set; }
    
    public SpecialistViewModel? Specialist { get; set; }
    
    public string ClientName { get; set; }
    
    public string PhoneNumber { get; set; }
}