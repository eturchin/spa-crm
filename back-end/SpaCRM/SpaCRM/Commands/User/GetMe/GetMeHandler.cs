using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpaCRM.Data;
using SpaCRM.ViewModels;

namespace SpaCRM.Commands.User.GetMe;

public class GetMeHandler(AppDbContext context, IMapperBase mapper) : IRequestHandler<GetMeQuery, GetMeResponse>
{
    public async Task<GetMeResponse> Handle(GetMeQuery request, CancellationToken cancellationToken)
    {
        var userEntity = await context.Users
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken) ??
                         throw new ValidationException("User not found");

        var model = mapper.Map<UserViewModel>(userEntity);

        return new GetMeResponse
        {
            Message = "User have been successfully received",
            StatusCode = StatusCodes.Status200OK,
            Item = model
        };
    }
}