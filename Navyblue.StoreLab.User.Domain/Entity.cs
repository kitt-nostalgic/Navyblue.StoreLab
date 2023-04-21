// ***********************************************************************************************************************
// Project          : Navyblue.BBS.User
// File             : Entity.cs
// Created          : 2023-04-02  19:25
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-02  19:25
// ***********************************************************************************************************************
// <copyright file="Entity.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************


using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Navyblue.StoreLab.User.Domain.Events;

namespace Navyblue.StoreLab.User.Domain;

public abstract class Entity
{
    int? _requestedHashCode;

    [Column(Order = 1)]
    public virtual int Id { get; set; }

    [Column(Order = 98, TypeName = "bit")]
    [Comment("informs if this data is deleted, 1 is Yes, 0 is No, default is 0")]
    public virtual bool IsDeleted { get; set; }

    [Column(Order = 99, TypeName = "datetime2")]
    [Comment("A time that when this data was created")]
    public virtual DateTime CreateTime { get; set; }

    [Column(Order = 100, TypeName = "datetime2")]
    [Comment("A lastest time that when this data was updated")]
    public virtual DateTime UpdateTime { get; set; }

    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => this._domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent eventItem)
    {
        this._domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(IDomainEvent eventItem)
    {
        this._domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        this._domainEvents?.Clear();
    }

    public bool IsTransient()
    {
        return this.Id == default(int);
    }

    public override bool Equals(object obj)
    {
        if (obj is not Entity)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (this.GetType() != obj.GetType())
            return false;

        Entity item = (Entity)obj;

        if (item.IsTransient() || this.IsTransient())
            return false;

        return item.Id == this.Id;
    }

    public override int GetHashCode()
    {
        if (!this.IsTransient())
        {
            this._requestedHashCode ??= this.Id.GetHashCode() ^ 31;

            return this._requestedHashCode.Value;
        }

        // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
        return base.GetHashCode();

    }
    public static bool operator ==(Entity left, Entity right)
    {
        if (Equals(left, null))
            return (Equals(right, null));

        return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }
}