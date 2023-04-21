// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : UserContactInfo.cs
// Created          : 2023-04-03  15:25
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-03  15:25
// ******************************************************************************************************
// <copyright file="UserContactInfo.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************

namespace Navyblue.StoreLab.User.Domain.ValueObjects;

public record UserContactInfo
{
    public string Email { get; }

    public string PhoneNumber { get; }

    public UserContactInfo(string email, string phoneNumber)
    {
        this.Email = email;
        this.PhoneNumber = phoneNumber;
    }
}