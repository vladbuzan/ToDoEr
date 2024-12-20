using Application.Abstractions.Services.CacheService;
using MessagePack;

namespace Infrastructure.Services.CacheService.Models;

public class UserCacheEntry : ICacheEntry
{
    [Key(0)]
    public Guid Id { get; set; }

    [Key(1)]
    public required string Email { get; set; }
}