// ***********************************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : UserProfile.cs
// Created          : 2023-04-16  14:43
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-16  14:43
// ***********************************************************************************************************************
// <copyright file="UserProfile.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************


using AutoMapper;
using Navyblue.StoreLab.User.Application.Commands.UserRegister;
using Navyblue.StoreLab.User.Presentation.Requests;

namespace Navyblue.StoreLab.User.Presentation;

public class UserProfile : Profile
{
    public UserProfile()
    {
        this.CreateMap<UserRegisterRequest, UserRegisterCommand>();
    }
}