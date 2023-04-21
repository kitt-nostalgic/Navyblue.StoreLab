// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : IDomainEventNotification.cs
// Created          : 2023-04-11  17:51
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  17:51
// ******************************************************************************************************
// <copyright file="IDomainEventNotification.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using MediatR;

namespace Navyblue.StoreLab.User.Domain.Events;

public interface IDomainEventNotification<out TEventType> : IDomainEventNotification
{
    TEventType DomainEvent { get; }
}

public interface IDomainEventNotification : INotification
{
    Guid Id { get; }
}