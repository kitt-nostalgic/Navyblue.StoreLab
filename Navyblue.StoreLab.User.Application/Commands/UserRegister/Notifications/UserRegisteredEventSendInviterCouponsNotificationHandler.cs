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

/// <summary>
/// 此处应该有两种实现，一种是内存型，一种是外接RabbitMQ
/// 此处涉及到跨领域调用，需要将事件转换成跨领域通用事件，然后卡券领域需要切换成命令模式
/// 为了防止事件丢失，需要对数据进行持久化处理
/// </summary>
public class UserRegisteredEventSendInviterCouponsNotificationHandler : INotificationHandler<UserRegisteredEvent>
{
    private readonly IEventBus _eventsBus;

    public UserRegisteredEventSendInviterCouponsNotificationHandler(IEventBus eventsBus)
    {
        this._eventsBus = eventsBus;
    }

    public Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}