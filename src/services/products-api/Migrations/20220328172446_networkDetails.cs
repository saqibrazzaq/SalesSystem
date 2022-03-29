using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace products_api.Migrations
{
    public partial class networkDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NetworkDetail",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetworkDetail");
        }
    }
}
