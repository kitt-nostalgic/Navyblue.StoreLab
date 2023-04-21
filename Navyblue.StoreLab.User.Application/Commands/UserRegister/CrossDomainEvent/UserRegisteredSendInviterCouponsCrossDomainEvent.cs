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


using Navyblue.StoreLab.User.Domain.Events;

namespace Navyblue.StoreLab.User.Application.Commands.UserRegister.CrossDomainEvent;

public class UserRegisteredSendInviterCouponsCrossDomainEvent : DomainEvent
{
    public string InviteCode { get; set; }
}