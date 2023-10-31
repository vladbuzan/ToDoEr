using Data.Context;
using Data.Entities;
using Data.Repositories.Base;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ToDoErContext context) : base(context) { }
}