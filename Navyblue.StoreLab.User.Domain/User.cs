// ***********************************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : UserAggregation.cs
// Created          : 2023-04-02  19:20
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-02  19:20
// ***********************************************************************************************************************
// <copyright file="UserAggregation.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************


using Navyblue.BaseLibrary;
using Navyblue.StoreLab.User.Domain.Enums;
using Navyblue.StoreLab.User.Domain.Events.UserRegister;
using Navyblue.StoreLab.User.Domain.Utils;
using Navyblue.StoreLab.User.Domain.ValueObjects;

namespace Navyblue.StoreLab.User.Domain;

/// <summary>
/// User Aggregation 
/// </summary>
public class User : Entity, IAggregateRoot
{
    /// <summary>
    /// Gets the email.
    /// </summary>
    public EmailAddress Email { get; private set; }

    /// <summary>
    /// Gets the phone number.
    /// </summary>
    public PhoneNumber PhoneNumber { get; private set; }

    /// <summary>
    /// Gets the salt.
    /// </summary>
    public string Salt { get; private set; }

    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    public string UserName { get; private set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    public Password Password { get; private set; }

    /// <summary>
    /// Gets or sets the nickname.
    /// </summary>
    public string Nickname { get; private set; }

    /// <summary>
    /// Gets or sets the avatar.
    /// </summary>
    public string Avatar { get; private set; }

    /// <summary>
    /// Gets or sets the register time.
    /// </summary>
    public DateTime RegisterTime { get; private set; }

    /// <summary>
    /// Gets or sets the last login time.
    /// </summary>
    public DateTime LastLoginTime { get; private set; }

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
    public UserCredit Credit { get; private set; }

    /// <summary>
    /// Gets or sets the status.
    /// </summary>
    public UserStatus Status { get; private set; }

    /// <summary>
    /// Gets the invite code.
    /// </summary>
    public string? InviteCode { get; private set; }

    /// <summary>
    /// Gets the be invited code
    /// </summary>
    public string BeInvitedCode { get; private set; }

    /// <summary>
    /// Gets the address.
    /// </summary>
    public List<Address> Addresses { get; set; }

    private User(
        string userName,
        string? inviteCode,
        string nickname,
        string avatar,
        string signature)
    {
        this.UserName = userName;
        this.InviteCode = inviteCode;
        this.Salt = GuidUtility.NewSequentialGuid().ToString();
        this.Nickname = nickname;
        this.Avatar = avatar;
        this.RegisterTime = DateTime.UtcNow;
        this.LastLoginTime = DateTime.UtcNow;
        this.Signature = signature;
        this.Status = UserStatus.UnVerified;
        this.LevelId = (int)Enums.UserLevel.Default;
        this.Credit = new UserCredit(0);
        this.InviteCode = InviteCodeUtil.ConvertToInviteCode(this.PhoneNumber!.Value.ToLong());
    }

    /// <summary>
    /// This is a workaround to fix below problem. The reason why we need this is because in my understanding of DDD, we should not create a empty constructor for an entity.
    /// ########
    /// No suitable constructor was found for entity type 'User'. The following constructors had parameters that could not be bound to properties of the entity type: 
    /// Cannot bind 'password', 'phoneNumber', 'email', 'address' in 'User(string userName, string password, string phoneNumber, string email, string nickname, string avatar, string registerTime, string lastLoginTime, string signature, Address address)'
    /// Note that only mapped properties can be bound to constructor parameters.Navigations to related entities, including references to owned types, cannot be bound.
    /// ########
    /// </summary>
    /// <param name="userName">Name of the user.</param>
    /// <param name="password">The password.</param>
    /// <param name="phoneNumber">The phone number.</param>
    /// <param name="email">The email.</param>
    /// <param name="inviteCode"></param>
    /// <param name="nickname">The nickname.</param>
    /// <param name="avatar">The avatar.</param>
    /// <param name="signature">The signature.</param>
    /// <param name="address">The address.</param>
    public User(
        string userName,
        string password,
        string phoneNumber,
        string email,
        string? inviteCode,
        string nickname,
        string avatar,
        string signature,
        Address address):this(userName, inviteCode, nickname, avatar, signature)
    {
        this.Password = new Password(password, this.Salt);
        this.PhoneNumber = new PhoneNumber(phoneNumber);
        this.Email = new EmailAddress(email);
        this.Addresses = new List<Address> { address };

        this.AddDomainEvent(new UserRegisteredEvent(this.UserName, email, phoneNumber));
    }

    //public User CreateUser(
    //    string userName,
    //    string password,
    //    string phoneNumber,
    //    string email,
    //    string nickname,
    //    string avatar,
    //    string registerTime,
    //    string lastLoginTime,
    //    string signature)
    //{
    //    User user = new(userName, password, phoneNumber, email, nickname, avatar, registerTime, lastLoginTime, signature);

    //    return user;
    //}

    public void UpdateProfile(string nickname, string signature, string avatar, string email, string phoneNumber)
    {
        this.Nickname = nickname;
        this.Signature = signature;
        this.Avatar = avatar;
        this.Email = new EmailAddress(email);
        this.PhoneNumber = new PhoneNumber(phoneNumber);

        //this.AddDomainEvent(new ProfileUpdatedEvent(nickname, signature, avatar, email, phoneNumber));
    }

    public void CreatePassword(string password)
    {
        this.Salt = GuidUtility.NewSequentialGuid().ToString();
        this.Password = new Password(password, this.Salt);
    }

    public void UpdateStatus(UserStatus status)
    {
        this.Status = status;
    }

    public void AddCredit(int value)
    {
        this.Credit.Add(value);
        //this.LevelId.UpdateLevel(this.Credit.Value);
    }
}