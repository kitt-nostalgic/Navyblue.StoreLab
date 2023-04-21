// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : UserCreatedEventHandler.cs
// Created          : 2023-04-04  18:34
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-04  18:34
// ******************************************************************************************************
// <copyright file="UserCreatedEventHandler.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using MediatR;

namespace Navyblue.StoreLab.User.Domain.Events.UserRegister;

public class UserRegisteredEventHandler : INotificationHandler<UserRegisteredEvent>
{
    public Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
    {
        //事件处理逻辑
        //Console.WriteLine($"Order created: {notification.OrderId}");

        return Task.CompletedTask;
    }
}