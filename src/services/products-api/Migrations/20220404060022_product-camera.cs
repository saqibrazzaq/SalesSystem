using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace products_api.Migrations
{
    public partial class productcamera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnnouncedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight_grams = table.Column<int>(type: "int", nullable: false),
                    Height_mm = table.Column<decimal>(type: "decimal(5,1)", nullable: false),
                    Width_mm = table.Column<decimal>(type: "decimal(5,1)", nullable: false),
                    Thickness_mm = table.Column<decimal>(type: "decimal(5,1)", nullable: false),
                    DisplaySize_in = table.Column<decimal>(type: "decimal(5,1)", nullable: false),
                    OSId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OSVersionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RAM_bytes = table.Column<int>(type: "int", nullable: false),
                    Storage_bytes = table.Column<int>(type: "int", nullable: false),
                    SDCardSlotId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BatteryCapacity_mAh = table.Column<int>(type: "int", nullable: false),
                    ChipsetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GPUId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CpuCores = table.Column<int>(type: "int", nullable: false),
                    CpuDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_CardSlot_SDCardSlotId",
                        column: x => x.SDCardSlotId,
                        principalTable: "CardSlot",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Chipset_ChipsetId",
                        column: x => x.ChipsetId,
                        principalTable: "Chipset",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_GPU_GPUId",
                        column: x => x.GPUId,
                        principalTable: "GPU",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_OS_OSId",
                        column: x => x.OSId,
                        principalTable: "OS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_OSVersion_OSVersionId",
                        column: x => x.OSVersionId,
                        principalTable: "OSVersion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCamera",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CameraTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Resolution_MP = table.Column<int>(type: "int", nullable: false),
                    FNumber = table.Column<decimal>(type: "decimal(5,1)", nullable: false),
                    FocalLength_mm = table.Column<int>(type: "int", nullable: false),
                    SensorSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PixelSize_um = table.Column<decimal>(type: "decimal(5,1)", nullable: false),
                    OIS = table.Column<bool>(type: "bit", nullable: false),
                    LensTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCamera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCamera_CameraType_CameraTypeId",
                        column: x => x.CameraTypeId,
                        principalTable: "CameraType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCamera_LensType_LensTypeId",
                        column: x => x.LensTypeId,
                        principalTable: "LensType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCamera_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ChipsetId",
                table: "Product",
                column: "ChipsetId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_GPUId",
                table: "Product",
                column: "GPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OSId",
                table: "Product",
                column: "OSId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OSVersionId",
                table: "Product",
                column: "OSVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SDCardSlotId",
                table: "Product",
                column: "SDCardSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCamera_CameraTypeId",
                table: "ProductCamera",
                column: "CameraTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCamera_LensTypeId",
                table: "ProductCamera",
                column: "LensTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCamera_ProductId",
                table: "ProductCamera",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCamera");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
