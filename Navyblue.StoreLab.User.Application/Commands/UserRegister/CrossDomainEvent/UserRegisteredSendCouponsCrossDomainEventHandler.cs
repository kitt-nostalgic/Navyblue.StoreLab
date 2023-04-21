// ******************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : UserRegisteredSendCouponsCrossDomainEvent.cs
// Created          : 2023-04-20  16:48
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-20  16:48
// ******************************************************************************************************
// <copyright file="UserRegisteredSendCouponsCrossDomainEvent.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using MediatR;

namespace Navyblue.StoreLab.User.Application.Commands.UserRegister.CrossDomainEvent;

public class UserRegisteredSendCouponsCrossDomainEventHandler : INotificationHandler<UserRegisteredSendCouponsCrossDomainEvent>
{
    public Task Handle(UserRegisteredSendCouponsCrossDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}