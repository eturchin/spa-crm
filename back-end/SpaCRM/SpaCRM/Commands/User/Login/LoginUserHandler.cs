using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpaCRM.Commands.Token.GenerateToken;
using SpaCRM.Data;

namespace SpaCRM.Commands.User.Login;

public class LoginUserHandler(AppDbContext context, ISender sender) : IRequestHandler<LoginUserCommand, LoginUserResponse>
{
    public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var userEntity = await context.Users
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber, cancellationToken) ??
                         throw new ValidationException("User not found with this phone number");

        if (!await VerifyPassword(request.Password, userEntity.PasswordHash, userEntity.PasswordSalt))
        {
            throw new ValidationException("Wrong password");
        }
        
        var generateTokenCommand = new GenerateTokenCommand
        {
            Id = userEntity.Id,
            RoleId = userEntity.RoleId,
            PhoneNumber = userEntity.PhoneNumber
        };

        var token = await sender.Send(generateTokenCommand, cancellationToken);
        
        return new LoginUserResponse
        {
            Message = "You have successfully logged in",
            StatusCode = StatusCodes.Status200OK,
            Item = token.Item
        };
    }
    
    private Task<bool> VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        
        return Task.FromResult(computedHash.SequenceEqual(passwordHash));
    }
}