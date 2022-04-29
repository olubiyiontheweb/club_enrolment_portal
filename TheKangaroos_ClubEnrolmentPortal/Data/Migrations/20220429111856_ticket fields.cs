using Microsoft.EntityFrameworkCore.Migrations;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Migrations
{
    public partial class ticketfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_Clubs_CreatedByClubId",
                schema: "TheKangaroos",
                table: "Notices");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventId",
                schema: "TheKangaroos",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EventId",
                schema: "TheKangaroos",
                table: "Tickets");

            migrationBuilder.AlterColumn<string>(
                name: "EventId",
                schema: "TheKangaroos",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "TheKangaroos",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                schema: "TheKangaroos",
                table: "Events",
                type: "real",
                maxLength: 250,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                schema: "TheKangaroos",
                table: "Tickets",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                schema: "TheKangaroos",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_Clubs_CreatedByClubId",
                schema: "TheKangaroos",
                table: "Notices",
                column: "CreatedByClubId",
                principalSchema: "TheKangaroos",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventId",
                schema: "TheKangaroos",
                table: "Tickets",
                column: "EventId",
                principalSchema: "TheKangaroos",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserId",
                schema: "TheKangaroos",
                table: "Tickets",
                column: "UserId",
                principalSchema: "TheKangaroos",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_Clubs_CreatedByClubId",
                schema: "TheKangaroos",
                table: "Notices");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventId",
                schema: "TheKangaroos",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserId",
                schema: "TheKangaroos",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EventId",
                schema: "TheKangaroos",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserId",
                schema: "TheKangaroos",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "TheKangaroos",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "TheKangaroos",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "EventId",
                schema: "TheKangaroos",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EventId",
                schema: "TheKangaroos",
                table: "Tickets",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_Clubs_CreatedByClubId",
                schema: "TheKangaroos",
                table: "Notices",
                column: "CreatedByClubId",
                principalSchema: "TheKangaroos",
                principalTable: "Clubs",
                principalColumn: "Id");

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
    }
}
