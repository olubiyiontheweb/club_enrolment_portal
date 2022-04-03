using Microsoft.EntityFrameworkCore.Migrations;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Migrations
{
    public partial class newEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Users_OwnerId",
                schema: "TheKangaroos",
                table: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_OwnerId",
                schema: "TheKangaroos",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "TheKangaroos",
                table: "Clubs");

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
                name: "Membership",
                schema: "TheKangaroos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClubId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membership_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalSchema: "TheKangaroos",
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membership_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "TheKangaroos",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Membership_ClubId",
                schema: "TheKangaroos",
                table: "Membership",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_UserId",
                schema: "TheKangaroos",
                table: "Membership",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Membership",
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
        }
    }
}
