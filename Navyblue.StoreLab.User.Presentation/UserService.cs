// ***********************************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : UserServic.cs
// Created          : 2023-04-02  18:59
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-02  18:59
// ***********************************************************************************************************************
// <copyright file="UserServic.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************


using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Navyblue.StoreLab.User.Presentation.Requests;
using Navyblue.StoreLab.User.Presentation.Responses;

namespace Navyblue.StoreLab.User.Presentation;

public class UserService : IUserService
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<User> _users = new List<User>
    {
        new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
    };

    private readonly AppSettings _appSettings;

    public UserService(IOptions<AppSettings> appSettings)
    {
        this._appSettings = appSettings.Value;
    }

    public AuthenticateResponse? Authenticate(AuthenticateRequest model)
    {
        User? user = this._users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        string token = this.GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public IEnumerable<User> GetAll()
    {
        return this._users;
    }

    public User GetById(int id)
    {
        return this._users.FirstOrDefault(x => x.Id == id);
    }

    // helper methods

    private string GenerateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(this._appSettings.Secret);
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken? token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}