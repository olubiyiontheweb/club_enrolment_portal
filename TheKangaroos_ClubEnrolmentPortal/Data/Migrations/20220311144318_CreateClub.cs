using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Migrations
{
    public partial class CreateClub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(maxLength: 256, nullable: false),
                    Image = table.Column<string>(maxLength: 256, nullable: false),
                    OwnerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                    /* table.ForeignKey(
                        name: "FK_Club_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict); */
                }
            );      
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Club");
        }
    }
}
