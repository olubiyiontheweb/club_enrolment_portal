using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Migrations
{
    public partial class club_user_membership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Users_OwnerId",
                schema: "TheKangaroos",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Clubs_CreatedByClubId",
                schema: "TheKangaroos",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_OwnerId",
                schema: "TheKangaroos",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "TheKangaroos",
                table: "Clubs");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "TheKangaroos",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "TheKangaroos",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                schema: "TheKangaroos",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "TheKangaroos",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attendees",
                schema: "TheKangaroos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enquiries",
                schema: "TheKangaroos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enrolments",
                schema: "TheKangaroos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                schema: "TheKangaroos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClubId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memberships_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalSchema: "TheKangaroos",
                        principalTable: "Clubs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Memberships_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "TheKangaroos",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "TheKangaroos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "TheKangaroos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                schema: "TheKangaroos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                schema: "TheKangaroos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_ClubId",
                schema: "TheKangaroos",
                table: "Memberships",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_UserId",
                schema: "TheKangaroos",
                table: "Memberships",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Clubs_CreatedByClubId",
                schema: "TheKangaroos",
                table: "Events",
                column: "CreatedByClubId",
                principalSchema: "TheKangaroos",
                principalTable: "Clubs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Clubs_CreatedByClubId",
                schema: "TheKangaroos",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Attendees",
                schema: "TheKangaroos");

            migrationBuilder.DropTable(
                name: "Enquiries",
                schema: "TheKangaroos");

            migrationBuilder.DropTable(
                name: "Enrolments",
                schema: "TheKangaroos");

            migrationBuilder.DropTable(
                name: "Memberships",
                schema: "TheKangaroos");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "TheKangaroos");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "TheKangaroos");

            migrationBuilder.DropTable(
                name: "Tickets",
                schema: "TheKangaroos");

            migrationBuilder.DropTable(
                name: "Venues",
                schema: "TheKangaroos");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                schema: "TheKangaroos",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "TheKangaroos",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "TheKangaroos",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "TheKangaroos",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                schema: "TheKangaroos",
                table: "Clubs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_OwnerId",
                schema: "TheKangaroos",
                table: "Clubs",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Users_OwnerId",
                schema: "TheKangaroos",
                table: "Clubs",
                column: "OwnerId",
                principalSchema: "TheKangaroos",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Clubs_CreatedByClubId",
                schema: "TheKangaroos",
                table: "Events",
                column: "CreatedByClubId",
                principalSchema: "TheKangaroos",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
