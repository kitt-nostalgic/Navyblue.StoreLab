// ******************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : UserRegisteredEventNotification.cs
// Created          : 2023-04-11  17:53
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  17:53
// ******************************************************************************************************
// <copyright file="UserRegisteredEventNotification.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using Navyblue.StoreLab.User.Domain.Events;
using Navyblue.StoreLab.User.Domain.Events.UserRegister;

namespace Navyblue.StoreLab.User.Application.Commands.UserRegister.Notifications;

public class UserRegisteredEventNotification : BaseDomainNotification<UserRegisteredEvent>
{
    // [JsonConstructor]
    public UserRegisteredEventNotification(UserRegisteredEvent domainEvent, Guid id) : base(domainEvent, id)
    {
    }
}