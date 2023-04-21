// ******************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : IRepository.cs
// Created          : 2023-04-11  13:55
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  13:55
// ******************************************************************************************************
// <copyright file="IRepository.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Navyblue.StoreLab.User.Domain;

public interface IRepository<T> where T : class
{
    #region Methods

    /// <summary>
    ///     Delete entity
    /// </summary>
    /// <param name="entity">Entity</param>
    void Delete(T entity);

    /// <summary>
    ///     Delete entities
    /// </summary>
    /// <param name="entities">Entities</param>
    void Delete(IEnumerable<T> entities);

    /// <summary>
    ///     Entries the specified t.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <returns></returns>
    EntityEntry Entry(T t);

    /// <summary>
    ///     Get entity by identifier
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <returns>Entity</returns>
    ValueTask<T?> GetByIdAsync(object id);

    /// <summary>
    ///     Insert entity
    /// </summary>
    /// <param name="entity">Entity</param>
    Task<int> AddAsync(T entity);

    /// <summary>
    ///     Insert entities
    /// </summary>
    /// <param name="entities">Entities</param>
    Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities);

    /// <summary>
    ///     Update entity
    /// </summary>
    /// <param name="entity">Entity</param>
    Task UpdateAsync(T entity);

    /// <summary>
    ///     Update entities
    /// </summary>
    /// <param name="entities">Entities</param>
    Task UpdateAsync(IEnumerable<T> entities);

    #endregion Methods

    #region Properties

    /// <summary>
    ///     Gets the read only. asnotracking
    /// </summary>
    IQueryable<T> ReadOnly { get; }

    /// <summary>
    ///     Gets a table
    /// </summary>
    IQueryable<T> Table { get; }

    #endregion Properties
}
