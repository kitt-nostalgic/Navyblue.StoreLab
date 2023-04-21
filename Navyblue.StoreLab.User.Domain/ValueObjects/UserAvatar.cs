// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : UserAvatar.cs
// Created          : 2023-04-03  15:24
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-03  15:24
// ******************************************************************************************************
// <copyright file="UserAvatar.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************

namespace Navyblue.StoreLab.User.Domain.ValueObjects;

public record UserAvatar
{
    public string Url { get; }

    public int Width { get; }

    public int Height { get; }

    public UserAvatar(string url, int width, int height)
    {
        this.Url = url;
        this.Width = width;
        this.Height = height;
    }
}