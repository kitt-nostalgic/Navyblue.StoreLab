// ***********************************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : AuthenticateResponse.cs
// Created          : 2023-04-02  18:57
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-02  18:57
// ***********************************************************************************************************************
// <copyright file="AuthenticateResponse.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************

namespace Navyblue.StoreLab.User.Presentation.Responses;

public class AuthenticateResponse
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Token { get; set; }


    public AuthenticateResponse(User user, string token)
    {
        this.Id = user.Id;
        this.Username = user.Username;
        this.Token = token;
    }
}