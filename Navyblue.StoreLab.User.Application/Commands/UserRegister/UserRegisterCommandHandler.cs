// ******************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : UserRegisterCommandHandler.cs
// Created          : 2023-04-11  17:20
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  17:20
// ******************************************************************************************************
// <copyright file="UserRegisterCommandHandler.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using Navyblue.StoreLab.User.Domain;

namespace Navyblue.StoreLab.User.Application.Commands.UserRegister;

public class UserRegisterCommandHandler : ICommandHandler<UserRegisterCommand, int>
{
    private readonly IRepository<Domain.User> _userRepository;

    public UserRegisterCommandHandler(IRepository<Domain.User> userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<int> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
    {
        Domain.User user = new(
            request.UserName,
            request.Password,
            request.PhoneNumber,
            request.Email,
            request.InviteCode,
            request.Nickname,
            request.Avatar,
            request.Signature,
            request.Addresses);

        int userId = await this._userRepository.AddAsync(user);

        return userId;
    }
}