using Application.Models.Base;
using Domain.Entities;

namespace Application.Features.Users.Models;

public class UserSimpleDto : BaseDto<UserSimpleDto, User>
{
    public required string Email { get; set; }
}