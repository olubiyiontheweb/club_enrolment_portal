using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Migrations
{
    public partial class CreateEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    CreatedByClubId = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Image = table.Column<string>(maxLength: 256, nullable: false),
                    Location = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Club_CreatedByClubId",
                        column: x => x.CreatedByClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            /* migrationBuilder.CreateIndex(
                name: "IX_Event_CreatedByClubId",
                table: "Event",
                column: "CreatedByClubId"
            ); */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
