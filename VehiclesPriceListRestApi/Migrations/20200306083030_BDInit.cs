using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehiclesPriceListRestApi.Migrations
{
    public partial class BDInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleMenufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMenufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleMenufacturingOrigin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMenufacturingOrigin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleOwner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VehiclePriceListItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Color = table.Column<string>(nullable: true),
                    DateReceived = table.Column<DateTime>(nullable: false),
                    AskingPrice = table.Column<string>(nullable: true),
                    TestValidExpiration = table.Column<DateTime>(nullable: false),
                    EngineType = table.Column<string>(nullable: true),
                    EquippingDetails = table.Column<string>(nullable: true),
                    VehicleMenufacturingOriginId = table.Column<int>(nullable: false),
                    VehicleOwnerId = table.Column<int>(nullable: false),
                    VehicleStatusId = table.Column<int>(nullable: false),
                    VehicleMenufacturerId = table.Column<int>(nullable: false),
                    VehicleTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePriceListItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePriceListItem_VehicleMenufacturer_VehicleMenufacturerId",
                        column: x => x.VehicleMenufacturerId,
                        principalTable: "VehicleMenufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePriceListItem_VehicleMenufacturingOrigin_VehicleMenufacturingOriginId",
                        column: x => x.VehicleMenufacturingOriginId,
                        principalTable: "VehicleMenufacturingOrigin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePriceListItem_VehicleOwner_VehicleOwnerId",
                        column: x => x.VehicleOwnerId,
                        principalTable: "VehicleOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePriceListItem_VehicleStatus_VehicleStatusId",
                        column: x => x.VehicleStatusId,
                        principalTable: "VehicleStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehiclePriceListItem_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePriceListItem_VehicleMenufacturerId",
                table: "VehiclePriceListItem",
                column: "VehicleMenufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePriceListItem_VehicleMenufacturingOriginId",
                table: "VehiclePriceListItem",
                column: "VehicleMenufacturingOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePriceListItem_VehicleOwnerId",
                table: "VehiclePriceListItem",
                column: "VehicleOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePriceListItem_VehicleStatusId",
                table: "VehiclePriceListItem",
                column: "VehicleStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePriceListItem_VehicleTypeId",
                table: "VehiclePriceListItem",
                column: "VehicleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VehiclePriceListItem");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "VehicleMenufacturer");

            migrationBuilder.DropTable(
                name: "VehicleMenufacturingOrigin");

            migrationBuilder.DropTable(
                name: "VehicleOwner");

            migrationBuilder.DropTable(
                name: "VehicleStatus");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
