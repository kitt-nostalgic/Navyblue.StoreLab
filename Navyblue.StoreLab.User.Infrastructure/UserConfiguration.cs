// ***********************************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : UserConfiguration.cs
// Created          : 2023-04-02  21:46
// 
// Last Modified By : 马新心(jstsmaxx@163.com)
// Last Modified On : 2023-04-02  21:46
// ***********************************************************************************************************************
// <copyright file="UserConfiguration.cs" company="">
//     Copyright ©  2011-2022 . All rights reserved.
// </copyright>
// ***********************************************************************************************************************


using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Navyblue.StoreLab.User.Infrastructure;

public class UserConfiguration : IEntityTypeConfiguration<Domain.User>
{
    public void Configure(EntityTypeBuilder<Domain.User> builder)
    {
        //builder.ToTable("User").SplitToTable("PhoneNumber", tb =>
        //{
        //    tb.Property(p => p.Id).HasColumnName("UserId");
        //    tb.Property(p => p.PhoneNumber);
        //}).HasKey(p => p.Id);

        builder.ToTable("User").HasKey(p => p.Id);
        builder.Property(p => p.UserName).HasColumnType("varchar").HasComment("User Name, for logging").HasMaxLength(32).HasColumnOrder(2).IsRequired();
        builder.OwnsOne(p => p.PhoneNumber).Property(p => p.Value).HasColumnType("varchar").HasComment("User phone number").HasColumnName("PhoneNumber").HasMaxLength(20).HasColumnOrder(3).IsRequired();
        builder.OwnsOne(p => p.Email).Property(p => p.Value).HasColumnType("varchar").HasComment("User Email").HasColumnName("Email").HasMaxLength(64).HasColumnOrder(4).IsRequired();
        builder.Property(p => p.Salt).HasColumnType("varchar").HasComment("Salt").HasMaxLength(32).HasColumnOrder(5).IsRequired();
        builder.OwnsOne(p => p.Password).Property(p => p.Value).HasColumnType("varchar").HasComment("User Password").HasColumnName("Password").HasMaxLength(255).HasColumnOrder(6).IsRequired();
        builder.Property(p => p.Nickname).HasColumnType("varchar").HasComment("A friendly name for communication").HasMaxLength(32).HasColumnOrder(7).IsRequired();
        builder.Property(p => p.Avatar).HasColumnType("varchar").HasComment("Head image").HasMaxLength(255).HasColumnOrder(8).IsRequired();
        builder.Property(p => p.Signature).HasColumnType("varchar").HasComment("a paragraph that user like").HasMaxLength(255).HasColumnOrder(9).IsRequired();
        builder.OwnsOne(p => p.Credit).Property(p => p.Value).HasColumnType("int").HasComment("A score that is related to user level").HasColumnName("Credit").HasColumnOrder(10).IsRequired();
        builder.Property(p => p.LevelId).HasColumnType("smallint").HasComment("the identifier that how a user actives").HasColumnOrder(11).IsRequired();
        builder.Property(p => p.Status).HasColumnType("smallint").HasComment("0: Normal, 1: Banned, 2: Suspended").HasColumnOrder(12).IsRequired();
        builder.Property(p => p.InviteCode).HasColumnType("varchar").HasComment("inform this user can invite someone to register by this code").HasMaxLength(10).HasColumnOrder(13).IsRequired();
        builder.Property(p => p.BeInvitedCode).HasColumnType("varchar").HasComment("inform this user is invited by someone").HasMaxLength(10).HasColumnOrder(14).IsRequired();
        builder.OwnsMany(p => p.Addresses, a =>
        {
            a.ToTable("UserAddress");
            a.WithOwner().HasForeignKey("UserId");
            a.Property(t => t.Country).HasColumnType("varchar").HasMaxLength(64).HasComment("Country").HasColumnOrder(2).IsRequired();
            a.Property(t => t.Province).HasColumnType("varchar").HasColumnOrder(3).HasMaxLength(64).HasComment("Province").HasColumnOrder(3).IsRequired();
            a.Property(t => t.City).HasColumnType("varchar").HasColumnOrder(4).HasMaxLength(64).HasComment("City").HasColumnOrder(4).IsRequired();
            a.Property(t => t.ZipCode).HasColumnType("varchar").HasColumnOrder(5).HasMaxLength(32).HasComment("ZipCode").HasColumnOrder(5).IsRequired();
            a.Property(t => t.Street).HasColumnType("varchar").HasColumnOrder(6).HasMaxLength(64).HasComment("Street").HasColumnOrder(6).IsRequired();
            a.Property(t => t.Remark).HasColumnType("varchar").HasColumnOrder(7).HasMaxLength(255).HasComment("Remark").HasColumnOrder(7).IsRequired();
        });
        builder.Property(p => p.RegisterTime).HasColumnType("datetime2").HasComment("A time that user registered").HasColumnOrder(14).IsRequired();
        builder.Property(p => p.LastLoginTime).HasColumnType("datetime2").HasComment("A time that user last logged").HasColumnOrder(15).IsRequired();

        //builder.HasQueryFilter(u => !EF.Property<bool>(u, "IsDeleted")).Property<bool>(p=>p.IsDeleted);
    }
}