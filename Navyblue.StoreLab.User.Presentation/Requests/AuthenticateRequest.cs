// ***********************************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : AuthenticateRequest.cs
// Created          : 2023-04-02  18:57
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-02  18:57
// ***********************************************************************************************************************
// <copyright file="AuthenticateRequest.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************


using System.ComponentModel.DataAnnotations;

namespace Navyblue.StoreLab.User.Presentation.Requests;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}