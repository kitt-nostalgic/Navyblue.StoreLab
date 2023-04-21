// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : IDbContext.cs
// Created          : 2023-04-11  14:11
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  14:11
// ******************************************************************************************************
// <copyright file="IDbContext.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Navyblue.StoreLab.User.Domain;

public interface IDbContext
{
    void Dispose();

    EntityEntry EntityEntry(Entity entity);

    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

    DbSet<T> Set<T>() where T : class;
}