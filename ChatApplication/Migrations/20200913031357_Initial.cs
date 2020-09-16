using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatApplication.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    groupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    groupName = table.Column<string>(nullable: true),
                    groupParticipants = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.groupId);
                });

            migrationBuilder.CreateTable(
                name: "UserChat",
                columns: table => new
                {
                    Chatid = table.Column<long>(nullable: false),
                    Connectionid = table.Column<string>(maxLength: 50, nullable: true),
                    Senderid = table.Column<string>(maxLength: 50, nullable: true),
                    Receiverid = table.Column<string>(maxLength: 50, nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Messagestatus = table.Column<string>(maxLength: 10, nullable: true),
                    Messagedate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsGroup = table.Column<bool>(nullable: true),
                    IsMultiple = table.Column<bool>(nullable: true),
                    IsPrivate = table.Column<bool>(nullable: true),
                    groupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChat", x => x.Chatid);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    UserPass = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "NonClusteredIndex-20200419-114105",
                table: "UserChat",
                columns: new[] { "Senderid", "Receiverid" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "UserChat");

            migrationBuilder.DropTable(
                name: "UserLogin");
        }
    }
}
