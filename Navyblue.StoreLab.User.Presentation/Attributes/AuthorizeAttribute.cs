// ***********************************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : AuthorizeAttribute.cs
// Created          : 2023-04-02  18:53
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-02  18:53
// ***********************************************************************************************************************
// <copyright file="AuthorizeAttribute.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Navyblue.StoreLab.User.Presentation.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        User? user = (User)context.HttpContext.Items["User"];
        if (user == null)
        {
            // not logged in
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}