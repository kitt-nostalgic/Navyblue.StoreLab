// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : EventBus.cs
// Created          : 2023-04-11  18:28
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  18:28
// ******************************************************************************************************
// <copyright file="EventBus.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Navyblue.StoreLab.User.Domain.Events;

public class EventBus : IEventBus
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly Dictionary<Type, List<Type>> _eventHandlers;

    public EventBus(IServiceScopeFactory serviceScopeFactory)
    {
        this._serviceScopeFactory = serviceScopeFactory;
        this._eventHandlers = new Dictionary<Type, List<Type>>();
    }

    public async Task PublishAsync<T>(T @event) where T : class
    {
        if (this._eventHandlers.TryGetValue(typeof(T), out List<Type> handlers))
        {
            using IServiceScope scope = this._serviceScopeFactory.CreateScope();
            foreach (Type handlerType in handlers)
            {
                object? handler = scope.ServiceProvider.GetService(handlerType);
                MethodInfo? method = handler?.GetType().GetMethod("HandleAsync");
                Task task = (Task)method?.Invoke(handler, new object?[] { @event })!;
                await task;
            }
        }
    }

    public void Subscribe<TEvent, TEventHandler>()
        where TEvent : INotification
        where TEventHandler : INotificationHandler<TEvent>, INotification
    {
        Type eventType = typeof(TEvent);
        Type handlerType = typeof(TEventHandler);

        if (!this._eventHandlers.ContainsKey(eventType))
        {
            this._eventHandlers.Add(eventType, new List<Type>());
        }

        if (!this._eventHandlers[eventType].Contains(handlerType))
        {
            this._eventHandlers[eventType].Add(handlerType);
        }
    }
}
