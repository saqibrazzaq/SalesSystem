﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace products_api.Migrations
{
    public partial class batterytype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RemovableBattery");

            migrationBuilder.CreateTable(
                name: "BatteryType",
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
                    table.PrimaryKey("PK_BatteryType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatteryType_Name",
                table: "BatteryType",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatteryType");

            migrationBuilder.CreateTable(
                name: "RemovableBattery",
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
                    table.PrimaryKey("PK_RemovableBattery", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RemovableBattery_Name",
                table: "RemovableBattery",
                column: "Name",
                unique: true);
        }
    }
}
