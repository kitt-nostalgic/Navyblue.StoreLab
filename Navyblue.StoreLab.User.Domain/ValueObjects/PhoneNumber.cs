// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : PhoneNumber.cs
// Created          : 2023-04-03  16:56
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-03  16:56
// ******************************************************************************************************
// <copyright file="PhoneNumber.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using System.Text.RegularExpressions;

namespace Navyblue.StoreLab.User.Domain.ValueObjects;

public record PhoneNumber
{
    private const string PHONE_NUMBER_REGEX = @"^1[3-9]\d{9}$";

    public string Value { get; }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Phone number cannot be null or empty", nameof(value));
        }

        if (!Regex.IsMatch(value, PHONE_NUMBER_REGEX))
        {
            throw new ArgumentException("Invalid phone number format", nameof(value));
        }

        this.Value = value;
    }
}