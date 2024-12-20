using Application.Abstractions.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Infrastructure.Repositories;

public class UserRepository(ToDoErContext context) : BaseRepository<User>(context), IUserRepository;