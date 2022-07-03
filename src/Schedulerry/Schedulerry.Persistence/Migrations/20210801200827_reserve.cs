using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Schedulerry.Persistence.Migrations
{
    public partial class reserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerFk = table.Column<long>(type: "bigint", nullable: false),
                    ServiceOptionUid = table.Column<Guid>(type: "uuid", nullable: false),
                    ServiceOptionFk = table.Column<long>(type: "bigint", nullable: false),
                    DateTimeOfReservation = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ReservationLastsForMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Customer_CustomerFk",
                        column: x => x.CustomerFk,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_ServiceOption_ServiceOptionFk",
                        column: x => x.ServiceOptionFk,
                        principalSchema: "dbo",
                        principalTable: "ServiceOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerFk",
                schema: "dbo",
                table: "Reservation",
                column: "CustomerFk");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ServiceOptionFk",
                schema: "dbo",
                table: "Reservation",
                column: "ServiceOptionFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation",
                schema: "dbo");
        }
    }
}
