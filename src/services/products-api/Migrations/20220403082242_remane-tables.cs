using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace products_api.Migrations
{
    public partial class remanetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyFormFactor");

            migrationBuilder.DropTable(
                name: "BodyIpCertificate");

            migrationBuilder.CreateTable(
                name: "FormFactor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFactor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IpCertificate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IpCertificate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormFactor_Name",
                table: "FormFactor",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IpCertificate_Name",
                table: "IpCertificate",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormFactor");

            migrationBuilder.DropTable(
                name: "IpCertificate");

            migrationBuilder.CreateTable(
                name: "BodyFormFactor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyFormFactor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BodyIpCertificate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyIpCertificate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyFormFactor_Name",
                table: "BodyFormFactor",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BodyIpCertificate_Name",
                table: "BodyIpCertificate",
                column: "Name",
                unique: true);
        }
    }
}
