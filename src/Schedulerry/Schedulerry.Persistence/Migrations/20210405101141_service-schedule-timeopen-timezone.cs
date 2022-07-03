using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Schedulerry.Persistence.Migrations
{
    public partial class servicescheduletimeopentimezone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOpen",
                schema: "dbo",
                table: "ServiceOptionSchedule",
                type: "timestamptz",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "TimeOpen",
                schema: "dbo",
                table: "ServiceOptionSchedule",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz");
        }
    }
}
