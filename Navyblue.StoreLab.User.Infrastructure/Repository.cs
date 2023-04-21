// ******************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : Repository.cs
// Created          : 2023-04-11  14:09
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-11  14:09
// ******************************************************************************************************
// <copyright file="Repository.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Navyblue.StoreLab.User.Domain;

namespace Navyblue.StoreLab.User.Infrastructure;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly IDbContext _dbContext;

    private DbSet<T> _entities;

    public Repository(IDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public DbSet<T> Entities => this._entities ??= this._dbContext.Set<T>();

    #region IRepository<T> Members

    public IQueryable<T> ReadOnly => this.Entities.AsNoTracking();

    public IQueryable<T> Table => this.Entities;

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(IEnumerable<T> entities)
    {
        throw new NotImplementedException();
    }

    public EntityEntry Entry(T t)
    {
        return this._dbContext.EntityEntry(t);
    }

    public ValueTask<T?> GetByIdAsync(object id)
    {
        return this.Entities.FindAsync(id);
    }

    public async Task<int> AddAsync(T entity)
    {
        try
        {
            this.Entities.Add(entity);
            await this._dbContext.SaveChangesAsync();

            return entity.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities)
    {
        this.Entities.AddRange(entities);
        await this._dbContext.SaveChangesAsync();

        return entities;
    }

    public async Task UpdateAsync(T entity)
    {
        this.Entities.Update(entity);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(IEnumerable<T> entities)
    {
        this.Entities.UpdateRange(entities);
        await this._dbContext.SaveChangesAsync();
    }

    #endregion IRepository<T> Members
}
