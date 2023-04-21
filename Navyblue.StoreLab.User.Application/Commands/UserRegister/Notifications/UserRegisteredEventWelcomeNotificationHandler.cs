// ******************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : UserRegisteredEventNotificationHandler.cs
// Created          : 2023-04-11  17:55
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  17:55
// ******************************************************************************************************
// <copyright file="UserRegisteredEventNotificationHandler.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using MediatR;
using Navyblue.StoreLab.User.Domain.Events;
using Navyblue.StoreLab.User.Domain.Events.UserRegister;
using Serilog;

namespace Navyblue.StoreLab.User.Application.Commands.UserRegister.Notifications;

public class UserRegisteredEventWelcomeNotificationHandler : INotificationHandler<UserRegisteredEvent>
{
    private readonly ILogger _logger;

    public UserRegisteredEventWelcomeNotificationHandler(IEventBus eventsBus, ILogger logger)
    {
        this._logger = logger;
    }

    public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
    {
        this._logger.Information("Welcome to Store Lab, hope you have a interesting journey");

        await Task.FromResult(0);
    }
}