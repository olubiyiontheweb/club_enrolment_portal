using Microsoft.EntityFrameworkCore.Migrations;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Migrations
{
    public partial class noticesfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                schema: "TheKangaroos",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Notices",
                schema: "TheKangaroos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    isAnnouncement = table.Column<bool>(type: "bit", nullable: false),
                    isEnquiry = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByClubId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notices_Clubs_CreatedByClubId",
                        column: x => x.CreatedByClubId,
                        principalSchema: "TheKangaroos",
                        principalTable: "Clubs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notices_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "TheKangaroos",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notices_CreatedByClubId",
                schema: "TheKangaroos",
                table: "Notices",
                column: "CreatedByClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Notices_CreatedByUserId",
                schema: "TheKangaroos",
                table: "Notices",
                column: "CreatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notices",
                schema: "TheKangaroos");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                schema: "TheKangaroos",
                table: "Users");
        }
    }
}
