// ******************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : UserRegisterCommand.cs
// Created          : 2023-04-11  17:15
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  17:15
// ******************************************************************************************************
// <copyright file="UserRegisterCommand.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using Navyblue.StoreLab.User.Domain.Enums;
using Navyblue.StoreLab.User.Domain.ValueObjects;

namespace Navyblue.StoreLab.User.Application.Commands.UserRegister;

public class UserRegisterCommand : CommandBase<int>
{
    private UserRegisterCommand(){}

    public UserRegisterCommand(
        string userName,
        string password,
        string phoneNumber,
        string email,
        string nickname,
        string avatar,
        string signature,
        Address address)
    {
        this.UserName = userName;
        this.Password = password;
        this.PhoneNumber = phoneNumber;
        this.Email = email;
        this.Nickname = nickname;
        this.Avatar = avatar;
        this.Signature = signature;
        this.Addresses = address;
    }

    /// <summary>
    /// Gets the email.
    /// </summary>
    public string Email { get; private set; }

    /// <summary>
    /// Gets the phone number.
    /// </summary>
    public string PhoneNumber { get; private set; }

    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    public string UserName { get; private set; }

    /// <summary>
    /// Gets the invite code.
    /// </summary>
    public string? InviteCode { get; private set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    public string Password { get; private set; }

    /// <summary>
    /// Gets or sets the nickname.
    /// </summary>
    public string Nickname { get; private set; }

    /// <summary>
    /// Gets or sets the avatar.
    /// </summary>
    public string Avatar { get; private set; }

    /// <summary>
    /// Gets or sets the signature.
    /// </summary>
    public string Signature { get; private set; }

    /// <summary>
    /// Gets or sets the level.
    /// </summary>
    public int LevelId { get; private set; }

    /// <summary>
    /// Gets or sets the credit.
    /// </summary>
    public int Credit { get; private set; }

    /// <summary>
    /// Gets or sets the status.
    /// </summary>
    public UserStatus Status { get; private set; }

    /// <summary>
    /// Gets the address.
    /// </summary>
    public Address Addresses { get; private set; }
}