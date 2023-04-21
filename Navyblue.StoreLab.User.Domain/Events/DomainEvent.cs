// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : BaseDomainEvent.cs
// Created          : 2023-04-03  18:43
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-03  18:43
// ******************************************************************************************************
// <copyright file="BaseDomainEvent.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using Navyblue.BaseLibrary;

namespace Navyblue.StoreLab.User.Domain.Events;

public class DomainEvent : Entity, IDomainEvent
{
    public Guid EventId { get; }

    public DateTime OccurredOn { get; }

    public DomainEvent()
    {
        this.EventId = GuidUtility.NewSequentialGuid();
        this.OccurredOn = DateTime.UtcNow;
    }

}