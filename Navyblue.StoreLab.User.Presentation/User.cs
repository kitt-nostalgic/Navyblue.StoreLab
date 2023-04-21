// ***********************************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : User.cs
// Created          : 2023-04-02  19:00
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-02  19:00
// ***********************************************************************************************************************
// <copyright file="User.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************


using Newtonsoft.Json;

namespace Navyblue.StoreLab.User.Presentation;

public class User
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Username { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
}