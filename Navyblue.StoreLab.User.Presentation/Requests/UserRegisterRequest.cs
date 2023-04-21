// ***********************************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : UserRegisterRequest.cs
// Created          : 2023-04-16  13:41
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-16  13:41
// ***********************************************************************************************************************
// <copyright file="UserRegisterRequest.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************


using System.Text.Json.Serialization;
using Navyblue.StoreLab.User.Domain.Enums;
using Navyblue.StoreLab.User.Domain.ValueObjects;

namespace Navyblue.StoreLab.User.Presentation.Requests;

/// <summary>
/// 
/// </summary>
public class UserRegisterRequest : BaseRequest
{
    /// <summary>
    /// Gets the email.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// Gets the phone number.
    /// </summary>
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    [JsonPropertyName("userName")]
    public string UserName { get; set; }

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the nickname.
    /// </summary>
    [JsonPropertyName("nickname")]
    public string Nickname { get; set; }

    /// <summary>
    /// Gets or sets the avatar.
    /// </summary>
    [JsonPropertyName("avatar")]
    public string Avatar { get; set; }

    /// <summary>
    /// Gets or sets the signature.
    /// </summary>
    [JsonPropertyName("signature")]
    public string Signature { get; set; }

    /// <summary>
    /// Gets or sets the level.
    /// </summary>
    [JsonPropertyName("levelId")]
    public int LevelId { get; set; }

    /// <summary>
    /// Gets or sets the credit.
    /// </summary>
    [JsonPropertyName("credit")]
    public int Credit { get; set; }

    /// <summary>
    /// Gets or sets the status.
    /// </summary>
    [JsonPropertyName("status")]
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets the address.
    /// </summary>
    [JsonPropertyName("address")]
    public Address Address { get; set; }
}