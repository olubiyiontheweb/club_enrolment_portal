﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace TheKangaroos_ClubEnrolmentPortal.Data.Migrations
{
    public partial class addedticketsavailablefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketsAvailable",
                schema: "TheKangaroos",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketsAvailable",
                schema: "TheKangaroos",
                table: "Events");
        }
    }
}
