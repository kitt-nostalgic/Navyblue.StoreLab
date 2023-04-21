using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Navyblue.StoreLab.User.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "User Name, for logging"),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "User phone number"),
                    Email = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "User Email"),
                    Salt = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "Salt"),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "User Password"),
                    Nickname = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "A friendly name for communication"),
                    Avatar = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Head image"),
                    Signature = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "a paragraph that user like"),
                    Credit = table.Column<int>(type: "int", nullable: false, comment: "A score that is related to user level"),
                    LevelId = table.Column<short>(type: "smallint", nullable: false, comment: "the identifier that how a user actives"),
                    Status = table.Column<short>(type: "smallint", nullable: false, comment: "0: Normal, 1: Banned, 2: Suspended"),
                    InviteCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, comment: "inform this user can invite someone to register by this code"),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "A time that user registered"),
                    BeInvitedCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, comment: "inform this user is invited by someone"),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "A time that user last logged"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "informs if this data is deleted, 1 is Yes, 0 is No, default is 0"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "A time that when this data was created"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "A lastest time that when this data was updated")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "Level Name, for logging"),
                    LevelSort = table.Column<int>(type: "int", nullable: false, comment: "Specifies a sort value of level"),
                    MinCredit = table.Column<int>(type: "int", nullable: false, comment: "Specifies a level of beginning score"),
                    MaxCredit = table.Column<int>(type: "int", nullable: false, comment: "Specifies a level of ending score"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "informs if this data is deleted, 1 is Yes, 0 is No, default is 0"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "A time that when this data was created"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "A lastest time that when this data was updated")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAddress",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "Country"),
                    Province = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "Province"),
                    City = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "City"),
                    ZipCode = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "ZipCode"),
                    Street = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "Street"),
                    Remark = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Remark"),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_UserAddress_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAddress");

            migrationBuilder.DropTable(
                name: "UserLevel");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
