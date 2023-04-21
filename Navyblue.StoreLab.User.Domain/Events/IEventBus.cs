// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : IEventBus.cs
// Created          : 2023-04-11  18:28
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  18:28
// ******************************************************************************************************
// <copyright file="IEventBus.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using MediatR;

namespace Navyblue.StoreLab.User.Domain.Events;

public interface IEventBus
{
    Task PublishAsync<T>(T @event) where T : class;

    void Subscribe<TEvent, TEventHandler>()
        where TEvent : INotification
        where TEventHandler : INotificationHandler<TEvent>, INotification;
}