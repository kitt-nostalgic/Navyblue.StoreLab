// ***********************************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : UserCreatedEvent.cs
// Created          : 2023-04-03  21:04
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-03  21:04
// ***********************************************************************************************************************
// <copyright file="UserCreatedEvent.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************

namespace Navyblue.StoreLab.User.Domain.Events.UserRegister;

/// <summary>
/// 
/// </summary>
/// <seealso cref="DomainEvent" />
public class UserRegisteredEvent : DomainEvent
{
    /// <summary>
    /// Gets the name of the user.
    /// </summary>
    public string UserName { get; private set; }

    /// <summary>
    /// Gets the email.
    /// </summary>
    public string Email { get; private set; }

    /// <summary>
    /// Gets the phone number.
    /// </summary>
    public string PhoneNumber { get; private set; }

    public UserRegisteredEvent(string userName, string email, string phoneNumber)
    {
        this.UserName = userName;
        this.Email = email;
        this.PhoneNumber = phoneNumber;
    }
}