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
using Navyblue.StoreLab.User.Domain;

namespace Navyblue.StoreLab.User.Infrastructure;

public class UserLevelConfiguration : IEntityTypeConfiguration<UserLevel>
{
    public void Configure(EntityTypeBuilder<UserLevel> builder)
    {
        builder.ToTable("UserLevel").HasKey(p => p.Id);
        builder.Property(p => p.LevelName).HasColumnType("varchar").HasComment("Level Name, for logging").HasMaxLength(32).HasColumnOrder(2).IsRequired();
        builder.Property(p => p.LevelSort).HasColumnType("int").HasComment("Specifies a sort value of level").HasColumnOrder(3).IsRequired();
        builder.Property(p => p.MinCredit).HasColumnType("int").HasComment("Specifies a level of beginning score").HasColumnOrder(4).IsRequired();
        builder.Property(p => p.MaxCredit).HasColumnType("int").HasComment("Specifies a level of ending score").HasColumnOrder(5).IsRequired();

        //builder.HasQueryFilter(u => !EF.Property<bool>(u, "IsDeleted")).Property<bool>(p=>p.IsDeleted);
    }
}