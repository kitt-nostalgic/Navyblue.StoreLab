// ******************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : ICommandHandler.cs
// Created          : 2023-04-11  17:21
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  17:21
// ******************************************************************************************************
// <copyright file="ICommandHandler.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using MediatR;

namespace Navyblue.StoreLab.User.Application;

public interface ICommandHandler<in TCommand> :
    IRequestHandler<TCommand>
    where TCommand : ICommand
{
}

public interface ICommandHandler<in TCommand, TResult> :
    IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>
{
}