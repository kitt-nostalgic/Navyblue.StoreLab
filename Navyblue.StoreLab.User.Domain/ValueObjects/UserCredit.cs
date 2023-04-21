// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : UserCredit.cs
// Created          : 2023-04-03  15:27
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-03  15:27
// ******************************************************************************************************
// <copyright file="UserCredit.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************

namespace Navyblue.StoreLab.User.Domain.ValueObjects;

public record UserCredit
{
    public int Value { get; private set; }

    public UserCredit(int value)
    {
        this.Value = value;
    }

    public void Add(int value)
    {
        this.Value += value;
    }
}