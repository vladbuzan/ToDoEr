using Application.Models.Base;
using Domain.Entities;

namespace Application.Features.Users.Models;

public class UserComplexDto : BaseDto<UserComplexDto, User>
{
    public required string Email { get; set; }
}