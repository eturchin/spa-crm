using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SpaCRM.Data;

namespace SpaCRM.Commands.Token.GenerateToken;

public class GenerateTokenHandler(AppDbContext context, IConfiguration configuration) : IRequestHandler<GenerateTokenCommand, GenerateTokenResponse>
{
    public async Task<GenerateTokenResponse> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
    {
        var roleEntity = await context.Roles
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.Id == request.RoleId, cancellationToken: cancellationToken) ?? 
                         throw new ValidationException("Role not found.");
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, request.Id.ToString()),
            new(ClaimTypes.Name, request.PhoneNumber),
            new(ClaimTypes.Role, roleEntity.Name)
        };
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(14),
            SigningCredentials = credentials,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return new GenerateTokenResponse
        {
            Message = "Token have been successfully generated",
            StatusCode = StatusCodes.Status201Created,
            Item = tokenHandler.WriteToken(token)
        };
    }
}