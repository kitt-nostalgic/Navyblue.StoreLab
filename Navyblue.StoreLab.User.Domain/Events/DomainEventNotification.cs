// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : BaseDomainNotification.cs
// Created          : 2023-04-11  17:52
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  17:52
// ******************************************************************************************************
// <copyright file="BaseDomainNotification.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


namespace Navyblue.StoreLab.User.Domain.Events;

public class DomainEventNotification<T> : IDomainEventNotification<T>
    where T : IDomainEvent
{
    public T DomainEvent { get; }

    public Guid Id { get; }

    public DomainEventNotification(T domainEvent, Guid id)
    {
        this.Id = id;
        this.DomainEvent = domainEvent;
    }
}