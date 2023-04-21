// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : Password.cs
// Created          : 2023-04-03  16:32
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-03  16:32
// ******************************************************************************************************
// <copyright file="Password.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using System.Security.Cryptography;
using System.Text;

namespace Navyblue.StoreLab.User.Domain.ValueObjects;

public record Password
{
    public string Value { get; private set; }

    public Password() { }

    public Password(string password, string salt)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new ArgumentException("Password cannot be empty");
        }

        this.Value = this.HashPassword(password + salt);
    }

    public bool Validate(string password, string salt)
    {
        string hashedInputPassword = this.HashPassword(password + salt);

        return this.Value.Equals(hashedInputPassword);
    }

    private string HashPassword(string password)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

        return Convert.ToBase64String(hashedBytes);
    }
}
