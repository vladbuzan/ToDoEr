﻿using MediatR;

namespace Business.MediatR.Interfaces;

public interface ICacheInvalidateRequest : IRequest
{
    public Guid Id { get; set; }
}

public interface ICacheInvalidateRequest<out T> : IRequest<T>
{
    public Guid Id { get; set; }
}