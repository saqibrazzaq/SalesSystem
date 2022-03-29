using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace products_api.Migrations
{
    public partial class network_band_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetworkDetail");

            migrationBuilder.CreateTable(
                name: "NetworkBand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    NetworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkBand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkBand_Network_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Network",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NetworkBand_Name",
                table: "NetworkBand",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NetworkBand_NetworkId",
                table: "NetworkBand",
                column: "NetworkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetworkBand");

            migrationBuilder.CreateTable(
                name: "NetworkDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NetworkId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkDetail_Network_NetworkId",
                        column: x => x.NetworkId,
                        principalTable: "Network",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NetworkDetail_Name",
                table: "NetworkDetail",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NetworkDetail_NetworkId",
                table: "NetworkDetail",
                column: "NetworkId");
        }
    }
}
