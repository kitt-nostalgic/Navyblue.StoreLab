// ******************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : UserRegisteredEventNotificationHandler.cs
// Created          : 2023-04-11  17:55
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  17:55
// ******************************************************************************************************
// <copyright file="UserRegisteredEventNotificationHandler.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using MediatR;
using Navyblue.StoreLab.User.Domain.Events;
using Navyblue.StoreLab.User.Domain.Events.UserRegister;

namespace Navyblue.StoreLab.User.Application.Commands.UserRegister.Notifications;

public class UserRegisteredEventSendCouponsNotificationHandler : INotificationHandler<UserRegisteredEvent>
{
    private readonly IEventBus _eventsBus;

    public UserRegisteredEventSendCouponsNotificationHandler(IEventBus eventsBus)
    {
        this._eventsBus = eventsBus;
    }

    public Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}