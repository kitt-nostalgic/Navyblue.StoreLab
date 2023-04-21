// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : Email.cs
// Created          : 2023-04-03  17:01
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-03  17:01
// ******************************************************************************************************
// <copyright file="Email.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using System.Net.Mail;

namespace Navyblue.StoreLab.User.Domain.ValueObjects;

public record EmailAddress
{
    public string Value { get; }

    public EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Email address cannot be null or empty", nameof(value));
        }

        if (!this.IsValidEmail(value))
        {
            throw new ArgumentException("Invalid email address format", nameof(value));
        }

        this.Value = value;
    }

    private bool IsValidEmail(string value)
    {
        try
        {
            MailAddress address = new MailAddress(value);
            return address.Address == value;
        }
        catch
        {
            return false;
        }
    }
}
