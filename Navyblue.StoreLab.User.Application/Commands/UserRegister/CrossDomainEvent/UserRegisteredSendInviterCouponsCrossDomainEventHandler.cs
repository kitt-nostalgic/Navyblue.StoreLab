// ******************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : UserRegisteredSendInviterCouponsCrossDomainEvent.cs
// Created          : 2023-04-20  16:49
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-20  16:49
// ******************************************************************************************************
// <copyright file="UserRegisteredSendInviterCouponsCrossDomainEvent.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using MediatR;

namespace Navyblue.StoreLab.User.Application.Commands.UserRegister.CrossDomainEvent;

public class UserRegisteredSendInviterCouponsCrossDomainEventHandler: INotificationHandler<UserRegisteredSendInviterCouponsCrossDomainEvent>
{
    public Task Handle(UserRegisteredSendInviterCouponsCrossDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}