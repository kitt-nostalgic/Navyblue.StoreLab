// ******************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : CommandBase.cs
// Created          : 2023-04-11  17:14
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  17:14
// ******************************************************************************************************
// <copyright file="CommandBase.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


namespace Navyblue.StoreLab.User.Application;

public abstract class CommandBase : ICommand
{
    public Guid Id { get; }

    protected CommandBase()
    {
        this.Id = Guid.NewGuid();
    }

    protected CommandBase(Guid id)
    {
        this.Id = id;
    }
}

public abstract class CommandBase<TResult> : ICommand<TResult>
{
    public Guid Id { get; }

    protected CommandBase()
    {
        this.Id = Guid.NewGuid();
    }

    protected CommandBase(Guid id)
    {
        this.Id = id;
    }
}