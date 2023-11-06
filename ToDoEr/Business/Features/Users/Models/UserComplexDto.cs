using Business.Models.Base;
using Data.Entities;

namespace Business.Features.Users.Models;

public class UserComplexDto : BaseDto<UserComplexDto, User>
{
    public Guid Id { get; set; }
    public required string Email { get; set; }
}