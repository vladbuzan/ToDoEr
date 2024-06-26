﻿using Data.Entities;
using Data.Repositories.Base;

namespace Data.Repositories.Interfaces;

public interface IToDoListRepository : IBaseRepository<ToDoList>
{
    public Task<int> GetToDoCountByIdAsync(Guid id, CancellationToken cancellationToken);
}