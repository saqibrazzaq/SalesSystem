using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace products_api.Migrations
{
    public partial class phoneimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Phone",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PhoneNetworkBand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NetworkBandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNetworkBand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNetworkBand_NetworkBand_NetworkBandId",
                        column: x => x.NetworkBandId,
                        principalTable: "NetworkBand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNetworkBand_Phone_PhoneId",
                        column: x => x.PhoneId,
                        principalTable: "Phone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNetworkBand_NetworkBandId",
                table: "PhoneNetworkBand",
                column: "NetworkBandId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNetworkBand_PhoneId",
                table: "PhoneNetworkBand",
                column: "PhoneId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNetworkBand");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Phone");
        }
    }
}
