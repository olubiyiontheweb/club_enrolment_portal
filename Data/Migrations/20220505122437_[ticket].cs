using Microsoft.EntityFrameworkCore.Migrations;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Migrations
{
    public partial class ticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_EventId",
                schema: "TheKangaroos",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                schema: "TheKangaroos",
                table: "Tickets",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tickets_EventId",
                schema: "TheKangaroos",
                table: "Tickets");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                schema: "TheKangaroos",
                table: "Tickets",
                column: "EventId",
                unique: true);
        }
    }
}
