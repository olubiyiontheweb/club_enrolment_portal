using Microsoft.EntityFrameworkCore.Migrations;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Migrations
{
    public partial class noticesfieldschanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventId",
                schema: "TheKangaroos",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventId",
                schema: "TheKangaroos",
                table: "Attendees",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                schema: "TheKangaroos",
                table: "Tickets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_EventId",
                schema: "TheKangaroos",
                table: "Attendees",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Events_EventId",
                schema: "TheKangaroos",
                table: "Attendees",
                column: "EventId",
                principalSchema: "TheKangaroos",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventId",
                schema: "TheKangaroos",
                table: "Tickets",
                column: "EventId",
                principalSchema: "TheKangaroos",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Events_EventId",
                schema: "TheKangaroos",
                table: "Attendees");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventId",
                schema: "TheKangaroos",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EventId",
                schema: "TheKangaroos",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_EventId",
                schema: "TheKangaroos",
                table: "Attendees");

            migrationBuilder.DropColumn(
                name: "EventId",
                schema: "TheKangaroos",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EventId",
                schema: "TheKangaroos",
                table: "Attendees");
        }
    }
}
