// ******************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : Command.cs
// Created          : 2023-04-11  16:29
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  16:29
// ******************************************************************************************************
// <copyright file="Command.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using MediatR;

namespace Navyblue.StoreLab.User.Application;

public interface ICommand<out TResult> : IRequest<TResult>
{
    Guid Id { get; }
}

public interface ICommand : IRequest
{
    Guid Id { get; }
}