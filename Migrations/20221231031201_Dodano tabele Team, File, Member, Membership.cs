using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class DodanotabeleTeamFileMemberMembership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    memberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    oID = table.Column<int>(type: "int", nullable: false),
                    memberName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    memberSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    memberNickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.memberID);
                    table.ForeignKey(
                        name: "FK_Member_Organization_oID",
                        column: x => x.oID,
                        principalTable: "Organization",
                        principalColumn: "oID");
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    teamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    oID = table.Column<int>(type: "int", nullable: false),
                    teamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    teamDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.teamID);
                    table.ForeignKey(
                        name: "FK_Team_Organization_oID",
                        column: x => x.oID,
                        principalTable: "Organization",
                        principalColumn: "oID");
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    fileID = table.Column<int>(type: "int", nullable: false),
                    teamID = table.Column<int>(type: "int", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fileExtension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => new { x.fileID, x.teamID });
                    table.ForeignKey(
                        name: "FK_File_Team_teamID",
                        column: x => x.teamID,
                        principalTable: "Team",
                        principalColumn: "teamID");
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    memberID = table.Column<int>(type: "int", nullable: false),
                    teamID = table.Column<int>(type: "int", nullable: false),
                    MembershipDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => new { x.memberID, x.teamID });
                    table.ForeignKey(
                        name: "FK_Membership_Member_memberID",
                        column: x => x.memberID,
                        principalTable: "Member",
                        principalColumn: "memberID");
                    table.ForeignKey(
                        name: "FK_Membership_Team_teamID",
                        column: x => x.teamID,
                        principalTable: "Team",
                        principalColumn: "teamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_teamID",
                table: "File",
                column: "teamID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_oID",
                table: "Member",
                column: "oID");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_teamID",
                table: "Membership",
                column: "teamID");

            migrationBuilder.CreateIndex(
                name: "IX_Team_oID",
                table: "Team",
                column: "oID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Team");
        }
    }
}
