﻿namespace MediatorLib.Abstractions;

public interface IMediator
{
    TResponse Send<TResponse>(IRequest<TResponse> request);
}
