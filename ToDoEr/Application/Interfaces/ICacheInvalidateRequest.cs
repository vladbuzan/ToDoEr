﻿using MediatR;

namespace Application.Interfaces;

public interface ICacheInvalidateRequest : IRequest
{
    public Guid Id { get; init; }
}

public interface ICacheInvalidateRequest<out T> : IRequest<T>
{
    public Guid Id { get; init; }
}