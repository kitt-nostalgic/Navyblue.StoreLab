﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Navyblue.StoreLab.User.Infrastructure;

#nullable disable

namespace Navyblue.StoreLab.User.Infrastructure.Migrations
{
    [DbContext(typeof(StoreLabDbContext))]
    [Migration("20230420034627_BB")]
    partial class BB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Navyblue.StoreLab.User.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnOrder(8)
                        .HasComment("Head image");

                    b.Property<string>("BeInvitedCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar")
                        .HasColumnOrder(14)
                        .HasComment("inform this user is invited by someone");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(99)
                        .HasComment("A time that when this data was created");

                    b.Property<string>("InviteCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar")
                        .HasColumnOrder(13)
                        .HasComment("inform this user can invite someone to register by this code");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(98)
                        .HasComment("informs if this data is deleted, 1 is Yes, 0 is No, default is 0");

                    b.Property<DateTime>("LastLoginTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(15)
                        .HasComment("A time that user last logged");

                    b.Property<short>("LevelId")
                        .HasColumnType("smallint")
                        .HasColumnOrder(11)
                        .HasComment("the identifier that how a user actives");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar")
                        .HasColumnOrder(7)
                        .HasComment("A friendly name for communication");

                    b.Property<DateTime>("RegisterTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(14)
                        .HasComment("A time that user registered");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar")
                        .HasColumnOrder(5)
                        .HasComment("Salt");

                    b.Property<string>("Signature")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnOrder(9)
                        .HasComment("a paragraph that user like");

                    b.Property<short>("Status")
                        .HasColumnType("smallint")
                        .HasColumnOrder(12)
                        .HasComment("0: Normal, 1: Banned, 2: Suspended");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(100)
                        .HasComment("A lastest time that when this data was updated");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar")
                        .HasColumnOrder(2)
                        .HasComment("User Name, for logging");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Navyblue.StoreLab.User.Domain.UserLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(99)
                        .HasComment("A time that when this data was created");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(98)
                        .HasComment("informs if this data is deleted, 1 is Yes, 0 is No, default is 0");

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar")
                        .HasColumnOrder(2)
                        .HasComment("Level Name, for logging");

                    b.Property<int>("LevelSort")
                        .HasColumnType("int")
                        .HasColumnOrder(3)
                        .HasComment("Specifies a sort value of level");

                    b.Property<int>("MaxCredit")
                        .HasColumnType("int")
                        .HasColumnOrder(5)
                        .HasComment("Specifies a level of ending score");

                    b.Property<int>("MinCredit")
                        .HasColumnType("int")
                        .HasColumnOrder(4)
                        .HasComment("Specifies a level of beginning score");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(100)
                        .HasComment("A lastest time that when this data was updated");

                    b.HasKey("Id");

                    b.ToTable("UserLevel", (string)null);
                });

            modelBuilder.Entity("Navyblue.StoreLab.User.Domain.User", b =>
                {
                    b.OwnsMany("Navyblue.StoreLab.User.Domain.ValueObjects.Address", "Addresses", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("varchar")
                                .HasColumnOrder(4)
                                .HasComment("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("varchar")
                                .HasColumnOrder(2)
                                .HasComment("Country");

                            b1.Property<string>("Province")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("varchar")
                                .HasColumnOrder(3)
                                .HasComment("Province");

                            b1.Property<string>("Remark")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar")
                                .HasColumnOrder(7)
                                .HasComment("Remark");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("varchar")
                                .HasColumnOrder(6)
                                .HasComment("Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(32)
                                .HasColumnType("varchar")
                                .HasColumnOrder(5)
                                .HasComment("ZipCode");

                            b1.HasKey("UserId", "Id");

                            b1.ToTable("UserAddress", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Navyblue.StoreLab.User.Domain.ValueObjects.EmailAddress", "Email", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("varchar")
                                .HasColumnName("Email")
                                .HasColumnOrder(4)
                                .HasComment("User Email");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Navyblue.StoreLab.User.Domain.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("varchar")
                                .HasColumnName("Password")
                                .HasColumnOrder(6)
                                .HasComment("User Password");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Navyblue.StoreLab.User.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar")
                                .HasColumnName("PhoneNumber")
                                .HasColumnOrder(3)
                                .HasComment("User phone number");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Navyblue.StoreLab.User.Domain.ValueObjects.UserCredit", "Credit", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("Credit")
                                .HasColumnOrder(10)
                                .HasComment("A score that is related to user level");

                            b1.HasKey("UserId");

                            b1.ToTable("User");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Addresses");

                    b.Navigation("Credit")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();

                    b.Navigation("PhoneNumber")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
