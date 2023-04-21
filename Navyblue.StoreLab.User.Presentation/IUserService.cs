// ***********************************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : IUserService.cs
// Created          : 2023-04-02  18:59
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-02  18:59
// ***********************************************************************************************************************
// <copyright file="IUserService.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************


using Navyblue.StoreLab.User.Presentation.Requests;
using Navyblue.StoreLab.User.Presentation.Responses;

namespace Navyblue.StoreLab.User.Presentation;

public interface IUserService
{
    AuthenticateResponse? Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
}
