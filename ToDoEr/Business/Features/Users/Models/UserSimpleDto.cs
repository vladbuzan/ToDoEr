using Business.Models.Base;
using Data.Entities;

namespace Business.Features.Users.Models;

public class UserSimpleDto : BaseDto<UserSimpleDto, User>
{
    public required string Email { get; set; }
} 