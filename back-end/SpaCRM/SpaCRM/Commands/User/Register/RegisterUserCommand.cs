using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SpaCRM.Commands.User.Register;

public class RegisterUserCommand : IRequest<RegisterUserResponse>
{
    [Required][StringLength(35)] public string FirstName { get; set; }

    [Required][StringLength(35)] public string LastName { get; set; }

    [Required][StringLength(35)] public string PhoneNumber { get; set; }

    [Required]
    [StringLength(35)]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}