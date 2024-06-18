using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpaCRM.Commands.Token.GenerateToken;
using SpaCRM.Data;
using SpaCRM.Data.Entities;

namespace SpaCRM.Commands.User.Register;

public class RegisterUserHandler(AppDbContext context, IMapperBase mapper, ISender sender) 
    : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = context.Users
            .AsNoTracking()
            .FirstOrDefault(x => x.PhoneNumber == request.PhoneNumber);

        if (existingUser != null)
        {
            throw new ValidationException("User already exist with this phone number");
        }
        
        await CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);

        var userEntity = mapper.Map<UserEntity>(request);
        
        userEntity.PasswordSalt = passwordSalt;
        userEntity.PasswordHash = passwordHash;
        userEntity.RoleId = Guid.Parse("855f7b5b-0a38-4d85-9afb-11c642bf47c2");
        
        await context.Users.AddAsync(userEntity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var generateTokenCommand = new GenerateTokenCommand
        {
            Id = userEntity.Id,
            RoleId = userEntity.RoleId,
            PhoneNumber = userEntity.PhoneNumber
        };

        var token = await sender.Send(generateTokenCommand, cancellationToken);
        
        return new RegisterUserResponse
        {
            Message = "User have been successfully received",
            StatusCode = StatusCodes.Status201Created,
            Item = token.Item
        };
    }
    
    private static Task CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        
        return Task.CompletedTask;
    }
}