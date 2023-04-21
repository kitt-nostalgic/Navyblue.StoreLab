// ***********************************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : IDomainEvent.cs
// Created          : 2023-04-02  19:34
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-02  19:34
// ***********************************************************************************************************************
// <copyright file="IDomainEvent.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************


using MediatR;

namespace Navyblue.StoreLab.User.Domain.Events;

public interface IDomainEvent : INotification
{
    Guid EventId { get; }

    DateTime OccurredOn { get; }
}