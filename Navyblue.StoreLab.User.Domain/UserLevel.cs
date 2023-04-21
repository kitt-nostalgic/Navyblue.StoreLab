// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : UserLevel.cs
// Created          : 2023-04-03  17:09
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-03  17:09
// ******************************************************************************************************
// <copyright file="UserLevel.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


namespace Navyblue.StoreLab.User.Domain;

public class UserLevel : Entity, IAggregateRoot
{
    public string LevelName { get; private set; }

    public int LevelSort { get; private set; }

    public int MinCredit { get; private set; }

    public int MaxCredit { get; private set; }

    public UserLevel() { }

    private UserLevel(int levelValue, int minCredit, int maxCredit, string levelName)
    {
        if (levelValue < 1)
        {
            throw new ArgumentException("Level value cannot be less than 1.");
        }

        if (minCredit < 0 || maxCredit < 0 || maxCredit <= minCredit)
        {
            throw new ArgumentException("Invalid credit range.");
        }

        this.LevelSort = levelValue;
        this.MinCredit = minCredit;
        this.MaxCredit = maxCredit;
        this.LevelName = levelName;
    }
}