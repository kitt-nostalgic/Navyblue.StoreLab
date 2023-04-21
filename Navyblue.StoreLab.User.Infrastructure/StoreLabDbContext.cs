// ***********************************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : StoreLabDbContext.cs
// Created          : 2023-04-02  21:45
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-02  21:45
// ***********************************************************************************************************************
// <copyright file="StoreLabDbContext.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Navyblue.StoreLab.User.Domain;
using Navyblue.StoreLab.User.Domain.Events;

namespace Navyblue.StoreLab.User.Infrastructure;

public class StoreLabDbContext : DbContext, IDbContext
{
    public StoreLabDbContext(DbContextOptions<StoreLabDbContext> options)
        : base(options)
    { }

    public DbSet<Domain.User> Users { get; set; }

    public DbSet<UserLevel> UserLevels { get; set; }

    public EntityEntry EntityEntry(Entity entity)
    {
        return this.Entry(entity);
    }

    public override int SaveChanges()
    {
        foreach (EntityEntry entry in this.ChangeTracker.Entries())
        {
            if (entry.Entity is Entity root)
            {
                foreach (IDomainEvent domainEvent in root.DomainEvents)
                {
                    // TODO: 将 domainEvent 发送到消息队列或事件总线
                }
                root.ClearDomainEvents();
            }

            if (entry.State == EntityState.Deleted && entry.Entity.GetType().BaseType == typeof(Entity))
            {
                entry.State = EntityState.Modified;
                entry.CurrentValues["IsDeleted"] = true;
            }
        }

        return base.SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreLabDbContext).Assembly);
    }
}