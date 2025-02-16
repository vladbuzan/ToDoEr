using Application.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Infrastructure.Repositories;

public class BoardRepository(ToDoErContext context) : BaseRepository<Board>(context), IBoardRepository;